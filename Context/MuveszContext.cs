using Microsoft.EntityFrameworkCore;
using MuveszetiGaleriaApi.Entities;

namespace MuveszetiGaleriaApi.Context
{
    public class MuveszContext :DbContext
    {
        public MuveszContext(DbContextOptions<MuveszContext> options):base(options) { }
        public DbSet<Kiallitas> Kiallitasok { get; set; }
        public DbSet<Mualkotas> Mualkotasok { get; set; }
        public DbSet<Muvesz> Muveszek {  get; set; }
    }
}
