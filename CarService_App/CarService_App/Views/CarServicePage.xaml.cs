// CarServicePage.xaml.cs
using Xamarin.Forms;
using CarService_App.Models;
using CarService_App.ViewModels;
using CarService_App.Services;
using System;
using System.IO;

namespace CarService_App.Views
{
    public partial class CarServicePage : ContentPage
    {
        public CarServicePage()
        {
            InitializeComponent();
            opacityImage.Opacity = 0.25;
           
        }
       

        protected override void OnAppearing()
        {
            // Refresh the list of cars when the page appears
            // Assuming you want to get all cars
            CarsList.ItemsSource = App.Database.GetCarAll();

            base.OnAppearing();
        }


        private async void OnCarSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Car selectedCar)
            {
                await Navigation.PushAsync(new CarDetailsPage(new CarDetailsViewModel(
                selectedCar.CarId,          // Pass carId
                selectedCar.Brand,
                selectedCar.Model,           // Pass model
                selectedCar.Year,            // Pass year
                selectedCar.Description,
                selectedCar.ImagePath
            )));

            }

            ((ListView)sender).SelectedItem = null; // Clear selection
        }
        private async void CreateCar(object sender, EventArgs e)
        {
            // Create an instance of CarDetailsViewModel for adding a new car
            CarDetailsViewModel viewModel = new CarDetailsViewModel();

            // Create a new instance of CarDetailsPage and pass the viewModel
            CarDetailsPage CarPage = new CarDetailsPage(viewModel);

            // Set the BindingContext of the page to the viewModel
            CarPage.BindingContext = viewModel;

            // Navigate to CarDetailsPage for adding a new car
            await Navigation.PushAsync(CarPage);
        }
        public async void DeleteCar(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirm Deletion", "Are you sure you want to delete this friend?", "Yes", "No");
            if (answer)
            {
                var Car = (Car)BindingContext;
                App.Database.DeleteCar(Car.CarId); // Assuming CarId is the unique identifier

                // If DeleteCar returns a Car object, you can use it like this:
                // var deletedCar = App.Database.DeleteCar(friend.CarId);
                // If needed, you can handle the deletedCar object

                this.Navigation.PopAsync();
            }
        }

    }
}

