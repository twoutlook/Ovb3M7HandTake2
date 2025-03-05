namespace Ovb3HandPwa.Client;
public static partial class DevUtil
{
    // A container for seat info
    public class PlayerInfo
    {
        public string PlayerId { get; set; } = "";
        public string Chips { get; set; } = "";
        public bool IsFolded { get; set; } = false; // 🚀 NEW: Track fold status
    }

}
