using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafioAvanade.Validations
{
    public class validarEntradaValoresIniciais
    {
        public static T ObterNumeroPositivo<T>() where T : struct
        {
            T valor;

            do
            {
                string input = Console.ReadLine();

                try
                {
                    valor = (T)Convert.ChangeType(input, typeof(T));

                    if (Convert.ToDouble(valor) >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido. Por favor, insira um número positivo.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ocorreu um erro inesperado. Por favor, tente novamente.");
                }

            } while (true);

            return valor;
        }
    }
}