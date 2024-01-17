using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafioAvanade.Validations
{
    public class validarHoras
    {
        public static int ObterHorasEstacionado()
        {
        
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            int horasEstacionado;

            while(true)
            {
                string horas = Console.ReadLine();
                if(int.TryParse(horas, out horasEstacionado) && horasEstacionado >= 0)
                {
                    break;
                }
                else
                {

                Console.WriteLine("A quantidade de horas é inválida. Deve ser um número positivo.");
                }


            }
            
            return horasEstacionado;

        }
    }
    
}