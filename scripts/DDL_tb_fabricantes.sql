CREATE TABLE IF NOT EXISTS public.tb_fabricantes
(
    "id" uuid NOT NULL,
    "nome" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_fabricantes" PRIMARY KEY ("id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tb_fabricantes
    OWNER to mstar_supply;