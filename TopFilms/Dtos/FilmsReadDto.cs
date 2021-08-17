namespace TopFilms.Dtos
{
    public class FilmsReadDto
    {
        public int Id { get; set; }

        public string NameFilm { get; set; }

        public int YearFilm { get; set; }

        public string AboutFilm { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        public string Director { get; set; }

        public string Genres { get; set; }

        public string Team { get; set; }
    }
}
