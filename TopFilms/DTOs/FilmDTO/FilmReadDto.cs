namespace TopFilms.Dtos
{
    public class FilmReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string About { get; set; }

        public int Budget { get; set; }

        public int Gross { get; set; }

        public string Genres { get; set; }

        public int DirectorId { get; set; }

        public IList<ActorDTO> Actors { get; set; }
    }
}
