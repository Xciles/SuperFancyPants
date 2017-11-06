﻿using System.ComponentModel.DataAnnotations;

namespace SuperFancyWeb.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
