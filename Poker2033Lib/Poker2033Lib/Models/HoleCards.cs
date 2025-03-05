namespace Poker2033.Hand;

public class HoleCards
{
    public string Card1 { get; set; }  // The first card (e.g., 9d)
    public string Card2 { get; set; }  // The second card (e.g., Ah)
    public override string ToString()
    {
        return $"({Card1},{Card2} )";
    }
}