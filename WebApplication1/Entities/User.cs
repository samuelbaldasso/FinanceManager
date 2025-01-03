using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using BCrypt.Net;

namespace WebApplication1.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private string email;
        private string password;
        private string name;
        private string phone;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Password
        {
            get => password;
            set
            {
                if (string.IsNullOrWhiteSpace(value) && VerifyPassword(password))
                    throw new ArgumentNullException(nameof(value), "Password cannot be null or empty.");
                password = HashPassword(value);
            }
        }

        [EmailAddress]
        public string Email
        {
            get => email;
            private set
            {
                if (!IsValidEmail(value))
                    throw new ArgumentException("Invalid email format.", nameof(value));
                email = value;
            }
        }

        public string Phone
        {
            get => phone;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Phone cannot be null or empty.");
                phone = value;
            }
        }

        public User(string email, string password, string name, string phone)
        {
            Email = email;
            Password = password;
            Name = name;
            Phone = phone;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool VerifyPassword(string passwordToCheck)
        {
            return BCrypt.Net.BCrypt.Verify(passwordToCheck, password);
        }
    }
}