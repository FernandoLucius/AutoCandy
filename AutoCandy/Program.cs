using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AutoCandy
{
    class Program
    {
        static void Main(string[] args)
        {
            const int INTERVALO_DE_TEMPO = 2000;
            const int DIA_PARA_EXECUTAR_ROTINA = 25;

            var exitCode = HostFactory.Run(x => 
            {

                x.Service<RotinaDoceria>(s => 
                {
                    s.ConstructUsing(rotina => new RotinaDoceria(INTERVALO_DE_TEMPO, DIA_PARA_EXECUTAR_ROTINA));
                    s.WhenStarted(rotina => rotina.Start());
                    s.WhenStopped(rotina => rotina.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("AutoCandyService");
                x.SetDisplayName("AutoCandy Service");
                x.SetDescription("Este serviço realiza periodicamente rotinas da Doceria Elefer automaticamente.");

            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode,exitCode.GetTypeCode());
            Environment.ExitCode =  exitCodeValue;

        }
    }
}
