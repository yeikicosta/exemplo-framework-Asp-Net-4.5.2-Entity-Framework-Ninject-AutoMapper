namespace RepositoryProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDev4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Product", name: "Category_Id", newName: "IdCategory");
            RenameIndex(table: "dbo.Product", name: "IX_Category_Id", newName: "IX_IdCategory");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Product", name: "IX_IdCategory", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Product", name: "IdCategory", newName: "Category_Id");
        }
    }
}
