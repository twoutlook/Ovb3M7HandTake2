namespace Ovb3HandPwa.Client;

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;


//<!--
//Step definitions:
//Step 0 => seats only(no pot, no cards)
//Step 1 => post blinds(SB $1 seat #2, BB $2 seat #3)
//Step 2 => deal hole cards
//Step 3 => preflop bet (multi-action sub-steps)
//Step 4 => flop(3 cards)
//Step 5 => turn(4th card)
//Step 6 => river(5th card)
//Step 7 => showdown
//-->
public static partial class DevUtil
{
    // if (flopActionIndex == 0){
    //     for (int i = 0; i < 6; i++)
    //     {
    //         seatLastAction[i] = "";
    //     }
    //     StateHasChanged();
    // }

    /// <summary>
    /// Main parser. Returns a ParseHandResult object that contains
    /// the seat/player data, hero seat, community cards, preflop actions, etc.
    /// </summary>
    public static ParseHandResult ParseHand(string pokerHand)
    {
        // These arrays/collections will be populated and then returned
        var playerCards = new string[6, 2];
        var communityCards = new string[5];
        var seatShowdownRevealed = new bool[6];
        var playerIdToSeat = new Dictionary<string, int>();
        var seatInfos = new PlayerInfo[6];
        var preflopActions = new List<PreflopAction>();

        // We'll track debug info in a StringBuilder, then return it as a string
        var sb = new StringBuilder();

        int heroSeatIndex = -1;
        int dealerSeatIndex = 0;

        sb.AppendLine("ParseHand() called.");

        // 1) Split lines
        var lines = pokerHand
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(l => l.Trim())
            .ToList();

        // 2) Identify dealer seat
        foreach (var line in lines)
        {
            if (line.Contains("is the button"))
            {
                int idx = line.IndexOf("Seat #");
                if (idx >= 0)
                {
                    int start = idx + "Seat #".Length;
                    int spaceAfterSeat = line.IndexOf(' ', start);
                    if (spaceAfterSeat < 0) spaceAfterSeat = line.Length;

                    string seatStr = line.Substring(start, spaceAfterSeat - start).Trim();
                    if (int.TryParse(seatStr, out int seatNum))
                    {
                        dealerSeatIndex = seatNum - 1;  // 0-based
                        sb.AppendLine($"Dealer seatIndex={dealerSeatIndex}");
                    }
                }
            }
        }

        // 3) Parse "Seat X: Player (Chips)" lines
        foreach (var line in lines)
        {
            if (line.StartsWith("Seat ") && line.Contains(" in chips"))
            {
                int colonIndex = line.IndexOf(':');
                if (colonIndex < 0) continue;

                string seatNumberPart = line.Substring(5, colonIndex - 5).Trim();
                if (int.TryParse(seatNumberPart, out int seatNum))
                {
                    int seatIndex = seatNum - 1;
                    string afterColon = line.Substring(colonIndex + 1).Trim();

                    int parenIndex = afterColon.IndexOf('(');
                    string playerId = "";
                    string chipStr = "";
                    if (parenIndex >= 0)
                    {
                        playerId = afterColon.Substring(0, parenIndex).Trim();
                        int closeParen = afterColon.IndexOf(')', parenIndex + 1);
                        if (closeParen > parenIndex)
                        {
                            chipStr = afterColon.Substring(parenIndex + 1, closeParen - (parenIndex + 1)).Trim();
                        }
                    }
                    else
                    {
                        playerId = afterColon;
                    }

                    playerIdToSeat[playerId] = seatIndex;
                    seatInfos[seatIndex] = new PlayerInfo
                    {
                        PlayerId = playerId,
                        Chips = chipStr
                    };
                }
            }
        }

        // 4) Dealt to <Player> [card1 card2]
        var dealtLines = lines.Where(l => l.StartsWith("Dealt to")).ToList();
        foreach (var line in dealtLines)
        {
            int startBracket = line.IndexOf('[');
            int endBracket = line.IndexOf(']');
            if (startBracket >= 0 && endBracket > startBracket)
            {
                string cardStr = line.Substring(startBracket + 1, endBracket - startBracket - 1);
                var parts = cardStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    string prefix = line.Substring("Dealt to".Length).Trim();
                    int bracketIndex = prefix.IndexOf('[');
                    if (bracketIndex > 0)
                    {
                        string playerId = prefix.Substring(0, bracketIndex).Trim();
                        if (playerIdToSeat.TryGetValue(playerId, out int seatIdx))
                        {
                            playerCards[seatIdx, 0] = parts[0];
                            playerCards[seatIdx, 1] = parts[1];
                        }
                        // check if hero
                        if (playerId.Equals("Hero", StringComparison.OrdinalIgnoreCase))
                        {
                            heroSeatIndex = seatIdx;
                            sb.AppendLine($"Hero seatIndex={heroSeatIndex}");
                        }
                    }
                }
            }
        }

        // 5) Preflop section
        int holeCardsIndex = lines.FindIndex(l => l.StartsWith("*** HOLE CARDS ***"));
        int flopIndex = lines.FindIndex(l => l.StartsWith("*** FLOP ***"));
        if (holeCardsIndex < 0) holeCardsIndex = 0;
        if (flopIndex < 0) flopIndex = lines.Count;

        var preflopSection = lines.Skip(holeCardsIndex + 1)
                                  .Take(flopIndex - (holeCardsIndex + 1))
                                  .ToList();
        var betLines = preflopSection.Where(l =>
            l.Contains("folds") || l.Contains("calls") || l.Contains("raises"))
            .ToList();

        sb.AppendLine("Preflop bet lines found:");
        foreach (var betLine in betLines)
        {
            sb.AppendLine($"  {betLine}");
        }

        // parse them
        foreach (var line in betLines)
        {
            int colonPos = line.IndexOf(':');
            if (colonPos < 0) continue;

            string playerId = line.Substring(0, colonPos).Trim();
            string afterColon = line.Substring(colonPos + 1).Trim();

            int seatIndex = -1;
            if (playerIdToSeat.TryGetValue(playerId, out int foundSeat))
            {
                seatIndex = foundSeat;
            }
            else if (playerId.Equals("Hero", StringComparison.OrdinalIgnoreCase) && heroSeatIndex >= 0)
            {
                seatIndex = heroSeatIndex;
            }
            else
            {
                // unknown seat => skip
                continue;
            }

            if (afterColon.Contains("folds"))
            {
                preflopActions.Add(new PreflopAction(seatIndex, "fold", 0));
            }
            else if (afterColon.Contains("calls"))
            {
                double amt = ExtractNumeric(afterColon, "calls $");
                preflopActions.Add(new PreflopAction(seatIndex, "call", amt));
            }
            else if (afterColon.Contains("raises"))
            {
                double amt = ExtractRaiseAmount(afterColon);
                preflopActions.Add(new PreflopAction(seatIndex, "raise", amt));
            }
        }
        sb.AppendLine($"Found {preflopActions.Count} preflop bet lines.");

        // 6) Community cards
        var boardLine = lines.FirstOrDefault(l =>
            l.StartsWith("*** FLOP ***") ||
            l.StartsWith("*** TURN ***") ||
            l.StartsWith("*** RIVER ***") ||
            l.Contains("Board ["));

        if (boardLine != null)
        {
            int start = boardLine.IndexOf('[');
            int end = boardLine.IndexOf(']');
            if (start >= 0 && end > start)
            {
                string boardStr = boardLine.Substring(start + 1, end - start - 1);
                var parts = boardStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length && i < 5; i++)
                {
                    communityCards[i] = parts[i];
                }
            }
        }

        // 7) Showdown lines => seatShowdownRevealed
        foreach (var line in lines)
        {
            if (line.Contains(": shows ["))
            {
                int colonPos = line.IndexOf(':');
                if (colonPos < 0) continue;

                string possiblePlayerId = line.Substring(0, colonPos).Trim();
                if (!playerIdToSeat.TryGetValue(possiblePlayerId, out int seatIdx))
                    continue;

                int openBracket = line.IndexOf('[', colonPos);
                int closeBracket = line.IndexOf(']', openBracket + 1);
                if (openBracket < 0 || closeBracket < 0) continue;

                string cardStr = line.Substring(openBracket + 1, closeBracket - openBracket - 1);
                var parts = cardStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    playerCards[seatIdx, 0] = parts[0];
                    playerCards[seatIdx, 1] = parts[1];
                    seatShowdownRevealed[seatIdx] = true;
                }
            }
        }

        // Return a record containing all necessary info
        return new ParseHandResult(
            PlayerCards: playerCards,
            CommunityCards: communityCards,
            SeatShowdownRevealed: seatShowdownRevealed,
            PlayerIdToSeat: playerIdToSeat,
            SeatInfos: seatInfos,
            PreflopActions: preflopActions,
            HeroSeatIndex: heroSeatIndex,
            DealerSeatIndex: dealerSeatIndex,
            DebugMessages: sb.ToString()
        );
    }

    // -----------------------------------------------------
    // Helpers for numeric extraction
    // -----------------------------------------------------
    private static double ExtractNumeric(string text, string prefix)
    {
        int idx = text.IndexOf(prefix);
        if (idx < 0) return 0.0;
        idx += prefix.Length;
        var remainder = text.Substring(idx).Trim();
        var parts = remainder.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double.TryParse(parts[0], out double val);
        return val;
    }

    private static double ExtractRaiseAmount(string text)
    {
        int toPos = text.IndexOf("to $");
        if (toPos < 0) return 0.0;
        var afterTo = text.Substring(toPos + "to $".Length).Trim();
        var parts = afterTo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double.TryParse(parts[0], out double val);
        return val;
    }

    public static double ExtractAmount(string input)
    {
        // Regex to match a number with a period as the decimal separator (and an optional minus sign)
        Regex regex = new Regex(@"-?(?<number>\d+\.\d+)");
        Match match = regex.Match(input);

        if (!match.Success)
        {
            return 0;
        }

        string numberStr = match.Groups["number"].Value;

        // Try to parse the number using InvariantCulture since we're using a period as the decimal separator.
        if (double.TryParse(numberStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double amount))
        {
            return amount;
        }

        return 0;
    }
}
