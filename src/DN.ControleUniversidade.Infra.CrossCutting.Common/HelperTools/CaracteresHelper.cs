using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DN.ControleUniversidade.Infra.CrossCutting.Common.HelperTools
{
    public class CaracteresHelper
    {
        public static string SomenteNumeros(string texto)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(texto, "");
            return resultString;
        }
    }
}
