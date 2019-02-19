namespace ProjectOrgChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        EmployeeModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.EmployeeModels", t => t.EmployeeModel_Id)
                .Index(t => t.EmployeeModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "EmployeeModel_Id", "dbo.EmployeeModels");
            DropIndex("dbo.ImageModels", new[] { "EmployeeModel_Id" });
            DropTable("dbo.ImageModels");
        }
    }
}
