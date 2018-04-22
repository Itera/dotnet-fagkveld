using System;

namespace DiExample.Repositories
{
    public interface IRepository : IDisposable
    {
        string GetText();
    }
}