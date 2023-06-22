using System.ComponentModel.DataAnnotations;

namespace GameStore.Client.Models;

public class Game
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    [StringLength(30)] 
    public required string Genre { get; set; }
    
    [Range(1, 100)]
    public double Price { get; set; }
    public DateTime ReleaseDate { get; set; }
}


