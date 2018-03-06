using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels.Movies
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenreType> MovieGenreTypes { get; set; }
    
        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte MovieGenreTypeId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            MovieGenreTypeId = movie.MovieGenreTypeId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }

        public string Title
        {
            get
            {
                return Id == 0 ? "New Movie" : "Edit Movie";

            }
        }

    }
}