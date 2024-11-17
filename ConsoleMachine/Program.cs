using MachineDashboarding.Istructure;
using MachineDashboardingDomain.Interfaces;
using MachineDashboardingInfrastructure.DAOImp;
using MachineManagerBusiness.services;

IDAOMachine dbMachine = new DAOImpMachine();




IMachineManagement dashboard = new MachineManagement(dbMachine);


dashboard.startTracing(1);
dashboard.startTracing(2);


while (true)
{
    Console.WriteLine("dashboard working");
    Thread.Sleep(1000 * 10);
}
