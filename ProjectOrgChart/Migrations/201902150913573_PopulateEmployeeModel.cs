namespace ProjectOrgChart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEmployeeModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Animesh','animesh@gmail.com','9967884435')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Anand','anand@gmail.com','9967884405')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Bagath','bagath@gmail.com','9962884435')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Nandini','nandini@gmail.com','9962284435')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Shreya','shreya@gmail.com','9967284435')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Manu','manu@gmail.com','9964884435')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Riya','riya@gmail.com','9967884432')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Saima','saima@gmail.com','9961284435')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Priya','priya@gmail.com','9961284435')");
            Sql("INSERT INTO EmployeeModels(Name,Email,Contact) VALUES ('Shiv','shiv@gmail.com','9969284435')");

        }
        
        public override void Down()
        {
        }
    }
}
