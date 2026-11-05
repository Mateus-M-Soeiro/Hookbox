using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hookbox.Models
{
    public class User
    {
        [Required]
        public Guid Id {get;set;}

        public string Name {get;set;}

        [Required]
        public string Email {get;set;}
        [Required]
        public string PasswordHash {get;set;}

    }
}