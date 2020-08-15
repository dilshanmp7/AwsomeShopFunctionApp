using System;
using System.Collections.Generic;
using System.Text;

namespace AwsomeShop.AzureFunctions.Email
{
    public class EmailConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Sender { get; set; }
        public string  Password { get; set; }

        public EmailConfig(string host,int port, string sender,string password)
        {
            if (host == null)
            {
                throw new ArgumentException(nameof(host));
            }

            if (sender == null)
            {
                throw new ArgumentException(nameof(Sender));
            }

            if (host == null)
            {
                throw new ArgumentException(nameof(host));
            }

            if (password == null)
            {
                throw new ArgumentException(nameof(Password));
            }

            Host = host;
            Port = port;
            Sender = sender;
            Password = password;

        }


    }
}
