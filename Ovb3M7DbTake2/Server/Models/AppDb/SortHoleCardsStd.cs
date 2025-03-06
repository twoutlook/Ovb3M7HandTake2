using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ovb3M7Db.Server.Models.AppDb
{
    [Table("SortHoleCardsStd", Schema = "dbo")]
    public partial class SortHoleCardsStd
    {
        [Key]
        [Required]
        public string HoleCardsStd { get; set; }

        public int? HoleCardsStdSort { get; set; }
    }
}