using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Model
{
    public class Model
    {
        public class Customer
        {
            [Key]
            [Required]
            public int CustomerID { get; set; }

            [Required]
            public int Gender { get; set; }

            [Required]
            [MaxLength(50)]
            public string FirstName { get; set; }

            [Required]
            [MaxLength(75)]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthday { get; set; }

            [Required]
            [MaxLength(75)]
            public string Street { get; set; }

            [MaxLength(10)]
            public string HouseNumber { get; set; }

            [Required]
            [MaxLength(10)]
            public string ZipCode { get; set; }

            [Required]
            [MaxLength(75)]
            public string Town { get; set; }
        }

        public class Bike
        {
            [Key]
            [Required]
            public int BikeID { get; set; }

            [Required]
            [MaxLength(25)]
            public string Brand { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime PurchaseDate { get; set; }

            [MaxLength(1000)]
            public string notes { get; set; }

            [DataType(DataType.Date)]
            public DateTime? DateOfLastService { get; set; }

            [Required]
            [Range(0.00, Double.MaxValue)]
            public Double RentalPriceHourOne { get; set; }

            [Required]
            [Range(1.00, Double.MaxValue)]
            public Double RentalPriceAdditionalHour { get; set; }

            [Required]
            public int BikeCategory { get; set; }
        }

        public class Rental
        {
            [Key]
            public int RentalID { get; set; }

            [Required]
            public Customer Customer { get; set; }

            [Required]
            public Bike Bike { get; set; }

            [Required]
            public DateTime RentalBegin { get; set; }

            public DateTime? RentalEnd { get; set; }

            [Required]
            [Range(1.00, Double.MaxValue)]
            public Double Costs { get; set; }

            [Required]
            public bool Paid { get; set; }
        }
    }
}
