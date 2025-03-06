using System.Text.RegularExpressions;

namespace Poker2033.Hand;
//namespace Poker2033.Hand;
public class OneHandExt
{
    public OneHandExt() { }
  

    public (bool result, decimal Pot, decimal rakeSum) TestFinalPot()
    {
        var lastScene = Scenes.FirstOrDefault(a => a.Seq == MAX_STEP);
        decimal pot = lastScene?.Pot ?? -999.99m;
        decimal rakeSum = TableRake + TableJackpot + TableBingo + TableFortune + TableTax;
        return (pot == rakeSum, pot, rakeSum);
    }
    public string GetScenePrompt()
    {

        var str = "";
        if (SceneId == 0)
        {
            return "人員就座，準備開始。";
        }

        var scene = Scenes.FirstOrDefault(a => a.Seq == SceneId);
        if (scene != null)
        {
            str = $"Keynote：｜{scene.Stage}｜{scene.PlayerId}｜{scene.ActName}｜{scene.ActAmt}｜{scene.RawText}｜（原始記錄）{scene.text}｜";
            //str = $"［{scene.Seq}］{scene.Stage}|{scene.Player}|{scene.ActName}|{scene.ActAmt}|{scene.RawText}|";
        }
        if (SceneId == MAX_STEP)
        {
            str += "此手結束！";
        }

        return str;
    }
    public string GetCurrentCommunityCards()
    {

        var str = "";


        var scene = Scenes.FirstOrDefault(a => a.Seq == SceneId);
        if (scene != null)
        {
            str = scene.CommunityCards;
            //str = $"［{scene.Seq}］{scene.Stage}|{scene.Player}|{scene.ActName}|{scene.ActAmt}|{scene.RawText}|";
        }


        return str;
    }


    public (int, string) GetCurrentCommunityCardsExt()
    {
        var scene = Scenes.FirstOrDefault(a => a.Seq == SceneId);
        if (scene == null) return (0, ""); // No scene found, return default values.

        int effectiveAllInCnt = scene.AllInCnt;
        string communityCards = scene.CommunityCards ?? "";

        // If current scene has no AllInCnt, find the last known AllInCnt
        if (effectiveAllInCnt == 0)
        {
            var previousScene = Scenes
                .Where(a => a.Seq < SceneId && a.AllInCnt > 0)  // Find the last scene with AllInCnt > 0
                .OrderByDescending(a => a.Seq)
                .FirstOrDefault();

            if (previousScene != null)
            {
                effectiveAllInCnt = previousScene.AllInCnt; // Carry forward the AllInCnt
            }
        }

        return (effectiveAllInCnt, communityCards);
    }

    public Player GetTopLevelPlayerBySeatNum(int seatNum)
    {
        return Players.Where(a => a.SeatNum == seatNum).FirstOrDefault();
    }
    public Scene GetCurrentScene()
    {
        return Scenes.FirstOrDefault(a => a.Seq == SceneId);
    }

    public Player GetCurrentScenePlayerBySeat(int seatNum)
    {
        var scene = GetCurrentScene();
        if (scene == null)
        {
            return null;
            //return new Player();// just an emtpy object to avoid null 
        }
        return scene.Players.Where(a => a.SeatNum == seatNum).FirstOrDefault();
    }
    public string GetCurrentScenePlayerActionDetailBySeat(int seatNum)
    {
        var scene = GetCurrentScene();
        if (scene == null) { return ""; }
        var p = scene.Players.Where(a => a.SeatNum == seatNum).FirstOrDefault();
        if (p == null)
        {
            return "";
        }

        var str = scene.Players.Where(a => a.SeatNum == seatNum).FirstOrDefault().ActionDetail;
        if (str == null) str = "";
        return str;
    }

    /// <summary>
    /// 視同全部發牌
    /// </summary>
    /// <returns></returns>
    public int Get_PREFLOP()
    {
        var preflop = Scenes.Where(a => a.Stage == "PREFLOP").FirstOrDefault();
        if (preflop != null)
        {
            return preflop.Seq;
        }
        return -1;
    }


    public bool Get_Is_PREFLOP()
    {
        var preflop = Scenes.Where(a => a.Stage == "PREFLOP").FirstOrDefault();
        if (preflop != null)
        {
            if (SceneId >= preflop.Seq) return true;
        }
        return false;
    }
    private static readonly string[] PositionOrder6Max =
 {
    "BTN", // offset 0
    "SB",  // offset 1
    "BB",  // offset 2
    "UTG", // offset 3
    "MP",  // offset 4
    "CO"   // offset 5
};
    private static readonly string[] PositionOrder9Max =
{
    "BTN", // offset 0
    "SB",  // offset 1
    "BB",  // offset 2
    "UTG", // offset 3
    "UTG+1", // offset 4
    "MP",  // offset 5
    "MP+1", // offset 6
    "CO",  // offset 7
    "HJ"   // offset 8 (Hijack)
};

    private string GetPositionName(int seatIndex, int buttonSeatIndex)
    {
        // Determine if it's a 6-max or 9-max table
        string[] positionOrder = (MAX_SEAT == 6) ? PositionOrder6Max : PositionOrder9Max;

        // Normalize the offset based on button position
        int offset = (seatIndex + MAX_SEAT - buttonSeatIndex) % MAX_SEAT;

        // Return the correct position name
        return positionOrder[offset];
    }


    // ver: 1.26.0 顯示 手牌原始資料
    // ver: 1.26.1 微調 手牌原始資料 位置及字體
    // ver: 1.26.2 微調 手牌原始資料 位置及字體
    public string Ver { get { return "ver: 1.26.1 "; } }


    public string RawText { get; set; }
    public int dealerSeatIndex { get; set; }
    public int heroSeatIndex { get; set; }
    public int MAX_SEAT { get; set; }// 6 or 9
    public int ACTUAL_SEAT { get; set; }// 6 or 9

    public int SceneId { get; set; } = 0;
    public int MAX_STEP { get; set; }
    public bool NO_MORE_NEXT { get; set; } = false;
    public bool NO_MORE_PREV { get; set; } = true;
    public string CommunityCards;
    public void Next()
    {
        SceneId++;
        if (SceneId > 0)
        {
            NO_MORE_PREV = false;
        }
        if (SceneId >= MAX_STEP)
        {
            NO_MORE_NEXT = true;
            SceneId = MAX_STEP;
        }
    }
    public void ToStart()
    {
        SceneId = 0;

        NO_MORE_PREV = true;
        NO_MORE_NEXT = false;
    }
    public void Prev()
    {
        SceneId--;
        if (SceneId < MAX_STEP)
        {
            NO_MORE_NEXT = false;
        }
        if (SceneId <= 0)
        {
            NO_MORE_PREV = true;
            SceneId = 0;
        }
    }



    public List<RawHandRecord> RawHandRecords = new();
    public List<Player> Players = new();
    public List<Player> PlayerWithInitialChips = new();

    public int ActionSeq = new();
    public List<Scene> Scenes = new();
    //Total pot $126.72 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
    public decimal TablePot; // 由 手牌記錄 解析獲得的
    public decimal TableRake;
    public decimal TableJackpot;
    public decimal TableBingo;
    public decimal TableFortune;
    public decimal TableTax;

    public string GetCuurentSceneRawText()
    {
       return GetCurrentScene()?.text ?? string.Empty;
    }


    public decimal Pot => GetCurrentScene()?.Pot ?? 0m;

    public async Task InitAsync()
    {
        //  OneHandSet = new();
        InitLines();
        DetermineDealer(); //確認 BTN 所在座次 0 to 5
        DetermineSeating();//在這裡建立 Player 實例, 同時確認 HERO 座次

        //Console.WriteLine($"{MAX_SEAT} 人桌");
        //Console.WriteLine($"{dealerSeatIndex} BTN 的座次(0 base)");
        //Console.WriteLine($"{heroSeatIndex} HERO 的座次(0 base)");


        //  DevOutput4();

        //foreach (var p in Players.OrderBy(a => a.SeatNum))
        //{
        //    Console.WriteLine($"{p.SeatNum} {p.PlayerId}  {p.Position}");
        //}
        // Players 改到show   在這裡先補入, 後續要往前移

        InitSections();
        DetermineAnte();

        DetermineBlind();// 使用 section
        DetermineHeroHoleCards();


        InitSectionForAction();
        InitCommunityCards();
        InitActions();

        // MARKTODO
        Settings();

        //最後才指定 seq=0 PlayerWithInitialChips;
        Scenes.Where(a => a.Seq == 0).FirstOrDefault().Players = PlayerWithInitialChips;
        //DevOutput3();


        Patch___ALLIN();
        // AdjPotandPlayerChips DOING  
        //    DevOutput3();
        AdjScenePotAndPlayerChips___RAISE();
        UpdateScenePotAndPlayerChips();





        AdjScenePotAndPlayerChips___RETURN();
        UpdateScenePotAndPlayerChips();


        Patch___RAISE_ALLIN();
        UpdateScenePotAndPlayerChips();


        Patch___CALL_ALLIN();
        UpdateScenePotAndPlayerChips();

        DetermineRakeAndOthers();


        //
        //DevOutput3();




    }

    /// <summary>
    /// 在 sample 7, BTN
    /// all-in 後 chips= -50 by Raise
    /// 同一手 BB 在 all-in 後 chips = -20
    /// POT 目前是OK, 就是 player's chips 要校正
    /// </summary>
    public void Patch___RAISE_ALLIN()
    {
        // init Adj of Pot and Player's Chips

        foreach (var scene in Scenes)
        {
            //if (scene.Stage != null && scene.Stage.ToUpper() == "BLIND") scene.Stage = "PREFLOP";

            // sceno.AdjPot and Players' AdjChips just the same, copy it 
            scene.AdjPot = scene.Pot;
            foreach (var player in scene.Players)
            {
                player.AdjChips = player.Chips;
            }
        }

        // to actual Adj  DOING
        foreach (var scene in Scenes.OrderBy(a => a.Seq))
        {
            double diff = 0;
            if (scene.ActName != null && scene.ActName.ToUpper() == "RAISE")
            {
                string checking = scene.PlayerId;
              //  Console.WriteLine($"\nPatch___RAISE_ALLIN 找到 RAISE, PlayerId={checking} ");

                if (scene.IsAllIn)
                {
                 //   Console.WriteLine($"  確認是 ALL-IN   {checking} ");
                    var hotPlayer = scene.Players.FirstOrDefault(a => a.PlayerId == scene.PlayerId);
                    if (hotPlayer != null)
                    {
                        var toFixAmt = hotPlayer.AdjChips;
                        if (toFixAmt < 0)
                        {
                            toFixAmt = (-1) * toFixAmt;
                            foreach (var scene2 in Scenes.Where(a => a.Seq >= scene.Seq))
                            {
                                var scenePlayer = scene2.Players.FirstOrDefault(a => a.PlayerId == scene.PlayerId);
                                if (scenePlayer != null) scenePlayer.AdjChips += toFixAmt;
                            }
                        }
                    }
                }            

            }
        }
    }

    public void Patch___CALL_ALLIN()
    {
        // init Adj of Pot and Player's Chips

        foreach (var scene in Scenes)
        {
            //if (scene.Stage != null && scene.Stage.ToUpper() == "BLIND") scene.Stage = "PREFLOP";

            // sceno.AdjPot and Players' AdjChips just the same, copy it 
            scene.AdjPot = scene.Pot;
            foreach (var player in scene.Players)
            {
                player.AdjChips = player.Chips;
            }
        }

        // to actual Adj  DOING
        foreach (var scene in Scenes.OrderBy(a => a.Seq))
        {
            double diff = 0;
            if (scene.ActName != null && scene.ActName.ToUpper() == "CALL")
            {
                string checking = scene.PlayerId;
              //  Console.WriteLine($"\n CALL 仿 Patch___RAISE_ALLIN 找到 RAISE, PlayerId={checking} ");

                if (scene.IsAllIn)
                {
               //     Console.WriteLine($"  確認是 ALL-IN   {checking} ");
                    //  var previousActions = GetPreviousActionsInSameStage(checking, scene);
                    var hotPlayer = scene.Players.FirstOrDefault(a => a.PlayerId == scene.PlayerId);
                    if (hotPlayer != null)
                    {
                        var toFixAmt = hotPlayer.AdjChips;
                        if (toFixAmt < 0)
                        {
                            toFixAmt = (-1) * toFixAmt;
                            foreach (var scene2 in Scenes.Where(a => a.Seq >= scene.Seq))
                            {
                                var scenePlayer = scene2.Players.FirstOrDefault(a => a.PlayerId == scene.PlayerId);
                                if (scenePlayer != null) scenePlayer.AdjChips += toFixAmt;
                            }
                        }
                    }
                }




            }
        }
    }

    /// <summary>
    /// 在優化前先打補丁
    /// </summary>
    public void Patch___ALLIN()
    {
        foreach (var scene in Scenes)
        {
            if (scene.text != null && scene.text.Contains("all-in"))
            {
                scene.IsAllIn = true;
                foreach (var scene2 in Scenes.Where(a => a.Seq >= scene.Seq))
                {
                    var allinPlayer = scene2.Players.FirstOrDefault(a => a.PlayerId == scene.PlayerId);
                    if (allinPlayer != null) allinPlayer.IsAllIn = true;

                }
            }
        }
    }
    //public void AdjPotandPlayerChips()
    //{
    //    foreach(var scene in Actions)
    //    {
    //        string checking;
    //        if (scene.ActName.ToUpper() == "RAISE")
    //        {
    //            checking = scene.PlayerId;
    //            Console.WriteLine($"RAISE case for {checking} ");

    //            // now to maintain givenPlayersPreviousActionsWhinTheSameStage



    //        }
    //        foreach(var player in Players)
    //        {

    //        }
    //    }
    //}

    public void AdjScenePotAndPlayerChips___RETURN()
    {
        // Initialize AdjPot and Players' AdjChips
        foreach (var scene in Scenes)
        {
            scene.AdjPot = scene.Pot;
            foreach (var player in scene.Players)
            {
                player.AdjChips = player.Chips;
            }
        }

        // Process RETURN actions
        foreach (var scene in Scenes)
        {
            decimal diff = 0;
            if (scene.ActName != null && scene.ActName.ToUpper() == "RETURN")
            {
                string checking = scene.PlayerId;
              //  Console.WriteLine($"\nRETURN case for {checking} ");

                // Get the uncalled bet amount
                diff = (2) * (decimal)scene.ActAmt;

                // Adjust the player's chips in the current scene
                var targetPlayer = scene.Players.FirstOrDefault(a => a.PlayerId == checking);
                if (targetPlayer != null)
                {
                    targetPlayer.AdjChips += diff; // Return the chips to the player
                    scene.AdjPot -= diff; // Remove from pot
                }

                // Propagate adjustments to all future scenes
                foreach (var scene2 in Scenes.Where(a => a.Seq > scene.Seq))
                {
                    scene2.AdjPot -= diff; // Adjust pot

                    // Adjust player's chips in future scenes
                    var futurePlayer = scene2.Players.FirstOrDefault(p => p.PlayerId == checking);
                    if (futurePlayer != null)
                    {
                        futurePlayer.AdjChips += diff;
                    }
                }
            }
        }
    }

    public void UpdateScenePotAndPlayerChips()
    {
        // init Adj of Pot and Player's Chips

        foreach (var scene in Scenes)
        {

            scene.Pot = scene.AdjPot;
            foreach (var player in scene.Players)
            {
                player.Chips = player.AdjChips;
            }
        }
    }
    public void AdjScenePotAndPlayerChips___RAISE()
    {
        // init Adj of Pot and Player's Chips

        foreach (var scene in Scenes)
        {
            if (scene.Stage != null && scene.Stage.ToUpper() == "BLIND") scene.Stage = "PREFLOP";

            // sceno.AdjPot and Players' AdjChips just the same, copy it 
            scene.AdjPot = scene.Pot;
            foreach (var player in scene.Players)
            {
                player.AdjChips = player.Chips;
            }
        }

        // to actual Adj  DOING
        foreach (var scene in Scenes)
        {
            decimal diff = 0;
            if (scene.ActName != null && scene.ActName.ToUpper() == "RAISE")
            {
                string checking = scene.PlayerId;
               // Console.WriteLine($"\nRAISE case for {checking} ");

                // Get previous actions of the same player in the same stage
                var previousActions = GetPreviousActionsInSameStage(checking, scene);

                if (previousActions != null)
                {
                    //Console.WriteLine($"Previous actions of {checking} in stage {scene.Stage}:");
                    //Console.WriteLine($"  Seq: {previousActions.Seq}, Action: {previousActions.ActName}, Amount: {previousActions.ActAmt}");
                    var targetPlayer = scene.Players.Where(a => a.PlayerId == checking).FirstOrDefault();
                    if (targetPlayer != null)
                    {
                        diff = (decimal)previousActions.ActAmt;
                        targetPlayer.AdjChips -= diff;
                        scene.AdjPot -= diff;
                    }
                }

                // Step 3: Propagate adjustments to all future scenes
                foreach (var scene2 in Scenes.Where(a => a.Seq > scene.Seq))
                {
                    // var futureScene = Actions[j];

                    // Carry forward the pot adjustment
                    scene2.AdjPot -= diff;

                    // Carry forward each player's chip adjustment
                    foreach (var futurePlayer in scene2.Players.Where(a => a.PlayerId == checking))
                    {
                        var previousPlayerState = scene.Players.FirstOrDefault(p => p.PlayerId == futurePlayer.PlayerId);
                        if (previousPlayerState != null)
                        {
                            futurePlayer.AdjChips -= diff;
                        }
                    }
                }


            }
        }
    }

    private Scene GetPreviousActionsInSameStage(string playerId, Scene currentScene)
    {
        return Scenes
            .Where(a => a.PlayerId == playerId) // Same player
            .Where(a => a.Stage == currentScene.Stage) // Same stage
            .Where(a => a.Seq < currentScene.Seq) // Previous actions only
            .Where(a => a.ActAmt > 0) // Previous actions only

            .OrderByDescending(a => a.Seq) // Sort by sequence
            .FirstOrDefault();
    }


    #region done!

    /// <summary>
    /// 解析手牌記錄 
    /// Table 'RushAndCash638177' 6-max Seat #1 is the button
    /// 取得 Seat #1 is the button 裡的 #1 的 1
    /// </summary>
    public void DetermineDealer()
    {
        foreach (var x in RawHandRecords)
        {
            var line = x.text;
            if (line.Contains("is the button"))
            {
                // 確認幾人桌, 在 CANVAS 做 六或九人桌
                var match = Regex.Match(line, @"(\d+)-max");
                if (match.Success)
                {
                    MAX_SEAT = int.Parse(match.Groups[1].Value);
                }



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
                    }
                }
            }
        }
    }

    /// <summary>
    /// Total pot $126.72 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
    /// </summary>
    public void DetermineRakeAndOthers()
    {
        foreach (var x in RawHandRecords)
        {
            var line = x.text;
            if (line.Contains("Total pot"))
            {
                TablePot = ExtractAmount(line, "Total pot $");
                TableRake = ExtractAmount(line, "Rake $");
                TableJackpot = ExtractAmount(line, "Jackpot $");
                TableBingo = ExtractAmount(line, "Bingo $");
                TableFortune = ExtractAmount(line, "Fortune $");
                TableTax = ExtractAmount(line, "Tax $");

                //Console.WriteLine($"Pot: {TablePot}, Rake: {TableRake}, Jackpot: {TableJackpot}, Bingo: {TableBingo}, Fortune: {TableFortune}, Tax: {TableTax}");
            }
        }
    }

    // Helper method to extract amounts safely
    private decimal ExtractAmount(string line, string keyword)
    {
        int index = line.IndexOf(keyword);
        if (index < 0) return 0m; // If keyword is not found, return 0

        index += keyword.Length;
        var remainingText = line.Substring(index).Trim();
        var parts = remainingText.Split(' ', '|'); // Split by space or pipe "|"

        if (decimal.TryParse(parts[0], out decimal value))
        {
            return value;
        }

        return 0m; // Return 0 if parsing fails
    }



    /// <summary>
    /// 同時建立 Players 的每一個 Player 實例
    /// 
    /// </summary>
    public void DetermineSeating()
    {
        /*
            有可能有些位子沒人就座
            Seat 1: 4cacd4e7 ($327.58 in chips)
            Seat 2: 622cae43 ($212.2 in chips)
            Seat 3: a3e68cdb ($184 in chips)
            Seat 4: f5bc2b5d ($200 in chips)
            Seat 5: bd907983 ($227.02 in chips)
            Seat 6: Hero ($311.11 in chips)
         */
        try
        {
            foreach (var x in RawHandRecords)
            {
                var line = x.text;
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

                        chipStr = chipStr.Replace(" in chips", "");
                        //Players
                        var p = new Player();
                        p.PlayerId = playerId;
                        p.SeatNum = seatIndex;
                        var chip = ParseAmount(chipStr);

                        p.Position = GetPositionName(p.SeatNum, dealerSeatIndex);

                        //    p.InitialChips = chip;
                        p.Chips = chip;
                        Players.Add(p);

                        //Players
                        var p2 = new Player();
                        p2.PlayerId = playerId;
                        p2.SeatNum = seatIndex;
                        var chip2 = ParseAmount(chipStr);

                        p2.Position = GetPositionName(p.SeatNum, dealerSeatIndex);

                        //   p2.InitialChips = chip;
                        p2.Chips = chip;
                        PlayerWithInitialChips.Add(p2);
                        //Players.Add(p2);
                    }
                }
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        //
        var hero = Players.Where(x => x.PlayerId.ToUpper() == "HERO").FirstOrDefault();
        if (hero != null)
        {
            heroSeatIndex = hero.SeatNum - 1;
        }

        // 
        ACTUAL_SEAT = Players.Count();
    }
    public static decimal ParseAmount(string amountWithCurrency)
    {
        // Regular expression to match a currency symbol followed by the number (e.g., "$118.52")
        //string pattern = @"([^\d]+)?([\d.]+)"; // Matches currency symbols (if any) and the numeric value
        string pattern = @"([^\d]+)?([\d,]+(?:\.\d+)?)"; // Matches currency symbols (if any) and the numeric value

        Match match = Regex.Match(amountWithCurrency, pattern);

        if (match.Success)
        {
            // The second group is the numeric value (without the currency symbol)
            string amountStr = match.Groups[2].Value;

            // Convert the numeric value to a double
            decimal amount = decimal.Parse(amountStr);

            return amount;
        }

        throw new FormatException("Invalid currency format");
    }
    public void InitActions()
    {
        // remove all-in
        //string[] actKeywords = new string[] { "all-in", "check", "fold", "bet", "call", "raise", "collect", "return", "show" };
        string[] actKeywords = new string[] { "check", "fold", "bet", "call", "raise", "collect", "return", "show" };

        foreach (var raw in RawHandRecords.Where(a => a.is_action_record == true))
        {

            if (actKeywords.Any(keyword => raw.text.Contains(keyword)))
            {
                var act = ParseAction(raw.text);
                if (act != null)
                {
                    // act.text = raw.text;  // ✅ Assign RawHandRecord.text to Action.text NOT!!!
                    raw.Action = act;
                }
            }
            else
            {
                raw.is_action_record = false;
            }
        }
    }

    /// <summary>
    /// NOTE by Mark, 01/26 16:30 為何前幾筆沒有? 因為不在目前 Action 的定義裡
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static Scene ParseAction(string line)
    {
        Scene act = new Scene();
        act.text = line;

        // Special case: Uncalled bet being returned
        string pattern0 = @"Uncalled bet \(\$(\d+(\.\d+)?)\) returned to (\S+)";

        // 處理 千位分隔符（,）
        Match match0 = Regex.Match(line.Replace(",", ""), pattern0);

        if (match0.Success)
        {
            act.PlayerId = match0.Groups[3].Value;  // Extract player ID
            act.ActName = "RETURN";
            act.ActAmt = decimal.Parse(match0.Groups[1].Value);  // Extract amount
                                                                //    act.ActAmt = (-1) * act.ActAmt;
            return act;
        }

        // ( WIN )    (39) SHOWDOWN True   af9dcee9 collected $118.52 from pot
        if (line.Contains("collected"))
        {
            act = ParseCollectedAction(line);

        }

        int colonPos = line.IndexOf(':');
        if (colonPos > 0)
        {

            string playerId = line.Substring(0, colonPos).Trim();
            string afterColon = line.Substring(colonPos + 1).Trim();
            act.PlayerId = playerId;


            if (afterColon.Contains("folds"))
            {
                act.ActName = "FOLD";
            }
            else if (afterColon.Contains("calls"))
            {
                decimal amt = ExtractNumeric(afterColon, "calls $");
                act.ActName = "CALL";
                act.ActAmt = amt;
            }
            else if (afterColon.Contains("raises"))
            {
                // Usually "raises $2 to $5" => final amount is "to $5"
                //double amt = ExtractRaiseAmount(afterColon);
                decimal amt = ExtractRaiseAmount(afterColon);// ON-HOLD CASE Poker Hand #HD1605201605

                act.ActName = "RAISE";
                act.ActAmt = amt;
            }
            else if (afterColon.Contains("bets"))
            {
                decimal amt = ExtractNumeric(afterColon, "bets $");
                act.ActName = "BET";
                act.ActAmt = amt;
            }// 🔥 ADD THIS NEW CHECKS HANDLING HERE:
            else if (afterColon.Contains("checks"))
            {
                act.ActName = "CHECK";
            }
            else if (afterColon.Contains("shows"))
            {
                act.ActName = "SHOW";
                if (line.Contains(": shows ["))
                {

                    int colonPos2 = line.IndexOf(':');
                    if (colonPos2 > 0)
                    {

                        string possiblePlayerId = line.Substring(0, colonPos).Trim();
                        //if (!playerIdToSeat.TryGetValue(possiblePlayerId, out int seatIdx)) continue;
                        act.PlayerId = possiblePlayerId;
                        int openBracket = line.IndexOf('[', colonPos);
                        int closeBracket = line.IndexOf(']', openBracket + 1);
                        string pattern = @"(\S+): shows \[([^\]]+)\]";  // Match player ID, action "shows", and hole cards
                        Match match = Regex.Match(line, pattern);

                        if (match.Success)
                        {
                            string player = match.Groups[1].Value;    // Extract player ID
                            string holeCards = match.Groups[2].Value; // Extract the hole cards (e.g., "Qs Qd")
                            act.RawText = "[" + holeCards + "]";
                            //        Console.WriteLine($"Player: {player}, Action: SHOW, Hole Cards: {holeCards}");
                        }

                    }

                }
            }
        }

        return act;
    }

    public void InitLines()
    {
        var lines = RawText.Split("\n");
        var num = 0;
        foreach (var line in lines)
        {
            if (line.Trim().Length == 0) continue;
            num++;
            RawHandRecords.Add(new RawHandRecord { num = num, text = line.Trim() });
        }
    }

    /// <summary>
    /// 按照手牌記錄的順序及結構取其所在的 區塊
    /// </summary>
    public void InitSections()
    {
        var currentSection = "";
        foreach (var raw in RawHandRecords)
        {
            var x = raw.text;
            if (currentSection == "")
            {
                if (x.StartsWith("Poker Hand"))
                {
                    //currentSection = "HandInfo";
                    raw.section = "HandInfo";
                    continue;
                }
                if (x.StartsWith("Table"))
                {
                    //currentSection = "HandInfo";
                    raw.section = "TableInfo";
                    continue;
                }
                if (x.StartsWith("Seat"))
                {
                    //currentSection = "HandInfo";
                    raw.section = "Seating";
                    continue;
                }
                if (x.Contains("blind"))
                {
                    //currentSection = "HandInfo";
                    raw.section = "Blind";
                    //raw.section = "PREFLOP";
                    continue;
                }
                if (x.Contains("ante"))
                {
                    //currentSection = "HandInfo";
                    raw.section = "Ante";
                    //raw.section = "PREFLOP";
                    continue;
                }
            }



            if (x.StartsWith("***"))
            {
                currentSection = ExtractKeyword(x);
                raw.StreetPoint = true;
                raw.section = currentSection;
                continue;
            }
            else
            {
                raw.section = currentSection;
                continue;
            }
        }
    }

    /// <summary>
    /// 因應多次跑馬
    /// *** FIRST FLOP *** [5s Js 8h]
    ///*** FIRST TURN *** [5s Js 8h][5d]
    ///*** FIRST RIVER***[5s Js 8h 5d][7s]
    ///*** SECOND FLOP***[Ts Qc Kc]
    ///*** SECOND TURN***[Ts Qc Kc][6d]
    ///*** SECOND RIVER***[Ts Qc Kc 6d][4d]
    /// </summary>
    /// <param name="handHistory"></param>
    /// <returns></returns>
    private string ParseCommunityCards(string handHistory)
    {
        List<string> communityCards = new List<string>();
        var lines = handHistory.Split('\n');

        foreach (var line in lines)
        {
            if (line.Contains("FLOP ***") || line.Contains("TURN ***") || line.Contains("RIVER ***"))
            {
                // Extract cards within brackets [Xx Xx Xx]
                //var match = Regex.Match(line, @"\[(.*?)\]");
                var matches = Regex.Matches(line, @"\[([^\]]+)\]");
                foreach (Match match in matches)
                {
                    var cards = match.Groups[1].Value.Split(' ');
                    communityCards.AddRange(cards);
                }
            }
        }
        return string.Join(" ", communityCards);
    }
    private (int, string) ParseCommunityCardsExt(string handHistory)
    {
        List<string> communityCards = new List<string>();
        var lines = handHistory.Split('\n');
        int AllInCnt = 0;
        foreach (var line in lines)
        {
            if (line.Contains("FLOP ***") || line.Contains("TURN ***") || line.Contains("RIVER ***"))
            {
                if (line.Contains("FIRST")) AllInCnt = 1;
                if (line.Contains("SECOND")) AllInCnt = 2;
                if (line.Contains("THIRD")) AllInCnt = 3;

                // Extract cards within brackets [Xx Xx Xx]
                //var match = Regex.Match(line, @"\[(.*?)\]");
                var matches = Regex.Matches(line, @"\[([^\]]+)\]");
                foreach (Match match in matches)
                {
                    var cards = match.Groups[1].Value.Split(' ');
                    communityCards.AddRange(cards);
                }
            }
        }
        return (AllInCnt, string.Join(" ", communityCards));
    }

    public static string ExtractCommunityCards(string line)
    {
        // Match the last community cards inside the last pair of square brackets []
        Match match = Regex.Match(line.Trim(), @"\[\s*([^\]]+)\s*\]$");
        //Console.WriteLine(line);
        //Console.WriteLine(match.Success);

        if (match.Success)
        {
            return $"[{match.Groups[1].Value.Trim()}]";  // Return the community cards in proper format
        }

        return "";  // If no match, return empty square brackets
    }
    public static Scene ParseCollectedAction(string line)
    {
        Scene act = new();
        // Match the line to extract player and amount
        string pattern = @"(\S+) collected \$([\d.]+) from pot"; // Match player ID and amount
        Match match = Regex.Match(line, pattern);

        if (match.Success)
        {
            string player = match.Groups[1].Value;   // Extract player ID
            string amount = match.Groups[2].Value;   // Extract the amount

            act.PlayerId = player;
            act.ActAmt = decimal.Parse(amount);
            act.ActName = "WIN";

            //Console.WriteLine($"Player: {player}, Amount: {amount}");
        }
        else
        {
            //Console.WriteLine("No match found");
        }
        return act;
    }
    /// <summary>
    /// 起承轉合 + winner
    /// </summary>
    public void InitSectionForAction()
    {
        string[] sectionKeywords = new string[] { "HOLE", "FLOP", "TURN", "RIVER", "SHOWDOWN" };

        foreach (var raw in RawHandRecords)
        {

            if (sectionKeywords.Any(keyword => raw.section.Contains(keyword)))
            {
                raw.is_action_record = true;
            }
            else
            {
                raw.is_action_record = false;
            }
        }
    }
    #endregion

    /// <summary>
    /// 為了因應多次跑馬，改版為取記錄的所有牌
    /// </summary>
    public void InitCommunityCards()
    {
        /*
            *** FIRST TURN *** [5d 4h 3h] [4c]
            *** FIRST RIVER *** [5d 4h 3h 4c] [8h]
            *** SECOND TURN *** [5d 4h 3h] [Kd]
            *** SECOND RIVER *** [5d 4h 3h Kd] [6d]
            *** THIRD TURN *** [5d 4h 3h] [8c]
            *** THIRD RIVER *** [5d 4h 3h 8c] [9s]
         */
        var list = RawHandRecords.Where(a => a.is_action_record).Where(a => a.text.StartsWith("***")).ToList();
        foreach (var raw in list)
        {
            (var AllInCnt, var allCards) = ParseCommunityCardsExt(raw.text);
            if (!string.IsNullOrEmpty(allCards))
            {
              //  Console.WriteLine($"檢查全部的公共牌 {allCards} 及跑馬次 {AllInCnt}");
                var p = new Scene();
                p.AllInCnt = AllInCnt;
                p.Stage = raw.section;
                p.ActName = "COMMUNITY";
                p.RawText = allCards;  // ✅ Use accumulated version
                raw.Action = p;
            }
        }
    }


    #region Tools
    public static string ExtractKeyword(string line)
    {
        // Match the content between ***
        Match match = Regex.Match(line, @"\*\*\* (.*?) \*\*\*");
        if (match.Success)
        {
            return match.Groups[1].Value.Trim(); // Extract the keyword
        }
        return string.Empty;  // Return an empty string if no match found
    }
    private static decimal ExtractNumeric(string text, string prefix)
    {
        int idx = text.IndexOf(prefix);
        if (idx < 0) return 0m;
        idx += prefix.Length;
        var remainder = text.Substring(idx).Trim();
        var parts = remainder.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        decimal.TryParse(parts[0], out decimal val);
        return val;
    }

    /// <summary>
    /// 在 section  HOLE CARDS, 包括了發牌及翻前的動作
    /// 在此只取 發牌
    /// </summary>
    public void DetermineHeroHoleCards()
    {
        /*
            在 section  HOLE CARDS, 包括了發牌及翻前的動作
            *** HOLE CARDS ***
            Dealt to 4cacd4e7 
            Dealt to 622cae43 
            Dealt to a3e68cdb 
            Dealt to f5bc2b5d 
            Dealt to bd907983 
            Dealt to Hero [Ts Qs]
            f5bc2b5d: folds
            bd907983: folds
            Hero: raises $2.4 to $4.4
            4cacd4e7: folds
            622cae43: raises $17.6 to $22
            a3e68cdb: calls $20
            Hero: calls $17.6
         */
        foreach (var x in RawHandRecords.Where(a => a.text.StartsWith("Dealt")))
        {
            var line = x.text;

            // Regular expression to match "Dealt to Hero" and extract the hole cards
            string pattern = @"Dealt to (\S+) \[(.*?)\]"; // Capture player name and cards inside brackets
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string player = match.Groups[1].Value;      // Extract player name (e.g., Hero)
                string holeCards = match.Groups[2].Value;   // Extract hole cards (e.g., 9d Ah)

                x.HoleCards = holeCards;
                x.HoleCardsOwner = player;

                var p = new Scene();
                p.Stage = "PREFLOP";
                p.ActName = "hole";
                p.PlayerId = player;
                p.RawText = holeCards;
                x.Action = p;
                //Console.WriteLine($"Player: {player}, Hole Cards: {holeCards}");
            }
            else
            {
                //   Console.WriteLine("No match found");
            }
        }
    }

    public void DetermineAnte()
    {
        /*
            Example lines:
            fb51de23: posts the ante $2
            9a0300d8: posts the ante $2
            Hero: posts the ante $2
        */

        var list = RawHandRecords.Where(a => a.text.Contains("posts the ante")).ToList();

        foreach (var x in list)
        {
            var line = x.text;

            // Regular expression to capture player ID and ante amount
            string pattern = @"(\S+): posts the ante \$(\d+(\.\d+)?)";
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string player = match.Groups[1].Value;  // Extract player ID
                decimal amount = ParseAmount(match.Groups[2].Value); // Extract ante amount

                var anteAction = new Scene
                {
                    Stage = "ANTE",
                    ActName = "ANTE",
                    PlayerId = player,
                    ActAmt = amount
                };

                x.Action = anteAction;
            }
        }
    }


    public void DetermineBlind()
    {
        //  Blind
        var list = RawHandRecords.Where(a => a.section == "Blind").ToList();
        foreach (var x in list)
        {
            var line = x.text;

            // Regular expression to capture player, blind type, and amount
            string pattern = @"(\S+): posts (small blind|big blind) \$(\d+(\.\d+)?)";
            Match match = Regex.Match(line, pattern);


            if (match.Success)
            {
                string player = match.Groups[1].Value;   // Extract player ID
                string blindType = match.Groups[2].Value; // Extract blind type (small/big)
                string amount = match.Groups[3].Value;   // Extract the amount (without $)

                var shortBlind = "BB";
                if (blindType == "small blind") shortBlind = "SB";




                var p = new Scene();
                p.Stage = "Blind";
                p.ActName = shortBlind;
                p.PlayerId = player;
                p.ActAmt = ParseAmount(amount);
                //   p.RawText = holeCards;
                x.Action = p;
                //Console.WriteLine($"Player: {player}, Hole Cards: {holeCards}");
            }
            else
            {
                //    Console.WriteLine("No match found");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private static decimal ExtractRaiseAmount(string text)
    {
        // Regular expression to match "raises $Y to $X"
        string pattern = @"raises \$(\d{1,3}(?:,\d{3})*(?:\.\d+)?) to \$(\d{1,3}(?:,\d{3})*(?:\.\d+)?)";
        Match match = Regex.Match(text, pattern);

        if (match.Success)
        {
            string finalAmountStr = match.Groups[2].Value; // 抓取 "to $X" 的數值

            // 移除千分位逗號
            finalAmountStr = finalAmountStr.Replace(",", "");

            if (decimal.TryParse(finalAmountStr, out decimal finalAmount))
            {
                return finalAmount;
            }
        }

        return 0m; // 解析失敗時回傳 0
    }

    /// <summary>
    /// 在原本取 raise amt 的基礎上, 
    /// 要多檢查上一個動作是否已有 大小盲的投入,
    /// 如果有, 僅管 raise amt 的顯示不變, 
    /// 但player chips要返回 大小盲的投入
    /// POT 也要扣掉重覆的 大小盲的投入
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private double ExtractRaiseAmountExt(string text)//NOTE by Mark, 同時拿掉 static
    {



        // Regular expression to match "raises $Y to $X"
        string pattern = @"raises \$(\d{1,3}(?:,\d{3})*(?:\.\d+)?) to \$(\d{1,3}(?:,\d{3})*(?:\.\d+)?)";
        Match match = Regex.Match(text, pattern);

        if (match.Success)
        {
            string finalAmountStr = match.Groups[2].Value; // 抓取 "to $X" 的數值

            // 移除千分位逗號
            finalAmountStr = finalAmountStr.Replace(",", "");

            if (double.TryParse(finalAmountStr, out double finalAmount))
            {
                return finalAmount;
            }
        }

        return 0.0; // 解析失敗時回傳 0
    }
    private static double BUGExtractRaiseAmount(string text)
    {
        // e.g. "raises $2 to $5"
        int toPos = text.IndexOf("to $");
        if (toPos < 0) return 0.0;
        var afterTo = text.Substring(toPos + "to $".Length).Trim();
        var parts = afterTo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double.TryParse(parts[0], out double val);
        return val;
    }
    #endregion

    /// <summary>
    /// MARKNOTE 先在此調試, 調好後要移至 init 最後
    /// </summary>
    public void Settings()
    {
        // 從原始數據整理出 Actions
        MakeSceneList();


        // 處理手牌基本信息
        SettingHoleCards();


        // 獨立處理 SHOW at
        SettingShowdAt();
        // 獨立處理 FOLD at
        SettingFoldAt();


        // 獨立處理 動作內容 ACTION DETAIL
        SettingAcitonDetails();

        // 設定公共牌
        SettingCommunityCards();

        // CHIPS AND POT
        SettingAmoutAndPot();// 剛才動了 IsAllIn, 

        SettingAllIn();

        // 🔹 設定探照灯 SpotTo
        SetSpotlight();



    }

    /// <summary>
    /// 設定每個 scene 探照灯
    /// 
    /// </summary>
    public void SetSpotlight()
    {
        foreach (var scene in Scenes.Where(a => a.Seq > 0))// BUG FIXED, SpotTo was overwritten
        {
            scene.SpotTo = ""; // 預設沒有 spotlight

            if (scene.ActName == "hole")
            {
                continue; // 發手牌時，不打 spotlight
            }

            if (!string.IsNullOrEmpty(scene.PlayerId))
            {
                var p = Players.FirstOrDefault(x => x.PlayerId == scene.PlayerId);
                if (p != null)
                {
                    scene.SpotTo = p.SeatNum.ToString(); // 針對這個 SeatNum 打 spotlight
                }
            }

            // 如果需要多個 spotlight，例如 showdown 時亮多個座位
            //if (scene.ActName == "SHOW")
            //{
            //    var showingPlayers = Players.Where(p => p.ShowAt > 0).ToList();
            //    scene.SpotTo = string.Join(",", showingPlayers.Select(p => p.SeatNum));
            //}
        }
    }

    /// <summary>
    /// 處理手牌基本信息
    /// </summary>
    public void SettingHoleCards()
    { //
      // MARKNOTE, DOING
      // 手牌一開始是沒有, PREFLOP 時視同一次全部發完, 大家都有牌。
      // 這時只有玩家(HERO)的牌可以看到正面, 其它的都是背面。
      // 隨著牌局進行, 有蓋牌的, 就要將牌拿掉。
      // 最後有比牌時, 才將牌翻開。

        // NOTE by Mark, 啟用 ACTUAL_SEAT, 解決 動態 六人或九人桌 的需求       
        foreach (var x in Scenes)
        {
            x.Players = new List<Player>(); // Initialize the list before adding players
            for (int i = 0; i < ACTUAL_SEAT; i++) // Ensure no out-of-range errors
            {
                x.Players.Add(new Player(Players[i])); // Cloning Players[i] into x.Players
            }
        }



        var step = 0;
        foreach (var scene in Scenes)
        {
            step++;
            foreach (var p in scene.Players)
            {
                // 已在 class 直接給預設值, 但為全局的給值, 仍然保留
                p.HoleRef[0] = "__"; //沒有牌
                p.HoleRef[1] = "__"; //沒有牌

                if (step >= Get_PREFLOP())
                {
                    if (p.HoleCards != null)
                    {
                        var cards = p.HoleCards.Split(' ');
                        if (cards.Length == 2)
                        {
                            p.HoleRef[0] = cards[0]; //有牌
                            p.HoleRef[1] = cards[1]; //有牌
                        }
                    }
                    else
                    {
                        p.HoleRef[0] = "Xx"; //牌背
                        p.HoleRef[1] = "Xx"; //牌背
                    }
                }
            }

            if (scene.ActName == "FOLD")
            {
                var topP = Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                topP.FoldAt = scene.Seq; ;

                var p = scene.Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                if (p != null)
                {
                    p.FoldAt = scene.Seq;
                    p.HoleRef[0] = "__"; //沒有牌
                    p.HoleRef[1] = "__"; //沒有牌
                }
            }
            if (scene.ActName == "SHOW")
            {
                var topP = Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                topP.ShowAt = scene.Seq; ;

                var p = scene.Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                if (p != null)
                {
                    p.ShowAt = scene.Seq;
                    //var cards=
                    p.HoleRef[0] = "As"; //沒有牌
                    p.HoleRef[1] = "Ks"; //沒有牌
                }
            }
        }

    }

    /// <summary>
    /// 從原始數據整理出 Actions
    /// </summary>
    public void MakeSceneList()
    {
        // 設定序列號
        var seq = 0;
        foreach (RawHandRecord x in RawHandRecords)
        {
            if (x.Action != null)
            {
                seq++;
                x.Action.Seq = seq;
                //Console.WriteLine("XXX " + x.Action);
            }
        }
        string lastStage = ""; // Track last known stage
        foreach (RawHandRecord x in RawHandRecords.Where(a => a.Action != null && a.Action.Seq > 0).OrderBy(a => a.Action.Seq))
        {
            if (x.Action != null)
            {
                x.Action.text = x.text; // 為了在頁面仍能參照原始文本
                //   Console.WriteLine(x.Action);
                Scenes.Add(x.Action);
                MAX_STEP = x.Action.Seq;

                //need to carry Stage to next scene as well, how to fix
                if (!string.IsNullOrEmpty(x.Action.Stage))
                {
                    lastStage = x.Action.Stage; // Update last known stage
                }
                else
                {
                    x.Action.Stage = lastStage; // Carry forward last stage
                }
            }

        }

        //Console.WriteLine("DEBUG... SEQ=0 要有 Player 的 chips");
        //foreach (var p in PlayerWithInitialChips)
        //{
        //    Console.WriteLine($"   {p.PlayerId} {p.Chips}");
        //}


        // 🔹 插入 `SceneId == 0` 的初始場景
        Scenes.Add(new Scene
        {
            Seq = 0,
            ActName = "START",
            PlayerId = "",
            RawText = "就座",
            CommunityCards = "",

            Pot = 0,

            // NOTE by Mark, 03/04 15:00, 是否可以取到 Player 的初始 chips?
            Players = PlayerWithInitialChips.Select(p => new Player(p)).ToList(), //Create deep copy of Players list

            //DEV NOTE: 確認可以照到多人
            //SpotTo = "0,1,2,3,4,5",
            SpotTo = "",
            //   Players = PlayerWithInitialChips // 改到 init 最後才指定?
        }); ;

    }

    /// <summary>
    /// 獨立處理 SHOW at
    /// </summary>
    public void SettingShowdAt()
    {
        foreach (var scene in Scenes)
        {
            if (scene.ActName == "SHOW")
            {
                var cards = scene.RawText;
                var px = Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                if (px != null)
                {
                    px.ShowAt = scene.Seq;
                    px.HoleCards = cards;
                }
            }
            if (scene.ActName == "hole")
            {
                var cards = scene.RawText;
                var px = Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                if (px != null)
                {
                    px.ShowAt = scene.Seq;
                    px.HoleCards = cards;
                }
            }

            foreach (var p in scene.Players)
            {
                var pTop = GetTopLevelPlayerBySeatNum(p.SeatNum);
                if (pTop.ShowAt > 0)
                {
                    var showAt = pTop.ShowAt;
                    if (scene.Seq >= showAt)
                    {
                        //p.IsFold = true;
                        if (pTop.HoleCards != null)
                        {


                            var cards = pTop.HoleCards.Replace("[", "").Replace("]", "").Split(' ');
                            if (cards.Length == 2)
                            {
                                p.HoleRef[0] = cards[0];
                                p.HoleRef[1] = cards[1];
                            }
                            else
                            {
                                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^沒有給值");
                            }
                        }
                        else
                        {
                            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^ NULL");
                        }

                    }
                }
            }

        }
    }

    // 獨立處理 FOLD at
    public void SettingFoldAt()
    {
        foreach (var scene in Scenes)
        {
            foreach (var p in scene.Players)
            {
                var pTop = GetTopLevelPlayerBySeatNum(p.SeatNum);
                if (pTop.FoldAt > 0)
                {
                    var foldAt = pTop.FoldAt;
                    if (scene.Seq >= foldAt)
                    {
                        p.IsFold = true;
                        p.HoleRef[0] = "__"; //沒有牌
                        p.HoleRef[1] = "__"; //沒有牌
                    }
                }
            }

        }

    }


    /// <summary>
    /// //獨立處理 動作內容 ACTION DETAIL
    /// </summary>
    public void SettingAcitonDetails()
    {
        foreach (var scene in Scenes.Where(a => a.Seq >= 1))
        {
            if (scene.text.Contains("***"))// 要清掉在此之後的
            {
                foreach (var scene2 in Scenes.Where(a => a.Seq >= scene.Seq))
                    foreach (var p in scene2.Players)
                    {
                        p.ActionDetail = "";
                    }
            }
            else
            {
                foreach (var p in scene.Players.Where(a => a.PlayerId == scene.PlayerId))
                {
                    var playerX = p.PlayerId;
                    //   Console.WriteLine("scene seq" + scene.Seq + " actname " + scene.ActName + " player id " + p.PlayerId + " setnum " + p.SeatNum);

                    if (scene.ActName != null && scene.ActName != "" && scene.ActName != "hole") // FIX hole
                    {


                        p.ActionDetail = scene.ActName;
                        if (scene.ActAmt > 0)
                        {
                            p.ActionDetail += " " + scene.ActAmt;
                        }

                        var copyMore = p.ActionDetail;
                        ////或是一次性按同一個 player 全部先填上, 後面再覆蓋即可
                        var list2 = Scenes.Where(a => a.Seq > scene.Seq);
                        //Console.WriteLine("list2 " + list2.Count());


                        foreach (var scene2 in list2)
                        {
                            var list2x = scene2.Players.Where(a => a.PlayerId == playerX);
                            //Console.WriteLine("list2x " + list2x.Count());
                            foreach (var p2 in list2x)
                            {
                                p2.ActionDetail = copyMore;
                            }
                        }
                    }
                }
            }
        }

    }

    /// <summary>
    /// //獨立處理 CHIPS 底池
    /// </summary>
    /// 
    public void SettingAmoutAndPot() //DOING
    {
        // 先將頂層 Players 的 初始籌碼, 放到各 Scene 的 Players ,  籌 HGNI
        foreach (var scene in Scenes.Where(a => a.Seq > 0))
        {
            //Console.WriteLine($"scene.Seq = {scene.Seq}");
            foreach (var p in scene.Players)
            {
                //    Console.WriteLine($"p.PlayerId = {p.PlayerId} {p.Chips}");
                var top = Players.Where(a => a.PlayerId == p.PlayerId).FirstOrDefault();//.FirstOrDefault().Chips;
                if (top == null)
                {
                    Console.WriteLine($"🚨 Error: Player {p.PlayerId} not found in Players list!");
                    continue; // Skip this player to prevent null reference
                }
                p.Chips = top.Chips;


            }
        }


        foreach (var scene in Scenes.Where(a => a.Seq > 0))
        {
            foreach (var p in scene.Players.Where(a => a.PlayerId == scene.PlayerId))
            {
                var top = Players.Where(a => a.PlayerId == p.PlayerId).FirstOrDefault();
                if (top == null) continue;
                //Console.WriteLine("");
                //Console.WriteLine(""); Console.WriteLine("scene seq=" + scene.Seq + " actname =" + scene.ActName + " player=" + p.PlayerId + " setnum=" + p.SeatNum);
                //Console.WriteLine("");
                if (scene.ActName != null && scene.ActName != "") // FIX hole
                {
                    //Console.WriteLine("scene.ActName " + scene.ActName );

                    if (scene.ActAmt > 0)
                    {
                        decimal amt = (decimal)scene.ActAmt;
                        if (scene.ActName == "WIN")
                        {
                            amt = -amt;
                        }
                        //Console.WriteLine($"p.Chips {p.Chips}  top.Chips {top.Chips} (double)scene.ActAmt {amt} "  );


                        p.Chips = top.Chips - amt;
                        if (scene.ActName == "WIN")
                        {
                            p.Chips = p.Chips + amt;
                        }

                        top.Chips = p.Chips;
                        //     Console.WriteLine($"p.Chips {p.Chips}  top.Chips {top.Chips} (double)scene.ActAmt {amt} ");

                        //    Console.WriteLine($"scene.Pot {scene.Pot} ");
                        scene.Pot = scene.Pot + amt;
                        //   Console.WriteLine($"scene.Pot {scene.Pot} ");


                    }
                }
            }
            //將整個 Scene 的 Players Chips 往後全部複製
            foreach (var scene2 in Scenes.Where(a => a.Seq > 0).Where(a => a.Seq > scene.Seq))
            {
                scene2.Pot = scene.Pot;
                //      Console.WriteLine($"scene.Seq = {scene.Seq}");
                foreach (var p in scene2.Players)
                {
                    //      Console.WriteLine($"p.PlayerId = {p.PlayerId} {p.Chips}");
                    var top = Players.Where(a => a.PlayerId == p.PlayerId).FirstOrDefault();//.Chips;
                    if (top == null)
                    {
                        Console.WriteLine($"另一個 NULL");
                        continue;
                    }
                    p.Chips = top.Chips;
                    //p.IsAllIn = top.IsAllIn; // Carry forward all-in state
                    //Console.WriteLine($"也檢查 all in 是否有帶到往後的 scene {p.IsAllIn} p.PlayerId = {p.PlayerId} {p.Chips}");
                    //if (p.IsAllIn)
                    //{
                    //    Console.WriteLine($"\t\t *** all in ***");
                    //}
                }
            }
        }
    }
    public void SettingAllIn()
    {
        
        foreach (var scene in Scenes.Where(a => a.Seq > 0))
        {
            if (scene.ActName == "ALL-IN")
            {
                Console.WriteLine($"SettingAllIn: Player {scene.PlayerId} went all-in at scene {scene.Seq}");

                var p = scene.Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                if (p != null)
                {
                    p.IsAllIn = true;
                    Console.WriteLine($"Player {p.PlayerId} is now marked as All-In");
                    Console.WriteLine($"*** 在這情況下,這立 Player 在往後的 Scene 都是 all in 狀態");
                    foreach (var scene2 in Scenes.Where(a => a.Seq > scene.Seq))
                    {
                        var p2 = scene2.Players.Where(a => a.PlayerId == scene.PlayerId).FirstOrDefault();
                        if (p2 != null)
                        {
                            p2.IsAllIn = true;
                        }
                    }
                }
            }
        }


    }



    /// <summary>
    /// 設定公共牌
    /// </summary>
    public void SettingCommunityCards()
    {
        // 
        foreach (var scene in Scenes.Where(a => a.Seq > 0)) // BUG FIXED
        {
            if (scene.ActName == "COMMUNITY")
            {
                //var cards = scene.RawText.Trim().Replace("[", "").Replace("]", "");
                //scene.CommunityCards += CommunityCards + " " + cards;
                //scene.CommunityCards = scene.CommunityCards.Trim();
                //CommunityCards = scene.CommunityCards;

                scene.CommunityCards = scene.RawText;
                CommunityCards = scene.CommunityCards;
            }
            else
            {
                //這是為 showdown 要保持著最後的公共牌
                scene.CommunityCards = CommunityCards;
            }
        }
    }


    /// <summary>
    ///     手牌及公共牌
    /// </summary>
    public void DevOutput1()
    {
        foreach (var scene in Scenes)
        {
            Console.Write("場景:" + scene.Seq + "  ");

            foreach (var p in scene.Players)
            {
                Console.Write(p.GetHoleRef() + " ");
            }
            Console.Write("公共牌 [" + scene.CommunityCards + "]");
            Console.WriteLine();
        }
    }
    /// <summary>
    /// 動作內容
    /// </summary>
    public void DevOutput2()
    {
        foreach (var scene in Scenes)
        {
            Console.Write("場景:" + scene.Seq + "  ");

            foreach (var p in scene.Players)
            {
                Console.Write($"[{p.SeatNum}]{p.ActionDetail}   ");
            }
            //Console.Write("公共牌 [" + scene.CommunityCards + "]");
            Console.WriteLine();
        }

    }

    /// <summary>
    /// amt and Pot 底池
    /// </summary>
    public void DevOutput3()
    {
        Console.WriteLine();
        foreach (var scene in Scenes.OrderBy(a => a.Seq))
        {
            var allinScene = scene.IsAllIn ? "@" : "";
            //Console.WriteLine("場景:" + scene.Seq + "  " + scene.text + "  探照灯:" + scene.SpotTo + " " + "ALL IN" + scene.IsAllIn + " ");
            Console.Write($"{scene.Stage} ({scene.Seq}) {allinScene} pot: {scene.Pot:F2} ");
            if (scene.AdjPot != scene.Pot)
            {
                Console.Write($" adj to {scene.AdjPot:F2} ");
            }
            foreach (var p in scene.Players)
            {

                //p.Chips = 100 * scene.Seq + 10 * p.SeatNum;
                if (p.AdjChips == p.Chips)
                {
                    var allin = p.IsAllIn ? "@" : "";
                    Console.Write($"{allin}[{p.SeatNum}]{p.Chips:F2}   ");
                }
                else
                {
                    Console.Write($"[{p.SeatNum}]{p.Chips:F2} =>adj to {p.AdjChips:F2}    ");
                }

            }

            if (scene.ActAmt != null && scene.ActAmt != 0)
            {
                //                Console.Write($" {scene.text}");
                Console.Write($" {scene.PlayerId}  {scene.ActName} {scene.ActAmt}");

            }
            //    Console.Write($" {scene.PlayerId}  {scene.ActName} {scene.ActAmt}");
            Console.WriteLine();
        }
    }


    public void DevOutputaAllIn()
    {
        foreach (var scene in Scenes.OrderBy(a => a.Seq))
        {
            Console.Write($"場景:  {scene.Seq} ALL IN:  {(scene.IsAllIn ? "有" : "沒")}  ");
            //if (scene.IsAllIn)
            //{
            //    Console.WriteLine("\n場景:" + scene.Seq + " 出現 ALL IN [" + scene.PlayerId + "] 應該要有記錄 ");
            //}
            foreach (var p in scene.Players.OrderBy(a => a.SeatNum))
            {
                //Console.Write($"{p.SeatNum}[{p.PlayerId}] {(p.IsAllIn ? "T" : "_")}  ");
                Console.Write($"[{p.SeatNum}]{(p.IsAllIn ? "有" : "_")} ");
            }
            //  Console.Write("底池=" + scene.Pot + " " + scene.text);
            Console.WriteLine();
        }
    }
    /// <summary>
    /// amt and Pot 底池
    /// </summary>
    public void DevOutput3Sim()
    {
        foreach (var scene in Scenes)
        {
            Console.Write("場景:" + scene.Seq + "  ");

            foreach (var p in scene.Players)
            {
                p.Chips = 100 * scene.Seq + 10 * p.SeatNum;
                Console.Write($"[{p.SeatNum}]{p.Chips}   ");
            }
            Console.Write("底池=" + Pot);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 查看 頂層 Players
    /// </summary>
    public void DevOutput4()
    {
        Console.Write("頂層 Players ");

        foreach (var p in Players)
        {
            Console.WriteLine(p);
        }


    }
}
