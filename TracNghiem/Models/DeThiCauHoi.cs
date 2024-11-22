using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class DeThiCauHoi
{
    public int Id { get; set; }

    public int? MaDeThi { get; set; }

    public int? MaCauHoi { get; set; }

    public virtual ICollection<KetQua> KetQuas { get; set; } = new List<KetQua>();

    public virtual CauHoi? MaCauHoiNavigation { get; set; }

    public virtual DeThi? MaDeThiNavigation { get; set; }
}
