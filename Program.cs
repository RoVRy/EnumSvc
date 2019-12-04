using System;
using System.Text;
using System.ServiceProcess;
using System.Configuration;

namespace EnumSvc
{
    class Program
    {
        class CurrentService
        {
            public string ServiceName;
            public string DisplayName;
            public string Status;
        }

        static void Main(string[] args)
        {
            CurrentService CurSvc = new CurrentService();
            ServiceController[] ComSvc,DevSvc;
            ComSvc = ServiceController.GetServices();
            DevSvc = ServiceController.GetDevices();
            int CSc = 0, DSc = 0, CSl = ComSvc.Length, DSl = DevSvc.Length,MinNumOfSvc = (CSl > DSl) ? DSl : CSl;
            while (CSc < CSl && DSc < DSl)
            {
                if (String.Compare(ComSvc[CSc].ServiceName,DevSvc[DSc].ServiceName,true)>0)
                {
                    CurSvc.ServiceName = DevSvc[DSc].ServiceName;
                    CurSvc.DisplayName = DevSvc[DSc].DisplayName;
                    CurSvc.Status = DevSvc[DSc].Status.ToString();
                    DSc++;
                }
                else
                {
                    CurSvc.ServiceName = ComSvc[CSc].ServiceName;
                    CurSvc.DisplayName = ComSvc[CSc].DisplayName;
                    CurSvc.Status = ComSvc[CSc].Status.ToString();
                    CSc++;
                }
                Console.Write(CurSvc.ServiceName); Console.Write('\t');
                Console.Write(CurSvc.DisplayName); Console.Write('\t');
                Console.WriteLine(CurSvc.Status);
            }
            if (DSc == DSl)
               while (++CSc < CSl)
               {
                    Console.Write(ComSvc[CSc].ServiceName); Console.Write('\t');
                    Console.Write(ComSvc[CSc].DisplayName); Console.Write('\t');
                    Console.WriteLine(ComSvc[CSc].Status.ToString());
                    
               }
            else while (++DSc < DSl)
                {
                    Console.Write(DevSvc[DSc].ServiceName); Console.Write('\t');
                    Console.Write(DevSvc[DSc].DisplayName); Console.Write('\t');
                    Console.WriteLine(DevSvc[DSc].Status.ToString());
                }
            }
        }
    }
