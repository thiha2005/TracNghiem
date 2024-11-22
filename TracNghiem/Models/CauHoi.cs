using System;
using System.Collections.Generic;

namespace TracNghiem.Models;

public partial class CauHoi
{
    public int Id { get; set; }

    public string? CauHoi1 { get; set; }

    public string? DapAnA { get; set; }

    public string? DapAnB { get; set; }

    public string? DapAnC { get; set; }

    public string? DapAnD { get; set; }

    public string? DapAn { get; set; }

    public string? GhiChu { get; set; }

    public int? MaMonHoc { get; set; }

    public int? MaMucDo { get; set; }

    public virtual ICollection<DeThiCauHoi> DeThiCauHois { get; set; } = new List<DeThiCauHoi>();

    public virtual MonHoc? MaMonHocNavigation { get; set; }

    public virtual MucDo? MaMucDoNavigation { get; set; }
}
