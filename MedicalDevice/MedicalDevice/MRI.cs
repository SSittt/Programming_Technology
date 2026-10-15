using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDevice
{
    /// <summary>
    /// класс магнитного- резонансного томографа
    /// </summary>
    public class MRI : MedicalDevice, ISterilizable
    {
        /// <summary>
        /// сила магнитного поля томографа в теслах
        /// </summary>
        public double TeslaStrength { get; set; }
        /// <summary>
        /// проверяет.ю является ли томограф мощным
        /// </summary>
        public bool IsPowerful => TeslaStrength >= 3.0;

        /// <summary>
        /// создаем томограф и задаем основный характеристики 
        /// </summary>
        /// <param name="serial">серийный номер устройства</param>
        /// <param name="name">название</param>
        /// <param name="power">мощность</param>
        /// <param name="tesla">сила магнитного поля в теслах</param>
        public MRI(string serial, string name, int power, double tesla) : base(serial, name, power)
        {
            TeslaStrength = tesla;
            Class = DeviceClass.Diagnostic;
        }

        /// <summary>
        /// выполняет сканирование пациента
        /// </summary>
        public override void Operate()
        {
            Console.WriteLine($"{Name} scans patient.");
        }

        /// <summary>
        /// стерилизация устройства
        /// </summary>
        public void Sterilize()
        {
            Console.WriteLine($"{Name} sterilized.");
        }

        /// <summary>
        /// возвразщает инфу о томографе в виде сторки 
        /// </summary>
        /// <returns>название, силу магнитног поля и класс устройства </returns>
        public override string ToString()
        {
            return $"[MRI] {Name}, tesla = {TeslaStrength}, class: {Class}";
        }
    }
}
