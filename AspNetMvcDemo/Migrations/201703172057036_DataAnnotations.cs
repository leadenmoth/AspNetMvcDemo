namespace AspNetMvcDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Category", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Category", c => c.String());
        }
    }
}
