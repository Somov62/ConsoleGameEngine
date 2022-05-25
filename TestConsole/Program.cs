namespace TestConsole
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            ConsoleVizulizator.ApplySettings();
            Engine engine = new ();

            engine.Start();            
        }               
    }
}
