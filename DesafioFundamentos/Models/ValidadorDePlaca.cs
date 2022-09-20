using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    internal static class ValidadorDePlaca
    {

        public static bool ValidarPlaca(string placa)
        {

            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8 || placa.Length < 7) { return false; }

            placa = placa.Replace("-", "").Trim();

            /*
             * Regex gerado em conformidade com RESOLUÇÃO Nº 780, DE 26 DE JUNHO DE 2019
             * A mesma demonstra o padrão para placas de veículos
             */

            var padraoMercosul = new Regex(@"[a-zA-Z]{3}[0-9]{1}[a-zA-Z\d]{1}[0-9]{2}");


            if (padraoMercosul.IsMatch(placa)) 
            {
                /*
                 *  Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                 */
                return padraoMercosul.IsMatch(placa);
            }

            //Bloco else abaixo preterido, validação mais completa via regex foi possível
            //else
            //{
            //    // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
            //    var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
            //    return padraoNormal.IsMatch(placa);
            //}

            return false;
        }


    }
}
