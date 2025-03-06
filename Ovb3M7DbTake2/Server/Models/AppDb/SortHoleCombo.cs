using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ovb3M7Db.Server.Models.AppDb
{
    [Table("SortHoleCombo", Schema = "dbo")]
    public partial class SortHoleCombo
    {
        [Key]
        [Required]
        public string HoleCombo { get; set; }

        public int? HoleComboSort { get; set; }
    }
}