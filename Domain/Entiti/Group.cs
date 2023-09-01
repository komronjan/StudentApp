using System.ComponentModel.DataAnnotations;

namespace Domain.Entiti;

public class Group
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string GroupName { get; set; }
    public string Description { get; set; }
    public string CourseFormal { get; set; }
    public int Duration { get; set; }
    public DurationType DurationType { get; set; }
    public int RequairedStudent { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime FinishedsAt { get; set; }
    public Status Status { get; set; }
    public string Course { get; set; }
}
public enum DurationType
{
    Month = 1,
    Week,
    Day,
}
