--drop database MyHours;
create database MyHours;
--drop table users;
create table users(
	id serial primary key,
	firstName text not null,
	lastname text not null,
	username text not null,
	pass text not null
);
--drop table projects;
create table projects(
	id serial primary key,
	id_user integer not null,
	projectName text not null,
	timecheckin timestamp,
	timecheckout timestamp,
	constraint fk_user foreign key (id_user)
    references users(id)
);