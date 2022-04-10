namespace blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpostsmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreatedAt = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        BlogImage = c.String(),
                        Categories_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriesModels", t => t.Categories_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Categories_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "Categories_Id", "dbo.CategoriesModels");
            DropIndex("dbo.Posts", new[] { "Categories_Id" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropTable("dbo.Posts");
        }
    }
}
