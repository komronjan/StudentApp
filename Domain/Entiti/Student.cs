using System.ComponentModel.DataAnnotations;
namespace Domain.Entiti;

public class Student
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }
    [Required, MaxLength(100)]
    public string Address { get; set; }
    [Required, MaxLength(255)]
    public string EmailAddress { get; set; }
    [Required, MaxLength(12)]
    public string PhoneNumber { get; set; }
    [Required, MaxLength(50)]
    public string TelegramUserName { get; set; }
    public string FileName { get; set; }
}
public enum Status
{
    Active = 1,
    InActive
}
