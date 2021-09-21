using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired();
            
            builder.HasOne(i => i.Issue)
                .WithOne(b => b.Book)
                .HasForeignKey<Book>(b => b.Id);
        }
    }
}