using System;
using System.Collections.Generic;
using System.Text;

namespace GradeExpertCRM.Models
{
    /// <summary>
    /// DTO.
    /// </summary>
    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Number { get; set; }

        public string Loss { get; set; } //TODO в моделе Damaged есть свойство LossNumber

        public string VIN { get; set; }

        public string CarBodyType { get; set; }

        public int ReleaseYear { get; set; }

        public string Color { get; set; }

        public int Run { get; set; }

        public string Note { get; set; }

    }
}
