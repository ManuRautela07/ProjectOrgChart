namespace ProjectOrgChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enterlevelforall : DbMigration
    {
        public override void Up()
        {
            Sql("Update EmployeeModels set ReportsTo=4 where Id=5");
            Sql("Update EmployeeModels set ReportsTo=4 where Id=6");
            Sql("Update EmployeeModels set ReportsTo=5 where Id=9");
            Sql("Update EmployeeModels set ReportsTo=5 where Id=10");
            Sql("Update EmployeeModels set ReportsTo=6 where Id=7");
            Sql("Update EmployeeModels set ReportsTo=6 where Id=8");
            Sql("Update EmployeeModels set ReportsTo=8 where Id=12");
            Sql("Update EmployeeModels set ReportsTo=7 where Id=11");
            Sql("Update EmployeeModels set ReportsTo=9 where Id=13");
        }
        
        public override void Down()
        {
        }
    }
}
