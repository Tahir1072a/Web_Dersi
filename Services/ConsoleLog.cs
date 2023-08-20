using System;

namespace WebApplication1.Services
{
    public class ConsoleLog : ILog
    {
        public void Log()
        {
            Console.WriteLine("Console loglandı");
        }
    }
}
