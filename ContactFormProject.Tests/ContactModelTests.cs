using ContactFormProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace ContactFormProject.Tests
{
    public class ContactModelTests
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public void ContactModel_ValidModel_NoValidationErrors()
        {
            var model = new ContactModel
            {
                Imie = "Jan",
                Email = "jan@example.com",
                Wiadomosc = "To jest testowa wiadomość."
            };

            var results = ValidateModel(model);
            Assert.Empty(results);
        }

        [Fact]
        public void ContactModel_EmptyFields_ShouldHaveValidationErrors()
        {
            var model = new ContactModel();
            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Imie"));
            Assert.Contains(results, r => r.MemberNames.Contains("Email"));
            Assert.Contains(results, r => r.MemberNames.Contains("Wiadomosc"));
        }

        [Fact]
        public void ContactModel_InvalidEmail_ShouldFailValidation()
        {
            var model = new ContactModel
            {
                Imie = "Anna",
                Email = "nieprawidlowy-email",
                Wiadomosc = "Test"
            };

            var results = ValidateModel(model);
            Assert.Contains(results, r => r.MemberNames.Contains("Email"));
        }

        [Fact]
        public void Email_ZbytDlugi_ShouldFailValidation()
        {
            var model = new ContactModel
            {
                Imie = "Anna",
                Email = new string('a', 250) + "@example.com", // ponad 254 znaki
                Wiadomosc = "Przykładowa wiadomość"
            };

            var results = ValidateModel(model);

            Assert.Contains(results, r => r.MemberNames.Contains("Email"));
        }
    }
}
