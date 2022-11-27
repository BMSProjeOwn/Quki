using System;
using System.Collections.Generic;
using System.Linq;
using Quki.Dal.Concrete.Entityframework.Context;
using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Dal.Abstract
{
    public interface IDocumentsRepository : IGenericRepository<Document>
    {
        //public Document GetDocumentByMenuId(int menuID);
        //public Document GetDocumentByMenuId(int menuID, int languageId);
        //public void DocumentUpdateByDocumetSeqID(Document model);
        //public Document GetImagePath(int menuId);
        //public bool Create(DocumentModel documentModel);

    }
}
