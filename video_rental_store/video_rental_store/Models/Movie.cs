using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace video_rental_store.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        
        public Genre Genre { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Added Date")]
        public DateTime? AddedDate { get; set; }

        [Display(Name = "Number in stack")]
        [NumberInStackRange]
        public int NumberInStock { get; set; }


        public static readonly byte MinInStack = 1;
        public static readonly byte MaxInStack = 20;

    }
}