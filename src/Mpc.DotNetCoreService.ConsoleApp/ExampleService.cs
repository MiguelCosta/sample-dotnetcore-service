namespace Mpc.DotNetCoreService.ConsoleApp
{
    using System;
    using System.IO;
    using Microsoft.Extensions.PlatformAbstractions;
    using PeterKottas.DotNetCore.WindowsService.Interfaces;

    public class ExampleService : IMicroService
    {
        private IMicroServiceController controller;

        private string fileName = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt");

        public ExampleService()
        {
            controller = null;
        }

        public ExampleService(IMicroServiceController controller)
        {
            this.controller = controller;
        }

        public void Start()
        {
            Console.WriteLine("I started");
            Console.WriteLine(fileName);
            File.AppendAllText(fileName, "Started");
            if (controller != null)
            {
                //controller.Stop();
            }
        }

        public void Stop()
        {
            File.AppendAllText(fileName, "Stopped\n");
            Console.WriteLine("I stopped");
        }
    }
}
