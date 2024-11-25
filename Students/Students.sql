create database Students;

use Students;

create table class (
	ID int not null auto_increment,
    class_name varchar(10) not null,
    primary key (ID)
);

create table division (
	ID int not null auto_increment,
    div_name varchar(2) not null,
    primary key (ID)
);

create table student (
	ID int not null auto_increment,
    st_name varchar(100) not null,
    birth date,
	address varchar(200),
    photo varchar(255),
    class_id int,
    division_id int,
    primary key (ID),
    foreign key (class_id) references class(ID) on delete cascade,
    foreign key (division_id) references division(ID) on delete cascade
);

insert into class (class_name) values ('I');
insert into class (class_name) values ('II');
insert into class (class_name) values ('III');
insert into class (class_name) values ('IV');

insert into division (div_name) values('A');
insert into division (div_name) values('B');
insert into division (div_name) values('C');
insert into division (div_name) values('D');

insert into student (st_name, birth, address, photo, class_id, division_id)
values (
	'Marry Ann',
    '2000-04-10',
    '24th/Pine Av./Kentovesky',
    'marry_ann_2000.png',
    (select ID from class where class_name = "III" limit 1),
    (select ID from division where div_name = "A" limit 1)
);

insert into student (st_name, birth, address, photo, class_id, division_id)
values (
	'Tomskoi Nevsky',
    '1999-02-02',
    '10th/Birch Dist./Kentovesky',
    'tomskoi_nevsky_1999.png',
    (select ID from class where class_name = "IV" limit 1),
    (select ID from division where div_name = "C" limit 1)
);

insert into student (st_name, birth, address, photo, class_id, division_id)
values (
	'Diankoptsly D.Vladimir',
    '1998-01-09',
    'F10/East Wing/River Side Dorm/ Unit 10/Uni',
    'diankoptsly_d_vladimir.png',
    (select ID from class where class_name = "I" limit 1),
    (select ID from division where div_name = "B" limit 1)
);

insert into student (st_name, birth, address, photo, class_id, division_id)
values (
	'Akito Hanaku',
    '2001-07-04',
    '5th/Lion St./Kentovesky',
    'akito_hanaku.png',
    (select ID from class where class_name = "II" limit 1),
    (select ID from division where div_name = "D" limit 1)
);

insert into student (st_name, birth, address, photo, class_id, division_id)
values (
	'Johny Hill',
    '1997-04-05',
    '40th/Capital/East Entrance/Arsky/Kentovesky',
    'johny_hill.png',
    (select ID from class where class_name = "I" limit 1),
    (select ID from division where div_name = "A" limit 1)
);

select * from class;
select * from division;
select * from student;

select s.ID, s.st_name, s.birth, s.address, s.photo, c.class_name, d.div_name from student s join class c on s.class_id = c.ID join division d on s.division_id = d.ID;

select s.ID, s.st_name, s.birth, s.address, s.photo, c.class_name, d.div_name from student s join class c on s.class_id = c.ID join division d on s.division_id = d.ID where s.st_name like '%john%';