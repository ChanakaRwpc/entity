namespace CustomerInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContatctInfoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Cus_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModels", t => t.Cus_Id, cascadeDelete: true)
                .Index(t => t.Cus_Id);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        Cus_Id = c.Int(nullable: false, identity: true),
                        Cus_FirstName = c.String(nullable: false),
                        Cus_LastName = c.String(),
                        Cus_DOB = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cus_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContatctInfoModels", "Cus_Id", "dbo.CustomerModels");
            DropIndex("dbo.ContatctInfoModels", new[] { "Cus_Id" });
            DropTable("dbo.CustomerModels");
            DropTable("dbo.ContatctInfoModels");
        }
    }
}
