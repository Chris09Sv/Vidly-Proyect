using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<Genre> genres { get; set; }
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Genre Type")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Released Date")]
        [Required]
        public DateTime Release_Date { get; set; }

        
        [Display(Name ="Number in Stock")]
        [Range(1,20)]
        [Required]
        public byte? Stock { get; set; }
        public string Title
        {
            get
            {
               
                    return  Id !=0? "Edit Movies":"New Movies";

            }
            
        }
        public MoviesViewModel()
        {

        }
        public MoviesViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Release_Date = movie.Release_Date;
                Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}