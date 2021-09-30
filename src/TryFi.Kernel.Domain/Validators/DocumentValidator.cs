using FluentValidation;

namespace TryFi.Kernel.Domain.Validators
{
    public static class DocumentValidator
    {
        public static IRuleBuilderOptions<T, string> IsValidDocument<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(p => CheckDocument(p)).WithSeverity(Severity.Error);
        }

        public static IRuleBuilderOptions<T, string> IsCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(p => IsCPF(p));
        }

        public static IRuleBuilderOptions<T, string> IsCNPJ<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(p => IsCNPJ(p));
        }


        private static bool CheckDocument(string document)
        {
            if (IsCNPJ(document)) return true;
            if (IsCPF(document)) return true;

            return false;
        }

        public static string NormalizeDocument(string documentNumber)
        {
            if (string.IsNullOrEmpty(documentNumber)) return string.Empty;

            documentNumber = documentNumber
                .Replace("-", "")
                .Replace(".", "")
                .Replace(",", "")
                .Replace("/", "")
                .Replace(@"\", "")
                .Replace("Null", "", StringComparison.InvariantCultureIgnoreCase)
                .Trim();

            return documentNumber;
        }
        public static bool IsCPF(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digit;
            int sum;
            int rest;

            cpf = NormalizeDocument(cpf);

            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf += digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit += rest.ToString();
            return cpf.EndsWith(digit);
        }
        public static bool IsCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }

    }
}
