using Poker2033.Hand;
using Poker2033.Hand.Data;

class Program
{
    static async Task Main()
    {
        OneHandExt one = new();
        one.RawText = DevData.pokerHand13;
        await one.InitAsync();
    }
}
