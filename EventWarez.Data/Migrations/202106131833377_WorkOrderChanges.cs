namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkOrderChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff");
            DropIndex("dbo.WorkOrder", new[] { "StaffId" });
            AddColumn("dbo.Show", "IsSoldOut", c => c.Boolean(nullable: false));
            AlterColumn("dbo.WorkOrder", "StaffId", c => c.Int());
            CreateIndex("dbo.WorkOrder", "StaffId");
            AddForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff", "StaffId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff");
            DropIndex("dbo.WorkOrder", new[] { "StaffId" });
            AlterColumn("dbo.WorkOrder", "StaffId", c => c.Int(nullable: false));
            DropColumn("dbo.Show", "IsSoldOut");
            CreateIndex("dbo.WorkOrder", "StaffId");
            AddForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff", "StaffId", cascadeDelete: true);
        }
    }
}
