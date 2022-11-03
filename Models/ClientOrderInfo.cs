using System.ComponentModel.DataAnnotations;

namespace Company_CRM.Models
{
    public class ClientOrderInfo
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string OrganisationName { get; set; } = null!;
        [Phone (ErrorMessage = "Некорректный номер телефона")]
        public string? Phone { get; set; }
        public string? Email { get; set; }  
        public string? Address { get; set; }
        public int? ContractId { get; set; }
        public DateTime? Meeting { get; set; }
        public Contract ContractInfo { get; set; }
        // [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public Dictionary<string, string> SneakerIdToValue { get; set; }
    }
}
