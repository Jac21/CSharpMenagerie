using System;

namespace ExploringSpansAndPipes.Models
{
    public class Videogame
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Genres Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public bool HasMultiplayer { get; set; }
    }
}