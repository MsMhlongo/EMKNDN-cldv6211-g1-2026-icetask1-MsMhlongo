using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Gamer
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Range(13, 99)]
    public int Age { get; set; }
}
