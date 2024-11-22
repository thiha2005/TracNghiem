using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class KetQua
{
    public int Id { get; set; }

    public string? MaSinhVien { get; set; }

    public string? DapAn { get; set; }

    public int? MaDeThiCauHoi { get; set; }

    public virtual DeThiCauHoi? MaDeThiCauHoiNavigation { get; set; }

    public virtual ThanhVien? MaSinhVienNavigation { get; set; }
}
