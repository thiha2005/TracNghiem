using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class MucDo
{
    public int Id { get; set; }

    public string? TenMucDo { get; set; }

    public virtual ICollection<CauHoi> CauHois { get; set; } = new List<CauHoi>();
}
