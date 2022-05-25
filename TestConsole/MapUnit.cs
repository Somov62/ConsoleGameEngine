using System;

namespace TestConsole
{
    internal struct MapUnit
    {
        public BiomeType Biome { get; set; }
    }

    public enum BiomeType
    {
        Plains,
        Sea,
        Forest,
        Desert
    }
}
