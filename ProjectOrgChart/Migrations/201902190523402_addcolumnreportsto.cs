namespace ProjectOrgChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnreportsto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "ReportsTo", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeModels", "ReportsTo");
        }
    }
}
