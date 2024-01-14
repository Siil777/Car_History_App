using CarService_App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Xamarin.Forms;

namespace CarService_App.Services
{
    public class DatabaseService
    {
        private SQLiteConnection database;

        public DatabaseService(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Car>();
        }

        public IEnumerable<Car> GetCars()
        {
            try
            {
                //safeguard to prevent accessing the database before it's properly set up
                if (database == null)
                {
                    throw new Exception("Database is not initialized. Call Initialize method first.");
                }

                return database.Table<Car>().ToList();
            }
            catch (Exception ex)
            {
            
                Console.WriteLine($"Error getting cars from the database: {ex.Message}");
                throw;
            }
        }
        //
        public List<Car> GetCarAll()
        {
            try
            {
                // database.Table<Car>() returns all cars in the table
                // retrieves all rows (records) from the Car table
                return database.Table<Car>().ToList();
            }
            catch (Exception ex)
            {
             
                Console.WriteLine($"Error getting cars from the database: {ex.Message}");
                throw new Exception($"Error getting cars from the database: {ex.Message}", ex);
            }
        }
        public Car AddOrUpdateCar(Car car)
        {
            try
            {
                var existingCar = GetCarById(car.CarId);

                if (existingCar == null)
                {
                    // New car, add to the collection and insert into the database
                    InsertCar(car);
                }
                 else
                {
                    // Existing car, update the collection and database
                    existingCar.Brand = car.Brand;
                    existingCar.Model = car.Model;
                    existingCar.Year = car.Year;
                    existingCar.Description = car.Description;
                    existingCar.ImagePath = car.ImagePath;

                    UpdateCar(existingCar);
                }
              

                return car;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding or updating car: {ex.Message}");
                return null; // Indicates failure
            }
        
        }



        //Insert a new Car object using Insert method
        public Car InsertCar(Car car)
        {
            try
            {
                database.Insert(car);
                return car; // successful insertion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting car into the database: {ex.Message}");
                return null; //  failure
            }
        }

        //Update existing Car object in the database using Update method
        public Car UpdateCar(Car car)
        {
            try
            {
                database.Update(car);
                return car; // successful update
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating car in the database: {ex.Message}");
                return null; // Indicates failure
            }
        }





        public Car GetCarById(int carId)
        {
            return database.Table<Car>().FirstOrDefault(c => c.CarId == carId);
        }

        public Car DeleteCar(int carId)
        {
            try
            {
                var carToDelete = GetCarById(carId);
                if (carToDelete != null)
                {
                    database.Delete(carToDelete);
                    return carToDelete;
                }
                else
                {
                    Console.WriteLine($"Car with ID {carId} not found.");
                    return null; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting car from the database: {ex.Message}");
                return null; 
            }
        }

    }


}



