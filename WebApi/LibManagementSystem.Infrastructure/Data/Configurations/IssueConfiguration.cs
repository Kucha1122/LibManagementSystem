using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configurations
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable("Issues");
            builder.HasKey(i => i.Id);

            builder.HasOne(b => b.Book)
                .WithOne(i => i.Issue)
                .HasForeignKey<Issue>(b => b.BookId)
                .OnDelete((DeleteBehavior.Cascade));

            builder.HasOne(m => m.Member)
                .WithMany(i => i.Issues)
                .HasForeignKey(m => m.MemberId);
        }
    }
}