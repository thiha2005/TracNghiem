using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class DeThi
{
    public int Id { get; set; }

    public DateOnly? NgayThi { get; set; }

    public int? ThoiGianThi { get; set; }

    public string? TenDeThi { get; set; }

    public int? SoLuongCauKho { get; set; }

    public int? SoLuongCauHoi { get; set; }

    public virtual ICollection<DeThiCauHoi> DeThiCauHois { get; set; } = new List<DeThiCauHoi>();
}
