﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using video_rental_store.Models;

namespace video_rental_store.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int? GenreId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? AddedDate { get; set; }

//        [NumberInStackRange]
        public int? NumberInStock { get; set; }
    }
}