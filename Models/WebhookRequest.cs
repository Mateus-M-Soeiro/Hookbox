using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hookbox.Models
{
    public class WebhookRequest
    {
        [Required]
        public Guid Id {get;set;}

        [Required]
        public Guid InboxId { get; set; }
        public string Header { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }

        public DateTime ReceivedAt { get; set; }
    }
}