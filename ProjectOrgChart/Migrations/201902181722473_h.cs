namespace ProjectOrgChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EmployeeModels", "Designation");
            DropColumn("dbo.EmployeeModels", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeModels", "Level", c => c.String());
            AddColumn("dbo.EmployeeModels", "Designation", c => c.String());
        }
    }
}
