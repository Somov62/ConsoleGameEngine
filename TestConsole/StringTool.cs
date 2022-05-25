namespace TestConsole
{
    public static class StringTool
    {
        public static string BuildString(char symbol, int length)
        {
            string result = string.Empty;
            for (int i = 0; i < length; i++)
            {
                result += symbol;
            }
            return result;
        }
    }
}
