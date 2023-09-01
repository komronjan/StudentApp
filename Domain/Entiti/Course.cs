
using System.ComponentModel.DataAnnotations;

namespace Domain.Entiti;

public class Course
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string ImageName { get; set; }
    [Required]
    public string SubTitle { get; set; }
    [Required]
    public decimal Fee { get; set; }
}
