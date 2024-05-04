using CarFactory.Models.CarColor;
using CarFactory.Models.CarEngine;
using CarFactory.Models.CarFormType;
using CarFactory.Models.CarTransmission;

namespace CarFactory.Models.Car
{
    public interface ICar
    {
        public ICarEngine Engine { get; }
        public ICarFormType FormType { get; }
        public ICarColor Color { get; }
        public ICarTransmission Transmission { get; }
    }
}