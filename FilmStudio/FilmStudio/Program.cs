using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace FilmStudio
{
    internal class Program
    {
        /// <summary>
        /// поиск режиссера по названию фильма
        /// <summary>
        public static Director FindDirector(string title, List<Film> films, List<Director> directors)
        {
            foreach (Film film in films)
            {
                if (film.Title == title)
                {
                    int directorId = film.DirectorId;
                    foreach (Director director in directors)
                    {
                        if (director.idDirector == directorId)
                            return director;
                    }
                    break;
                }
            }
            return null;

        }

        /// <summary>
        /// поиск студии по фильму 
        /// </summary>
        public static Studio FindStudio(Film film, List<Studio> studios)
        {
            if (film is null) return null;

            foreach (Studio studio in studios)
            {
                if (film.StudioId == studio.idStudio)
                    return studio;
            }
            return null;
        }

        /// <summary>
        ///  общий бюджет фильмов 
        /// </summary>
        public static decimal GetTotalBudget(List<Film> films)
        {
            decimal totalBudget = 0;

            foreach (Film film in films)
                totalBudget += film.Budget;
            return totalBudget;
        }

        /// <summary>
        /// поиск режиссера по макс бюджету
        /// </summary>
        public static Director GetDirectorWithMaxBudget(List<Film> films, List<Director> directors)
        {
            if (films.Count == 0) return null;

            decimal maxBudget = 0;
            int maxDerictorId = 0;

            for (int i = 0; i < directors.Count; i++)
            {
                if (films[i].Budget > maxBudget)
                {
                    maxBudget = films[i].Budget;
                    maxDerictorId = films[i].DirectorId;
                }
            }

            for (int i = 0; i < directors.Count; i++)
            {
                if (directors[i].idDirector == maxDerictorId) return directors[i];
            }
            return null;
        }
        /// <summary>
        /// вся инфа О ВСЕХ ФИЛЬМАХ
        /// </summary>
        public static void PrintAllFilms(List<Film> films, List<Director> directors , List<Studio> studios)
        {
            foreach (Film film in films)
            {
                Director director = null;
                Studio studio = null;

                // Ищем режиссера
                foreach (Director d in directors)
                {
                    if (d.idDirector == film.DirectorId)
                    {
                        director = d;
                        break;
                    }
                }

                // Ищем студию
                foreach (Studio s in studios)
                {
                    if (s.idStudio == film.StudioId)
                    {
                        studio = s;
                        break;
                    }
                }

                string directorName = "_";
                string studioName = "_";

                if (director != null) directorName = director.Fullname;

                if (studio != null) studioName = studio.name;

                Console.WriteLine("\"" + film.GetInfo() + "\" - режиссер" + directorName + ", студия \"" + studioName + "\"");

            }



        }

        /// <summary>
        /// выводим всю инфу 
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("FilmStudio\n");
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1.InMemoryRepository");
            Console.WriteLine("2.CsvRepository");
            Console.WriteLine("Выбери уже:");

            string vivod = Console.ReadLine();
            int choice;
            if (!int.TryParse(vivod, out choice))
            {
                Console.WriteLine("Неверный выбор");
                return;
            }

            List<Film> films;
            List<Director> directors;
            List<Studio> studios;
            try
            {
                switch (choice)
                {

                    case 1:
                        InMemoryRepository memory = new InMemoryRepository();
                        studios = memory.GetStudios();
                        films = memory.GetFilms();
                        directors = memory.GetDirectors();
                        break;

                    case 2:
                        CsvRepository csvRepository = new CsvRepository("data");
                        studios = csvRepository.GetStudios();
                        films = csvRepository.GetFilms();
                        directors = csvRepository.GetDirectors();
                        break;

                    default:
                        Console.WriteLine("Неверный выбоор");
                        return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка считывание данных:" + ex.Message);
                return;
            }

            Director findDirector = FindDirector("Начало", films, directors);
            Console.WriteLine("1.FindDirector(\"Начало\"): ");
            if (findDirector != null)
            {
                Console.WriteLine(findDirector.GetInfo());
            }
            else
            {
                Console.WriteLine("null");
            }

            Film findFilm = null;

            for (int i = 0; i < films.Count; i++)
            {
                if (films[i].Title == "Начало")
                {
                    findFilm = films[i];
                    break;
                }
            }

            Studio findSdudio = FindStudio(findFilm, studios);

            Console.WriteLine("2.FindStudio(film \"Начало\"):");

            if (findSdudio != null)
            {
                Console.WriteLine($"{findSdudio.GetInfo()}");
            }
            else
            {
                Console.WriteLine("null");
            }

            decimal budget = GetTotalBudget(films);
            Console.WriteLine("3. GetTotalBudget:" + budget + " руб.");

            Director maxBudget = GetDirectorWithMaxBudget(films, directors);
            Console.WriteLine("4. GetDirectorWithMaxBudget: ");

            if (maxBudget != null)
            {
                decimal directorBudget = 0;
                for (int i = 0; i < films.Count; i++)
                {
                    if (films[i].DirectorId == maxBudget.idDirector)
                        directorBudget += films[i].Budget;
                }
                Console.WriteLine($"{maxBudget.Fullname} ({directorBudget})");
            }
            else
            {
                Console.WriteLine("null");
            }

            Console.WriteLine("5. PrintAllFilms: ");
            PrintAllFilms(films, directors, studios);

            Director NotFindDirector = FindDirector("Неизвестный фильм", films, directors);
            Console.WriteLine("FindDirector(\"Неизвестный фильм\")");


            if (NotFindDirector is null)
                Console.WriteLine("null");
            else
            {
                Console.WriteLine(NotFindDirector.GetInfo());
            }


        }
    }
}
