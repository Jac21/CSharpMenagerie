using EnumDetailsService.Enums;

namespace EnumDetailsService.Models
{
    public class ModularSynth
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public ModularTypes Type { get; set; }
    }
}