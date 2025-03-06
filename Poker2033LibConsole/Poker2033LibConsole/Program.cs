using Poker2033.Hand.Data;
using Poker2033.Hand;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ovb3M7Db.Server.Data;

class Program
{
    static async Task Main()
    {
        await Main17();

        //await Main1000();
        //not to close
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    static async Task Main1000Only()
    {
        var AppDbConnection = "Server=(localdb)\\mssqllocaldb;Connection Timeout=30;Command Timeout=30;Persist Security Info=False;TrustServerCertificate=True;Integrated Security=True;Initial Catalog=PokerHandDbTake2";


        var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseSqlServer(AppDbConnection)
               .Options;

        using var appDb = new AppDbContext(options); // Pass the configured options
                                                     //using var appDb = new Ovb3M7Db.Server.Data.AppDbContext();
        OneHandExt one;
        var testBatch = await appDb.PokerHands
            .OrderBy(x => x.Id)
            .Take(1000) // Only fetch 10 records
            .ToListAsync();

        foreach (var x in testBatch)
        {
            one = new();
            var hand = x.PokerHandText;

            one.RawText = hand;
            await one.InitAsync();
            (bool result, decimal pot, decimal rakes) = one.TestFinalPot();

            string statusMessage = result ? "POT餘額正確!" : "POT餘額錯誤!";
            //Console.WriteLine($"範例 {x.Id} => {statusMessage} ({result:0.00}, {rakes:0.00}) ");
            Console.WriteLine($"範例 {x.Id} => {statusMessage} ({result}, {pot.ToString("0.00")}, {rakes.ToString("0.00")}) ");

            x.LastScenePot = pot;
            x.Rakes = rakes;
            x.Runtime = DateTime.Now;
        }

        await appDb.SaveChangesAsync();
        Console.WriteLine("Test completed for 10 records.");
    }


    static async Task Main1000()
    {
        var AppDbConnection = "Server=(localdb)\\mssqllocaldb;Connection Timeout=30;Command Timeout=30;Persist Security Info=False;TrustServerCertificate=True;Integrated Security=True;Initial Catalog=PokerHandDbTake2";


        var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseSqlServer(AppDbConnection)
               .Options;

        using var appDb = new AppDbContext(options); // Pass the configured options



        const int batchSize = 1000; // Adjust batch size as needed
        OneHandExt one;

      //  using var appDb = new Ovb3M7Db.Server.Data.AppDbContext();

        int totalRecords = await appDb.PokerHands.CountAsync();
        int processedRecords = 0;

        while (processedRecords < totalRecords)
        {
            var batch = await appDb.PokerHands
                .OrderBy(x => x.Id) // Ensure a stable order
                .Skip(processedRecords)
                .Take(batchSize)
                .ToListAsync();

            if (!batch.Any()) break; // Stop if no more records

            foreach (var x in batch)
            {
                one = new();
                var hand = x.PokerHandText;

                one.RawText = hand;
                await one.InitAsync();
                (bool result, decimal pot, decimal rakes) = one.TestFinalPot();

                string statusMessage = result ? "POT餘額正確!" : "POT餘額錯誤!";
                //Console.WriteLine($"範例 {x.Id} => {statusMessage} ({result:0.00}, {rakes:0.00}) ");
                //string statusMessage = result ? "POT餘額正確!" : "POT餘額錯誤!";
                ////Console.WriteLine($"範例 {x.Id} => {statusMessage} ({result:0.00}, {rakes:0.00}) ");
                Console.WriteLine($"範例 {x.Id} => {statusMessage} ({result}, {pot.ToString("0.00")}, {rakes.ToString("0.00")}) ");

                x.LastScenePot = pot;
                x.Rakes = rakes;
                x.Runtime = DateTime.Now;
            }

            // Save the batch and clear memory
            await appDb.SaveChangesAsync();
            processedRecords += batch.Count;

            Console.WriteLine($"Processed {processedRecords}/{totalRecords} records...");
        }

        Console.WriteLine("Processing completed.");
    }

    static async Task Main17()
    {




        OneHandExt one;

        for (int i = 1; i <= 18; i++)
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

        //not to close
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
}
