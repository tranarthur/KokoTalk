Create DATABASE [KokoTalkDB];
GO
USE [KokoTalkDB];
GO

DROP TABLE dbo.Messages;
DROP TABLE dbo.Friends
DROP TABLE dbo.Posts;
DROP TABLE dbo.Profile;


CREATE TABLE [dbo].[Profile] (
	profile_id		int			IDENTITY(1,1),
	fullname		varchar(50) NOT NULL,
	password		varchar(30) NOT NULL,
	email			varchar(50) NOT NULL,
	sex				char(1),
	age				int,
	num_of_friends 	int,
	city			varchar(100),
	province		varchar(100),
	job				varchar(100),
	company			varchar(100),
	school			varchar(100),
	profile_pic		varchar(250),
	profile_status	nvarchar(140),
	
	CONSTRAINT profile_pk PRIMARY KEY ([profile_id])
);

CREATE TABLE [dbo].[Messages] (
	message_id		int			IDENTITY(1,1),
	time            DATETIME NOT NULL,
	sender_id		int NOT NULL,
	receiver_id		int NOT NULL,
	text			nvarchar(500) NOT NULL,
	CONSTRAINT [messages_pk] PRIMARY KEY (message_id),
	CONSTRAINT [sender_fk] FOREIGN KEY (sender_id) REFERENCES [dbo].[Profile] (profile_id),
	CONSTRAINT [receiver_fk] FOREIGN KEY (receiver_id) REFERENCES [dbo].[Profile] (profile_id)
);
 
CREATE TABLE [dbo].[Friends] (
	profile_id int NOT NULL,
	friend_id int NOT NULL, /*This is another profile id to find a friends info*/
	newMessage bit,
	CONSTRAINT friend_pk PRIMARY KEY ([friend_id], [profile_id]),
	CONSTRAINT [friend_fk] FOREIGN KEY (friend_id) REFERENCES [dbo].[Profile] (profile_id)
	
);

CREATE TABLE [dbo].[Posts] (
	post_id int IDENTITY(1,1),
	profile_id int NOT NULL,
	post nvarchar(500) NOT NULL,
	postdate DATE NOT NULL,
	CONSTRAINT posts_pk PRIMARY KEY ([post_id]),
	CONSTRAINT [profile_fk] FOREIGN KEY (profile_id) REFERENCES [dbo].[Profile] (profile_id)
);

/*
select f.friend_id, f.newMessage, p.fullname,p.profile_pic, c3.sender_id, c3.text, c3.time 
	FROM dbo.Friends f LEFT OUTER JOIN dbo.Profile p 
		ON f.friend_id = p.profile_id 
	LEFT OUTER JOIN 
		(select c2.friend_id, c2.message_id, m.sender_id, m.text ,m.time FROM
			(select c1.friend_id, max(c1.message_id) AS message_id from (
				select message_id, receiver_id AS friend_id 
					from dbo.Messages 
				where sender_id = 1 
				UNION 
				select message_id, sender_id AS friend_id 
					from dbo.Messages 
				where receiver_id = 1) c1
			GROUP BY c1.friend_id) c2 
		INNER JOIN dbo.Messages m ON m.message_id = c2.message_id) c3
	 ON f.friend_id = c3.friend_id 
	WHERE f.profile_id = 1
	 ORDER BY time DESC;
*/	 
