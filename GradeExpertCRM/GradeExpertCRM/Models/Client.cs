namespace GradeExpertCRM.Models
{
    /// <summary>
    /// DTO. The client can be a person or a company.
    /// </summary>
    public class Client
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Street { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// ИНН - ITN (Individual Taxpayer Number)
        /// </summary>
        public string ITN { get; set; }

        /// <summary>
        /// КПП — IEC (Industrial Enterprises Classifier)
        /// </summary>
        public string IEC { get; set; }

        public string Bank { get; set; }

        /// <summary>
        /// БИК - BIC (Bank Indentification Code)
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// Расчетный счет - Current account
        /// </summary>
        public string CurrentAccount { get; set; }

        /// <summary>
        /// Корреспондирующий счёт — Corresponding account
        /// </summary>
        public string CorrespondingAccount { get; set; }
    }
}
