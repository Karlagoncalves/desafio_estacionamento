using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafioAvanade.Validations
{
    public class validacaoPlaca
    {
        public static bool validarPlaca(string placa, out string mensagemErro)
        {
            mensagemErro = null;

            placa = placa.Trim().Replace("-", "");

            if (placa.Length != 7 && placa.Length != 8)
            {
                mensagemErro = "A placa deve conter 7 caracteres.";
                return false;
            }


            for (int i = 0; i < placa.Length; i++)
            {
                if (!char.IsLetterOrDigit(placa[i]))
                {
                    mensagemErro = "A placa deve conter apenas letras e números";
                    return false;
                }
            }

            return true;
        }
    }
}