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
                CONSTRAINT unique_name UNIQUE (name)
            );
            ALTER TABLE public."MeasurementUnits" OWNER TO CURRENT_USER;
            
            INSERT INTO public."MeasurementUnits" (id, name)
            VALUES
            (0, 'грамм'),
            (1, 'литр'),
            (2, 'ст. ложка');
        END IF;
    END $$;