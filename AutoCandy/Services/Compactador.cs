using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCandy.Services
{
    public static class Compactador
    {

        public static void Compactar(string diretorio)
        {
            try
            {
                ZipFile.CreateFromDirectory(diretorio, diretorio + ".zip");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao compactar. \n" + e.Message);
            }

        }

        public static void Descompactar(string arquivo, string destino)
        {
            try
            {
                ZipFile.ExtractToDirectory(arquivo, destino);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao descompactar. \n" + e.Message);
            }

        }

    }
}
