using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-P97T8LK\\MSSQLSERVER2019;database=CoreBlogDb; integrated security=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }

        //Boş bir Migration oluşturup;
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{

        //    var result1 = migrationBuilder.Sql($"Create Trigger AddBlogInRatingTable2022 on Blogs After Insert As Declare @Id int Select @Id=BlogId from inserted Insert Into BlogRaytings (BlogId,BlogTotalScore,BlogRaytingCount) Values (@Id,0,0)");

        //    var result2 = migrationBuilder.Sql($"Create Trigger AddScoreInComment on Comments after Insert as Declare @Id int Declare @Score int Declare @RaytingCount int Select @Id=BlogId,@Score=BlogScore from inserted Update BlogRaytings Set BlogTotalScore=BlogTotalScore+@Score , BlogRaytingCount+=1 where BlogId=@Id");


        //}

        //Bu şekilde Up kodları arasına triggerları yazabilir , projeye entegre edebilirsiniz.
    }
}
