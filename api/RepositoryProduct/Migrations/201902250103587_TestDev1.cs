namespace RepositoryProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDev1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_Id" });
            AlterColumn("dbo.Product", "Category_Id", c => c.Int());
            CreateIndex("dbo.Product", "Category_Id");
            AddForeignKey("dbo.Product", "Category_Id", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_Id" });
            AlterColumn("dbo.Product", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "Category_Id");
            AddForeignKey("dbo.Product", "Category_Id", "dbo.Category", "Id", cascadeDelete: true);
        }
    }
}
