using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public byte GenreId { get; set; }


        public DateTime Release_Date { get; set; }

        public DateTime Date_Add { get; set; }

        public GenreDto Genre { get; set; }
        public byte Stock { get; set; }
    }
}