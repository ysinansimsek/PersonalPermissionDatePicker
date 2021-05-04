namespace PersonalPermission.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class DboPersonalPermissionDBInitializer : DropCreateDatabaseAlways<DboPersonalPermissionEntities>
    {
        protected override void Seed(DboPersonalPermissionEntities context)
        {
            IList<TblPermission> defaultStandards = new List<TblPermission>();

            defaultStandards.Add(new TblPermission()
            {
                Id=1,
                Name = "Doğum İzni"
            });
            defaultStandards.Add(new TblPermission()
            {
                Id = 2,
                Name = "Düğün İzni"
            });
            defaultStandards.Add(new TblPermission()
            {
                Id = 3,
                Name = "Hastalık İzni"
            });
            defaultStandards.Add(new TblPermission()
            {
                Id = 4,
                Name = "Özel İzin"
            });
            context.TblPermissions.AddRange(defaultStandards);

            base.Seed(context);
            context.SaveChanges();
        }
    }

    public partial class DboPersonalPermissionEntities : DbContext
    {

        public DboPersonalPermissionEntities()
            : base("name=DboPersonalPermissionEntities")
        {

            Database.SetInitializer<DboPersonalPermissionEntities>(new CreateDatabaseIfNotExists<DboPersonalPermissionEntities>());
            Database.SetInitializer(new DboPersonalPermissionDBInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<TblPermission> TblPermissions { get; set; }
        public virtual DbSet<TblPersonal> TblPersonals { get; set; }
    }
   
    
}