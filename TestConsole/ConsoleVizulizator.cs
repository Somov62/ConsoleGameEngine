using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace TestConsole
{
    public static class ConsoleVizulizator
    {
        private static readonly int _windowWidth = 1920; //in pixels
        private static readonly int _windowHeight = 1080; //in pixels
        private static readonly int _bufferWidth = _windowWidth / 8; //in symbols
        private static readonly int _bufferHeight = _windowHeight / 16; //in symbols
        public static int BufferLength { get; private set; }


        public static void ShowFrame(CharInfo[] buffer)
        {
            ConsoleVizulizator.WriteConsoleOutput(_safeFileHandle, buffer, _bufferSize, _bufferCoord, ref _rect);
        }

        public static void ApplySettings()
        {
            var hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
            SetConsoleDisplayMode(hConsole, 1, IntPtr.Zero);
            Console.SetBufferSize(_bufferWidth, _bufferHeight);
            Console.WindowHeight = _bufferHeight;
            Console.WindowWidth = _bufferWidth;
            Console.SetWindowPosition(0, 0);

            BufferLength = _bufferHeight * _bufferWidth;
        }


        #region WinApi

        const int STD_OUTPUT_HANDLE = -11;

        private static readonly SafeFileHandle _safeFileHandle = new SafeFileHandle(GetStdHandle(STD_OUTPUT_HANDLE), false);

        private static SmallRect _rect = new SmallRect()
        {
            Left = 0,
            Top = 0,
            Right = (short)_bufferWidth,
            Bottom = (short)_bufferHeight
        };


        private static readonly Coord _bufferSize = new Coord((short)_bufferWidth, (short)_bufferHeight);
        private static readonly Coord _bufferCoord = new Coord(0, 0);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleDisplayMode(IntPtr ConsoleHandle, uint Flags, IntPtr NewScreenBufferDimensions);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteConsoleOutput
            ( SafeFileHandle hConsoleOutput, CharInfo[] lpBuffer, 
            Coord dwBufferSize, Coord dwBufferCoord, ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        private struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        public struct CharUnion
        {
            [FieldOffset(0)]
            public char UnicodeChar;
            [FieldOffset(0)]
            public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct CharInfo
        {
            [FieldOffset(0)]
            public CharUnion Char;
            [FieldOffset(2)]
            public ushort Attributes;

            public CharInfo(char @char, ushort attributes)
            {
                this.Char = new CharUnion();
                Char.UnicodeChar = @char;
                Attributes = attributes;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        #endregion
    }
}
