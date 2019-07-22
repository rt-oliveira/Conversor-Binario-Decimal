using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConversorBinarioDecimal
{
    class Conversao
    {
        /* Esse atributo 'testador' será o responsável por dizer se o que o usuário está digitando
           é um número binário válido ou não.
           Este Regex (^[0-1]+$) significa: só pode ter caracteres 0 ou 1, a combinação desses dois caracteres
           tem que ter pelo menos 1 caractere de tamanho.*/
        private static readonly Regex testador = new Regex("^[0-1]+$");
        public static bool EhValido(string entrada)
        {
            // Método que testará a validade do que o usuário digitou, de ser um número binário válido.
            return testador.IsMatch(entrada);
        }

        public static string ConverterParaBinario(string entrada)
        {
            // Método que fará a conversão do número válido digitado para a base decimal.
            try
            {
                /* Os comandos no 'try' tentarão fazer a conversão em si, onde em cada bit digitado verá se é 0 ou 1,
                   e seu valor será multiplicado pelo valor daquela posição, na base decimal, isto é:
                   O bit mais à direita vale 1, o segundo mais à direita vale 2, o terceiro, 4, e assim por diante. */
                UInt64 result_num = 0;
                for (int i = 0; i < entrada.Length; i++)
                {
                    UInt64 temp = Convert.ToUInt64(entrada[entrada.Length - i - 1] - '0');
                    result_num += Convert.ToUInt64(Math.Pow(2, i) * temp);
                }
                return result_num.ToString();
            }
            catch
            {
                /* Caso o número binário digitado seja grande a tal ponto que não caiba em um inteiro de 64 bits sem sinal,
                   uma exceção gerá gerada, e o método retornará 'null'. */
                return null;
            }
        }
    }
}
