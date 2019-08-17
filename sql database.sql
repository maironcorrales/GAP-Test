create database GAPTest;

create table Users(
id_user int not null primary key identity(1,1), 
username varchar(45) not null,
user_password varchar(255) not null 
);

create table Clients(
id_client int not null primary key identity(1,1),
full_name varchar(45) not null,
identification int unique not null
);

create table Policies(
id_policy int not null primary key identity (1,1),
policy_name varchar(50) not null,
policy_description nvarchar(max) NOT NULL,
);

create table Client_has_Policy(
id_coverage_plan int primary key identity(1,1),
plan_Coverage_description nvarchar (max) not null,
cover_object varchar(30),
client_id_client integer not null foreign key references Clients(id_client),
policy_id_policy integer not null foreign key references Policies(id_policy),
coverage_start date not null,
coverage_amount integer not null,
coverage_period integer not null,
coverage_monthly_price decimal not null,
risk integer not null,

);