using DevSnap.CommonLibrary.Extensions;
using LibraryToDocs.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryToDocs.Mappings
{
    internal class UserMap : EntityTypeConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.IdUser);
            builder.Property(x => x.IdUser).ValueGeneratedOnAdd();
        }
    }
}
