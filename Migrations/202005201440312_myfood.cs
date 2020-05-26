namespace MyFitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myfood : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyFoods",
                c => new
                    {
                        MyFoodId = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MyFoodId)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.FoodId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyFoods", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MyFoods", "FoodId", "dbo.Foods");
            DropIndex("dbo.MyFoods", new[] { "UserId" });
            DropIndex("dbo.MyFoods", new[] { "FoodId" });
            DropTable("dbo.MyFoods");
        }
    }
}
