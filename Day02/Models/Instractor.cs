using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Day02.Models
{
    public partial class Instractor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }
        [ForeignKey("DIdNavigation")]
        public int? DId { get; set; }
        [ForeignKey("CIdNavigation")]
        public int? CId { get; set; }

        [NotMapped]
        public IFormFile ProfileImage { get; set; }

        public virtual Course CIdNavigation { get; set; }
        public virtual Department DIdNavigation { get; set; }
    }
}
