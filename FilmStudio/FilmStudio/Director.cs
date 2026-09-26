using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

///<sumarry>
/// Режессеры
///</sumarry>
namespace FilmStudio
{
    internal class Director
    {
        /// <summary>
        /// свойство класса 
        /// </summary>
        public int idDirector { get; set; }
        public string Fullname { get; set; }

        public int Experience { get; set; }
        public int Awards { get; set; }

        /// <summary>
        /// конструкторы
        /// </summary>
        public Director()
        {

        }
        public Director(int idDirector, string fullname, int experience, int awards)
        {
            if (idDirector <= 0)
                throw new ArgumentOutOfRangeException("ID режиссёра должен быть положительным");

            if (string.IsNullOrWhiteSpace(fullname))
                throw new ArgumentException("Имя режиссёра не может быть пустым");

            if (experience < 0)
                throw new ArgumentOutOfRangeException("Опыт не может быть отрицательным");

            if (awards < 0)
                throw new ArgumentOutOfRangeException("Количество наград не может быть отрицательным");

            this.idDirector = idDirector;
            this.Fullname = fullname;
            this.Experience = experience;
            this.Awards = awards;
        }

        public bool IsExperienced
        {
            get
            {
                return Experience > 10;
            }
        }
        /// <summary>
        /// инфа о режиссере 
        /// </summary>
        public string GetInfo()
        {
            return $"{Fullname} ({Experience} лет, {Awards} наград)";
        }


    }
}
