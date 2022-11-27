using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Entity.Parameters;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class EmailTemplateRepository : GenericRepository<NotificationTemplatess>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(DbContext context) : base(context)
        {

        }
        //public void AddEmailTemplate(EmailTemplateAddModel emailTemplateAddModel)
        //{
        //    string newPath="";
        //    int imageHeight = 0;
        //    int imageWidth = 0;
        //    if (emailTemplateAddModel.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(emailTemplateAddModel.ImagePath.FileName);
        //        newPath = Guid.NewGuid() + path;
        //        var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/EmailTamplateImg/" + newPath;
        //        var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/EmailTamplateImg/Thump" + newPath;
        //        using (var steem = new FileStream(ImagePath, FileMode.Create))
        //        {
        //            emailTemplateAddModel.ImagePath.CopyTo(steem);
        //        }
        //        Utility.ResizeImage(emailTemplateAddModel.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
        //        using (var image = new Bitmap(System.Drawing.Image.FromFile(ImagePath)))
        //        {
        //            imageHeight = image.Height;
        //            imageWidth = image.Width;
        //        }
        //    }
        //    var entity = new NotificationTemplatess
        //    {
        //        NotificationTemplateName = emailTemplateAddModel.NotificationTemplateName,
        //        NotificationTemplateGroupID = emailTemplateAddModel.NotificationTemplateGroupID,
        //        NotificationHeader = emailTemplateAddModel.NotificationHeader,
        //        NotificationContent = emailTemplateAddModel.NotificationContent,
        //        NotificationFooter = emailTemplateAddModel.NotificationFooter,
        //        İsActive = true,
        //        LanguageID = emailTemplateAddModel.LanguageID,
        //        WhatsupInformation = "",
        //        BackgroundIamagePath = "/AdminImage/EmailTamplateImg/" + newPath,
        //        ThumpImagePath = "/AdminImage/EmailTamplateImg/Thump" + newPath,
        //        NotificationlTypeID=2

        //    };
        //    var mailTamplatePath = Directory.GetCurrentDirectory() + "/wwwroot/MailTemplate/MailTamplate.htm";
        //    string MailTamplate = "";
        //    try
        //    {
        //        using (var srdd = new StreamReader(mailTamplatePath))
        //        {
        //            MailTamplate = srdd.ReadToEnd();
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    MailTamplate = MailTamplate.Replace("@imageWidth", imageWidth.ToString());
        //    MailTamplate = MailTamplate.Replace("@imageHeight", imageHeight.ToString());
        //    MailTamplate = MailTamplate.Replace("@Content", emailTemplateAddModel.NotificationContent == null ? "" : emailTemplateAddModel.NotificationContent);
        //    MailTamplate = MailTamplate.Replace("@linkImage", "" + "https://Quki.com/" + "/AdminImage/EmailTamplateImg/" + newPath);
        //    MailTamplate = MailTamplate.Replace("@Header", "" + emailTemplateAddModel.NotificationHeader == null ? "" : emailTemplateAddModel.NotificationHeader);
        //    MailTamplate = MailTamplate.Replace("@Footer", "" + emailTemplateAddModel.NotificationFooter == null ? "" : emailTemplateAddModel.NotificationFooter);

        //    entity.NotificationInstraction = MailTamplate;
        //    TAdd(entity);
        //}

        //public void TestEmailTemplate(EmailTemplateAddModel emailTemplateAddModel)
        //{
        //    string newPath="";
        //    int imageHeight = 0;
        //    int imageWidth = 0;
        //    if (emailTemplateAddModel.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(emailTemplateAddModel.ImagePath.FileName);
        //        newPath = Guid.NewGuid() + path;
        //        string ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/EmailTamplateImg/" + newPath;
        //        var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/EmailTamplateImg/Thump" + newPath;
        //        using (var steem = new FileStream(ImagePath, FileMode.Create))
        //        {
        //            emailTemplateAddModel.ImagePath.CopyTo(steem);
        //        }
        //        Utility.ResizeImage(emailTemplateAddModel.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
        //        using (var image = new Bitmap(System.Drawing.Image.FromFile(ImagePath)))
        //        {
        //            imageHeight = image.Height;
        //            imageWidth = image.Width;
        //        }
        //    }
        //    var mailTamplatePath = Directory.GetCurrentDirectory() + "/wwwroot/MailTemplate/MailTamplate.htm";
        //    string MailTamplate = "";
        //    try
        //    {
        //        using (var srdd = new StreamReader(mailTamplatePath))
        //        {
        //            MailTamplate = srdd.ReadToEnd();
        //        }
        //    }
        //    catch
        //    {

        //    }


        //    MailTamplate = MailTamplate.Replace("@imageWidth", imageWidth.ToString());
        //    MailTamplate = MailTamplate.Replace("@imageHeight", imageHeight.ToString());
        //    MailTamplate = MailTamplate.Replace("@Content", emailTemplateAddModel.NotificationContent==null? "": emailTemplateAddModel.NotificationContent);
        //    MailTamplate = MailTamplate.Replace("@linkImage", "" + "https://Quki.com/" + "/AdminImage/EmailTamplateImg/" + newPath);
        //    MailTamplate = MailTamplate.Replace("@Header", "" + emailTemplateAddModel.NotificationHeader == null ? "": emailTemplateAddModel.NotificationHeader);
        //    MailTamplate = MailTamplate.Replace("@Footer", "" + emailTemplateAddModel.NotificationFooter == null ? "": emailTemplateAddModel.NotificationFooter);

        //    Utility.SendMail("info@Quki.com", "muhammed.merdini@gmail.com", "Qukiya Hoşgeldiniz!", MailTamplate, "mail.Quki.com", 587, "info@Quki.com ", "Quki.34076");

        //}
        //public NotificationTemplatess FindTamplewithId(int TypeId)
        //{

        //    var item = dbset.Find(TypeId);


        //    return item;
        //}



        //public List<NotificationTemplatess> GetTemplateList()
        //{

        //    var items = dbset.Where(a => a.İsActive == true).ToList();
            

        //    return items.ToList().OrderByDescending(u => u.NotificationTemplatesSeqID).ToList();
        //}



        //public bool UpdateEmailTemplate(EmailTemplateAddModel model)
        //{
        //    var Item = TgetItemByID(model.NotificationTemplatesSeqID);

        //    int imageHeight = 0;
        //    int imageWidth = 0;

        //    Item.NotificationTemplateName = model.NotificationTemplateName;
        //    Item.NotificationHeader = model.NotificationHeader;
        //    Item.NotificationContent = model.NotificationContent;
        //    Item.LanguageID = model.LanguageID;
        //    Item.NotificationFooter = model.NotificationFooter;
        //    string newPath = "";
        //    if (model.ImagePath != null)
        //    {
        //        var path = Path.GetExtension(model.ImagePath.FileName);
        //        newPath = Guid.NewGuid() + path;
        //        var ImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/EmailTamplateImg/" + newPath;
        //        var ThumbImagePath = Directory.GetCurrentDirectory() + "/wwwroot/AdminImage/EmailTamplateImg/Thump" + newPath;
        //        using (var steem = new FileStream(ImagePath, FileMode.Create))
        //        {
        //            model.ImagePath.CopyTo(steem); 
        //        }
        //        Utility.ResizeImage(model.ImagePath, ProductImageSize.Height, ProductImageSize.Width, ThumbImagePath);
        //        Item.BackgroundIamagePath = "/AdminImage/EmailTamplateImg/" + newPath;
        //        Item.ThumpImagePath = "/AdminImage/EmailTamplateImg/Thump" + newPath;
        //    }
        //    using (var image = new Bitmap(System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/wwwroot/" + Item.BackgroundIamagePath)))
        //    {
        //        imageHeight = image.Height;
        //        imageWidth = image.Width;
        //    }
        //    var mailTamplatePath = Directory.GetCurrentDirectory() + "/wwwroot/MailTemplate/MailTamplate.htm";
        //    string MailTamplate = "";
        //    try
        //    {
        //        using (var srdd = new StreamReader(mailTamplatePath))
        //        {
        //            MailTamplate = srdd.ReadToEnd();
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    MailTamplate = MailTamplate.Replace("@imageWidth", imageWidth.ToString()+"px");
        //    MailTamplate = MailTamplate.Replace("@imageHeight", imageHeight.ToString() + "px");
        //    MailTamplate = MailTamplate.Replace("@Content", Item.NotificationContent == null ? "" : Item.NotificationContent);
        //    MailTamplate = MailTamplate.Replace("@linkImage", "" + "https://Quki.com/" + Item.BackgroundIamagePath);
        //    MailTamplate = MailTamplate.Replace("@Header", "" + Item.NotificationHeader == null ? "" : Item.NotificationHeader);
        //    MailTamplate = MailTamplate.Replace("@Footer", "" + Item.NotificationFooter == null ? "" : Item.NotificationFooter);
        //    Item.NotificationInstraction = MailTamplate;
        //    TUpdate(Item);

        //    return true;
        //}



        //public EmailTemplateAddModel getEmailTemplateByID(int id)
        //{
        //    EmailTemplateAddModel mymodel = new EmailTemplateAddModel();
        //    var Item = TgetItemByID(id);
        //    mymodel.NotificationTemplateName = Item.NotificationTemplateName;
        //    mymodel.NotificationHeader = Item.NotificationHeader;
        //    mymodel.NotificationFooter = Item.NotificationFooter;
        //    mymodel.LanguageID = Item.LanguageID;
        //    mymodel.NotificationContent = Item.NotificationContent;
        //    mymodel.NotificationInstraction = Item.NotificationInstraction;
        //    mymodel.NotificationTemplatesSeqID = Item.NotificationTemplatesSeqID;
        //    mymodel.BackgroundIamagePath = Item.BackgroundIamagePath;
        //    return mymodel;
        //}

        //public bool DeleteEmailTemplate(int id)
        //{
        //    EmailTemplateAddModel mymodel = new EmailTemplateAddModel();
        //    var Item = TgetItemByID(id);
        //    Item.İsActive = false;
        //    TUpdate(Item);
        //    return true;
        //}

        //public List<NotificationTemplatess> GetTemplateListByType(int TypeID)
        //{

        //    var items = dbset.Where(a => a.İsActive == true && a.NotificationlTypeID== TypeID).ToList();


        //    return items.ToList().OrderByDescending(u => u.NotificationTemplatesSeqID).ToList();
        //}


    }
}
