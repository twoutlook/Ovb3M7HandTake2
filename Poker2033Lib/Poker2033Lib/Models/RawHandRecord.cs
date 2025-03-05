namespace Poker2033.Hand.Base.Model;

public class RawHandRecord
{
    private static readonly string[] PositionOrder6Max =
    {
    "BTN", // offset 0
    "SB",  // offset 1
    "BB",  // offset 2
    "UTG", // offset 3
    "MP",  // offset 4
    "CO"   // offset 5
};
    public int num { get; set; }
    public string CommunitiyCards { get; set; }
    public Scene Action { get; set; }
    public string section { get; set; }
    public bool StreetPoint { get; set; }=false;
    public string text { get; set; }
    public bool is_action_record { get; set; }
    public string action_name_raw { get; set; }
    public string action_name_std { get; set; }
    //public string action_name_std { get; set; }

    public string HoleCardsOwner { get; set; }
    public string HoleCards { get; set; }
    public override string ToString()
    {
        return $"{HoleCardsOwner}=>{HoleCards}    {Action}   {CommunitiyCards} ({num}) {section} {is_action_record} {action_name_std}  {text}";
    }

}
