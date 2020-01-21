using System;
using System.Text.RegularExpressions;

namespace Enriquecimento.Utils
{
    public class Funcoes
    {
        #region String
        public static string Reverse(string texto)
        {
            if (string.IsNullOrEmpty(texto) == true)
            {
                texto = "";
            }
            char[] charArray = texto.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string RemoverEspacoDuplos(string texto)
        {
            if (string.IsNullOrEmpty(texto) == true)
            {
                texto = string.Empty;
            }
            bool continua = true;
            while (continua)
            {
                if (texto.Contains("  ") == true)
                {
                    texto = texto.Replace("  ", " ");
                }
                else
                {
                    break;
                }
            }
            return texto;
        }

        public static string RemoverAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto) == true)
            {
                texto = "";
            }
            //Acentos no a e A
            texto = Regex.Replace(texto, "[áàâãááààââääããåå]", "a", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[ÁÀÂÃÁÁÀÀÂÂÄÄÃÃÅÅ]", "A", RegexOptions.Singleline);
            //Acentos no e e E
            texto = Regex.Replace(texto, "[éêééèèêêëë]", "e", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[ÉÊÉÉÈÈÊÊËË]", "E", RegexOptions.Singleline);
            //Acentos no i e I
            texto = Regex.Replace(texto, "[ííììîîïï]", "i", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[ÍÍÌÌÎÎÏÏ]", "I", RegexOptions.Singleline);
            //Acentos no o e O
            texto = Regex.Replace(texto, "[óôõóóòòôôööõ]", "o", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[ÓÔÕÓÓÒÒÔÔÖÖÕ]", "O", RegexOptions.Singleline);
            //Acentos no u e U
            texto = Regex.Replace(texto, "[úüüúúùùùûûü]", "u", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[ÚÜÜÚÚÙÙÙÛÛÜ]", "U", RegexOptions.Singleline);
            //Acentos no n e N
            texto = Regex.Replace(texto, "[ñ]", "n", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[Ñ]", "N", RegexOptions.Singleline);
            //Acentos no ç e Ç
            texto = Regex.Replace(texto, "[ç]", "c", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[Ç]", "C", RegexOptions.Singleline);
            //Acentos no y e Y
            texto = Regex.Replace(texto, "[ýýÿ]", "y", RegexOptions.Singleline);
            texto = Regex.Replace(texto, "[ÝÝŸ]", "Y", RegexOptions.Singleline);
            return (texto);
        }

        public static string RemoverCaractersInvalidos(string texto)
        {
            Regex expressao = null;
            if (string.IsNullOrEmpty(texto)==true)
            {
                texto = "";
            }
            expressao = new Regex("[^a-zA-Z0-9\\s]");
            texto = expressao.Replace(texto, "");
            return (texto);
        }

        public static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrEmpty(texto) == true)
            {
                texto = "";
            }
            //Passar para maiusculo
            texto = texto.ToUpper();
            //Remover acentuação
            texto = RemoverAcentos(texto);
            //Remover caracteres inválidos
            texto = RemoverCaractersInvalidos(texto);
            //Retirar os espaços duplos
            texto = RemoverEspacoDuplos(texto);
            //Retirar o espaços no inicio e final
            texto = texto.Trim();
            //Passar para maiusculo
            texto = texto.ToUpper();
            return (texto);
        }
        #endregion
    }
}