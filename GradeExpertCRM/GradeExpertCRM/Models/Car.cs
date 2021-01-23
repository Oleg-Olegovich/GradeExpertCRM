using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradeExpertCRM.Models
{
    /// <summary>
    /// DTO.
    /// </summary>
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string BodyType { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }

        public string Number { get; set; }

        public int Mileage { get; set; }

        public string Loss { get; set; }

        public string PolicyNumber { get; set; }

        public string InsuranceCompany { get; set; }

        public int Franchise { get; set; }

        public DateTime DateOfInspection { get; set; }

        public string PlaceOfInspection { get; set; }

        public string WhoMadeInspection { get; set; }

        public string TypeOfDamage { get; set; }

        public int ReleaseYear { get; set; }

        public string Note { get; set; }

        public List<Calculation> Calculations { get; set; } = new List<Calculation>();
    }
}
