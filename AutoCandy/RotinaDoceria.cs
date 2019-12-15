using AutoCandy.Services;
using System;
using System.Timers;

namespace AutoCandy
{
    public class RotinaDoceria
    {
        private readonly Timer _timer;
        private readonly int _dia;

        public RotinaDoceria(int miliseconds, int diaRotina = 1, bool autoReset = true)
        {
            _dia = diaRotina;
            _timer = new Timer(miliseconds) { AutoReset = autoReset };
            _timer.Elapsed += TimerElapsed; 
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            RotinaEnviarNotasContador(_dia);
        }

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();

        private void RotinaEnviarNotasContador(int dia)
        {
            // Verificar se notas do mês anterior já foram enviadas para o contator.
            //TODO

            if (isDiaParaExecutarRotina(dia))
            {
                //Compactar CF-e-SAT transmitidas
                Compactador.Compactar(@"C:\Users\prod-flgodinho\Desktop\Teste");

                //Enviar email para o contador

                //
                
            }
        }

        private bool isDiaParaExecutarRotina(int diaParaExecutar)
        {
            if ((diaParaExecutar < 1) || (diaParaExecutar > 31))
                return false;

            return DateTime.Now.Day == diaParaExecutar;
        }

        //string[] lines = new string[] { s };
        //File.AppendAllLines(@"C:/AutoCandyTest.txt", lines);
    }
}
