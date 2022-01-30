using FluentMigrator;

namespace TestTaskAliExpress.Migrations
{
    [Migration(20220130132324)]
    public class Migration_20220130132324: Migration
    {
        public override void Down()
        {
            Delete.Table("category");
        }

        public override void Up()
        {
            Create.Table("category")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("parentid").AsInt32().Nullable();

            Create.ForeignKey()
                .FromTable("category").ForeignColumn("parentid")
                .ToTable("category").PrimaryColumn("id");

            Execute.Sql(@"Insert into category (id, name) values (1,'First')");
            Execute.Sql(@"Insert into category (id, name) values (2,'Second')");
            Execute.Sql(@"Insert into category (id, name, parentid) values (3,'Third', 1)");

        }
    }
}
