using Quki.Entity.Base;
using System;

namespace BMS.Entity.Models.ZuPosWebPanel;

public partial class CondimentRelationModel : DtoBase
{
    public long CondimentRelationSeq { get; set; }

    public long? RelationSeq { get; set; }

    public string? RelationType { get; set; }

    public long? CondimentSubGroupDefSeq { get; set; }

    public short? CondimentProfileDefOrderNumber { get; set; }

    public long CondimentRelationNo { get; set; }

    public DateTime? UpdateDate { get; set; }

}
