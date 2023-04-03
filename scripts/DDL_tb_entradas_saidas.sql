CREATE TABLE IF NOT EXISTS public.tb_entradas_saidas
(
    "id" uuid NOT NULL,
    "quantidade" integer NOT NULL,
    "data_hora" timestamp with time zone NOT NULL,
    "local" text COLLATE pg_catalog."default",
    "tipo" integer NOT NULL,
    "mercadoria_id" uuid NOT NULL,
    CONSTRAINT "PK_entradas_saidas" PRIMARY KEY ("id"),
    CONSTRAINT "FK_entradas_saidas_mercadorias_mercadoriaId" FOREIGN KEY ("mercadoria_id")
        REFERENCES public.tb_mercadorias ("id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tb_entradas_saidas
    OWNER to mstar_supply;


CREATE INDEX IF NOT EXISTS "IX_entradas_saidas_mercadoria_id"
    ON public.tb_entradas_saidas USING btree
    ("mercadoria_id" ASC NULLS LAST)
    TABLESPACE pg_default;