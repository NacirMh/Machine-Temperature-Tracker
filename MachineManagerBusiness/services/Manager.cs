using MachineDashboarding.Entities;
using MachineDashboarding.Istructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagerBusiness.services
{
    public class Manager
    {
        IDAOMachine DAOmachine;
        float lastTemperature;

        public Manager(IDAOMachine dao)
        {
            DAOmachine = dao;
        }

        public void demarrerTracing(int m)
        {

            Thread threadmachine = new Thread(new ThreadStart(() =>
            {
                float currentTemperature;
                while (true)
                {
                    currentTemperature = DAOmachine.getTemperature(m);
                    if (lastTemperature != currentTemperature)
                    {
                        lastTemperature = currentTemperature;
                        
                        Console.ForegroundColor =  ConsoleColor.Red;
                        Console.WriteLine(lastTemperature);
                        Console.ResetColor();
                    }

                    Thread.Sleep(10000);
                 
                }

            }));
            threadmachine.Start();

        }
    }
}
