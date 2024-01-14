// CarService_App.ViewModels.CarViewModel
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CarService_App.Models;
using CarService_App.Services;

namespace CarService_App.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        private ObservableCollection<Car> _cars;
        private DatabaseService _databaseService;

        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }


        public CarViewModel()
        {
            // Default constructor
            Console.WriteLine("CarViewModel default constructor");
        }

        // Add another constructor that accepts databasePath
        public CarViewModel(string databasePath)
        {
            Console.WriteLine("CarViewModel initialization started.");

            // Initialize the collection with data from the SQLite database
            _databaseService = new DatabaseService(databasePath);
            Cars = new ObservableCollection<Car>(_databaseService.GetCars());
        }







        // Add methods for updating the database
        public void AddOrUpdateCar(Car car)
        {
            var existingCar = Cars.FirstOrDefault(c => c.CarId == car.CarId);

            if (existingCar == null)
            {
                // New car,  insert into the database
                Cars.Add(car);
                _databaseService.InsertCar(car);
            }
            else
            {
                // update the collection and database
                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Description = car.Description;
                existingCar.ImagePath = car.ImagePath;

                _databaseService.UpdateCar(existingCar);
            }
        }
        public Car ToCar()
        {
            return new Car
            {
                CarId = this.CarId,
                Brand = this.Brand,
                Model = this.Model,
                Year = this.Year,
                Description = this.Description,
                ImagePath = this.ImagePath
            };
        }

        // Method to get a car by its ID
        public Car GetCarById(int carId)
        {
            return Cars.FirstOrDefault(c => c.CarId == carId);
        }
        

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}




