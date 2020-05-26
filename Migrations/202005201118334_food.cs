namespace MyFitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class food : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        FoodCalories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
           
            
        }
        
        public override void Down()
        {
           
            DropTable("dbo.Foods");
          
        }
    }
}
