using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStudio
{
    /// <summary>
    /// класс с данными которые хранятся в памяти 
    /// </summary>
    internal class InMemoryRepository
    {
        private List<Film> _films;
        private List<Director> _directors;
        private List<Studio> _studios;


        public InMemoryRepository()
        {
            _films = new List<Film>
            {
                new Film {idFilm = 1, Title = "Начало", StudioId = 1, DirectorId = 1, Year = 2010, Budget = 160000000 },
                new Film {idFilm = 2, Title = "Интерстеллар", StudioId = 2, DirectorId = 1, Year = 2014, Budget = 140000000 },
                new Film {idFilm = 3, Title = "Парк Юрского периода", StudioId = 4, DirectorId = 2, Year = 1993, Budget = 63000000 },
                new Film {idFilm = 4, Title = "Утомлённые солнцем", StudioId = 3, DirectorId = 3, Year = 1994, Budget = 28000000 },
                new Film {idFilm = 5, Title = "Криминальное чтиво", StudioId = 4, DirectorId = 4, Year = 1994, Budget = 8000000 },
                new Film {idFilm = 6, Title = "9 рота", StudioId = 5, DirectorId = 5, Year = 2005, Budget = 9500000 }
            };

            _directors = new List<Director>
            {
                new Director{idDirector = 1, Fullname = "Нолан К.", Experience = 20, Awards = 5},
                new Director{idDirector = 2, Fullname = "Спилберг С.", Experience = 45, Awards = 12},
                new Director{idDirector = 3, Fullname = "Михалков Н.", Experience = 40, Awards = 8},
                new Director{idDirector = 4, Fullname = "Тарантино К.", Experience = 30, Awards = 6},
                new Director{idDirector = 5, Fullname = "Бондарчук Ф.", Experience = 8, Awards = 2}
            };

            _studios = new List<Studio>
            {
                new Studio{idStudio = 1, name = "Warner Bros", country = "США"},
                new Studio{idStudio = 2, name = "Paramount", country = "США"},
                new Studio{idStudio = 3, name = "Мосфильм", country = "Россия"},
                new Studio{idStudio = 4, name = "Universal", country = "США"},
                new Studio{idStudio = 5, name = "Ленфильм", country = "Россия"}
            };
        }
        public List<Film> GetFilms() { return _films; }
        public List<Director> GetDirectors() { return _directors; }
        public List<Studio> GetStudios() { return _studios; }
    }
}

