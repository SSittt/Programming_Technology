using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDevice
{
    /// <summary>
    /// класс ренгеновского аппарата 
    /// </summary>
    public class XRay : MedicalDevice, ISterilizable
    {
        /// <summary>
        /// уровень излучение ренгена
        /// </summary>
        public double RadiationLevel { get; set; }

        /// <summary>
        /// проеверяет, является ли аппарат опасным по уровню излучения
        /// </summary>
        public bool IsDangerous => RadiationLevel > 5.0;

        /// <summary>
        /// Создаём рентгеновский аппарат и задаём его характеристики
        /// </summary>
        /// <param name="serial"> серийный номер аппарата</param>
        /// <param name="name">название</param>
        /// <param name="power">мощность</param>
        /// <param name="radiation">уровень издучения</param>
        public XRay(string serial, string name, int power, double radiation) : base(serial, name, power)
        {
            RadiationLevel = radiation;
            Class = DeviceClass.Diagnostic;
        }

        /// <summary>
        /// выполняет ренгеновское обследование
        /// </summary>
        public override void Operate()
        {
            Console.WriteLine($"{Name} takes an X-ray.");
        }

        /// <summary>
        /// стерилизация устройства
        /// </summary>
        public void Sterilize()
        {
            Console.WriteLine($"{Name} sterilized.");
        }

        /// <summary>
        /// возвращаем инфу о ренгене в виде строки
        /// </summary>
        /// <returns>навзвание, уровень излучения и класс устройства</returns>
        public override string ToString()
        {
            return $"[XRay] {Name}, tesla = {RadiationLevel}, class: {Class}";
        }


    }
}
