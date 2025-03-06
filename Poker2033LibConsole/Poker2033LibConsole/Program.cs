using Poker2033.Hand.Data;
using Poker2033.Hand;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        OneHandExt one;

        for (int i = 1; i <= 17; i++)
        {
            one = new();
            var hand = DevData.GetPokerHandByGameID(i);
            one.RawText = hand;
            await one.InitAsync();
            (bool result, decimal pot, decimal rakes) = one.TestFinalPot();

            //string statusMessage = result ? "✅ POT餘額正確!" : "❌ POT餘額錯誤!";
            string statusMessage = result ? "POT餘額正確!" : "POT餘額錯誤!";
            //Console.WriteLine($"範例 {i} => {statusMessage} ({result}, {pot}, {rakes}) ");
            Console.WriteLine($"範例 {i} => {statusMessage} ({result}, {pot.ToString("0.00")}, {rakes.ToString("0.00")}) ");
        }

        // not to close
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
}
