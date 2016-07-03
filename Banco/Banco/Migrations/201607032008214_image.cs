namespace Banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coment",
                c => new
                    {
                        id = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        usuario = c.String(maxLength: 250),
                        id_image = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        comment = c.String(maxLength: 250),
                        Image_id = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Image", t => t.Image_id)
                .Index(t => t.Image_id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        id = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        id_image = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        imagen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        id_post = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        id_image = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        id_comment = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        tittle = c.String(nullable: false, maxLength: 250),
                        description = c.String(nullable: false, maxLength: 250),
                        contenido = c.String(nullable: false, maxLength: 250),
                        Coment_id = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        Image_id = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.id_post)
                .ForeignKey("dbo.Coment", t => t.Coment_id)
                .ForeignKey("dbo.Image", t => t.Image_id)
                .Index(t => t.Coment_id)
                .Index(t => t.Image_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Image_id", "dbo.Image");
            DropForeignKey("dbo.Post", "Coment_id", "dbo.Coment");
            DropForeignKey("dbo.Coment", "Image_id", "dbo.Image");
            DropIndex("dbo.Post", new[] { "Image_id" });
            DropIndex("dbo.Post", new[] { "Coment_id" });
            DropIndex("dbo.Coment", new[] { "Image_id" });
            DropTable("dbo.Post");
            DropTable("dbo.Image");
            DropTable("dbo.Coment");
        }
    }
}
