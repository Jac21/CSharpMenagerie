using System.Collections.Generic;
using System.Threading.Tasks;
using ExploringSpansAndPipes.Models;

namespace ExploringSpansAndPipes.Interfaces
{
    public interface IFileParser
    {
        Task<List<Videogame>> Parse(string file);
    }
}