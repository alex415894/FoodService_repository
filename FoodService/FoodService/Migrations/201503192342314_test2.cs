namespace FoodService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "Dish_Id", "dbo.Dishes");
            DropIndex("dbo.MenuItems", new[] { "Dish_Id" });
            AlterColumn("dbo.MenuItems", "Dish_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "Dish_Id");
            AddForeignKey("dbo.MenuItems", "Dish_Id", "dbo.Dishes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "Dish_Id", "dbo.Dishes");
            DropIndex("dbo.MenuItems", new[] { "Dish_Id" });
            AlterColumn("dbo.MenuItems", "Dish_Id", c => c.Int());
            CreateIndex("dbo.MenuItems", "Dish_Id");
            AddForeignKey("dbo.MenuItems", "Dish_Id", "dbo.Dishes", "Id");
        }
    }
}
