using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

// CarService_App.Models.Car
namespace CarService_App.Models
{
    [Table("SpaceShips")]
    public class Car
    {
        [PrimaryKey, AutoIncrement, Column("_carId")]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}

