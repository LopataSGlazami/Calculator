using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataModels.Entities
{
    public class Authorization
    {
        [ForeignKey("UserInfoKey")]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsConfirmed { get; set; }

        public static string ToHashString(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass))
                throw new ArgumentNullException(nameof(pass));
            using SHA1 hash = SHA1.Create();
            return string
                .Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass))
                .Select(x => x.ToString()));
        }
    }
}
