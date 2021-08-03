using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Repositories
{
    public class PretendRepository : IPretendRepository
    {
        public string GetManagerAccessCode()
        {
            return "Manager9876";
        }

        public string GetWorkerAccessCode()
        {
            return "Worker9876";
        }
    }
}
