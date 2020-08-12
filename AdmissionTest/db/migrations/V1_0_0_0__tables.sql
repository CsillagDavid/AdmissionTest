CREATE TABLE category (
    id int IDENTITY(1,1),
    name varchar(255) NOT NULL,
    created_at datetime2 NOT NULL,
    PRIMARY KEY (id)
)

CREATE TABLE subcategory(
    id int IDENTITY(1,1),
    name varchar(255) NOT NULL,
    created_at datetime2  NOT NULL,
    PRIMARY KEY (id)
)

CREATE TABLE category_subcategory (
    id int IDENTITY(1,1),
    category int NOT NULL,
    subcategory int NOT NULL,
    FOREIGN KEY (category) REFERENCES category(id),
    FOREIGN KEY (subcategory) REFERENCES subcategory(id)
)

CREATE TABLE activity (
    id int IDENTITY(1,1),
    category int NOT NULL,
    subcategory int NOT NULL,
    start_date datetime2  NOT NULL,
    end_date datetime2  NOT NULL,
    comment varchar(255) NOT NULL,
    created_at datetime2  NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (category) REFERENCES category(id),
    FOREIGN KEY (subcategory) REFERENCES subcategory(id)
)