using ExploringSpansAndPipes.Models;

namespace ExploringSpansAndPipes.Interfaces
{
    public interface ILineParser
    {
        Videogame Parse(string line);
    }
}