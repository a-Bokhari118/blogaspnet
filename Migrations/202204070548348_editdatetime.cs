namespace blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "CreatedAt", c => c.String());
        }
    }
}
