using Quki.Entity.Base;

namespace Quki.Entity.DtoModels;

public partial class CondimentMenuItemRelationModel:DtoBase
{
    public int CondimentMenuItemSeqId { get; set; }

    public int? CondimentSubGroupDefSeq { get; set; }

    public long? MiMasterDefSeq { get; set; }
}
