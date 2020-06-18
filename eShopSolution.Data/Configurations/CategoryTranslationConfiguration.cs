using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
	public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
	{
		public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
		{
			builder.ToTable("CategoryTranslations");
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Id).UseIdentityColumn();
			builder.Property(t => t.Name).IsRequired().HasMaxLength(200);
			builder.Property(t => t.SeoAlias).IsRequired().HasMaxLength(200);
			builder.Property(t => t.SeoDescription).HasMaxLength(500);
			builder.Property(t => t.SeoTitle).HasMaxLength(200);
			builder.Property(t => t.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);
			builder.HasOne(t => t.Language).WithMany(l => l.CategoryTranslations).HasForeignKey(t => t.LanguageId);
			builder.HasOne(x => x.Category).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.CategoryId);
		}
	}
}
