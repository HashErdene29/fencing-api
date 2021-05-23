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
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=dc2020;Database=Intouch;");
            }
        }
        #region Sets
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<CATEGORY> CATEGORYs { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACKs { get; set; }
        public virtual DbSet<JOB> JOBs { get; set; }
        public virtual DbSet<JOBIMG> JOBIMGs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<BANNER> BANNERs { get; set; }
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
