namespace ProjectOrgChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class def : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageModels", "EmployeeModel_Id", "dbo.EmployeeModels");
            DropIndex("dbo.ImageModels", new[] { "EmployeeModel_Id" });
            DropTable("dbo.ImageModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        EmployeeModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateIndex("dbo.ImageModels", "EmployeeModel_Id");
            AddForeignKey("dbo.ImageModels", "EmployeeModel_Id", "dbo.EmployeeModels", "Id");
        }
    }
}
