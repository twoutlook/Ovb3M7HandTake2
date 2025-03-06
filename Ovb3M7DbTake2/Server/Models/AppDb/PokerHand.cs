using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ovb3M7Db.Server.Models.AppDb
{
    [Table("PokerHands", Schema = "dbo")]
    public partial class PokerHand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string PokerHandNum { get; set; }

        public string DataSections { get; set; }

        public string GameInfo { get; set; }

        public string GameInfoJson { get; set; }

        public string TableInfo { get; set; }

        public int? SeatCnt { get; set; }

        public int? BtnSeat { get; set; }

        public int? HeroSeat { get; set; }

        public string HeroPosition { get; set; }

        public bool? IsFlop { get; set; }

        public bool? IsTurn { get; set; }

        public bool? IsRiver { get; set; }

        public bool? IsShowDown { get; set; }

        public string HoleCards { get; set; }

        public string HoleCardsStd { get; set; }

        public int? HoleCardsStdSort { get; set; }

        public string HoleCombo { get; set; }

        public int? HoleComboSort { get; set; }

        public string GameCur { get; set; }

        public decimal? HeroResult { get; set; }

        [Required]
        public string PokerHandText { get; set; }

        public decimal? LastScenePot { get; set; }

        public decimal? Rakes { get; set; }

        public DateTime? Runtime { get; set; }
    }
}