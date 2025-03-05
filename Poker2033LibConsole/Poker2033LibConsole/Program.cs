using Ovb3HandPwa.Client.Data;
using Poker2033.Hand;
using Poker2033Lib.Data;
using System;

class Program
{
    static async Task Main()
    {
        OneHandExt one = new();
        one.RawText = DevData.pokerHand7;
        await one.InitAsync();
    }
}
