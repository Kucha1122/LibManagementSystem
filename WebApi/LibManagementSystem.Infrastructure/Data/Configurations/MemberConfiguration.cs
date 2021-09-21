using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FirstName).IsRequired();
            builder.Property(m => m.LastName).IsRequired();
            builder.Property(m => m.PhoneNumber).IsRequired();

        }
    }
}