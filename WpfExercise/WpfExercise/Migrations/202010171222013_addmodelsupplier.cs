namespace WpfExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelsupplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Supplier",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_M_Supplier");
        }
    }
}
