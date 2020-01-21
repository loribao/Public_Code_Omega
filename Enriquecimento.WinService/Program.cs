using System.ServiceProcess;

namespace Enriquecimento.WinService
{
    public static class Program
    {
        public static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Enriquecimento()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}