﻿using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICarRepository carRepository;
        public MainWindow()
        {
            InitializeComponent();
            carRepository = new CarRepository();
        }
        private Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Get Car");
            }
            return car;
        }

        public void LoadCarList()
        {
            lvCars.ItemsSource = carRepository.GetCars();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load car list");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.InsertCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} updated successfully ", "Insert car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.UpdateCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} updated successfully ", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();

                MessageBox.Show(car.CarID.ToString());
                carRepository.DeleteCar(car.CarID);
                LoadCarList();
                MessageBox.Show($"{car.CarName} updated successfully ", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
