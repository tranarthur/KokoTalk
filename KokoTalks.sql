Create DATABASE KokoTalksDB;
USE KokoTalksDB;
GO

CREATE TABLE [dbo].[Messages] (
	time            DATETIME,
	sender_id		varchar(50) NOT NULL,
	receriver_id	varchar(50) NOT NULL,
	text				nvarchar(500) NOT NULL
	
);


CREATE TABLE [dbo].[Profile] (
	profile_id		int			NOT NULL IDENTITY(1,1),
	profile_pic		varchar(250),
	profile_status	varchar(25) NOT NULL,
	num_of_friends	int			NOT NULL,
	sex				bit			NOT NULL,
	email			varchar(50) NOT NULL,
	name			varchar(50) NOT NULL,
	
	CONSTRAINT profile_pk PRIMARY KEY ([profile_id] ASC)
);

CREATE TABLE [dbo].[Friends] (
	profile_id int NOT NULL,
	newMessage bit ,
	friend_id int NOT NULL, /*This is another profile id to find a friends info*/
	
	CONSTRAINT friend_pk PRIMARY KEY ([friend_id], [profile_id])
);

/*
	Friends:
	Dennis Henri 0
	Dennis Arthur 0
	Dennis Richard 0
*/



INSERT INTO Messages VALUES (CURRENT_TIMESTAMP , 'Henrique' , 'Dennis', 'Would you look at that');

Select * from messages;