using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataModels.Entities
{
    public class User : EntityBase
    {
        public string Nick { get; set; } = null!;
        public Authorization? Authorization {get;set;}
        public bool RememberMe { get; set; }

        public IList<History> Histories { get; set; } = new List<History>();

        public static readonly Guid GustGuid = new Guid("28A81A21-FABA-4C0F-827E-5B3E567A5523");
        public const string GuestNick = "Гость";

        public static readonly User Gust = new User()
        {
            Nick = GuestNick,
            Id = GustGuid
        };
    }
}
