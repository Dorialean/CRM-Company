namespace Company_CRM.Models;

public class UserInfo
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string? FirstName { get; set; } = null!;
    public string? SecondName { get; set; } = null!;
    public string? FatherName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? FactoryRole { get; set; }
    public string? SaltPass { get; set; }
    public DateTime Hired { get; set; } = DateTime.Now;
}