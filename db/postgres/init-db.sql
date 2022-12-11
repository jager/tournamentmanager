-- Active: 1670776499834@@127.0.0.1@5432
create table tournaments (
    id serial primary key,
    tournamentname varchar(255) not null,
    startdate date,
    enddate date,
    starthour time,
    status smallint,
    stages jsonb    
);

create table teams (
    id serial primary key,
    teamname varchar(255) not null,
    tournament_id int not null
);