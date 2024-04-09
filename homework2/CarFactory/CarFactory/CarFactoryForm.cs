using CarFactory.Models.Car;
using System.Drawing;
using System.Windows.Forms;
using System;
using CarFactory.Models.CarFormType;
using CarFactory.Models.CarColor;
using CarFactory.Models.CarEngine;
using CarFactory.Models.CarTransmission;

namespace CarFactory
{
    public partial class CarFactoryForm : Form
    {
        public CarFactoryForm()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carFormType.SelectedIndex = 0;
            carColor.SelectedIndex = 0;
            carEngine.SelectedIndex = 0;
            carTransmission.SelectedIndex = 0;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            ICar car = MakeConfiguration();
            if (car != null)
            {
                MessageBox.Show(GetCarCharacteristicsMessage(car));
            }
            else
            {
                MessageBox.Show("Not enough fields");
            }
        }

        private string GetCarCharacteristicsMessage(ICar car)
        {
            return $"Your configuration:\n" +
                $"Engine: {car.Engine.Name}\n" +
                $"Maximum speed: {car.Engine.MaxSpeed}\n" +
                $"Gears: {car.Engine.MaxGears}\n" +
                $"Form type: {car.FormType.Name}\n" +
                $"Color: {car.Color.Name}\n" +
                $"Transmission: {car.Transmission.Name}";
        }

        private ICar MakeConfiguration()
        {
            if (carFormType.SelectedItem == null
                || carColor.SelectedItem == null
                || carEngine.SelectedItem == null
                || carTransmission.SelectedItem == null)
            {
                return null;
            }
            ICarFormType formType = FormDictionary.CarForm[carFormType.SelectedItem.ToString()];
            ICarColor color = ColorDictionary.CarColor[carColor.SelectedItem.ToString()];
            ICarEngine engine = EngineDictionary.CarEngine[carEngine.SelectedItem.ToString()];
            ICarTransmission transmission = TransmissionDictionary.CarTransmission[carTransmission.SelectedItem.ToString()];

            return new Car(engine, formType, color, transmission);
        }

    }
}