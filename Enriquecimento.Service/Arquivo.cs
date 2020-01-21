using ICSharpCode.SharpZipLib.Zip;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Enriquecimento.Service
{
    public class Arquivo
    {
        public static void DeletarArquivoZip(string diretorio, string arquivoZip)
        {
            if (File.Exists(diretorio + arquivoZip) == true)
            {
                File.Delete(diretorio + arquivoZip);
            }
        }

        public static void CopiarArquivoOriginalParaPastaProcessado(string diretorioEntrada, string arquivoEntrada, string diretorioSaida)
        {
            if (File.Exists(diretorioSaida + arquivoEntrada) == true)
            {
                File.Delete(diretorioSaida + arquivoEntrada);
            }
            File.Copy(diretorioEntrada + arquivoEntrada, diretorioSaida + arquivoEntrada);
        }

        public static List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados> RetornarSufixoArquivosASerCompactados(int origemAppsettingsJson,
            long idProcedimentoCliente)
        {
            List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados> list = new List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados>();
            list = Data.SqlServer.Enriquecimento.SufixoArquivosCompactados.GetByIdProcedimentoCliente(origemAppsettingsJson, idProcedimentoCliente);
            return (list);
        }

        public static void GerarArquivoCompactado(string nomeArquivos, string diretorioSaida, string arquivoSaidaZip,
            List<Models.SqlServer.Enriquecimento.SufixoArquivosCompactados> listSufixoArquivosCompactados)
        {
            string partialName = nomeArquivos;
            DirectoryInfo hdDirectoryInWhichToSearch = null;
            FileInfo[] filesInDir = null;
            List<string> listDiretorioEArquivo = new List<string>();
            hdDirectoryInWhichToSearch = new DirectoryInfo(diretorioSaida);
            filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
            foreach (FileInfo foundFile in filesInDir)
            {
                if ((foundFile.Directory != null) &&
                    (string.IsNullOrEmpty(foundFile.Directory.FullName) == false) &&
                    (string.IsNullOrEmpty(foundFile.Name) == false) &&
                    (listSufixoArquivosCompactados != null) &&
                    (listSufixoArquivosCompactados.Count > 0))
                {
                    var resultCount = (from t1 in listSufixoArquivosCompactados
                                       where foundFile.Name.ToUpper().Contains(t1.SufixoArquivo.ToUpper()) == true
                                       select t1).Count();
                    if (resultCount > 0)
                    {
                        listDiretorioEArquivo.Add(foundFile.Directory.FullName + "\\" + foundFile.Name);
                    }
                }
            }
            if ((listDiretorioEArquivo != null) && (listDiretorioEArquivo.Count > 0))
            {
                using (ZipOutputStream strmZipOutputStream = new ZipOutputStream(File.Create(diretorioSaida + arquivoSaidaZip)))
                {
                    foreach (var item in listDiretorioEArquivo)
                    {
                        FileInfo fi = new FileInfo(item);
                        ZipEntry entry = new ZipEntry(fi.Name);
                        strmZipOutputStream.PutNextEntry(entry);
                        FileStream fs = File.OpenRead(fi.FullName);
                        try
                        {
                            int bytesRead = 0;
                            var transferBuffer = new byte[1024];
                            do
                            {
                                bytesRead = fs.Read(transferBuffer, 0, transferBuffer.Length);
                                strmZipOutputStream.Write(transferBuffer, 0, bytesRead);
                            }
                            while (bytesRead > 0);
                        }
                        catch
                        { }
                        finally
                        {
                            fs.Close();
                        }
                    }
                    strmZipOutputStream.CloseEntry();
                    strmZipOutputStream.Finish();
                    strmZipOutputStream.Close();
                }
            }
        }
    }
}