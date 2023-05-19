using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.Entities;
using BuberDinner.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => MenuId.Create(value)
                );

            builder
           .Property(m => m.Name)
           .HasMaxLength(100);

            builder
                .Property(m => m.Description)
                .HasMaxLength(100);

            builder.OwnsOne(m => m.AverageRating);

            builder
           .Property(m => m.HostId)
           .HasConversion(
               id => id.Value,
               value => HostId.Create(value));
        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sectionBuilder =>
            {
                sectionBuilder.ToTable("MenuSections");

                sectionBuilder
               .WithOwner()
               .HasForeignKey("MenuId");

                sectionBuilder.HasKey("Id", "MenuId");

                sectionBuilder.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

                sectionBuilder
                .Property(s => s.Name)
                .HasMaxLength(100);

                sectionBuilder
                    .Property(s => s.Description)
                    .HasMaxLength(100);

                sectionBuilder.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                    ib
                   .Property(i => i.Id)
                   .HasColumnName("MenuItemId")
                   .ValueGeneratedNever()
                   .HasConversion(
                       id => id.Value,
                       value => MenuItemId.Create(value));

                    ib  
                    .Property(s => s.Name)
                    .HasMaxLength(100);

                    ib
                    .Property(s => s.Description)
                    .HasMaxLength(100);

                });

                sectionBuilder
               .Navigation(s => s.Items).Metadata
               .SetField("_items");

                sectionBuilder
                .Navigation(s => s.Items)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
               
            });

            builder.Metadata
              .FindNavigation(nameof(Menu.Sections))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);

        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dinnerBuilder =>
            {
                dinnerBuilder.ToTable("MenuDinnerIds");

                dinnerBuilder
                    .WithOwner()
                    .HasForeignKey("MenuId");

                dinnerBuilder.HasKey("Id");

                dinnerBuilder
                    .Property(d => d.Value)
                    .HasColumnName("DinnerId")
                    .ValueGeneratedNever();
            });

            builder.Metadata
                .FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, reviewBuilder =>
            {
                reviewBuilder.ToTable("MenuReviewIds");

                reviewBuilder
                    .WithOwner()
                    .HasForeignKey("MenuId");

                reviewBuilder.HasKey("Id");

                reviewBuilder
                    .Property(r => r.Value)
                    .HasColumnName("ReviewId")
                    .ValueGeneratedNever();
            });

            builder.Metadata
                .FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}
