using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data.Models
{
    public class Platform
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("publisher")]
        [Required]
        public string Publisher { get; set; }

        [Column("cost")]
        public string Cost { get; set; }

    }
}
