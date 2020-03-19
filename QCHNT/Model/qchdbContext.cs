using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QCHNT.Model
{
    public partial class qchdbContext : DbContext
    {
        public qchdbContext()
        {
        }

        public qchdbContext(DbContextOptions<qchdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Cameraconfig> Cameraconfig { get; set; }
        public virtual DbSet<Carmanage> Carmanage { get; set; }
        public virtual DbSet<Carnumber> Carnumber { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Controller> Controller { get; set; }
        public virtual DbSet<Daozhaandcamera> Daozhaandcamera { get; set; }
        public virtual DbSet<Dibanganddaozha> Dibanganddaozha { get; set; }
        public virtual DbSet<Displayscreen> Displayscreen { get; set; }
        public virtual DbSet<Gatedetectionvalue> Gatedetectionvalue { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Printer> Printer { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Receivingunit> Receivingunit { get; set; }
        public virtual DbSet<Rfidreader> Rfidreader { get; set; }
        public virtual DbSet<Supplyunit> Supplyunit { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Weighinginstrument> Weighinginstrument { get; set; }
        public virtual DbSet<Weighingrecords> Weighingrecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=123456;Database=qchdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Cameraconfig>(entity =>
            {
                entity.ToTable("cameraconfig");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(50)");

                entity.Property(e => e.CameraIp)
                    .HasColumnName("CameraIP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CameraPassword).HasColumnType("varchar(50)");

                entity.Property(e => e.CameraUser).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Carmanage>(entity =>
            {
                entity.ToTable("carmanage");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CarDriver).HasColumnType("varchar(50)");

                entity.Property(e => e.CarFleet).HasColumnType("varchar(50)");

                entity.Property(e => e.CarNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.CarType).HasColumnType("varchar(50)");

                entity.Property(e => e.ContractNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FinishMark).HasColumnType("varchar(50)");

                entity.Property(e => e.Icnumber)
                    .HasColumnName("ICNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.NormWeight).HasColumnType("double(50,0)");

                entity.Property(e => e.Operator).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Carnumber>(entity =>
            {
                entity.ToTable("carnumber");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CameraNo).HasColumnType("int(11)");

                entity.Property(e => e.CarNumber1)
                    .HasColumnName("CarNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Flag).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Area).HasColumnType("varchar(50)");

                entity.Property(e => e.ContractNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.ContractReduction).HasColumnType("double(50,0)");

                entity.Property(e => e.ContractType).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.GoodsName).HasColumnType("varchar(50)");

                entity.Property(e => e.ReceiveUnit).HasColumnType("varchar(50)");

                entity.Property(e => e.ResidualContract).HasColumnType("double(50,0)");

                entity.Property(e => e.SupplyUnit).HasColumnType("varchar(50)");

                entity.Property(e => e.TotalContract).HasColumnType("double(50,0)");
            });

            modelBuilder.Entity<Controller>(entity =>
            {
                entity.ToTable("controller");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.MainBaute).HasColumnType("varchar(50)");

                entity.Property(e => e.MainCom)
                    .HasColumnName("MainCOM")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StandbyBaute).HasColumnType("varchar(50)");

                entity.Property(e => e.StandbyCom)
                    .HasColumnName("StandbyCOM")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Daozhaandcamera>(entity =>
            {
                entity.ToTable("daozhaandcamera");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CameraName).HasColumnType("varchar(50)");

                entity.Property(e => e.CardReaderName).HasColumnType("varchar(50)");

                entity.Property(e => e.DaoZhaName).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OutInSign).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Dibanganddaozha>(entity =>
            {
                entity.ToTable("dibanganddaozha");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(255)");

                entity.Property(e => e.DaoZhaName).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DiBangName).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Displayscreen>(entity =>
            {
                entity.ToTable("displayscreen");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LedHeight)
                    .HasColumnName("Led_height")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LedIp)
                    .HasColumnName("Led_IP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LedWidth)
                    .HasColumnName("Led_Width")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Gatedetectionvalue>(entity =>
            {
                entity.ToTable("gatedetectionvalue");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Goods>(entity =>
            {
                entity.ToTable("goods");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Area).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.GoodsName).HasColumnType("varchar(100)");

                entity.Property(e => e.Print).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.LogContent)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LogUser).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Printer>(entity =>
            {
                entity.ToTable("printer");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("process");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Area).HasColumnType("varchar(50)");

                entity.Property(e => e.CarNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FinishMark).HasColumnType("varchar(50)");

                entity.Property(e => e.Flow).HasColumnType("varchar(200)");

                entity.Property(e => e.Icnumber)
                    .HasColumnName("ICNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.InsertTime).HasColumnType("datetime");

                entity.Property(e => e.ProcessTime).HasColumnType("varchar(1000)");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WeightListNumber).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Receivingunit>(entity =>
            {
                entity.ToTable("receivingunit");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Area).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ReceiveUnit).HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Rfidreader>(entity =>
            {
                entity.ToTable("rfidreader");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.MainBaute).HasColumnType("varchar(50)");

                entity.Property(e => e.MainCom)
                    .HasColumnName("MainCOM")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StandbyBaute).HasColumnType("varchar(50)");

                entity.Property(e => e.StandbyCom)
                    .HasColumnName("StandbyCOM")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Supplyunit>(entity =>
            {
                entity.ToTable("supplyunit");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Area).HasColumnType("varchar(50)");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.SupplyUnit1)
                    .HasColumnName("SupplyUnit")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(50)");

                entity.Property(e => e.Area).HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Password).HasColumnType("varchar(50)");

                entity.Property(e => e.Type).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Weighinginstrument>(entity =>
            {
                entity.ToTable("weighinginstrument");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.MainBaute).HasColumnType("varchar(50)");

                entity.Property(e => e.MainCom)
                    .HasColumnName("MainCOM")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StandbyBaute).HasColumnType("varchar(50)");

                entity.Property(e => e.StandbyCom)
                    .HasColumnName("StandbyCOM")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Weighingrecords>(entity =>
            {
                entity.ToTable("weighingrecords");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(50)");

                entity.Property(e => e.Area).HasColumnType("varchar(50)");

                entity.Property(e => e.CarDriver).HasColumnType("varchar(50)");

                entity.Property(e => e.CarNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.ContractNumber).HasColumnType("varchar(50)");

                entity.Property(e => e.FinishMark).HasColumnType("varchar(50)");

                entity.Property(e => e.GoodsName).HasColumnType("varchar(50)");

                entity.Property(e => e.Icnumber)
                    .HasColumnName("ICNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.InsertTime).HasColumnType("datetime");

                entity.Property(e => e.NetWeight).HasColumnName(" NetWeight");

                entity.Property(e => e.Operator).HasColumnType("varchar(50)");

                entity.Property(e => e.ReceiveUnit).HasColumnType("varchar(50)");

                entity.Property(e => e.RoughWeightTime).HasColumnType("varchar(50)");

                entity.Property(e => e.SupplyUnit).HasColumnType("varchar(50)");

                entity.Property(e => e.TareWeightTime).HasColumnType("varchar(50)");

                entity.Property(e => e.WeightListNumber).HasColumnType("varchar(100)");
            });
        }
    }
}
