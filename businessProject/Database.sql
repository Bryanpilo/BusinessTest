CREATE DATABASE BusinessProject
Go
Use businessProject
go
CREATE TABLE TypeOfTransport (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
    Speed varchar(255)
);
