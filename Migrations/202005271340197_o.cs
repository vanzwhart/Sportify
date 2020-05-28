namespace MyFitness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class o : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HasilRekomendasis", "Hari");
            DropColumn("dbo.HasilRekomendasis", "Set");
            DropColumn("dbo.HasilRekomendasis", "Repetisi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HasilRekomendasis", "Repetisi", c => c.Int(nullable: false));
            AddColumn("dbo.HasilRekomendasis", "Set", c => c.Int(nullable: false));
            AddColumn("dbo.HasilRekomendasis", "Hari", c => c.Int(nullable: false));
        }
    }
}
