﻿INSERT INTO category (name, created_at)  VALUES ('Washing', '2020-08-11 10:00:00');
INSERT INTO category (name, created_at) VALUES ('Learning', '2020-08-11 10:00:00');
INSERT INTO category (name, created_at) VALUES ('Chilling', '2020-08-11 10:00:00');
INSERT INTO category (name, created_at) VALUES ('Cleaning', '2020-08-11 10:00:00');
INSERT INTO category (name, created_at) VALUES ('Walking', '2020-08-11 10:00:00');



INSERT INTO subcategory (name, category, created_at) VALUES ('Car', 1, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('Clothes', 1, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('Slow', 5, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('Fast', 5, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('Gameing', 3, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('Wathcing TV', 3, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('Sleeping', 3, '2020-08-11 10:00:00');

INSERT INTO activity (category, subcategory, start_date, end_date, comment, created_at) VALUES (1, 1, '2020-08-11 10:00:00', '2020-08-11 11:00:00', 'Cleaning my dirty car', '2020-08-11 10:00:00');
INSERT INTO activity (category, subcategory, start_date, end_date, comment, created_at) VALUES (2, null, '2020-08-11 12:00:00', '2020-08-11 13:00:00', 'Learn codeing', '2020-08-11 10:00:00');