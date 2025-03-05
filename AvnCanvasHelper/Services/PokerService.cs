namespace Ovb3HandPwa.Server.Services;


public class PokerService
{
    // The big hand history string:
    public string PokerHand => @"
Poker Hand #RC2129015124: Hold'em No Limit ($1/$2) - 2024/01/06 15:59:21
Table 'RushAndCash130384' 6-max Seat #1 is the button
Seat 1: a8b25666 ($200 in chips)
Seat 2: af9dcee9 ($174.1 in chips)
Seat 3: Hero ($200 in chips)
Seat 4: ff8f2fa ($206.35 in chips)
Seat 5: c9f5e922 ($129.91 in chips)
Seat 6: ba7fa506 ($345.17 in chips)
af9dcee9: posts small blind $1
Hero: posts big blind $2
...
*** SUMMARY ***
Total pot $127.52 | Rake $6
Board [6c 7d Kh Ks 5s]
Seat 1: a8b25666 (button) folded before Flop (didn't bet)
Seat 2: af9dcee9 (small blind) showed [Qs Qd] and won
Seat 3: Hero (big blind) folded before Flop
Seat 4: ff8f2fa folded before Flop
Seat 5: c9f5e922 folded before Flop (didn't bet)
Seat 6: ba7fa506 showed [Qh Ac] and lost
";

    // The 52-card deck list:
    public List<string> DeckList { get; } = new()
        {
            "As", "Ah", "Ad", "Ac", "Ks", "Kh", "Kd", "Kc",
            "Qs", "Qh", "Qd", "Qc", "Js", "Jh", "Jd", "Jc",
            "Ts", "Th", "Td", "Tc", "9s", "9h", "9d", "9c",
            "8s", "8h", "8d", "8c", "7s", "7h", "7d", "7c",
            "6s", "6h", "6d", "6c", "5s", "5h", "5d", "5c",
            "4s", "4h", "4d", "4c", "3s", "3h", "3d", "3c",
            "2s", "2h", "2d", "2c"
        };
}

