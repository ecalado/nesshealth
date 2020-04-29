using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Challenge.Models
{
    public class ValidPhoneNumberAttribute : ValidationAttribute
    {
        public ValidPhoneNumberAttribute(bool required)
        {
            Required = required;
        }

        public bool Required { get; }

        protected override ValidationResult
        IsValid(object value, ValidationContext validationContext)
        {
            if (IsValidPhoneNumber((string)value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("O Número do Telefone é invalido!");
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            if (Required)
            {
                if (string.IsNullOrEmpty(phone))
                    return false;
            }
            else
            {
                if (string.IsNullOrEmpty(phone))
                    return true;
            }

            var phoneNumber = phone.Trim()
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("(", "")
            .Replace(")", "");
            return Regex.Match(phoneNumber, @"^\+\d{5,15}$").Success;
        }
    }
}
