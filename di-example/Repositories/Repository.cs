using System;

namespace DiExample.Repositories
{
    public class Repository : IRepository
    {
        private readonly string text;

        public Repository(string text)
        {
            this.text = text;
        }

        public string GetText()
        {
            return text;
        }
        public void Dispose()
        {
            Console.WriteLine($"Disposing {text}");
        }
    }
}