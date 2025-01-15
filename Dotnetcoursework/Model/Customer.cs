using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnetcoursework.Model
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        [Unique]
        [Required]
        public string Username { get; set; }

        [Unique]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CurrencyType { get; set; }
    }
}