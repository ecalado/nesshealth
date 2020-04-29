using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static System.Convert;

namespace Challenge.Models
{
    public class ValidCPFAttribute : ValidationAttribute
    {
        public ValidCPFAttribute(bool required)
        {
            Required = required;
        }

        public bool Required { get; }

        protected override ValidationResult
        IsValid(object value, ValidationContext validationContext)
        {
           if (IsCpf((string) value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("O CPF é invalido!");
            }
        }
        private bool IsCpf(string strCpf)
        {
            if (Required)
            {
                if (string.IsNullOrEmpty(strCpf))
                    return false;
            } else
            {
                if (string.IsNullOrEmpty(strCpf))
                    return true;
            }

            strCpf = strCpf.Trim().Replace(".", "").Replace("-", "");
            if (strCpf.Length != 11)
                return false;

            if (strCpf.All(x => x == strCpf[0]))
                return false;

            var listCpf = strCpf.Select(num => ToInt32(num.ToString())).ToList();

            if (listCpf[9] != Mod11Cpf(listCpf, 10))
                return false;

            if (listCpf[10] != Mod11Cpf(listCpf, 11))
                return false;

            return true;
        }
        private int Mod11Cpf(List<int> elementos, int @base)
        {
            int soma = 0;
            for (int i = 0; i < (@base - 1); i++)
                soma += (@base - i) * elementos[i];

            int dv1, resto = soma % 11;

            if (resto < 2)
                dv1 = 0;
            else
                dv1 = 11 - resto;

            return dv1;
        }
    }
}
