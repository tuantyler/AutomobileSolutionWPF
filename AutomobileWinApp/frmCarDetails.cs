using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        private Car carInfo;
        private bool insertOrUpdate;
        private ICarRepository carRepository;
        public frmCarDetails(Car carInfo, bool insertOrUpdate, ICarRepository carRepository)
        {
            this.carInfo = carInfo;
            this.insertOrUpdate = insertOrUpdate;
            this.carRepository = carRepository;
            InitializeComponent();
            txtCarID.Enabled = !insertOrUpdate;
            if (insertOrUpdate)
            {
                txtCarID.Text = carInfo.CarID.ToString();
                txtCarName.Text = carInfo.CarName;
                txtPrice.Text = carInfo.Price.ToString();
                txtReleaseYear.Text = carInfo.ReleaseYear.ToString();
                cboManufacturer.Text = carInfo.Manufacturer.Trim();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = cboManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };
                if (insertOrUpdate)
                {
                    carRepository.UpdateCar(car);
                }
                else
                {
                    carRepository.InsertCar(car);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, insertOrUpdate == false ? "Add a new car" : "Update a car");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
