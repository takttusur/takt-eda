CREATE TABLE public."MeasurementUnits"
(
    id bigint,
    name text NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT unique_name UNIQUE (name)
);

ALTER TABLE IF EXISTS public."MeasurementUnits"
    OWNER to eda;