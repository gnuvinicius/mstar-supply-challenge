CREATE TABLE IF NOT EXISTS public.tb_mercadorias
(
    "id" uuid NOT NULL,
    "nome" text COLLATE pg_catalog."default",
    "descricao" text COLLATE pg_catalog."default",
    "numero_de_registro" integer NOT NULL,
    "tipo" text COLLATE pg_catalog."default",
    "fabricante_id" uuid NOT NULL,
    CONSTRAINT "PK_tb_mercadorias" PRIMARY KEY ("id"),
    CONSTRAINT "FK_tb_mercadorias_fabricantes_fabricante_id" FOREIGN KEY ("fabricante_id")
        REFERENCES public.tb_fabricantes ("id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tb_mercadorias
    OWNER to mstar_supply;

CREATE INDEX IF NOT EXISTS "IX_mercadorias_fabricante_id"
    ON public.tb_mercadorias USING btree
    ("fabricante_id" ASC NULLS LAST)
    TABLESPACE pg_default;