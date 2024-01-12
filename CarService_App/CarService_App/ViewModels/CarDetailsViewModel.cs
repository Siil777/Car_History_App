// CarDetailsViewModel.cs
// CarService_App.ViewModels.CarDetailsViewModel
using CarService_App.Models;
using System.ComponentModel;

namespace CarService_App.ViewModels
{
    public class CarDetailsViewModel : INotifyPropertyChanged
    {
        private string _brand;
        private string _model;
        private int _year;
        private string _description;
        private string _imagePath;
        private int _carId;  // property for the car ID

        public int CarId
        {
            get { return _carId; }
            set
            {
                _carId = value;
                OnPropertyChanged(nameof(CarId));
            }
        }

        public string Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public CarDetailsViewModel()
        {
            // Parameterless default constructor
        }


        public CarDetailsViewModel(int carId = 0, string brand = "", string model = "", int year = 0, string description = "", string imagePath = "")
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            Year = year;
            Description = description;
            ImagePath = imagePath;
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



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


