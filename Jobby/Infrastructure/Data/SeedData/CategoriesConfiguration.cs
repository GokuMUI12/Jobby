using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.SeedData
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                 new Category
                 {
                     Id = 1,
                     CategoryName = "Accounting and Finance"
                 },
                 new Category
                 {
                     Id = 2,
                     CategoryName = "Web Development"
                 }, 
                 new Category
                 {
                     Id = 3,
                     CategoryName = "Data Science"
                 }, 
                 new Category
                 {
                     Id = 4,
                     CategoryName = "Mobile Development"
                 }, 
                 new Category
                 {
                     Id = 5,
                     CategoryName = "Photoshop"
                 },
                 new Category
                 {
                     Id = 6,
                     CategoryName = "Video Editing"
                 }
                );
        }
    }
}
