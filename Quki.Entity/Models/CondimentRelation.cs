using Quki.Entity.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quki.Entity.Models;

public partial class CondimentRelation:EntityBase
{
    [Key]
    public long condiment_relation_seq { get; set; }

    public long? relation_seq { get; set; }

    public string? relation_type { get; set; }

    public long? condiment_sub_group_def_seq { get; set; }

    public short? condiment_profile_def_order_number { get; set; }

    public long condiment_relation_no { get; set; }

    public DateTime? UpdateDate { get; set; }

}
