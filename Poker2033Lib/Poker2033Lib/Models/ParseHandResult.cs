namespace Ovb3HandPwa.Client;
public static partial class DevUtil
{
    // Data record for the parse result
    public record ParseHandResult(
        string[,] PlayerCards,
        string[] CommunityCards,
        bool[] SeatShowdownRevealed,
        Dictionary<string, int> PlayerIdToSeat,
        PlayerInfo[] SeatInfos,
        List<PreflopAction> PreflopActions,
        int HeroSeatIndex,
        int DealerSeatIndex,
        string DebugMessages  // optional: concatenated debug logs
    );
}
