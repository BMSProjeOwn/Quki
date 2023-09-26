using Quki.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Quki.Entity.Models;

public partial class CondimentMenuItemRelation:EntityBase
{
    [Key]
    public int condiment_menu_item_seq_id { get; set; }

    public int? condiment_sub_group_def_seq { get; set; }

    public long? mi_master_def_seq { get; set; }
}
