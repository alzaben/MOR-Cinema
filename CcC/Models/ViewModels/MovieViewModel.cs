﻿using CcC.Models.SharedProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CcC.Models.ViewModels
{
    public class MovieViewModel:CommonProp
    {
        public int MovieId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal TicketPrice { get; set; }
        public IFormFile? Img { get; set; }
        public string? Director { get; set; }
        public string? Starring { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? RunningTime { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
