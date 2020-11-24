using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PTCG_Tracker.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Collection> Collections { get; set; }

        public DbSet<Attack> Attacks { get; set; }

        public DbSet<Ability> Abilities { get; set; }

        public DbSet<Weakness> Weaknesses { get; set; }

        public DbSet<Resistance> Resistances { get; set; }

        //public DbSet<CardCollection> CardCollections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            modelBuilder.Entity<Card>()
                .HasMany(c => c.Collections)
                .WithMany(cr => cr.Cards)
                .Map(
                m =>
                {
                    m.MapLeftKey("CollectionId");
                    m.MapRightKey("CardId");
                    m.ToTable("CardCollections");
                });
          

        }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Card.CardListItem> CardListItems { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Card.CardCreate> CardCreates { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Card.CardDetails> CardDetails { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Card.CardEdit> CardEdits { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Collection.CollectionCreate> CollectionCreates { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Collection.CollectionDetails> CollectionDetails { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Collection.CollectionEdit> CollectionEdits { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Attack.AttackListItem> AttackListItems { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Attack.AttackCreate> AttackCreates { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Attack.AttackDetails> AttackDetails { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Attack.AttackEdit> AttackEdits { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Ability.AbilityListItem> AbilityListItems { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Ability.AbilityCreate> AbilityCreates { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Ability.AbilityDetails> AbilityDetails { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Ability.AbilityEdit> AbilityEdits { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Resistance.ResistanceListItem> ResistanceListItems { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Resistance.ResistanceCreate> ResistanceCreates { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Resistance.ResistanceDetails> ResistanceDetails { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Resistance.ResistanceEdit> ResistanceEdits { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Weakness.WeaknessListItem> WeaknessListItems { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Weakness.WeaknessCreate> WeaknessCreates { get; set; }

        //public System.Data.Entity.DbSet<PTCG_Tracker.Models.Weakness.WeaknessDetails> WeaknessDetails { get; set; }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}