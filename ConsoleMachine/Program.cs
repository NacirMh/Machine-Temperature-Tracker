using MachineDashboarding.Entities;
using MachineDashboarding.Istructure;
using MachineDashboardingInfrastructure.DAOImp;
using MachineManagerBusiness.services;

IDAOMachine dbMachine = new DAOImpMachine();



Manager dashboard = new Manager(dbMachine);






dashboard.startTracing(1);
dashboard.startTracing(2);


while (true)
{
    Console.WriteLine("dashboard working");
    Thread.Sleep(1000 * 10);
}
