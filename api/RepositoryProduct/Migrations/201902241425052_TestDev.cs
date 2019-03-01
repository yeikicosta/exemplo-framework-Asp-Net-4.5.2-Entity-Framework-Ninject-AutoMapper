namespace RepositoryProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDev : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        IdParent = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        RegisterDate = c.DateTime(),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_Id" });
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
