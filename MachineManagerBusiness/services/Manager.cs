﻿using MachineDashboarding.Istructure;


namespace MachineManagerBusiness.services
{
    public class Manager
    {
        IDAOMachine DAOmachine;
        Mutex mutex;
        public Manager(IDAOMachine dao)
        {
            DAOmachine = dao;
            mutex = new Mutex();

        }


        public void startTracing(int m)
        {
            float lastTemperature=0;
            Thread threadmachine = new Thread(
            () =>
            {
                while (true)
                {

                    if (mutex.WaitOne())
                    {
                        float temperature = DAOmachine.getTemperature(m);
                        if ( lastTemperature != temperature)
                        {
                            lastTemperature = temperature;
                            Console.ForegroundColor = lastTemperature > 50 ? ConsoleColor.Red : ConsoleColor.Blue;
                            Console.WriteLine($"machine : {m} temperature : {lastTemperature}");
                        }
                        mutex.ReleaseMutex();

                    }

                    Console.ResetColor();


                    Thread.Sleep(10000);

                }

            });
            threadmachine.Start();

        }
    }
}
