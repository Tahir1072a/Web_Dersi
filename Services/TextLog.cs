using System;

namespace WebApplication1.Services
{
    public class TextLog : ILog
    {
        public void Log()
        {
            Console.WriteLine("Texte loglandı");
        }
    }
}
