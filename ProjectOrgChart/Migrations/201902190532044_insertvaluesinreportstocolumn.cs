namespace ProjectOrgChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertvaluesinreportstocolumn : DbMigration
    {
        public override void Up()
        {
            Sql("Update EmployeeModels set ReportsTo=0 where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
