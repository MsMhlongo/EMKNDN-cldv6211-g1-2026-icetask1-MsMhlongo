using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Game
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;
    
    public string Genre { get; set; } = string.Empty;
    
    [Range(0, 999.99)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    
    // For Azurite image storage
    public string ImageUrl { get; set; } = string.Empty;
}
