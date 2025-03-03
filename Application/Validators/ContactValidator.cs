using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Services.Exceptions;
using Services.Models;

namespace Services.Validators
{
    public static class ContactValidator
    {
        public static void Validate(ContactMeModel contactDto)
        {
            var errors = new List<string>();

            // Name validation (only letters and spaces)
            if (string.IsNullOrWhiteSpace(contactDto.Name) || !IsAlphabetic(contactDto.Name))
                errors.Add("Name must contain only alphabetic characters and spaces.");

            // Email validation (valid email format)
            if (string.IsNullOrWhiteSpace(contactDto.Email) || !IsValidEmail(contactDto.Email))
                errors.Add("A valid email address is required.");

            // Message validation (only letters, numbers, punctuation)
            if (string.IsNullOrWhiteSpace(contactDto.Message) || !IsValidMessage(contactDto.Message))
                errors.Add("Message contains invalid characters.");

            if (errors.Count > 0)
            {
                Console.WriteLine("Validation errors: " + string.Join(", ", errors)); // For debugging
                throw new ContactValidationException(string.Join(" ", errors));
            }
        }

        private static bool IsAlphabetic(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsValidMessage(string message)
        {
            return Regex.IsMatch(message, @"^[a-zA-Z0-9\s.,!?'-]+$");
        }
    }
}
