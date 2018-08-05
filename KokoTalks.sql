Create DATABASE KokoTalksDB;
USE KokoTalksDB;
GO

CREATE TABLE [dbo].[Messages] (
	message_id		int			IDENTITY(1,1),
	time            DATETIME,
	sender_id		int NOT NULL,
	receiver_id		int NOT NULL,
	text			nvarchar(500) NOT NULL,
	newMessage bit,
	CONSTRAINT [messages_pk] PRIMARY KEY (message_id),
	CONSTRAINT [sender_fk] FOREIGN KEY (sender_id) REFERENCES [dbo].[Profile] (profile_id),
	CONSTRAINT [receiver_fk] FOREIGN KEY (receiver_id) REFERENCES [dbo].[Profile] (profile_id)
);


CREATE TABLE [dbo].[Profile] (
	profile_id		int			IDENTITY(1,1),
	profile_pic		varchar(250),
	profile_status	varchar(25) NOT NULL,
	num_of_friends	int,
	sex				char(1)			NOT NULL,
	email			varchar(50) NOT NULL,
	password		varchar(30) NOT NULL,
	name			varchar(50) NOT NULL,
	CONSTRAINT profile_pk PRIMARY KEY ([profile_id] ASC)
);
 
CREATE TABLE [dbo].[Friends] (
	profile_id int NOT NULL,
	friend_id int NOT NULL, /*This is another profile id to find a friends info*/
	CONSTRAINT friend_pk PRIMARY KEY ([friend_id], [profile_id]),
	CONSTRAINT [friend_fk] FOREIGN KEY (friend_id) REFERENCES [dbo].[Profile] (profile_id)
	
);

/*
	Friends:
	Dennis Henri 0
	Dennis Arthur 0
	Dennis Richard 0
*/



INSERT INTO Messages VALUES (CURRENT_TIMESTAMP , 'Henrique' , 'Dennis', 'Would you look at that');

Select * from messages;