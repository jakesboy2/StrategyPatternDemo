using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Repositories
{
    public interface IPretendRepository
    {
        public string GetManagerAccessCode();
        public string GetWorkerAccessCode();
    }
}
