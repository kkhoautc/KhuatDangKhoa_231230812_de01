using Microsoft.EntityFrameworkCore;

namespace KhuatDangKhoa_231230812_de01.Data
{
    public class KdkApplicationDBContext : DbContext
    {
        public KdkApplicationDBContext(DbContextOptions<KdkApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<KhuatDangKhoa_231230812_de01.Models.KdkComputer> KdkComputers { get; set; }

    }

}
