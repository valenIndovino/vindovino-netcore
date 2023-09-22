-- Crear la base de datos "valendb"
CREATE DATABASE valendb;

-- Usar la base de datos "valendb"
USE valendb;

CREATE TABLE candidates (
    IdCandidate int PRIMARY KEY IDENTITY(1,1), -- IDENTITY indica autoincremento
    Name varchar(50),
    Surname varchar(150),
    Birthdate datetime,
    Email varchar(250) UNIQUE,
    InsertDate datetime,
    ModifyDate datetime NULL
);

CREATE TABLE candidateexperiences (
    IdCandidateExperience int PRIMARY KEY IDENTITY(1,1), -- IDENTITY indica autoincremento
    IdCandidate int,
    Company varchar(100),
    Job varchar(100),
    Description varchar(4000),
    Salary numeric(8,2),
    BeginDate datetime,
    EndDate datetime NULL,
    InsertDate datetime,
    ModifyDate datetime NULL,
    FOREIGN KEY (IdCandidate) REFERENCES candidates(IdCandidate)
);

SELECT * FROM candidates