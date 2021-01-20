namespace GradeExpertCRM.Models
{
    /// <summary>
    /// DTO. The client can be a person or a company.
    /// </summary>
    public class Client
    {
        public string Name { get; set; }

        public string Index { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// ИНН - TIN (Taxpayer Identification Number)
        /// </summary>
        public string TIN { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        public string CRR { get; set; }

        public string Bank { get; set; }

        /// <summary>
        /// БИК - BIC (Bank Indentification Code)
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// Расчетный счет
        /// </summary>
        public string PaymentAccount { get; set; }

        /// <summary>
        /// Корреспондирующий счёт — Corresponding account
        /// </summary>
        public string CorrespondentAccount { get; set; }
    }
}
