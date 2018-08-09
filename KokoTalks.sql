Create DATABASE [KokoTalkDB];
GO
USE [KokoTalkDB];
GO

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
	newMessage bit,
	CONSTRAINT [messages_pk] PRIMARY KEY (message_id),
	CONSTRAINT [sender_fk] FOREIGN KEY (sender_id) REFERENCES [dbo].[Profile] (profile_id),
	CONSTRAINT [receiver_fk] FOREIGN KEY (receiver_id) REFERENCES [dbo].[Profile] (profile_id)
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
	postdate DATE NOT NULL,
	CONSTRAINT posts_pk PRIMARY KEY ([profile_id]),
	CONSTRAINT [profile_fk] FOREIGN KEY (profile_id) REFERENCES [dbo].[Profile] (profile_id)
);

INSERT INTO dbo.Profile (fullname, password, email, age, sex, num_of_friends, city, province, job, company, school, profile_pic, profile_status) VALUES ('Henrique','password','henrique@email.com', 35, 'M', 3, 'Brantford', 'Ontario', 'System Administrator', 'Tim Hortons', 'Universidade Estadual de Campinas', 'images/profile/henrique-profile-pic.jpg','Look, I''ll make it all manageable');

INSERT INTO dbo.Profile (fullname, password, email, age, sex, num_of_friends, city, province, job, company, school, profile_pic, profile_status) VALUES ('Dennis','password','dennis@email.com', 18, 'M', 3, 'Mississauga',  'Ontario', 'Technical Support', 'Google', 'University of Toronto', 'images/profile/dennis-profile-pic.jpg','Hola!');

INSERT INTO dbo.Profile (fullname, password, email, age, sex, num_of_friends, city, province, job, company, school, profile_pic, profile_status) VALUES ('Arthur','password','arthur@email.com', 25, 'M', 3, 'Brampton', 'Ontario', 'Web Developer', 'Self-Employed', 'Sheridan College', 'images/profile/arthur-profile-pic.jpg','404 STATUS NOT FOUND');

INSERT INTO dbo.Profile (fullname, password, email, age, sex, num_of_friends, city, province, job, school, profile_pic, profile_status) VALUES ('Richard','password','richard@email.com', 22, 'M', 3, 'Mississauga', 'Ontario', 'Student', 'Harvard University', 'images/profile/richard-profile-pic.jpg','我喜欢大屁股');

INSERT INTO dbo.Friends VALUES (1,2);
INSERT INTO dbo.Friends VALUES (2,1);
INSERT INTO dbo.Friends VALUES (1,3);
INSERT INTO dbo.Friends VALUES (3,1);
INSERT INTO dbo.Friends VALUES (1,4);
INSERT INTO dbo.Friends VALUES (4,1);

INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-08 19:07:30',2,1,'Hey!',0);
INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-08 19:08:40',1,2,'How are you?',0);
INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-08 19:09:20',1,2,'Good you?',0);
INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-08 20:01:10',2,1,'😀',1);
INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-09 20:01:10',2,3,'Finished',1);
INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-06 20:01:10',1,3,'Test',1);
INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-08 20:01:10',3,1,'Test',0);
INSERT INTO dbo.Messages (time, sender_id, receiver_id, text, newMessage) VALUES ('2018-08-09 20:01:10',1,3,'New',0);

select f.friend_id, p.fullname, c3.sender_id, c3.text, c3.time 
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

Select * from messages;