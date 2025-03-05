namespace Poker2033.Hand;

/// <summary>
/// 有兩個實例應用:
/// 1. OneHandSet 級別: 如果 IsFold 先記在這裡
/// 2. 是 scene 級別: 如上已是 Fold 就持續使用
/// 上述不可行
/// 
/// 還是使用 FoldAt
/// 
/// </summary>
public class Player
{
    /// <summary>
    /// PREFLOP 視同發牌, 大家都有
    /// </summary>
    /// public int HasCardStart { get; set; } = 99;//大家都一樣, 就不做了

    /// <summary>
    /// 有 FOLD 時維護
    /// </summary>
    public int FoldAt { get; set; } = 0;
    public int ShowAt { get; set; } = 0;
    public bool IsFold { get; set; } = false;
    public bool IsAllIn { get; set; }

    public string PlayerId { get; set; }    // Unique identifier for the player (e.g., a8b25666)
    public int SeatNum { get; set; } // 0-5, zero base
    public string Position { get; set; } //單個要決定 Position
    public string ActionDetail { get; set; }
    public double Chips { get; set; } //單個可以是 initial chip, 

    public double AdjChips { get; set; } //單個可以是 initial chip, 

    //  public double InitialChips { get; set; }       // The amount of chips the player has
    //public bool IsSmallBlind { get; set; }  // Indicates if the player is posting the small blind
    //public bool IsBigBlind { get; set; }    // Indicates if the player is posting the big blind
    /// <summary>
    /// 手牌在解析 hand record 時就知道了
    /// 只能看到玩家和有比牌的
    /// 不同時機蓋牌決定在 canvas 要不要有牌背面來表示  DrawHoleCards()
    public string HoleCards { get; set; }
    public  bool IsHero()
    {
        return PlayerId?.ToUpper() == "HERO";  // 或其他方式判定
    }

    public string[] HoleRef { get; set; } = new string[2] { "__", "__" };//標準 As 黑桃A, 外加 Xx 背面, 其它任意值視為沒有卡
    public override string ToString()
    {
        // 籌 HBCKR
        return $"Canvas手牌 [{HoleRef[0]}][{HoleRef[1]}]  在 {FoldAt} 時蓋牌  座次{SeatNum} {PlayerId} POSITION {Position} 初始籌碼 {Chips} 手牌:{HoleCards}";
    }
    public string GetHoleRef()
    {
        return $"座次{SeatNum}[{HoleRef[0]} {HoleRef[1]}]";
        //return $"座次{SeatNum}[{HoleRef[0]} {HoleRef[1]}] Fold at {FoldAt} ";
    }

    /// <summary>
    /// 按學理補上
    /// </summary>
    public Player()
    { }

    // Copy Constructor
    /// <summary>
    /// Player p2 = new Player(p1); // Cloning p1
    /// </summary>
    /// <param name="other"></param>
    public Player(Player other)
    {
        FoldAt = other.FoldAt;
        PlayerId = other.PlayerId;
        SeatNum = other.SeatNum;
        Position = other.Position;
        //InitialChips = other.InitialChips;
        HoleCards = other.HoleCards;
        HoleRef = (string[])other.HoleRef.Clone(); // Deep copy to avoid reference issues
    }

}
