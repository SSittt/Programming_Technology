using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    /// <summary>
    /// Студии
    /// </summary>
    internal class Studio

    {
        /// <summary>
        /// свойство класса 
        /// </summary>
        public int idStudio { get; set; }
        public string name { get; set; }
        public string country { get; set; }

        /// <summary>
        /// конструкторы 
        /// </summary>
        public Studio()
        {

        }


        public Studio(int idStudio, string name, string country)
        {
            if (idStudio <= 0)
                throw new ArgumentException("ID студии должен быть положительным");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название студии не может быть пустым");

            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Страна не может быть пустой");

            this.idStudio = idStudio;
            this.name = name;
            this.country = country;
        }

        /// <summary>
        /// вычислем иностранные студии - свойство так как характеристика объекта 
        /// </summary>
        public bool IsForeign
        {
            get
            {
                return country != "Россия";
            }
        }

        /// <summary>
        /// метод для формата вывода инфу о студии
        /// </summary>
        public string GetInfo()
        {
            return $"{name} ({country})";
        }


    }


}
