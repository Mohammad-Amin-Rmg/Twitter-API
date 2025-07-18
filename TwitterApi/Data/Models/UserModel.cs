﻿using System.ComponentModel.DataAnnotations;

namespace TwitterApi.Data.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public required string UserName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [RegularExpression("^0[0-9]{10}",ErrorMessage = "Incorrect phone number format")]
        public string PhoneNumber { get; set; }

    }
}
