using Quki.Entity.DtoModels;
using Quki.Entity.Models;

namespace Quki.Interface
{
    public interface IDocumentsService : IGenericService<Document, DocumentModel>
    {
        public Document GetDocumentByMenuId(int menuID);
        public Document GetDocumentByMenuId(int menuID, int languageId);
        public void DocumentUpdateByDocumetSeqID(Document model);
        public Document GetImagePath(int menuId);
        public bool Create(DocumentModel documentModel);

    }
}
