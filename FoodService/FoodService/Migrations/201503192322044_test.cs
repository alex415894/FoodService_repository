namespace FoodService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dishes", "MenuItem_Id", "dbo.MenuItems");
            DropIndex("dbo.Dishes", new[] { "MenuItem_Id" });
            AddColumn("dbo.MenuItems", "Dish_Id", c => c.Int());
            CreateIndex("dbo.MenuItems", "Dish_Id");
            AddForeignKey("dbo.MenuItems", "Dish_Id", "dbo.Dishes", "Id");
            DropColumn("dbo.Dishes", "MenuItem_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "MenuItem_Id", c => c.Int());
            DropForeignKey("dbo.MenuItems", "Dish_Id", "dbo.Dishes");
            DropIndex("dbo.MenuItems", new[] { "Dish_Id" });
            DropColumn("dbo.MenuItems", "Dish_Id");
            CreateIndex("dbo.Dishes", "MenuItem_Id");
            AddForeignKey("dbo.Dishes", "MenuItem_Id", "dbo.MenuItems", "Id");
        }
    }
}
