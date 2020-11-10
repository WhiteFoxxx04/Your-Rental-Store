using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Game Games { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Required]
        public byte? CategoryId { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Game" : "New Game";
            }
        }

        public GameFormViewModel()
        {
            Id = 0;
        }

        public GameFormViewModel(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            NumberInStock = game.NumberInStock;
            CategoryId = game.CategoryId;
        }
    }
}