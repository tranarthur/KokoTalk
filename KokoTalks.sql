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
	username		varchar(50) NOT NULL,
	password		varchar(30) NOT NULL,
	email			varchar(50) NOT NULL,
	sex				char(1),
	age				int,
	num_of_friends 	int,
	city			varchar(100),
	province		varchar(100),
	job				varchar(100),
	school			varchar(100),
	profile_pic		varchar(250),
	profile_status	nvarchar(140),
	
	CONSTRAINT profile_pk PRIMARY KEY ([profile_id] ASC)
);
 
CREATE TABLE [dbo].[Friends] (
	profile_id int NOT NULL,
	friend_id int NOT NULL, /*This is another profile id to find a friends info*/
	CONSTRAINT friend_pk PRIMARY KEY ([friend_id], [profile_id]),
	CONSTRAINT [friend_fk] FOREIGN KEY (friend_id) REFERENCES [dbo].[Profile] (profile_id)
	
);

CREATE TABLE [dbo].[Posts] (
	post_id int IDENTITY(1,1),
	profile_id int NOT NULL,
	post nvarchar(500) NOT NULL,
	postdate DATETIME NOT NULL,
	CONSTRAINT posts_pk PRIMARY KEY ([profile_id]),
	CONSTRAINT [profile_fk] FOREIGN KEY (profile_id) REFERENCES [dbo].[Profile] (profile_id)
	
);

INSERT INTO dbo.Profile (username, password, email, sex, profile_pic, profile_status) VALUES ('Henrique'),'a','henrique@email.com','')


INSERT INTO Messages VALUES (CURRENT_TIMESTAMP , 'Henrique' , 'Dennis', 'Would you look at that');

Select * from messages;