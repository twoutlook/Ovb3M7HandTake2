using Poker2033.Hand;
using Poker2033.Hand.Data;

class Program
{
    static async Task Main()
    {
        OneHandExt one;
     
        for (int i = 1; i <= 16; i++)
        {
            one = new();
            var hand=DevData.GetPokerHandByGameID(i);
            one.RawText = hand;
            await one.InitAsync();
            (bool result, double pot, double rakes) = one.TestFinalPot();
            Console.WriteLine($"******************** {i} {result} {pot} {rakes}");
        }
        
    }
}
