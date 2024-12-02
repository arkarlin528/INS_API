using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net.Security;
using System.Net;
using ZeroBug.Helper;

namespace ZeroBug.Service
{
    public class Mail
    {
        public string   SenderEmail   { get; set; }
        public string   SenderName    { get; set; }
        public string   ToEmail       { get; set; }
        public string   ToName        { get; set; }
        public string   Subject       { get; set; }
        public string   Content       { get; set; }
        public string   BCC           { get; set; }
        public string   CC { get; set; }
        private string  Address     { get; set; }
        private int     Port        { get; set; }
        private bool    EnableSSL   { get; set; }
        private string  User        { get; set; }
        private string  Password    { get; set; }

        public bool MultipleRecipients = false;

        private bool UseDefault = true;


        public string[] AttachFiles { get; protected set; }

        public Mail(string address, int port, bool enableSSL, string user, string password) : base()
        {
            UseDefault = false;

            this.Address    = address;
            this.Port       = port;
            this.EnableSSL  = enableSSL;
            this.User       = user;
            this.Password   = password;


            AttachFiles = new string[0];
        }

        public void SetAttachment(string [] files)
        {
            AttachFiles = files;
        }

        public Mail()
        {
            UseDefault  = true;
            AttachFiles = new string[0];
            SenderEmail = ZeroBug.Helper.Utils.AppSetting["Smtp.SenderEmail"];
        }

        private SmtpClient GetSmtp()
        {
            SmtpClient smtp = new SmtpClient();

            smtp.DeliveryMethod         = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials  = false;
            smtp.Timeout                = 20000;

            if (UseDefault)
            {
                smtp.Host           = ZeroBug.Helper.Utils.AppSetting["Smtp.Address"];
                smtp.Port           = ZeroBug.Helper.Utils.AppSetting["Smtp.Port"].ToInt();
                smtp.EnableSsl      = ZeroBug.Helper.Utils.AppSetting["Smtp.EnableSSL"].ToBool();

                smtp.Credentials    = new NetworkCredential(ZeroBug.Helper.Utils.AppSetting["Smtp.User"], 
                    ZeroBug.Helper.Utils.AppSetting["Smtp.Password"]);
            }
            else
            {
                smtp.Host           = this.Address;
                smtp.Port           = this.Port;
                smtp.EnableSsl      = this.EnableSSL;
                if (!string.IsNullOrEmpty(this.User))
                {
                    smtp.Credentials = new NetworkCredential(this.User, this.Password);
                }
            }

            return smtp;
        }

        public void Send()
        {
            SmtpClient smtp     = GetSmtp();
            MailAddress from    = new MailAddress(SenderEmail, string.IsNullOrEmpty(SenderName) ? SenderEmail : SenderName);
            MailMessage message = new MailMessage();
            if (!this.MultipleRecipients)
            {
                MailAddress to = new MailAddress(ToEmail, string.IsNullOrEmpty(ToName) ? ToName : ToEmail);
                message.To.Add(to);
            }
            else
            {
                foreach(var email in this.ToEmail.Split(';'))
                {
                    if (email.IsEmpty())
                        continue;

                    MailAddress to = new MailAddress(email);
                    message.To.Add(to);
                }
            }

            message.From = from;

            if (!string.IsNullOrEmpty(BCC))
            {
                message.Bcc.Add(new MailAddress(BCC));
            }

            if (!string.IsNullOrEmpty(CC))
            {
                foreach (var ccemail in this.CC.Split(';'))
                {
                    if (ccemail.IsEmpty())
                        continue;

                    MailAddress cc = new MailAddress(ccemail);
                    message.CC.Add(cc);
                }
            }

            foreach (var file in AttachFiles)
            {
                Attachment attachment = new Attachment(file);
                message.Attachments.Add(attachment);
            }

            message.Body        = Content;
            message.Subject     = Subject;
            message.Priority    = MailPriority.High;
            message.IsBodyHtml  = true;

            try
            {
                smtp.SendCompleted += (s, e) =>
                {
                    message.Dispose();
                    smtp.Dispose();
                };
                smtp.Send(message);
            }
            catch(Exception ex)
            {

            }           
            
        }


    }
}
