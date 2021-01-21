using System;
using System.Collections.Generic;
using iText.Layout.Element;

namespace GradeExpertCRM.Models
{
    /// <summary>
    /// DTO.
    /// </summary>
    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string BodyType { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }

        public string Number { get; set; }

        public int Mileage { get; set; }

        public string Owner { get; set; } //TODO change type to Client

        public string Loss { get; set; }

        public string PolicyNumber { get; set; }

        public string InsuranceCompany { get; set; }

        public int Franchise { get; set; }

        public DateTime DateOfInspection { get; set; }

        public string PlaceOfInspection { get; set; }

        public string WhoMadeInspection { get; set; }

        public string TypeOfDamage { get; set; }

        public int ReleaseYear { get; set; }

        public List<Calculation> CalculationsList { get; set; } = new List<Calculation>();

        public string Note { get; set; } //TODO is this property necessary?
    }
}
