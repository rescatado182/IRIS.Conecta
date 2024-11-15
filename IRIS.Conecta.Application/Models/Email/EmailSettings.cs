using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Models.Email
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }

        public string SmtpPort { get; set; }

        public string SmptUsername { get; set; }

        public string SmptPassword { get; set; }

        public string FromAddress { get; set; }

        public string FromName { get; set; }
    }
}
