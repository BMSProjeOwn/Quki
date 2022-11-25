using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Quki.Bll.Base;
using Quki.Dal.Abstract;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;
using Quki.Interface;

namespace Quki.Bll
{
    public class DocumentsManager : BllBase<Document, DocumentModel>, IDocumentsService
    {
        public readonly IDocumentsRepository repo;
        public DocumentsManager(IServiceProvider service) : base(service)
        {
            repo = service.GetService<IDocumentsRepository>();
        }
        public Document GetDocumentByMenuId(int menuID)
        {
            return TGetList(I => I.MenuID == menuID && I.Status == true).FirstOrDefault();
        }
        public Document GetDocumentByMenuId(int menuID, int languageId)
        {
            Document d = new Document();
            try
            {
                d = TGetList(I => I.MenuID == menuID && I.Status == true && I.LanguageID.Equals(languageId)).FirstOrDefault();
            }
            catch { }
            return d;
        }
        public void DocumentUpdateByDocumetSeqID(Document model)
        {
            var document = TGetList(I => I.DocumentSeqID == model.DocumentSeqID).FirstOrDefault();
            document.Header = model.Header;
            document.Header2 = model.Header2;
            document.Contents = model.Contents;
            document.LanguageID = model.LanguageID;
            TUpdate(document);
        }
        public Document GetImagePath(int menuId)
        {
            return TGetList(I => I.MenuID == menuId).FirstOrDefault();
        }
        public bool Create(DocumentModel documentModel)
        {
            Document document = new Document();

            document.Header = documentModel.Header;
            document.Header2 = documentModel.Header2;
            document.Contents = documentModel.Contents;
            document.Status = documentModel.Status;
            document.Date = DateTime.Now;
            document.LanguageID = documentModel.LanguageID;
            document.MenuID = document.MenuID;

            TAdd(document);
            document.DocumentID = document.DocumentSeqID;
            document.MenuID = document.DocumentSeqID;
            TUpdate(document);
            return true;
        }

    }
}
