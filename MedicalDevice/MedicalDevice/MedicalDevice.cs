using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDevice
{
    /// <summary>
    /// абстрактный класс медицинского устройтва 
    /// </summary>
    public abstract class MedicalDevice
    {
        /// <summary>
        /// серийный номер устройства 
        /// </summary>
        private string _serial;

        /// <summary>
        /// название устройство 
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// потребление энергии
        /// </summary>
        public int PowerConsumption { get; private set; }

        /// <summary>
        /// класс устройства, по умолчанию Diagnostic
        /// </summary>
        public DeviceClass Class { get; set; } = DeviceClass.Diagnostic;

        /// <summary>
        /// проверяет, потребляет ли устройства больше 1000 единиц мощности 
        /// </summary>
        public bool IsRowIsPowerHungry => PowerConsumption > 1000;

        /// <summary>
        /// конструктор, задается серийный номер, название и мощность 
        /// </summary>
        /// <param name="serial">серийный номер</param>
        /// <param name="name">название устройства</param>
        /// <param name="power">мощность</param>
        public MedicalDevice(string serial, string name, int power)
        {
            _serial = serial;
            Name = name;
            PowerConsumption = power;
        }

        /// <summary>
        /// конструктор, в котором автоматически задается серийный номер и мощность 
        /// </summary>
        /// <param name="name">название устройства</param>
        public MedicalDevice(string name) : this("N/A", name, 0)
        {

        }

        /// <summary>
        /// метод, который реализуется в классах наследниках
        /// </summary>
        public abstract void Operate();

        /// <summary>
        /// свойство для получения серийного номерв внутри классов - наслдеников
        /// </summary>
        protected string Serial
        {
            get { return _serial; }
        }

    }
}
