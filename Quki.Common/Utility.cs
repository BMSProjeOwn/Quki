using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Quki.Common
{
    public class Utility
    {
        public static DateTime UnixTimeStampToDateTime(string unixTimeStamp)
        {
            long unixTimeStampd = Convert.ToInt64(unixTimeStamp);
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStampd).ToLocalTime();
            return dtDateTime;
        }
        public static string StringToMoney(string money)
        {
            string yeniPara = "";
            string[] mony = money.Split('.');
            if (mony.Length > 1)
            {
                string virguldenSonrasi = mony[1].ToString();
                yeniPara = mony[0].ToString();

                string karakter2 = virguldenSonrasi.Substring(0, 2).ToString();

                yeniPara = yeniPara +","+ karakter2;
            }
            return yeniPara;
        }

        // Unix timestamp is seconds past epoch
       

    public static bool SendMail(string from, string to, string subject, string body, string _mailServer, int _mailServerPort, string _mailUsername, string _mailPassword)
    {
        Boolean sonuc = false;
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(from));
        message.To.Add(new MailboxAddress(to));
        message.Subject = subject;
        message.Body = new TextPart("html")
        {
            Text = body
        };
        using (var client = new SmtpClient())
            {

              client.CheckCertificateRevocation = true;
                client.ServerCertificateValidationCallback = (s, c,ch, e) => true;
                client.Connect(_mailServer, _mailServerPort);
            client.Authenticate(from, _mailPassword);
            client.Send(message);
            client.Disconnect(false);
        }
        return sonuc;
    }

    //
    public static string ResizeImage(IFormFile file, int width, int height, string filePath)
    {

        using var image = Image.Load(file.OpenReadStream());
        image.Mutate(x => x.Resize(width, height));
        image.Save(filePath);
        return filePath;
    }
    //

}
}
