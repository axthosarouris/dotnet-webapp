--create database webappexampledatabase with owner 'orestis' encoding 'UTF8' locale 'en_US.UTF-8';
create table if not exists Person (id integer PRIMARY KEY,name varchar(100) NOT NULL);
insert into Person values (1, 'orestis');

