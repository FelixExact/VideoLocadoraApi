﻿using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FD.Videolocadora.Presentation.UI.App_Start.Identity
{
    public class EmailServico : IIdentityMessageService
    {
        private readonly string EMAIL_ORIGEM = "Felixgustavodonel@gmail.com";
        private readonly string EMAIL_SENHA = "UMHS7591";
        public async Task SendAsync(IdentityMessage message)
        {
            using (var mensagemDeEmail = new MailMessage())
            {
                mensagemDeEmail.From = new MailAddress(EMAIL_ORIGEM);

                mensagemDeEmail.Subject = message.Subject;
                mensagemDeEmail.To.Add(message.Destination);
                mensagemDeEmail.Body = message.Body;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(EMAIL_ORIGEM, EMAIL_SENHA);

                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;

                    smtpClient.Timeout = 20_000;
                    await smtpClient.SendMailAsync(mensagemDeEmail);
                }
            }

            
            throw new NotImplementedException();
        }
    }
}