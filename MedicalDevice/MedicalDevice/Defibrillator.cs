using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDevice
{
    /// <summary>
    /// класс дефибрилятора
    /// </summary>
    public class Defibrillator : MedicalDevice
    {
        /// <summary>
        /// максимум энергии разряда в джоулях
        /// </summary>
        public int MaxEnergy { get; set; }

        /// <summary>
        /// проверяет, является ли дефибрилятор портативным
        /// </summary>
        public bool IsPortable => MaxEnergy <= 500;


        /// <summary>
        /// создает дуфибрилятор и задает характеристики
        /// </summary>
        /// <param name="serial">серийный номер устройства</param>
        /// <param name="name">название</param>
        /// <param name="power">мощность</param>
        /// <param name="maxEnergy">максимальная энергия разрада</param>
        public Defibrillator(string serial, string name, int power, int maxEnergy)
           : base(serial, name, power)
        {
            MaxEnergy = maxEnergy;
            Class = DeviceClass.Therapeutic;
        }

        /// <summary>
        /// выполняет работу дефибриблятора
        /// </summary>
        public override void Operate()
        {
            Console.WriteLine($"{Name} defibrillates.");
        }

        /// <summary>
        /// возвращает инфу о дефибриляторе в виде строки
        /// </summary>
        /// <returns>название, максимальная днергия разряад и классс устройства</returns>
        public override string ToString()
        {
            return $"[Defibrillator] {Name}, max energy={MaxEnergy} J, class: {Class}";
        }
    }
}
