-- Utilisateurs

INSERT INTO "Utilisateurs" VALUES ('51288882-4750-467c-bf39-2b10caf120c4', 'Doe', 'John', 'john.doe@outlook.com', 'toto', now(), now())
ON CONFLICT DO NOTHING;

INSERT INTO "Utilisateurs" VALUES ('6b60950a-6365-4d06-882f-8260c01c4140', 'Doe', 'Jane', 'jane.doe@outlook.com', 'toto', now(), now())
ON CONFLICT DO NOTHING;


-- Livres

INSERT INTO "Livres" VALUES (gen_random_uuid(), 'Harry Potter: La chambre des secrets', 'JK Rowling', '9788831000154', now(), now())
ON CONFLICT DO NOTHING;

INSERT INTO "Livres" VALUES (gen_random_uuid(), 'Tintin au Tibet', 'Hergé', '9780316358392', now(), now())
ON CONFLICT DO NOTHING;
