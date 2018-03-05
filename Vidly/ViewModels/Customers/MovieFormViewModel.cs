﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels.Customers
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenreType> MovieGenreTypes { get; set; }
        public Movie Movie { get; set; }

    }
}