# Database scripts for TaktTusur.Eda

This folder contains scripts for create DB and migrate DB to new version of models.

### File naming convention

Use sortable date format `YYYYMMDD` and attach short name to describe changes in this script.
The name of file should be not longer than 80 chars.
So, finally the name of files should follow this template `YYYYMMDD_WhatsInsideThisScript.sql`

__Examples:__
`20240511_AddAdditionalNameForIngredient.sql`
`20241101_AddFavouriteRecipesForUser.sql`

### Idempotence

Add scripts should be idempotent, it means, if I apply one script twice,
the result will be same to apply this script once, without throwing exceptions.

__Example:__

```postgresql
DO
$$
BEGIN
    IF NOT EXISTS (
        SELECT 1 
        FROM   information_schema.columns 
        WHERE  table_name = 'table_name' 
        AND    column_name = 'column_name'
    ) 
    THEN 
        ALTER TABLE table_name
        ADD COLUMN column_name column_type;
    END IF;
END
$$;
```

there we'll check, if the column doesn't exist, we'll add it.

_Bad example:_
DON'T DO THIS!

```postgresql
DO
$$
BEGIN
    ALTER TABLE table_name
        ADD COLUMN column_name column_type;
END
$$;
```

If I run this script twice, on second call I'll get an error about column already exists.

### Changes for scripts

Don't change existing scripts, create new if you need to change something in DB.

### Entities mapping

If you have changes in schema, check `TaktTusur.Eda.DataAccess` project,
probably you have to change entities mapping in Entity Framework.