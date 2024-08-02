DO $$
    BEGIN
        IF NOT EXISTS (
            SELECT FROM pg_catalog.pg_tables
            WHERE  schemaname = 'public'
              AND    tablename  = 'MeasurementUnits'
        )
        THEN
            CREATE TABLE public."MeasurementUnits"
            (
                id bigint,
                name text NOT NULL,
                CONSTRAINT unique_measurementUnits_name UNIQUE (name)
            );
            ALTER TABLE public."MeasurementUnits" OWNER TO CURRENT_USER;
            
            INSERT INTO public."MeasurementUnits" (id, name)
            VALUES
            (0, 'грамм'),
            (1, 'литр'),
            (2, 'ст. ложка');
        END IF;

        IF NOT EXISTS (SELECT
                       FROM pg_catalog.pg_tables
                       WHERE schemaname = 'public'
                         AND tablename = 'Ingredients')
        THEN
            CREATE TABLE public."Ingredients"
            (
                id   bigint,
                name text NOT NULL,
                CONSTRAINT unique_ingredients_name UNIQUE (name)
            );
            ALTER TABLE public."Ingredients"
                OWNER TO CURRENT_USER;

            INSERT INTO public."Ingredients" (id, name)
            VALUES (0, 'куриное филе'),
                   (1, 'сыр плавленый'),
                   (2, 'вермишель'),
                   (3, 'картофель'),
                   (4, 'лук репчатый'),
                   (5, 'морковь'),
                   (6, 'зелень'),
                   (7, 'масло сливочное');
        END IF;

        IF NOT EXISTS (SELECT
                       FROM pg_catalog.pg_tables
                       WHERE schemaname = 'public'
                         AND tablename = 'Recipes')
        THEN
            CREATE TABLE public."Recipes"
            (
                id                  bigint  NOT NULL,
                name                text    NOT NULL,
                time_to_prepare_sec integer NOT NULL DEFAULT 0,
                time_to_cook_sec    integer NOT NULL DEFAULT 0,
                cooking_guide       text,
                PRIMARY KEY (id),
                CONSTRAINT recipe_name_unique UNIQUE (name)
            );

            ALTER TABLE public."Recipes"
                OWNER TO CURRENT_USER;
        END IF;


    END $$;