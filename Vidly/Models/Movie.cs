using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre Type")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Released Date")]

        public DateTime Release_Date { get; set; }

        [Display(Name = "Date Add ")]
        public DateTime Date_Add { get; set; }

        public byte Stock { get; set; }
    }
}