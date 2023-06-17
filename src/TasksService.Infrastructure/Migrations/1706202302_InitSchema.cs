using FluentMigrator;

namespace Dal.Migrations;

[Migration(1706202302, TransactionBehavior.None)]
public class InitSchema : Migration 
{
    public override void Up()
    {
        Create.Table("tasks")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("status").AsString().NotNullable()
            .WithColumn("created_at").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("tasks");
    }
}