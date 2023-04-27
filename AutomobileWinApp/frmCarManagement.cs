using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.Repository;
using System.ComponentModel;

namespace AutomobileWinApp
{
    public partial class frmCarManagement : Form
    {
        ICarRepository carRepository = new CarRepository();
        BindingSource source;
        public frmCarManagement()
        {
            InitializeComponent();
        }
        private void ClearText()
        {
            txtCarID.Text = string.Empty;
            txtCarName.Text = string.Empty;
            txtManufacturer.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtReleaseYear.Text = string.Empty;
        }
        public void LoadCarList()
        {
            var cars = carRepository.GetCars();
            try
            {
                source = new BindingSource();
                source.DataSource = cars;
                txtCarID.DataBindings.Clear();
                txtCarName.DataBindings.Clear();
                txtManufacturer.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtReleaseYear.DataBindings.Clear();

                txtCarID.DataBindings.Add("Text", source, "CarID");
                txtCarName.DataBindings.Add("Text", source, "CarName");
                txtManufacturer.DataBindings.Add("Text", source, "Manufacturer");
                txtPrice.DataBindings.Add("Text", source, "Price");
                txtReleaseYear.DataBindings.Add("Text", source, "ReleaseYear");

                dgvCarList.DataSource = null;
                dgvCarList.DataSource = source;

                if (cars.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load car list");
            }
        }

        private Car GetCarObject()
        {
            return new Car
            {
                CarID = int.Parse(txtCarID.Text),
                CarName = txtCarName.Text,
                Manufacturer = txtManufacturer.Text,
                Price = decimal.Parse(txtPrice.Text),
                ReleaseYear = int.Parse(txtReleaseYear.Text)
            };
        }

        private void dgvCarList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails(GetCarObject(), true, carRepository);
            if (frmCarDetails.ShowDialog() == DialogResult.OK)
            {
                LoadCarList();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCarList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails(new Car(), false, carRepository);
            if (frmCarDetails.ShowDialog() == DialogResult.OK)
            {
                LoadCarList();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var car = GetCarObject();
                carRepository.DeleteCar(car.CarID);
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a car");
            }
        }
    }
}