USE KokoTalksDB;
GO

CREATE TABLE [dbo].[Chat] (
	chat_id			int			NOT NULL IDENTITY(1,1),
	sender_id		varchar(50) NOT NULL,
	receriver_id	varchar(50) NOT NULL,
	message_id		int,
	
	CONSTRAINT chat_pk PRIMARY KEY ([chat_id] ASC)
);

CREATE TABLE [dbo].[Message] (
	message_id			int			 NOT NULL IDENTITY(1,1),
	message_delivered	TIME		 NOT NULL,
	messageUnread		bit			 NOT NULL,
	text				nvarchar(500) NOT NULL
	
	CONSTRAINT message_pk PRIMARY KEY ([message_id] ASC)
);

CREATE TABLE [dbo].[Profile] (
	profile_id		int			NOT NULL IDENTITY(1,1),
	profile_status	varchar(25) NOT NULL,
	num_of_friends	int			NOT NULL,
	sex				bit			NOT NULL,
	email			varchar(50) NOT NULL,
	name			varchar(50) NOT NULL,
	
	CONSTRAINT profile_pk PRIMARY KEY ([profile_id] ASC)
);

CREATE TABLE [dbo].[Friends] (
	profile_id int NOT NULL,
	newMessage bit NOT NULL,
	friend_id int NOT NULL, /*This is another profile id to find a friends info*/
	
	CONSTRAINT friend_pk PRIMARY KEY ([friend_id], [profile_id])
);

/*
	Friends:
	Dennis Henri 0
	Dennis Arthur 0
	Dennis Richard 0
*/