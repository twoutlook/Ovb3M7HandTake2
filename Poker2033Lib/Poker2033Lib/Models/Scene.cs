namespace Poker2033.Hand;

public class Scene
{
    public bool IsAllIn { get; set; } = false; // New property
    /// <summary>
    /// 探照灯的邏輯：
    ///SpotTo = "" 代表沒有 spotlight
    ///SpotTo = "0" 代表 spotlight 指向 seatNum = 0
    ///SpotTo = "0,1" 代表 spotlight 指向 seatNum = 0 和 seatNum = 1
    /// </summary>
    public string SpotTo { get; set; } // 最原始的記錄
    public double Pot { get; set; } = 0;
    public double AdjPot { get; set; } = 0;

    public bool StreetPoint { get; set; } = false;
    public string text; // 最原始的記錄
    public int Seq { get; set; }
    public string Stage { get; set; }    // Unique identifier for the player (e.g., a8b25666)
    public string PlayerId { get; set; }
    public string ActName { get; set; }
    public double? ActAmt { get; set; }       // The amount of chips the player has
                                   //public bool IsSmallBlind { get; set; }  // Indicates if the player is posting the small blind
    /// <summary>
    /// 跑馬時, 有 FIRST, SECOND, THIRD 分別記錄 123
    /// </summary>    
    public int AllInCnt { get; set; }                                    //public bool IsBigBlind { get; set; }
                                                                         // public string RawText { get; set; }// Indicates if the player is posting the big blind
    public string RawText { get; set; }
    public string CommunityCards { get; set; }
    /// <summary>
    /// NOTE by Mark, 2025-02-26 10:27
    /// 按劇本, 每一 Scene（場景）player 相關的資訊, 先處理手牌
    /// </summary>
    public Player Player { get; set; }
    public List<Player> Players { get; set; }
    public Scene()
    {
        // 確保 Players 被初始化
        Players = new List<Player>();

        // 之前的就急, 成為 BUG

        // NOTE by Mark, 02/26
        //Players.Add(new Player());
        //Players.Add(new Player());
        //Players.Add(new Player());
        //Players.Add(new Player());
        //Players.Add(new Player());
        //Players.Add(new Player());
    }

    public override string ToString()
    {
        return $"({Seq},{Stage} {PlayerId}=>{ActName}, {ActAmt}, {RawText})";
    }
}
