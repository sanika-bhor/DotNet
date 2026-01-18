using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    [Required]
    // [StringLength(100)]
    public string Name { get; set; }

    // [Range(1, 100000)]
    public decimal Price { get; set; }
}