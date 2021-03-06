namespace Common.Console{
    using System;
   public class ConsoleWriter{   
        public void ConsolePauseAndFix(string message, ConsoleColor color)
        {
            ConsoleWriteBackgroundColor(message, color);
            Console.ReadKey();
        }
        
        public void ConsoleWriteBackgroundColor(string message, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
   }
}