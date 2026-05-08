using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Gameplay
{
    public int Id { get; set; }
    
    public int GamerId { get; set; }
    public Gamer? Gamer { get; set; }
    
    public int GameId { get; set; }
    public Game? Game { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime PlayedOn { get; set; }
    
    [Range(1, 10)]
    public int Rating { get; set; }
}
