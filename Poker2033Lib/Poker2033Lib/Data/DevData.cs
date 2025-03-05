//namespace Ovb3HandPwa.Client.Data;
namespace Poker2033.Hand.Data;
public static class DevData
{
    public static string GetPokerHandByGameID(int gameID)
    {
        if (gameID == 1) return pokerHand1;
        if (gameID == 2) return pokerHand2;
        if (gameID == 3) return pokerHand3;
        if (gameID == 4) return pokerHand4;
        if (gameID == 5) return pokerHand5;
        if (gameID == 6) return pokerHand6;
        if (gameID == 7) return pokerHand7;
        if (gameID == 8) return pokerHand8;
        if (gameID == 9) return pokerHand9;
        if (gameID == 10) return pokerHand10;
        if (gameID == 11) return pokerHand11;
        if (gameID == 12) return pokerHand12;
        if (gameID == 13) return pokerHand13;
        if (gameID == 14) return pokerHand14;
        if (gameID == 15) return pokerHand15;
        if (gameID == 16) return pokerHand16;

        return pokerHand1;

    }
    // NOTE by Mark, 2025-02-26 10:23 將撲克牌背面定義 Xx
    public static List<string> deckList = new()
{
    "As", "Ah", "Ad", "Ac", "Ks", "Kh", "Kd", "Kc",
    "Qs", "Qh", "Qd", "Qc", "Js", "Jh", "Jd", "Jc",
    "Ts", "Th", "Td", "Tc", "9s", "9h", "9d", "9c",
    "8s", "8h", "8d", "8c", "7s", "7h", "7d", "7c",
    "6s", "6h", "6d", "6c", "5s", "5h", "5d", "5c",
    "4s", "4h", "4d", "4c", "3s", "3h", "3d", "3c",
    "2s", "2h", "2d", "2c", "Xx"
};
    public static string pokerHand { get { return pokerHand1; } }
    public static string pokerHand15 = @"
Poker Hand #HD1613464220: Hold'em No Limit ($2/$5) - 2024/01/30 21:56:02
Table 'NLHAPlatinum2' 9-max Seat #4 is the button
Seat 1: ab27a92 ($708.51 in chips)
Seat 2: efb0439 ($1,795.72 in chips)
Seat 3: 1a5d5b6e ($1,046.02 in chips)
Seat 4: Hero ($1,530.56 in chips)
Seat 5: 8db7e270 ($1,062.8 in chips)
Seat 6: 91224dca ($632.31 in chips)
Seat 7: ef6ad99f ($1,087.81 in chips)
Seat 8: 5fa4d0f0 ($2,055.48 in chips)
Seat 9: 327b5f75 ($1,372.3 in chips)
1a5d5b6e: posts the ante $2
5fa4d0f0: posts the ante $2
327b5f75: posts the ante $2
8db7e270: posts the ante $2
efb0439: posts the ante $2
ab27a92: posts the ante $2
Hero: posts the ante $2
ef6ad99f: posts the ante $2
91224dca: posts the ante $2
8db7e270: posts small blind $2
91224dca: posts big blind $5
*** HOLE CARDS ***
Dealt to ab27a92 
Dealt to efb0439 
Dealt to 1a5d5b6e 
Dealt to Hero [Kh Kd]
Dealt to 8db7e270 
Dealt to 91224dca 
Dealt to ef6ad99f 
Dealt to 5fa4d0f0 
Dealt to 327b5f75 
ef6ad99f: folds
5fa4d0f0: folds
327b5f75: folds
ab27a92: raises $10 to $15
efb0439: folds
1a5d5b6e: raises $45 to $60
Hero: raises $68 to $128
8db7e270: folds
91224dca: folds
ab27a92: folds
1a5d5b6e: calls $68
*** FLOP *** [Jc Jh 9s]
1a5d5b6e: checks
Hero: bets $74
1a5d5b6e: raises $86 to $160
Hero: calls $86
*** TURN *** [Jc Jh 9s] [Ad]
1a5d5b6e: checks
Hero: bets $62
1a5d5b6e: calls $62
*** RIVER *** [Jc Jh 9s Ad] [Tc]
1a5d5b6e: checks
Hero: checks
1a5d5b6e: shows [Qh Qc] (Pair of Queens and Pair of Jacks)
Hero: shows [Kh Kd] (Pair of Kings and Pair of Jacks)
*** SHOWDOWN ***
Hero collected $728 from pot
*** SUMMARY ***
Total pot $740 | Rake $8 | Jackpot $4 | Bingo $0 | Fortune $0 | Tax $0
Board [Jc Jh 9s Ad Tc]
Seat 1: ab27a92 folded before Flop
Seat 2: efb0439 folded before Flop
Seat 3: 1a5d5b6e showed [Qh Qc] and lost with Pair of Queens and Pair of Jacks
Seat 4: Hero (button) showed [Kh Kd] and won ($728) with Pair of Kings and Pair of Jacks
Seat 5: 8db7e270 (small blind) folded before Flop
Seat 6: 91224dca (big blind) folded before Flop
Seat 7: ef6ad99f folded before Flop
Seat 8: 5fa4d0f0 folded before Flop
Seat 9: 327b5f75 folded before Flop


";
    public static string pokerHand16 = @"
Poker Hand #HD1613478899: Hold'em No Limit ($2/$5) - 2024/01/30 21:29:01
Table 'NLHAPlatinum6' 9-max Seat #2 is the button
Seat 1: 77fef0f6 ($1,000 in chips)
Seat 2: 1fa5fec0 ($1,034.1 in chips)
Seat 3: fb51de23 ($1,147.14 in chips)
Seat 5: Hero ($2,024.66 in chips)
Seat 6: 1a116023 ($185.46 in chips)
Seat 8: 9a0300d8 ($1,086.3 in chips)
Seat 9: c74eed01 ($347.72 in chips)
fb51de23: posts the ante $2
9a0300d8: posts the ante $2
c74eed01: posts the ante $2
1fa5fec0: posts the ante $2
Hero: posts the ante $2
77fef0f6: posts the ante $2
1a116023: posts the ante $2
fb51de23: posts small blind $2
Hero: posts big blind $5
*** HOLE CARDS ***
Dealt to 77fef0f6 
Dealt to 1fa5fec0 
Dealt to fb51de23 
Dealt to Hero [9d Ac]
Dealt to 1a116023 
Dealt to 9a0300d8 
Dealt to c74eed01 
1a116023: calls $5
9a0300d8: folds
c74eed01: folds
77fef0f6: folds
1fa5fec0: folds
fb51de23: folds
Hero: checks
*** FLOP *** [8h 5h 6d]
Hero: checks
1a116023: checks
*** TURN *** [8h 5h 6d] [2h]
Hero: checks
1a116023: checks
*** RIVER *** [8h 5h 6d 2h] [7s]
Hero: bets $19.5
1a116023: folds
Uncalled bet ($19.5) returned to Hero
*** SHOWDOWN ***
Hero collected $24.7 from pot
*** SUMMARY ***
Total pot $26 | Rake $1.3 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Board [8h 5h 6d 2h 7s]
Seat 1: 77fef0f6 folded before Flop
Seat 2: 1fa5fec0 (button) folded before Flop
Seat 3: fb51de23 (small blind) folded before Flop
Seat 5: Hero (big blind) won ($24.7)
Seat 6: 1a116023 folded on the River
Seat 8: 9a0300d8 folded before Flop
Seat 9: c74eed01 folded before Flop


";


    public static string pokerHand14 = @"
Poker Hand #RC2144222917: Hold'em No Limit ($1/$2) - 2024/01/10 11:57:19
Table 'RushAndCash638177' 6-max Seat #1 is the button
Seat 1: 4cacd4e7 ($327.58 in chips)
Seat 2: 622cae43 ($212.2 in chips)
Seat 3: a3e68cdb ($184 in chips)
Seat 4: f5bc2b5d ($200 in chips)
Seat 5: bd907983 ($227.02 in chips)
Seat 6: Hero ($311.11 in chips)
622cae43: posts small blind $1
a3e68cdb: posts big blind $2
*** HOLE CARDS ***
Dealt to 4cacd4e7 
Dealt to 622cae43 
Dealt to a3e68cdb 
Dealt to f5bc2b5d 
Dealt to bd907983 
Dealt to Hero [Ts Qs]
f5bc2b5d: folds
bd907983: folds
Hero: raises $2.4 to $4.4
4cacd4e7: folds
622cae43: raises $17.6 to $22
a3e68cdb: calls $20
Hero: calls $17.6
*** FLOP *** [5d 4h 3h]
622cae43: checks
a3e68cdb: bets $33
Hero: folds
622cae43: raises $157.2 to $190.2 and is all-in
a3e68cdb: calls $129 and is all-in
Uncalled bet ($28.2) returned to 622cae43
622cae43: shows [Ah As] (Pair of Aces)
a3e68cdb: shows [Js Jh] (Pair of Jacks)
*** FIRST TURN *** [5d 4h 3h] [4c]
*** FIRST RIVER *** [5d 4h 3h 4c] [8h]
*** SECOND TURN *** [5d 4h 3h] [Kd]
*** SECOND RIVER *** [5d 4h 3h Kd] [6d]
*** THIRD TURN *** [5d 4h 3h] [8c]
*** THIRD RIVER *** [5d 4h 3h 8c] [9s]
*** FIRST SHOWDOWN ***
622cae43 collected $127 from pot
*** SECOND SHOWDOWN ***
622cae43 collected $127 from pot
*** THIRD SHOWDOWN ***
622cae43 collected $127 from pot
*** SUMMARY ***
Total pot $390 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
Hand was run three times
FIRST Board [5d 4h 3h 4c 8h]
SECOND Board [Kd 6d]
THIRD Board [8c 9s]
Seat 1: 4cacd4e7 (button) folded before Flop (didn't bet)
Seat 2: 622cae43 (small blind) showed [Ah As] and won ($127) with Pair of Aces and Pair of Fours, and won ($127), and won ($127)
Seat 3: a3e68cdb (big blind) showed [Js Jh] and lost with Pair of Jacks and Pair of Fours, and lost, and lost
Seat 4: f5bc2b5d folded before Flop (didn't bet)
Seat 5: bd907983 folded before Flop (didn't bet)
Seat 6: Hero folded on the Flop



";
    public static string pokerHand12 = @"
Poker Hand #RC2128756022: Hold'em No Limit ($1/$2) - 2024/01/06 14:39:06
Table 'RushAndCash121282' 6-max Seat #1 is the button
Seat 1: 3496358a ($205.4 in chips)
Seat 2: bbd57c2 ($291.82 in chips)
Seat 3: 61a6afbb ($292.58 in chips)
Seat 4: 602a4f21 ($354.77 in chips)
Seat 5: 78ffc26c ($203.5 in chips)
Seat 6: Hero ($218.98 in chips)
bbd57c2: posts small blind $1
61a6afbb: posts big blind $2
*** HOLE CARDS ***
Dealt to 3496358a 
Dealt to bbd57c2 
Dealt to 61a6afbb 
Dealt to 602a4f21 
Dealt to 78ffc26c 
Dealt to Hero [6s 5s]
602a4f21: folds
78ffc26c: folds
Hero: raises $2 to $4
3496358a: folds
bbd57c2: calls $3
61a6afbb: raises $20 to $24
Hero: calls $20
bbd57c2: calls $20
*** FLOP *** [Ks Js 5h]
bbd57c2: checks
61a6afbb: bets $36
Hero: calls $36
bbd57c2: folds
*** TURN *** [Ks Js 5h] [7d]
61a6afbb: bets $172.8
Hero: calls $158.98 and is all-in
Uncalled bet ($13.82) returned to 61a6afbb
61a6afbb: shows [As Ah] (Pair of Aces)
Hero: shows [6s 5s] (Pair of Fives)
*** RIVER *** [Ks Js 5h 7d] [4c]
*** SHOWDOWN ***
61a6afbb collected $452.96 from pot
*** SUMMARY ***
Total pot $461.96 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
Board [Ks Js 5h 7d 4c]
Seat 1: 3496358a (button) folded before Flop (didn't bet)
Seat 2: bbd57c2 (small blind) folded on the Flop
Seat 3: 61a6afbb (big blind) showed [As Ah] and won ($452.96) with Pair of Aces
Seat 4: 602a4f21 folded before Flop (didn't bet)
Seat 5: 78ffc26c folded before Flop (didn't bet)
Seat 6: Hero showed [6s 5s] and lost with Pair of Fives
";


    public static string pokerHand11 = @"
Poker Hand #RC2128763767: Hold'em No Limit ($1/$2) - 2024/01/06 15:46:42
Table 'RushAndCash129027' 6-max Seat #1 is the button
Seat 1: 4bc55b45 ($200 in chips)
Seat 2: 706345bf ($161 in chips)
Seat 3: 6e15b0e7 ($311.41 in chips)
Seat 4: Hero ($246.35 in chips)
Seat 5: 1082fc09 ($804.87 in chips)
Seat 6: 77e9398b ($200 in chips)
706345bf: posts small blind $1
6e15b0e7: posts big blind $2
*** HOLE CARDS ***
Dealt to 4bc55b45 
Dealt to 706345bf 
Dealt to 6e15b0e7 
Dealt to Hero [8d 7d]
Dealt to 1082fc09 
Dealt to 77e9398b 
Hero: raises $2 to $4
1082fc09: folds
77e9398b: folds
4bc55b45: folds
706345bf: folds
6e15b0e7: calls $2
*** FLOP *** [5c 7s 2h]
6e15b0e7: checks
Hero: bets $2.97
6e15b0e7: raises $12.03 to $15
Hero: calls $12.03
*** TURN *** [5c 7s 2h] [4h]
6e15b0e7: bets $59
Hero: calls $59
*** RIVER *** [5c 7s 2h 4h] [4s]
6e15b0e7: bets $233.41 and is all-in
Hero: folds
Uncalled bet ($233.41) returned to 6e15b0e7
*** SHOWDOWN ***
6e15b0e7 collected $148 from pot
*** SUMMARY ***
Total pot $157 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
Board [5c 7s 2h 4h 4s]
Seat 1: 4bc55b45 (button) folded before Flop (didn't bet)
Seat 2: 706345bf (small blind) folded before Flop
Seat 3: 6e15b0e7 (big blind) won ($148)
Seat 4: Hero folded on the River
Seat 5: 1082fc09 folded before Flop (didn't bet)
Seat 6: 77e9398b folded before Flop (didn't bet)";
    public static string pokerHand9 = @"
Poker Hand #HD1588420620: Hold'em No Limit ($5/$10) - 2024/01/15 17:11:02
Table 'NLHDiamond7' 6-max Seat #4 is the button
Seat 1: 70e7208 ($1,000 in chips)
Seat 2: 56dea9ba ($315 in chips)
Seat 3: Hero ($1,166.25 in chips)
Seat 4: e13f385a ($1,069.98 in chips)
Seat 5: 676c1f56 ($1,010.2 in chips)
Seat 6: f31c22e3 ($1,037 in chips)
676c1f56: posts small blind $5
f31c22e3: posts big blind $10
*** HOLE CARDS ***
Dealt to 70e7208 
Dealt to 56dea9ba 
Dealt to Hero [Ks Ac]
Dealt to e13f385a 
Dealt to 676c1f56 
Dealt to f31c22e3 
70e7208: folds
56dea9ba: folds
Hero: raises $12 to $22
e13f385a: folds
676c1f56: folds
f31c22e3: calls $12
*** FLOP *** [Jd 2d 3h]
f31c22e3: checks
Hero: bets $12.74
f31c22e3: raises $55.86 to $68.6
Hero: folds
Uncalled bet ($55.86) returned to f31c22e3
*** SHOWDOWN ***
f31c22e3 collected $70.76 from pot
*** SUMMARY ***
Total pot $74.48 | Rake $3.72 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Board [Jd 2d 3h]
Seat 1: 70e7208 folded before Flop (didn't bet)
Seat 2: 56dea9ba folded before Flop (didn't bet)
Seat 3: Hero folded on the Flop
Seat 4: e13f385a (button) folded before Flop (didn't bet)
Seat 5: 676c1f56 (small blind) folded before Flop
Seat 6: f31c22e3 (big blind) won ($70.76)




";
    // BUG no seat 2
    public static string pokerHand10 = @"
Poker Hand #HD1588355252: Hold'em No Limit ($5/$10) - 2024/01/15 17:10:15
Table 'NLHDiamond9' 6-max Seat #4 is the button
Seat 1: 5f756b29 ($1,401.53 in chips)
Seat 3: b0a935 ($2,001.85 in chips)
Seat 4: e912847e ($1,000 in chips)
Seat 5: 2147c37c ($1,140.5 in chips)
Seat 6: Hero ($1,114 in chips)
2147c37c: posts small blind $5
Hero: posts big blind $10
*** HOLE CARDS ***
Dealt to 5f756b29 
Dealt to b0a935 
Dealt to e912847e 
Dealt to 2147c37c 
Dealt to Hero [Jc 7c]
5f756b29: folds
b0a935: folds
e912847e: folds
2147c37c: raises $20 to $30
Hero: calls $20
*** FLOP *** [3h 6d Td]
2147c37c: checks
Hero: checks
*** TURN *** [3h 6d Td] [3d]
2147c37c: bets $19.8
Hero: raises $49.8 to $69.6
2147c37c: folds
Uncalled bet ($49.8) returned to Hero
*** SHOWDOWN ***
Hero collected $94.62 from pot
*** SUMMARY ***
Total pot $99.6 | Rake $4.98 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Board [3h 6d Td 3d]
Seat 1: 5f756b29 folded before Flop (didn't bet)
Seat 3: b0a935 folded before Flop (didn't bet)
Seat 4: e912847e (button) folded before Flop (didn't bet)
Seat 5: 2147c37c (small blind) folded on the Turn
Seat 6: Hero (big blind) won ($94.62)




";
    public static string pokerHand8 = @"
Poker Hand #HD1588555956: Hold'em No Limit ($5/$10) - 2024/01/15 18:25:55
Table 'NLHDiamond1' 6-max Seat #6 is the button
Seat 1: 358af00b ($1,128.3 in chips)
Seat 2: 5ec67920 ($1,714.34 in chips)
Seat 3: Hero ($1,029.3 in chips)
Seat 4: 7fff82f5 ($1,807.47 in chips)
Seat 5: dda1ba15 ($584.12 in chips)
Seat 6: 4c0b8a40 ($1,250.5 in chips)
358af00b: posts small blind $5
5ec67920: posts big blind $10
*** HOLE CARDS ***
Dealt to 358af00b 
Dealt to 5ec67920 
Dealt to Hero [Jh Ad]
Dealt to 7fff82f5 
Dealt to dda1ba15 
Dealt to 4c0b8a40 
Hero: raises $10 to $20
7fff82f5: folds
dda1ba15: folds
4c0b8a40: folds
358af00b: folds
5ec67920: folds
Uncalled bet ($10) returned to Hero
*** SHOWDOWN ***
Hero collected $25 from pot
*** SUMMARY ***
Total pot $25 | Rake $0 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Seat 1: 358af00b (small blind) folded before Flop
Seat 2: 5ec67920 (big blind) folded before Flop
Seat 3: Hero collected ($25)
Seat 4: 7fff82f5 folded before Flop (didn't bet)
Seat 5: dda1ba15 folded before Flop (didn't bet)
Seat 6: 4c0b8a40 (button) folded before Flop (didn't bet)


";

    // BUG, chip 有千元,時 FIXED
    // all-in, 欠處理, 是在同一條街的叫牌, 之前的不能重複累計!!! MARKTODO
    public static string pokerHand7 = @"
Poker Hand #HD1588448539: Hold'em No Limit ($5/$10) - 2024/01/15 17:16:19
Table 'NLHDiamond1' 6-max Seat #5 is the button
Seat 1: d1036a42 ($395.97 in chips)
Seat 2: 5ec67920 ($1,015 in chips)
Seat 3: Hero ($1,583 in chips)
Seat 4: 33b914b4 ($916.83 in chips)
Seat 5: 3860cf77 ($1,136.13 in chips)
Seat 6: 8fec63a6 ($1,039.36 in chips)
8fec63a6: posts small blind $5
d1036a42: posts big blind $10
*** HOLE CARDS ***
Dealt to d1036a42 
Dealt to 5ec67920 
Dealt to Hero [Qs Ks]
Dealt to 33b914b4 
Dealt to 3860cf77 
Dealt to 8fec63a6 
5ec67920: folds
Hero: raises $15 to $25
33b914b4: folds
3860cf77: calls $25
8fec63a6: folds
d1036a42: raises $80 to $105
Hero: calls $80
3860cf77: raises $1,031.13 to $1,136.13 and is all-in
d1036a42: calls $290.97 and is all-in
Hero: folds
Uncalled bet ($740.16) returned to 3860cf77
3860cf77: shows [Th Ts]
d1036a42: shows [7c 7h]
*** FLOP *** [4h Ad 2c]
*** TURN *** [4h Ad 2c] [5s]
*** RIVER *** [4h Ad 2c 5s] [8d]
*** SHOWDOWN ***
3860cf77 collected $881.94 from pot
*** SUMMARY ***
Total pot $901.94 | Rake $10 | Jackpot $10 | Bingo $0 | Fortune $0 | Tax $0
Board [4h Ad 2c 5s 8d]
Seat 1: d1036a42 (big blind) showed [7c 7h] and lost with Pair of Sevens
Seat 2: 5ec67920 folded before Flop (didn't bet)
Seat 3: Hero folded before Flop
Seat 4: 33b914b4 folded before Flop (didn't bet)
Seat 5: 3860cf77 (button) showed [Th Ts] and won ($881.94) with Pair of Tens
Seat 6: 8fec63a6 (small blind) folded before Flop


";
    // BUG , 沒有 Seat 4
    public static string BUGpokerHand7 = @"
Poker Hand #HD1588143547: Hold'em No Limit ($2/$5) - 2024/01/15 12:37:18
Table 'NLHPlatinum1' 6-max Seat #5 is the button
Seat 1: 130aafc0 ($547.2 in chips)
Seat 2: 9ebc1b01 ($558.87 in chips)
Seat 3: 716e616 ($208.18 in chips)
Seat 5: Hero ($553.29 in chips)
Seat 6: d6c60663 ($556.06 in chips)
d6c60663: posts small blind $2
130aafc0: posts big blind $5
*** HOLE CARDS ***
Dealt to 130aafc0 
Dealt to 9ebc1b01 
Dealt to 716e616 
Dealt to Hero [6d 7d]
Dealt to d6c60663 
9ebc1b01: folds
716e616: folds
Hero: raises $7.5 to $12.5
d6c60663: calls $10.5
130aafc0: folds
*** FLOP *** [Kc Qd Ad]
d6c60663: checks
Hero: bets $7.8
d6c60663: folds
Uncalled bet ($7.8) returned to Hero
*** SHOWDOWN ***
Hero collected $28.5 from pot
*** SUMMARY ***
Total pot $30 | Rake $1.5 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Board [Kc Qd Ad]
Seat 1: 130aafc0 (big blind) folded before Flop
Seat 2: 9ebc1b01 folded before Flop (didn't bet)
Seat 3: 716e616 folded before Flop (didn't bet)
Seat 5: Hero (button) won ($28.5)
Seat 6: d6c60663 (small blind) folded on the Flop
";

    public static string pokerHand6 = @"
Poker Hand #HD1588169101: Hold'em No Limit ($2/$5) - 2024/01/15 12:39:16
Table 'NLHPlatinum11' 6-max Seat #4 is the button
Seat 1: 8ea6425a ($595.42 in chips)
Seat 2: f4cd7f7c ($367.99 in chips)
Seat 3: e3874313 ($944.41 in chips)
Seat 4: Hero ($518.96 in chips)
Seat 5: dfe02cbf ($502 in chips)
Seat 6: ed66cb39 ($525.8 in chips)
dfe02cbf: posts small blind $2
ed66cb39: posts big blind $5
*** HOLE CARDS ***
Dealt to 8ea6425a 
Dealt to f4cd7f7c 
Dealt to e3874313 
Dealt to Hero [Ac 6c]
Dealt to dfe02cbf 
Dealt to ed66cb39 
8ea6425a: folds
f4cd7f7c: folds
e3874313: raises $7.5 to $12.5
Hero: raises $25.5 to $38
dfe02cbf: folds
ed66cb39: folds
e3874313: calls $25.5
*** FLOP *** [Qh Td 8h]
e3874313: checks
Hero: bets $21.58
e3874313: folds
Uncalled bet ($21.58) returned to Hero
*** SHOWDOWN ***
Hero collected $78.85 from pot
*** SUMMARY ***
Total pot $83 | Rake $4.15 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Board [Qh Td 8h]
Seat 1: 8ea6425a folded before Flop (didn't bet)
Seat 2: f4cd7f7c folded before Flop (didn't bet)
Seat 3: e3874313 folded on the Flop
Seat 4: Hero (button) won ($78.85)
Seat 5: dfe02cbf (small blind) folded before Flop
Seat 6: ed66cb39 (big blind) folded before Flop


";
    //BUG 初始 chips 沒能解析到
    public static string BUGpokerHand6 = @"
Poker Hand #HD1586442750: Hold'em No Limit ($5/$10) - 2024/01/14 11:10:47
Table 'NLHDiamond5' 6-max Seat #4 is the button
Seat 1: 1fcc56ee ($242.65 in chips)
Seat 2: 71d05739 ($564.05 in chips)
Seat 3: e6028eb1 ($1,074.25 in chips)
Seat 4: d97af948 ($1,020.19 in chips)
Seat 5: Hero ($1,125.76 in chips)
Seat 6: 17fa2c64 ($3,290.39 in chips)
Hero: posts small blind $5
17fa2c64: posts big blind $10
*** HOLE CARDS ***
Dealt to 1fcc56ee 
Dealt to 71d05739 
Dealt to e6028eb1 
Dealt to d97af948 
Dealt to Hero [8s 8c]
Dealt to 17fa2c64 
1fcc56ee: folds
71d05739: folds
e6028eb1: raises $13 to $23
d97af948: folds
Hero: raises $77 to $100
17fa2c64: folds
e6028eb1: raises $135 to $235
Hero: calls $135
*** FLOP *** [8d Ac 3c]
Hero: checks
e6028eb1: bets $100
Hero: raises $110 to $210
e6028eb1: calls $110
*** TURN *** [8d Ac 3c] [4d]
Hero: bets $200
e6028eb1: calls $200
*** RIVER *** [8d Ac 3c 4d] [4s]
Hero: bets $480.76 and is all-in
e6028eb1: folds
Uncalled bet ($480.76) returned to Hero
*** SHOWDOWN ***
Hero collected $1,280 from pot
*** SUMMARY ***
Total pot $1,300 | Rake $10 | Jackpot $10 | Bingo $0 | Fortune $0 | Tax $0
Board [8d Ac 3c 4d 4s]
Seat 1: 1fcc56ee folded before Flop (didn't bet)
Seat 2: 71d05739 folded before Flop (didn't bet)
Seat 3: e6028eb1 folded on the River
Seat 4: d97af948 (button) folded before Flop (didn't bet)
Seat 5: Hero (small blind) won ($1,280)
Seat 6: 17fa2c64 (big blind) folded before Flop




";

    /// <summary>
    /// 3019
    /// </summary>
    public static string pokerHand1 = @"
Poker Hand #RC2144220710: Hold'em No Limit ($1/$2) - 2024/01/10 11:29:20
Table 'RushAndCash635970' 6-max Seat #1 is the button
Seat 1: c8fb1124 ($233.09 in chips)
Seat 2: 795296c7 ($229.2 in chips)
Seat 3: 97f042a4 ($215.94 in chips)
Seat 4: 75ec1730 ($236 in chips)
Seat 5: Hero ($247.29 in chips)
Seat 6: 347609c5 ($200 in chips)
795296c7: posts small blind $1
97f042a4: posts big blind $2
*** HOLE CARDS ***
Dealt to c8fb1124 
Dealt to 795296c7 
Dealt to 97f042a4 
Dealt to 75ec1730 
Dealt to Hero [As Kc]
Dealt to 347609c5 
75ec1730: folds
Hero: raises $2 to $4
347609c5: folds
c8fb1124: raises $10 to $14
795296c7: raises $29.5 to $43.5
97f042a4: folds
Hero: raises $203.79 to $247.29 and is all-in
c8fb1124: folds
795296c7: calls $185.7 and is all-in
Uncalled bet ($18.09) returned to Hero
Hero: shows [As Kc]
795296c7: shows [Js Jc]
*** FLOP *** [2s 3s Qd]
*** TURN *** [2s 3s Qd] [9s]
*** RIVER *** [2s 3s Qd 9s] [4s]
*** SHOWDOWN ***
Hero collected $465.4 from pot
*** SUMMARY ***
Total pot $474.4 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
Board [2s 3s Qd 9s 4s]
Seat 1: c8fb1124 (button) folded before Flop
Seat 2: 795296c7 (small blind) showed [Js Jc] and lost with Jack High Flush
Seat 3: 97f042a4 (big blind) folded before Flop
Seat 4: 75ec1730 folded before Flop (didn't bet)
Seat 5: Hero showed [As Kc] and won ($465.4) with Ace High Flush
Seat 6: 347609c5 folded before Flop (didn't bet)


";


    /// <summary>
    /// 抽水不完整?
    /// </summary>
    public static string BUGpokerHand1 = @"
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
*** HOLE CARDS ***
Dealt to a8b25666
Dealt to af9dcee9
Dealt to Hero [9d Ah]
Dealt to ff8f2fa
Dealt to c9f5e922
Dealt to ba7fa506
ff8f2fa: raises $4 to $6
c9f5e922: folds
ba7fa506: raises $11.25 to $17.25
a8b25666: folds
af9dcee9: calls $16.25
Hero: folds
ff8f2fa: folds
*** FLOP *** [6c 7d Kh]
af9dcee9: checks
ba7fa506: bets $10.63
af9dcee9: calls $10.63
*** TURN *** [6c 7d Kh] [Ks]
af9dcee9: checks
ba7fa506: bets $31.88
af9dcee9: calls $31.88
*** RIVER *** [6c 7d Kh Ks] [5s]
af9dcee9: checks
ba7fa506: checks
af9dcee9: shows [Qs Qd] (Pair of Kings and Pair of Queens)
ba7fa506: shows [Qh Ac] (Pair of Kings)
*** SHOWDOWN ***
af9dcee9 collected $118.52 from pot
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

    public static string pokerHand2 = @"
Poker Hand #RC2128756022: Hold'em No Limit ($1/$2) - 2024/01/06 14:39:06
Table 'RushAndCash121282' 6-max Seat #1 is the button
Seat 1: 3496358a ($205.4 in chips)
Seat 2: bbd57c2 ($291.82 in chips)
Seat 3: 61a6afbb ($292.58 in chips)
Seat 4: 602a4f21 ($354.77 in chips)
Seat 5: 78ffc26c ($203.5 in chips)
Seat 6: Hero ($218.98 in chips)
bbd57c2: posts small blind $1
61a6afbb: posts big blind $2
*** HOLE CARDS ***
Dealt to 3496358a 
Dealt to bbd57c2 
Dealt to 61a6afbb 
Dealt to 602a4f21 
Dealt to 78ffc26c 
Dealt to Hero [6s 5s]
602a4f21: folds
78ffc26c: folds
Hero: raises $2 to $4
3496358a: folds
bbd57c2: calls $3
61a6afbb: raises $20 to $24
Hero: calls $20
bbd57c2: calls $20
*** FLOP *** [Ks Js 5h]
bbd57c2: checks
61a6afbb: bets $36
Hero: calls $36
bbd57c2: folds
*** TURN *** [Ks Js 5h] [7d]
61a6afbb: bets $172.8
Hero: calls $158.98 and is all-in
Uncalled bet ($13.82) returned to 61a6afbb
61a6afbb: shows [As Ah] (Pair of Aces)
Hero: shows [6s 5s] (Pair of Fives)
*** RIVER *** [Ks Js 5h 7d] [4c]
*** SHOWDOWN ***
61a6afbb collected $452.96 from pot
*** SUMMARY ***
Total pot $461.96 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
Board [Ks Js 5h 7d 4c]
Seat 1: 3496358a (button) folded before Flop (didn't bet)
Seat 2: bbd57c2 (small blind) folded on the Flop
Seat 3: 61a6afbb (big blind) showed [As Ah] and won ($452.96) with Pair of Aces
Seat 4: 602a4f21 folded before Flop (didn't bet)
Seat 5: 78ffc26c folded before Flop (didn't bet)
Seat 6: Hero showed [6s 5s] and lost with Pair of Fives
";
    public static string pokerHand3 = @"
Poker Hand #RC2435502498: Hold'em No Limit ($1/$2) - 2024/04/08 14:45:12
Table 'RushAndCash1147758' 6-max Seat #1 is the button
Seat 1: 5d6d867c ($206.55 in chips)
Seat 2: Hero ($769.17 in chips)
Seat 3: a12f3e0 ($599.56 in chips)
Seat 4: 7548ccdb ($170.61 in chips)
Seat 5: e37156d5 ($200.55 in chips)
Seat 6: 57f3ab76 ($189.89 in chips)
Hero: posts small blind $1
a12f3e0: posts big blind $2
*** HOLE CARDS ***
Dealt to 5d6d867c 
Dealt to Hero [Js Jh]
Dealt to a12f3e0 
Dealt to 7548ccdb 
Dealt to e37156d5 
Dealt to 57f3ab76 
7548ccdb: folds
e37156d5: folds
57f3ab76: folds
5d6d867c: folds
Hero: raises $4 to $6
a12f3e0: raises $11.76 to $17.76
Hero: calls $11.76
*** FLOP *** [5s 7s 9h]
Hero: checks
a12f3e0: bets $19
Hero: calls $19
*** TURN *** [5s 7s 9h] [6s]
Hero: bets $16
a12f3e0: calls $16
*** RIVER *** [5s 7s 9h 6s] [5d]
Hero: bets $10.6
a12f3e0: calls $10.6
Hero: shows [Js Jh] (Pair of Jacks and Pair of Fives)
a12f3e0: shows [Jd 8c] (Nines-High Straight)
*** SHOWDOWN ***
a12f3e0 collected $117.72 from pot
*** SUMMARY ***
Total pot $126.72 | Rake $6 | Jackpot $3 | Bingo $0 | Fortune $0 | Tax $0
Board [5s 7s 9h 6s 5d]
Seat 1: 5d6d867c (button) folded before Flop (didn't bet)
Seat 2: Hero (small blind) showed [Js Jh] and lost with Pair of Jacks and Pair of Fives
Seat 3: a12f3e0 (big blind) showed [Jd 8c] and won ($117.72) with Nines-High Straight
Seat 4: 7548ccdb folded before Flop (didn't bet)
Seat 5: e37156d5 folded before Flop (didn't bet)
Seat 6: 57f3ab76 folded before Flop (didn't bet)

";
    public static string pokerHand5 = @"
Poker Hand #HD1586443134: Hold'em No Limit ($5/$10) - 2024/01/14 11:16:45
Table 'NLHDiamond5' 6-max Seat #3 is the button
Seat 1: 1fcc56ee ($343.78 in chips)
Seat 2: 71d05739 ($724.05 in chips)
Seat 3: e6028eb1 ($1,000 in chips)
Seat 4: d97af948 ($1,000 in chips)
Seat 5: Hero ($1,760.76 in chips)
Seat 6: 17fa2c64 ($3,279.89 in chips)
d97af948: posts small blind $5
Hero: posts big blind $10
*** HOLE CARDS ***
Dealt to 1fcc56ee 
Dealt to 71d05739 
Dealt to e6028eb1 
Dealt to d97af948 
Dealt to Hero [Tc Jd]
Dealt to 17fa2c64 
17fa2c64: raises $12 to $22
1fcc56ee: folds
71d05739: folds
e6028eb1: folds
d97af948: folds
Hero: calls $12
*** FLOP *** [9h 8d 7h]
Hero: checks
17fa2c64: checks
*** TURN *** [9h 8d 7h] [6h]
Hero: bets $36.75
17fa2c64: calls $36.75
*** RIVER *** [9h 8d 7h 6h] [Qh]
Hero: bets $20
17fa2c64: calls $20
Hero: shows [Tc Jd] (Queens-High Straight)
17fa2c64: shows [Jh Jc] (Queen High Flush)
*** SHOWDOWN ***
17fa2c64 collected $154.38 from pot
*** SUMMARY ***
Total pot $162.5 | Rake $8.12 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Board [9h 8d 7h 6h Qh]
Seat 1: 1fcc56ee folded before Flop (didn't bet)
Seat 2: 71d05739 folded before Flop (didn't bet)
Seat 3: e6028eb1 (button) folded before Flop (didn't bet)
Seat 4: d97af948 (small blind) folded before Flop
Seat 5: Hero (big blind) showed [Tc Jd] and lost with Queens-High Straight
Seat 6: 17fa2c64 showed [Jh Jc] and won ($154.38) with Queen High Flush



";

    public static string pokerHand4 = @"
Poker Hand #HD1586445049: Hold'em No Limit ($5/$10) - 2024/01/14 11:45:55
Table 'NLHDiamond5' 6-max Seat #2 is the button
Seat 1: acebb6de ($1,167.7 in chips)
Seat 2: 7ca93b36 ($1,032.5 in chips)
Seat 3: 51877394 ($950 in chips)
Seat 4: d97af948 ($1,000 in chips)
Seat 5: Hero ($2,308.59 in chips)
Seat 6: 17fa2c64 ($4,629.74 in chips)
51877394: posts small blind $5
d97af948: posts big blind $10
*** HOLE CARDS ***
Dealt to acebb6de 
Dealt to 7ca93b36 
Dealt to 51877394 
Dealt to d97af948 
Dealt to Hero [Td 9c]
Dealt to 17fa2c64 
Hero: folds
17fa2c64: folds
acebb6de: folds
7ca93b36: folds
51877394: calls $5
d97af948: raises $25 to $35
51877394: calls $25
*** FLOP *** [6s Ts Js]
51877394: bets $35
d97af948: folds
Uncalled bet ($35) returned to 51877394
*** SHOWDOWN ***
51877394 collected $66.5 from pot
*** SUMMARY ***
Total pot $70 | Rake $3.5 | Jackpot $0 | Bingo $0 | Fortune $0 | Tax $0
Board [6s Ts Js]
Seat 1: acebb6de folded before Flop (didn't bet)
Seat 2: 7ca93b36 (button) folded before Flop (didn't bet)
Seat 3: 51877394 (small blind) won ($66.5)
Seat 4: d97af948 (big blind) folded on the Flop
Seat 5: Hero folded before Flop (didn't bet)
Seat 6: 17fa2c64 folded before Flop (didn't bet)



";

    public static string pokerHand13 = @"

Poker Hand #HD1605201605: Hold'em No Limit ($5/$10) - 2024/01/25 15:15:39
Table 'NLHDiamond3' 6-max Seat #4 is the button
Seat 1: c442e6a ($2,322.98 in chips)
Seat 2: 5198f441 ($2,395.49 in chips)
Seat 3: fb4d4e4c ($513.28 in chips)
Seat 4: a938f366 ($3,037.39 in chips)
Seat 5: 3b814cc ($1,005 in chips)
Seat 6: Hero ($2,389.95 in chips)
3b814cc: posts small blind $5
Hero: posts big blind $10
*** HOLE CARDS ***
Dealt to c442e6a 
Dealt to 5198f441 
Dealt to fb4d4e4c 
Dealt to a938f366 
Dealt to 3b814cc 
Dealt to Hero [Jh Jd]
c442e6a: folds
5198f441: folds
fb4d4e4c: folds
a938f366: folds
3b814cc: raises $20 to $30
Hero: raises $60 to $90
3b814cc: raises $120 to $210
Hero: raises $2,179.95 to $2,389.95 and is all-in
3b814cc: calls $795 and is all-in
Uncalled bet ($1,384.95) returned to Hero
Hero: shows [Jh Jd]
3b814cc: shows [Kd Ac]
*** FIRST FLOP *** [5s Js 8h]
*** FIRST TURN *** [5s Js 8h] [5d]
*** FIRST RIVER *** [5s Js 8h 5d] [7s]
*** SECOND FLOP *** [Ts Qc Kc]
*** SECOND TURN *** [Ts Qc Kc] [6d]
*** SECOND RIVER *** [Ts Qc Kc 6d] [4d]
*** FIRST SHOWDOWN ***
Hero collected $995 from pot
*** SECOND SHOWDOWN ***
3b814cc collected $995 from pot
*** SUMMARY ***
Total pot $2,010 | Rake $10 | Jackpot $10 | Bingo $0 | Fortune $0 | Tax $0
Hand was run two times
FIRST Board [5s Js 8h 5d 7s]
SECOND Board [Ts Qc Kc 6d 4d]
Seat 1: c442e6a folded before Flop (didn't bet)
Seat 2: 5198f441 folded before Flop (didn't bet)
Seat 3: fb4d4e4c folded before Flop (didn't bet)
Seat 4: a938f366 (button) folded before Flop (didn't bet)
Seat 5: 3b814cc (small blind) showed [Kd Ac] and lost with Pair of Fives, and won ($995) with Pair of Kings
Seat 6: Hero (big blind) showed [Jh Jd] and won ($995) with Jacks Full over Fives, and lost with Pair of Jacks
";


}
