namespace WpfExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSupplierTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_M_Supplier");
        }
    }
}
