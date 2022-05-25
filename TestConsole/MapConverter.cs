using System;
using static TestConsole.ConsoleVizulizator;

namespace TestConsole
{
    internal static class MapConverter
    {
        public static CharInfo[] ConvertMapToFrame(MapUnit[,] map)
        {
            foreach (var item in map)
            {
                var mapunit = new CharInfo();

                switch (item.Biome)
                {
                    case BiomeType.Desert:
                        mapunit.Char = new CharUnion() { UnicodeChar = 'd' };
                        mapunit.Attributes = CombineColors(ConsoleColor.White, ConsoleColor.DarkYellow);
                        break;
                    case BiomeType.Sea:
                        mapunit.Char = new CharUnion() { UnicodeChar = 's' };
                        break;
                    case BiomeType.Plains:
                        mapunit.Char = new CharUnion() { UnicodeChar = 'p' };
                        break;
                    case BiomeType.Forest:
                        mapunit.Char = new CharUnion() { UnicodeChar = 'f' };
                        break;
                }
            }
            return null;
        }

        private static ushort CombineColors(ConsoleColor foreColor, ConsoleColor backColor)
        {
            
            return (ushort)((int)foreColor + (((int)backColor) << 4));
        }

    }
}
