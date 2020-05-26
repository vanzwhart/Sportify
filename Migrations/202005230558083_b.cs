namespace MyFitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "BMI", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "BMI", c => c.Int(nullable: false));
        }
    }
}
