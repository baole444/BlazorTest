-- Script for MySql Server version 8.0.39

create database Staffs;

use Staffs;

create table gender (
	GenderID int primary key not null auto_increment,
    GenderDescription varchar(100)
);

create table department (
	DepartmentID int primary key not null auto_increment,
    DepartmentName varchar(100)
);

create table employee (
	-- EmployeeID char(36) primary key default (UUID()),
    -- Above is ID in UUID v4, this is not compatible with some older version of mySQL, it is optional
	EmployeeID int primary key not null auto_increment,
    FirstName varchar(100),
    LastName varchar(100),
    Email varchar(100),
    DateOfBirth date,
    GenderID int,
    DepartmentID int,
    foreign key (GenderID) references gender(GenderID) on delete cascade,
    foreign key (DepartmentID) references department(DepartmentID) on delete cascade
    
);

insert into gender (GenderDescription) values
	("Male"),
    ("Female"),
    ("LGBTQ+"),
    ("Do not want to specify");

insert into department (DepartmentName) values
	("Sales"),
    ("Human Resources"),
    ("Financial Accounting"),
    ("Management"),
    ("IT"),
    ("Research and Development");
    
insert into employee (FirstName, LastName, Email, DateOfBirth, GenderID, DepartmentID) values
	("John", "Lee", "johnTheRockPillar@gmail.com", "1990-10-3", (select GenderID from gender where GenderDescription = "Male" limit 1), (select DepartmentID from department where DepartmentName = "IT" limit 1)),
    ("Porjasky", "Domskoi", "PDMru564376@gmail.com", "1995-3-4", (select GenderID from gender where GenderDescription = "Male" limit 1), (select DepartmentID from department where DepartmentName = "Research and Development" limit 1)),
	("Wuan", "Si", "handsomeQuan69420@gmail.com", "2000-5-6", (select GenderID from gender where GenderDescription = "Male" limit 1), (select DepartmentID from department where DepartmentName = "Financial Accounting" limit 1)),
    ("May", "Silla", "SillyMayXD@yahoo.com", "2002-10-2", (select GenderID from gender where GenderDescription = "Female" limit 1), (select DepartmentID from department where DepartmentName = "Human Resources" limit 1)),
	("Niko", "Oneshot", "NikodefNotaCat@TWM.protocol.com", "2014-6-30", (select GenderID from gender where GenderDescription = "Do not want to specify" limit 1), (select DepartmentID from department where DepartmentName = "Management" limit 1));


select * from gender;
select * from department;
select * from employee;

