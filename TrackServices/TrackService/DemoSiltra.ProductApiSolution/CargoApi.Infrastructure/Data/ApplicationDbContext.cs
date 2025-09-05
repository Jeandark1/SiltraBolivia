
using CargoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CargoApi.Domain.Enums;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace CargoApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        } 


        // DBSET ENTIENDADES
        public DbSet<DataUser> DataUsers { get; set; }
        public DbSet<BankAccount> BankAccountss { get; set; }
        public DbSet<DataClient> DataClients { get; set; }
        public DbSet<DataCompany> DataCompanies { get; set; }
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public DbSet<CompanyLegalRepresentative> CompanyLegalRepresentatives { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverDocument> DriverDocuments { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDocument> VehicleDocuments { get; set; }
        public DbSet<CargoLoad> CargoLoads { get; set; }
        public DbSet<PackageLoad> PackageLoads { get; set; }
        public DbSet<GpsTracking> GpsTrackings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; } 
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<CargoSharingGroup> CargoSharingGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasOne(c => c.Participant1)
                      .WithMany(u => u.ConversationsAsParticipant1)
                      .HasForeignKey(c => c.Participant1Id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Participant2)
                      .WithMany(u => u.ConversationsAsParticipant2)
                      .HasForeignKey(c => c.Participant2Id)
                      .OnDelete(DeleteBehavior.Restrict);
            });*/

           


            // Aplicar todas las configuraciones de entidades mediante reflexión
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Solo es necesario configurar conversiones para enums y relaciones complejas que no se pueden expresar con Data Annotations
            ConfigureEnumConversions(modelBuilder);
            ConfigureComplexRelationships(modelBuilder);
        }

        private void ConfigureEnumConversions(ModelBuilder modelBuilder)
        {
            // Conversiones para todos los enums a stringss
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType.IsEnum)
                    {
                        var convertertype = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                        var converter = (ValueConverter)Activator.CreateInstance(convertertype, new object[] { null });

                        property.SetValueConverter(converter);
                    }
                }
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }



        private void ConfigureComplexRelationships(ModelBuilder modelBuilder)
        {
            // Solo configurar relaciones que no se pueden expresar con Data Annotations
            // Por ejemplo, relaciones many-to-many o configuraciones especiales de eliminación

            // Configuración para DataUser
           

            // Ejemplo: Configurar eliminación en cascada para relaciones opcionales
            modelBuilder.Entity<DataUser>()
                .HasMany(u => u.BankAccount)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DataUser>()
                .HasMany(u => u.Notifications)
                .WithOne(n => n.User)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para DataUser
            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasOne(c => c.Participant1)
                      .WithMany(u => u.ConversationsAsParticipant1)
                      .HasForeignKey(c => c.Participant1Id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Participant2)
                      .WithMany(u => u.ConversationsAsParticipant2)
                      .HasForeignKey(c => c.Participant2Id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Relación Usuario -> Transacciones como Pagador
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Payer)
                .WithMany(u => u.PayerTransactions)
                .HasForeignKey(t => t.PayerId)
                .OnDelete(DeleteBehavior.Restrict); // evita borrados en cascada

            // Relación Usuario -> Transacciones como Receptor
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Payee)
                .WithMany(u => u.PayeeTransactions)
                .HasForeignKey(t => t.PayeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // esto es para el rating del chofer por usuario cliente
            
            // Configurar relación RatingsGiven
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Rater)                        // cada Rating tiene un Rater
                .WithMany(u => u.RatingsAsParticipantGiven)  // nombre correcto en DataUser
                .HasForeignKey(r => r.RaterId)               // FK en Rating
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relación RatingsReceived
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Rated)                         // cada Rating tiene un Rated
                .WithMany(u => u.RatingsParticipantReceived) // nombre correcto en DataUser
                .HasForeignKey(r => r.RatedId)               // FK en Rating
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relación DataUser-Driver (uno-a-uno)
            modelBuilder.Entity<DataUser>()
                .HasOne(u => u.Driver)
                .WithOne(d => d.User)
                .HasForeignKey<Driver>(d => d.UserId);

            // esto es para propiedades decimales

            // Configurar precisión para propiedades decimales
            modelBuilder.Entity<VehicleRental>()
                .Property(v => v.SecurityDeposit)
                .HasPrecision(18, 2); // 18 dígitos totales, 2 decimales

            // Si tienes otras propiedades decimales, configúralas también
            modelBuilder.Entity<Driver>()
                .Property(d => d.SalaryPerKm)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Driver>()
                .Property(d => d.Rating)
                .HasPrecision(3, 1); // Ejemplo para rating: 9.9

            // Configurar relaciones de herencia si es necesario
            // modelBuilder.Entity<DataUser>().HasDiscriminator<string>("UserType");

            // ELIMINACIONES EN CASCADA PARA ENTIDADES RELACIONADAS
            // Configuración específica para CompanyUser
            modelBuilder.Entity<CompanyUser>(entity =>
            {
                // Configurar la relación con Company
                entity.HasOne(cu => cu.Company)
                      .WithMany() // O WithMany(c => c.CompanyUsers) si existe
                      .HasForeignKey(cu => cu.CompanyId)
                      .OnDelete(DeleteBehavior.Cascade); // Mantener cascada para Company

                // Configurar la relación con User - CAMBIAR A RESTRICT
                entity.HasOne(cu => cu.User)
                      .WithMany() // O WithMany(u => u.CompanyUsers) si existe
                      .HasForeignKey(cu => cu.UserId)
                      .OnDelete(DeleteBehavior.Restrict); // Cambiado a Restrict
            });

            // Configuración para CargoLoad
            modelBuilder.Entity<CargoLoad>(entity =>
            {
                // Mantener eliminación en cascada para Vehicle
                entity.HasOne(cl => cl.Vehicle)
                      .WithMany() // O WithMany(v => v.CargoLoads) si existe la propiedad
                      .HasForeignKey(cl => cl.VehicleId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Cambiar a Restrict para Driver
                entity.HasOne(cl => cl.Driver)
                      .WithMany() // O WithMany(d => d.CargoLoads) si existe la propiedad
                      .HasForeignKey(cl => cl.DriverId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Configurar otras relaciones si es necesario
                entity.HasOne(cl => cl.SharingGroup)
                      .WithMany() // O WithMany(g => g.CargoLoads)
                      .HasForeignKey(cl => cl.SharingGroupId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cl => cl.CancelledBy)
                      .WithMany() // O WithMany(u => u.CancelledCargoLoads)
                      .HasForeignKey(cl => cl.CancelledById)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración para VehicleRental
            modelBuilder.Entity<VehicleRental>(entity =>
            {
                // Mantener eliminación en cascada para ClientCompany
                entity.HasOne(vr => vr.ClientCompany)
                      .WithMany() // O WithMany(c => c.VehicleRentals)
                      .HasForeignKey(vr => vr.ClientCompanyId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Cambiar a Restrict para Driver
                entity.HasOne(vr => vr.Driver)
                      .WithMany() // O WithMany(d => d.VehicleRentals)
                      .HasForeignKey(vr => vr.DriverId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Cambiar a Restrict para Vehicle
                entity.HasOne(vr => vr.Vehicle)
                      .WithMany() // O WithMany(v => v.VehicleRentals)
                      .HasForeignKey(vr => vr.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración EXPLÍCITA para GpsTracking
            modelBuilder.Entity<GpsTracking>(entity =>
            {
                // Relación con Vehicle - configuración explícita
                entity.HasOne(gt => gt.Vehicle)
                      .WithMany(v => v.GpsTrackings) // Especificar la navegación inversa
                      .HasForeignKey(gt => gt.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Relación con CargoLoad - configuración explícita
                entity.HasOne(gt => gt.Load)
                      .WithMany(cl => cl.GpsTrackings) // Especificar la navegación inversa
                      .HasForeignKey(gt => gt.LoadId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación OPCIONAL con User
                entity.HasOne(gt => gt.User)
                      .WithMany() // Sin navegación inversa
                      .HasForeignKey(gt => gt.UserId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);

                // IGNORAR cualquier propiedad duplicada que pueda existir
                entity.Ignore("CargoLoad"); // Si existe una propiedad duplicada
                entity.Ignore("Vehicle1");  // Si existe una propiedad duplicada
            });

            /*
            // Configuración EXPLÍCITA para PackageLoad
            modelBuilder.Entity<PackageLoad>(entity =>
            {
                // Configurar las relaciones que SÍ queremos
                entity.HasOne(pl => pl.CargoLoad)
                      .WithMany(cl => cl.PackageLoads)
                      .HasForeignKey(pl => pl.CargoLoadId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pl => pl.Client)
                      .WithMany()
                      .HasForeignKey(pl => pl.ClientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pl => pl.Vehicle)
                      .WithMany()
                      .HasForeignKey(pl => pl.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pl => pl.SharingGroup)
                      .WithMany()
                      .HasForeignKey(pl => pl.SharingGroupId)
                      .OnDelete(DeleteBehavior.Restrict);

                // IGNORAR EXPLÍCITAMENTE cualquier propiedad duplicada
                entity.Ignore("CargoSharingGroup");
                entity.Ignore("CargoSharingGroupId");
                entity.Ignore("DataUser");
                entity.Ignore("DataUserId");
                entity.Ignore("Vehicldotnet builde1");
                entity.Ignore("VehicleId1");
            }); /*/


            // ruta de optimizacion configuracion para eliminar tablas
            modelBuilder.Entity<RouteOptimization>(entity =>
            {
                entity.HasOne(ro => ro.CargoLoad)
                      .WithMany()
                      .HasForeignKey(ro => ro.CargoLoadId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ro => ro.Vehicle)
                      .WithMany()
                      .HasForeignKey(ro => ro.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict); // Cambiado a Restrict
            });

            // invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(i => i.PackageLoad)
                      .WithMany(pl => pl.Invoices)
                      .HasForeignKey(i => i.PackageLoadId)
                      .OnDelete(DeleteBehavior.Restrict); // <- Evita cascada aquí

                entity.HasOne(i => i.Client)
                      .WithMany(c => c.Invoices)
                      .HasForeignKey(i => i.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(i => i.Transaction)
                      .WithMany(t => t.Invoices)
                      .HasForeignKey(i => i.TransactionId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Otros FK que pueden ser opcionales sin cascada
                entity.HasOne(i => i.ServiceAgreement)
                      .WithMany()
                      .HasForeignKey(i => i.ServiceAgreementId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(i => i.VehicleRental)
                      .WithMany()
                      .HasForeignKey(i => i.VehicleRentalId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configurar explícitamente las relaciones que necesitan cascada
            modelBuilder.Entity<PackageLoad>()
                .HasOne(pl => pl.CargoLoad)
                .WithMany(cl => cl.PackageLoads)
                .HasForeignKey(pl => pl.CargoLoadId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RouteOptimization>()
                .HasOne(ro => ro.CargoLoad)
                .WithMany()
                .HasForeignKey(ro => ro.CargoLoadId)
                .OnDelete(DeleteBehavior.Cascade);






        }

    }
}
