using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TracNghiem.Models;

namespace TracNghiem.Data
{
    public class TracNghiemContext : DbContext
    {
        public TracNghiemContext (DbContextOptions<TracNghiemContext> options)
            : base(options)
        {
        }

        public DbSet<TracNghiem.Models.CauHoi> CauHoi { get; set; } = default!;
        public DbSet<TracNghiem.Models.DeThi> DeThi { get; set; } = default!;
        public DbSet<TracNghiem.Models.DeThiCauHoi> DeThiCauHoi { get; set; } = default!;
        public DbSet<TracNghiem.Models.KetQua> KetQua { get; set; } = default!;
        public DbSet<TracNghiem.Models.MonHoc> MonHoc { get; set; } = default!;
        public DbSet<TracNghiem.Models.MucDo> MucDo { get; set; } = default!;
        public DbSet<TracNghiem.Models.ThanhVien> ThanhVien { get; set; } = default!;
    }
}
