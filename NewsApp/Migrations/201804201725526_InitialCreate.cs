namespace NewsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DisplayArticle",
                c => new
                    {
                        idArticle = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        source = c.String(),
                        title = c.String(),
                        description = c.String(),
                        url = c.String(),
                        urlToImage = c.String(),
                        publishetAt = c.String(),
                        idCateogry = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idArticle);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        idCategory = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.idCategory);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Category");
            DropTable("dbo.DisplayArticle");
        }
    }
}
