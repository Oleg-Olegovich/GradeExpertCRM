namespace GradeExpertCRM.Models
{
    /// <summary>
    /// DTO. The client can be a person or a company.
    /// </summary>
    public class Client
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }
    }
}
