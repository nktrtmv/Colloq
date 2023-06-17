using FluentMigrator;

namespace Dal.Migrations;

[Migration(1706202303, TransactionBehavior.None)]
public class CreateTaskType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'task_type') THEN
            CREATE TYPE task_type AS (
                id INTEGER,
                name TEXT,
                description TEXT,
                status TEXT,
                created_at TIMESTAMP
            );
        END IF;
    END
$$;");
    }

    public override void Down()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        DROP TYPE IF EXISTS task_type;
    END
$$;");
    }
}