namespace MyFitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "JenisKelamin", c => c.String());
            AddColumn("dbo.UserInfoes", "BMI", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "BMI");
            DropColumn("dbo.UserInfoes", "JenisKelamin");
        }
    }
}
