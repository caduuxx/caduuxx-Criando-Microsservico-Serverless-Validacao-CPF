using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite o CPF (somente números): ");
        string cpf = Console.ReadLine();

        if (ValidarCpf(cpf))
            Console.WriteLine("CPF válido!");
        else
            Console.WriteLine("CPF inválido!");
    }

    static bool ValidarCpf(string cpf)
    {
        // Remove caracteres não numéricos
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        // Verifica se o CPF tem 11 dígitos
        if (cpf.Length != 11)
            return false;

        // Verifica se todos os dígitos são iguais (ex.: "111.111.111-11")
        if (cpf.Distinct().Count() == 1)
            return false;

        // Calcula o primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (cpf[i] - '0') * (10 - i);

        int resto = soma % 11;
        int primeiroDigito = (resto < 2) ? 0 : 11 - resto;

        // Calcula o segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (cpf[i] - '0') * (11 - i);

        resto = soma % 11;
        int segundoDigito = (resto < 2) ? 0 : 11 - resto;

        // Verifica os dígitos verificadores
        return cpf[9] - '0' == primeiroDigito && cpf[10] - '0' == segundoDigito;
    }
}


