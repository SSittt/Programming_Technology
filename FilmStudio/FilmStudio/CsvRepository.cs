using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilmStudio
{
    /// <summary>
    /// класс загрузки данных из файла 
    /// </summary>
    internal class CsvRepository
    {
        private string _basePath;
        public CsvRepository(string basePath)
        {
            _basePath = basePath;
        }
        /// <summary>
        /// загружаем фильмы
        /// </summary>
        /// <returns></returns>
        public List<Film> GetFilms()
        {
            List<Film> result = new List<Film>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "films.csv"));
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 6) continue;
                Film film = new Film(int.Parse(parts[0]), parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));

                result.Add(film);
            }
            return result;
        }

        /// <summary>
        /// загружаем режиссеров
        /// </summary>
        /// <returns></returns>
        public List<Director> GetDirectors()
        {
            List<Director> result = new List<Director>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "director.csv"));
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(",");
                if (parts.Length < 4) continue;
                Director director = new Director(int.Parse(parts[0]), parts[1], int.Parse(parts[2]), int.Parse(parts[3]));

                result.Add(director);
            }
            return result;
        }
        /// <summary>
        /// загружаем студии
        /// </summary>
        /// <returns></returns>
        public List<Studio> GetStudios()
        {
            List<Studio> result = new List<Studio>();
            string[] lines = File.ReadAllLines(Path.Combine(_basePath, "studio.csv"));
            if (lines.Length < 2) return result;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(",");
                if (parts.Length < 3) continue;


                Studio studio = new Studio(int.Parse(parts[0]), parts[1], parts[2]);

                result.Add(studio);
            }
            return result;
        }


    }
}
