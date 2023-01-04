using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public class CPFValidator
    {
        // Valida um CPF
        public static bool ValidaCPF(string cpf)
        {
            // Verifica se o CPF tem 11 dígitos aceitando ou não pontos e hífens
            if (!Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") &&
    !Regex.IsMatch(cpf, @"^\d{11}$"))
            {
                return false;
            }
            cpf = cpf.Replace(".", "").Replace("-", "");
            // Calcula os dígitos verificadores
            int dv1 = CalculaDV1(cpf);
            int dv2 = CalculaDV2(cpf, dv1);

            // Verifica se os dígitos verificadores são iguais aos últimos dois dígitos do CPF
            if (cpf[9] - '0' != dv1 || cpf[10] - '0' != dv2)
            {
                return false;
            }

            return true;
        }

        // Calcula o primeiro dígito verificador
        static int CalculaDV1(string cpf)
        {
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }
            int dv1 = 11 - (soma % 11);
            if (dv1 >= 10) dv1 = 0;
            return dv1;
        }

        // Calcula o segundo dígito verificador
        static int CalculaDV2(string cpf, int dv1)
        {
            int soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }
            int dv2 = 11 - (soma % 11);
            if (dv2 >= 10) dv2 = 0;
            return dv2;
        }
    }
}