using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    /// <summary>
    /// Фильмы 
    /// </summary>
    internal class Film
    {
        /// <summary>
        /// свойство класса 
        /// </summary>
        public int idFilm { get; set; }
        public string Title { get; set; }
        public int StudioId { get; set; }
        public int DirectorId { get; set; }
        public int Year { get; set; }

        public decimal Budget { get; set; }

        /// <summary>
        /// конструкторы
        /// </summary>
        public Film()
        {

        }
        public Film(int idFilm, string title, int studioId,
                int directorId, int year, decimal budget)
        {
            if (idFilm <= 0)
                throw new ArgumentOutOfRangeException("ID фильма должен быть положительным");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentOutOfRangeException("Название фильма не может быть пустым");

            if (studioId <= 0)
                throw new ArgumentOutOfRangeException("ID студии должен быть положительным");

            if (directorId <= 0)
                throw new ArgumentOutOfRangeException("ID режиссёра должен быть положительным");

            if (year <= 0)
                throw new ArgumentOutOfRangeException("Год фильма указан некорректно");

            if (budget < 0)
                throw new ArgumentOutOfRangeException("Бюджет не может быть отрицательным");

            this.idFilm = idFilm;
            this.Title = title;
            this.StudioId = studioId;
            this.DirectorId = directorId;
            this.Year = year;
            this.Budget = budget;
        }

        /// <summary>
        /// явл ли фильм дорогим 
        /// </summary>
        public bool IsExpensive
        {
            get
            {
                return Budget > 100000000;
            }
        }
        /// <summary>
        /// инфа о фильие 
        /// </summary>
        public string GetInfo()
        {
            return ($"{Title} ({Year}, {Budget} руб.)");
        }
    }
}
