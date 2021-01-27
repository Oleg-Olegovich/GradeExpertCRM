﻿using System;
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

        [Required]
        public string Brand { get; set; }

        //[Required]
        public string Model { get; set; }

        //[Required]
        public string BodyType { get; set; }

        //[Required]
        public string Color { get; set; }

        //[Required]
        //[RegularExpression(@"^[A-Za-z0-9_-]*$")]
        //[StringLength(17, MinimumLength = 17, ErrorMessage = "VIM must be 17 characters long")]
        public string VIN { get; set; }

        //[Required]
        public string Number { get; set; }

        //[Required]
        //[Range(0, Int32.MaxValue, ErrorMessage = "Value must be positive number or 0")]
        public int Mileage { get; set; }

        //[Required]
        public string Loss { get; set; }

        //[Required]
        public string PolicyNumber { get; set; }

        //[Required]
        public string InsuranceCompany { get; set; }

        //[Required]
        public int Franchise { get; set; }

        //[Required]
        public DateTime DateOfInspection { get; set; }

        //[Required]
        public string PlaceOfInspection { get; set; }

        //[Required]
        public string WhoMadeInspection { get; set; }

        //[Required]
        public string TypeOfDamage { get; set; }

        //[Range(1900, 2100, ErrorMessage = "Invalid year")]
        public int ReleaseYear { get; set; }

        public string Note { get; set; }

        public List<Calculation> Calculations { get; set; } = new List<Calculation>();
    }
}
