//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v4.1.2.0
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Testing
{
   /// <inheritdoc/>
   public partial class EFModel1 : DbContext
   {
      #region DbSets
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Testing.AssocClass> AssocClasses { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Testing.EntityAbstract> EntityAbstract { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Testing.EntityRelated> EntityRelated { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Testing.SourceClass> SourceClasses { get; set; }
      public virtual Microsoft.EntityFrameworkCore.DbSet<global::Testing.TargetClass> EntityImplementation { get; set; }

      #endregion DbSets

      /// <summary>
      /// Default connection string
      /// </summary>
      public static string ConnectionString { get; set; } = @"Data Source=.\sqlexpress;Initial Catalog=Test;Integrated Security=True";

      /// <summary>
      ///     <para>
      ///         Initializes a new instance of the <see cref="T:Microsoft.EntityFrameworkCore.DbContext" /> class using the specified options.
      ///         The <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" /> method will still be called to allow further
      ///         configuration of the options.
      ///     </para>
      /// </summary>
      /// <param name="options">The options for this context.</param>
      public EFModel1(DbContextOptions<EFModel1> options) : base(options)
      {
      }

      partial void CustomInit(DbContextOptionsBuilder optionsBuilder);

      /// <inheritdoc />
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseLazyLoadingProxies();

         CustomInit(optionsBuilder);
      }

      partial void OnModelCreatingImpl(ModelBuilder modelBuilder);
      partial void OnModelCreatedImpl(ModelBuilder modelBuilder);

      /// <summary>
      ///     Override this method to further configure the model that was discovered by convention from the entity types
      ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
      ///     and re-used for subsequent instances of your derived context.
      /// </summary>
      /// <remarks>
      ///     If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
      ///     then this method will not be run.
      /// </remarks>
      /// <param name="modelBuilder">
      ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
      ///     define extension methods on this object that allow you to configure aspects of the model that are specific
      ///     to a given database.
      /// </param>
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         OnModelCreatingImpl(modelBuilder);

         modelBuilder.HasDefaultSchema("dbo");

         modelBuilder.Entity<global::Testing.EntityAbstract>()
                     .ToTable("EntityAbstract")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.EntityAbstract>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();

         modelBuilder.Entity<global::Testing.EntityRelated>()
                     .ToTable("EntityRelated")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.EntityRelated>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::Testing.EntityRelated>()
                     .HasOne<global::Testing.EntityAbstract>(p => p.EntityAbstract)
                     .WithMany(p => p.EntityRelated);

         modelBuilder.Entity<global::Testing.SourceClass>()
                     .ToTable("SourceClasses")
                     .HasKey(t => t.Id);
         modelBuilder.Entity<global::Testing.SourceClass>()
                     .Property(t => t.Id)
                     .ValueGeneratedOnAdd()
                     .IsRequired();
         modelBuilder.Entity<global::Testing.SourceClass>()
                     .HasMany<global::Testing.TargetClass>(p => p.TargetClasses)
                     .WithMany(p => p.SourceClasses)
         .UsingEntity<global::Testing.AssocClass>(
            j => j
               .HasOne(x => x.SourceClass)
               .WithMany(x => x.TargetClass)
               .HasForeignKey(x => x.SourceClassId),
            j => j
               .HasOne(x => x.TargetClass)
               .WithMany(x => x.SourceClass)
               .HasForeignKey(x => x.TargetClassesId),
            j =>
            {
               j.ToTable("AssocClasses");
               j.HasKey(t => new { t.SourceClassesId, t.TargetClassesId });
               j.Property(t => t.Id).IsRequired().HasIndex(t => t.Id).IsUnique();
            });
         modelBuilder.Entity<global::Testing.SourceClass>()
                     .HasMany<global::Testing.AssocClass>(p => p.AssocClasses)
                     .WithOne(p => p.SourceClass);

         modelBuilder.Entity<global::Testing.TargetClass>()
                     .Property(t => t.Test)
                     .HasMaxLength(255);
         modelBuilder.Entity<global::Testing.TargetClass>()
                     .HasMany<global::Testing.AssocClass>(p => p.AssocClasses)
                     .WithOne(p => p.TargetClass);

         OnModelCreatedImpl(modelBuilder);
      }
   }
}
