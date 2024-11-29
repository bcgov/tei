CREATE SCHEMA IF NOT EXISTS codes;

CREATE SEQUENCE IF NOT EXISTS codes."USER_SEQ"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 100;

CREATE TABLE IF NOT EXISTS codes.USERS
(
    ID    numeric      not null
        constraint "USER_PK"
            primary key DEFAULT nextval('codes."USER_SEQ"'),
    NAME  varchar(200) not null,
    EMAIL varchar(200) not null
);
INSERT INTO codes.USERS (NAME, EMAIL)
VALUES ('John', 'John.ipsum@test.com'),
       ('Jane', 'Jane.ipsum@test.com'),
       ('Jack', 'Jack.ipsum@test.com'),
       ('Jill', 'Jill.ipsum@test.com'),
       ('Jam', 'Jam.ipsum@test.com');

