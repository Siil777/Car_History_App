// CarDetailsPage.xaml.cs
using Xamarin.Forms;
using CarService_App.ViewModels;
using CarService_App.Models;
using System;

namespace CarService_App.Views
{
    public partial class CarDetailsPage : ContentPage
    {
        private readonly CarDetailsViewModel _viewModel;

        public CarDetailsPage(CarDetailsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (_viewModel != null)
            {
                // Check if any property of _viewModel is null before accessing it
                if (_viewModel.Brand != null && _viewModel.Model != null && _viewModel.Description != null)
                {
                    //  CarViewModel to update the database
                    App.Database.AddOrUpdateCar(_viewModel.ToCar());
                    this.Navigation.PopAsync();

                    await DisplayAlert("Success", "Data saved successfully!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "One or more properties of the view model are null.", "OK");
                }
            }
        }

        private async void Delete_Clicked_2(object sender, EventArgs e)
        {
            if (_viewModel != null)
            {
                // Check if any property of _viewModel is null before accessing it
                if (_viewModel.Brand != null && _viewModel.Model != null && _viewModel.Description != null)
                {
                    //  CarViewModel to update the database
                    App.Database.DeleteCar(_viewModel.CarId);
                    this.Navigation.PopAsync();

                    await DisplayAlert("Success", "Data saved successfully!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "One or more properties of the view model are null.", "OK");
                }
            }

        }
    }

}



