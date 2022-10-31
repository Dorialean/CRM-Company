using System.ComponentModel.DataAnnotations;

namespace Company_CRM.Models;

public class UserInfo
{
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Поле обязательно к заполнению")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Пароль должен быть более 6 символов")]
    public string Password { get; set; }
    public string? FirstName { get; set; } = null!;
    public string? SecondName { get; set; } = null!;
    public string? FatherName { get; set; }
    
    [Phone (ErrorMessage = "Некорректный номер телефона")]
    public string? Phone { get; set; }
    
    [EmailAddress (ErrorMessage = "Некорректный Email")]
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? FactoryRole { get; set; }
    public string? SaltPass { get; set; }
    public DateTime Hired { get; set; } = DateTime.Now;
}