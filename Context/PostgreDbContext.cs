using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsApi.Models;

namespace NewsApi.Context
{
    public class PostgregDbContext : DbContext
    {
        public PostgregDbContext(DbContextOptions<PostgregDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=Fencing;");
            }
        }
        #region Sets
        public virtual DbSet<MEDEE> MEDEEs { get; set; }
        #endregion

        #region Functions
        public int GetTableId(string tableNm)
        {
            try
            {
                return Database.ExecuteSqlCommand("select nextval('\"SEQ_USER\"')");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
