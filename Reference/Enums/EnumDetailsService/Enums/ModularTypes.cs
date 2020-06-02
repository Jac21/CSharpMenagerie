using System;

namespace EnumDetailsService.Enums
{
    [Flags]
    public enum ModularTypes : ulong // defining an internal type for this enum
    {
        None = 0,
        Vca = 1,
        Mixer = 2,
        AdsrEnvelope = 4,
        Modulator = 8,
        Veils = Vca | Mixer
    }
}