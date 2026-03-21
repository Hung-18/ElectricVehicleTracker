using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        private static readonly Regex phoneReg = new Regex(@"^0[0-9]{9}$");
        private static readonly Regex emailReg = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        [Key]
        public Guid UserId { get;private set; }
        [Required]
        public string UserName { get;private set; }
        public string Password { get;private set; }
        [EmailAddress]
        public string Email { get;private set; }
        [Phone]
        public string PhoneNumber { get;private set; }
        [Required]
        public string IdentityCard { get;private set; }
        public string Role { get;private set; }
        public bool IsActive { get;private set; }

        public ICollection<ElectricVehicle> vehicles { get;private set; }

        public User()
        {
        }

        public User(string userName, string password, string email, string phoneNumber, string identityCard, string role, bool isActive)
        {
            UserId =  Guid.NewGuid();
            
            if(string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("UserName must be at least 6 characters long.");
            }
            UserName = userName;
            
            if(string.IsNullOrEmpty(password) || password.Length < 6)
            {
                throw new ArgumentException("Password cannot contain whitespace.");
            }
            Password = password;
            
            if(!emailReg.IsMatch(email))
            {
                throw new ArgumentException("Invalid email format.");
            }
            Email = email;
            
            if(!phoneReg.IsMatch(phoneNumber))
            {
                throw new ArgumentException("Invalid phone number format.");
            }
            PhoneNumber = phoneNumber;
            
            if(string.IsNullOrEmpty(identityCard) || identityCard.Length < 10)
            {
                throw new ArgumentException("Identity card cannot be empty.");
            }
            IdentityCard = identityCard;    
            Role = role;
            IsActive = isActive;
        }

        public void UpdatePasswords(string hashPassword)
        {
            if (string.IsNullOrEmpty(hashPassword)) throw new Exception("Password cannot empty");
            Password = hashPassword;
        }

        public void SetRole(string role)
        {
            Role = role;
        }
        public void SetIsActive(bool active)
        {
            IsActive = active;
        }
    }
}
