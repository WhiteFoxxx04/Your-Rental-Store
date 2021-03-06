﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RentStation.Models;

namespace RentStation.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}