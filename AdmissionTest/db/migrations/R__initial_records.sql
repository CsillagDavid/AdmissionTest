INSERT INTO category (name, created_at)  VALUES ('cat1', '2020-08-11 10:00:00');
INSERT INTO category (name, created_at) VALUES ('cat2', '2020-08-11 10:00:00');

INSERT INTO subcategory (name, category, created_at) VALUES ('cat1_subcat_1', 1, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('cat1_subcat_2', 1, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('cat2_subcat_1', 2, '2020-08-11 10:00:00');
INSERT INTO subcategory (name, category, created_at) VALUES ('cat2_subcat_2', 2, '2020-08-11 10:00:00');

INSERT INTO activity (category, subcategory, start_date, end_date, comment, created_at) VALUES (1, 1, '2020-08-11 10:00:00', '2020-08-11 11:00:00', 'comment1...', '2020-08-11 10:00:00');
INSERT INTO activity (category, subcategory, start_date, end_date, comment, created_at) VALUES (2, 4, '2020-08-11 12:00:00', '2020-08-11 13:00:00', 'comment2...', '2020-08-11 10:00:00');