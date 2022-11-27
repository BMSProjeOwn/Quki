using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Abstract;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Concrete.Entityframework.Repostories
{
    public class DocumentsRepository : GenericRepository<Document>, IDocumentsRepository
    {
        public DocumentsRepository(DbContext context) : base(context)
        {
            
        }
        //public Document GetDocumentByMenuId(int menuID)
        //{
        //    return dbset.Where(I => I.MenuID == menuID && I.Status == true).FirstOrDefault();
        //}
        //public Document GetDocumentByMenuId(int menuID, int languageId)
        //{
        //    Document d = new Document();
        //    try
        //    {
        //        d = dbset.Where(I => I.MenuID == menuID && I.Status == true && I.LanguageID.Equals(languageId)).FirstOrDefault();
        //    }
        //    catch { }
        //    return d;
        //}
        //public void DocumentUpdateByDocumetSeqID(Document model)
        //{
        //    var document = dbset.Where(I => I.DocumentSeqID == model.DocumentSeqID).FirstOrDefault();
        //    document.Header = model.Header;
        //    document.Header2 = model.Header2;
        //    document.Contents = model.Contents;
        //    document.LanguageID = model.LanguageID;
        //    TUpdate(document);
        //}


        //public Document GetImagePath(int menuId)
        //{

        //    return dbset.Where(I => I.MenuID == menuId).FirstOrDefault();

        //}


        //public bool Create(DocumentModel documentModel)
        //{
        //    Document document = new Document();

        //    document.Header = documentModel.Header;
        //    document.Header2 = documentModel.Header2;
        //    document.Contents = documentModel.Contents;
        //    document.Status = documentModel.Status;
        //    document.Date = DateTime.Now;
        //    document.LanguageID = documentModel.LanguageID;
        //    document.MenuID = document.MenuID;

        //    TAdd(document);
        //    document.DocumentID = document.DocumentSeqID;
        //    document.MenuID = document.DocumentSeqID;
        //    TUpdate(document);
        //    return true;
        //}
    }
}
