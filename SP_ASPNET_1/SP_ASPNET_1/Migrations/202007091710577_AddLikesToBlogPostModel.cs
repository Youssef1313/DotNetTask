namespace SP_ASPNET_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikesToBlogPostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPost", "Likes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogPost", "Likes");
        }
    }
}
