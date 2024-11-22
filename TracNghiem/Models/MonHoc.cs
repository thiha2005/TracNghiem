using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class MonHoc
{
    public int Id { get; set; }

    public string? TenMonHoc { get; set; }

    public virtual ICollection<CauHoi> CauHois { get; set; } = new List<CauHoi>();
}
