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


    END $$;