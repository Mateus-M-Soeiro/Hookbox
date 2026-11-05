using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hookbox.Models
{
    public class Inbox
    {

        [Required]
        public Guid Id {get;set;}
        [Required]
        public Guid UserId {get;set;}

        public string Name {get;set;}

        public string Description {get;set;}

        //Unique  identification 
        public string Token {get;set;}

        public DateTime CreatedAt {get;set;}

        public DateTime ExpireAt {get;set;}
    }
}