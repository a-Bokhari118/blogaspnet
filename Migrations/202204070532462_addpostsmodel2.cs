namespace blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpostsmodel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Categories_Id", "dbo.CategoriesModels");
            DropIndex("dbo.Posts", new[] { "Categories_Id" });
            DropColumn("dbo.Posts", "CategoryId");
            RenameColumn(table: "dbo.Posts", name: "Categories_Id", newName: "CategoryId");
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.CategoriesModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.CategoriesModels");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "CategoryId", newName: "Categories_Id");
            AddColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Categories_Id");
            AddForeignKey("dbo.Posts", "Categories_Id", "dbo.CategoriesModels", "Id");
        }
    }
}
