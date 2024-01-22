USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE tricks ( 
trick_id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
name varchar(60) NOT NULL,
stance varchar(60) NOT NULL,
bagged varchar (60) NOT NULL,
link varchar (300) NOT NULL
) 


--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO tricks (name, stance, bagged, link) VALUES('tre flip', 'regular', 'no', 'https://youtu.be/XGw3YkQmNig?si=C-8ClyT7bpZTGY1p')
INSERT INTO tricks (name, stance, bagged, link) VALUES('kickflip', 'regular', 'yes', 'https://youtu.be/Zebs7JZ2PW0?si=cqeRVCrc_Q88jb5z')
INSERT INTO tricks (name, stance, bagged, link) VALUES ('pop shuv', 'regular', 'yes', 'https://youtu.be/Oq9Y3i7HD40?si=dMmkjAmtq6UzP4Jp')
INSERT INTO tricks (name, stance, bagged, link) VALUES('Backside 360', 'regular', 'no', 'https://youtu.be/2v8dbWKry7w?si=WBHxrFHaCUrEQHEs')
INSERT INTO tricks (name, stance, bagged, link) VALUES('backside kickflip', 'regular', 'no', 'https://youtu.be/0Ae_bLiOA8s?si=MG4sKjD8WXkD-yph')
INSERT INTO tricks (name, stance, bagged, link) VALUES ('backside bigspin', 'regular', 'no', 'https://youtu.be/Oq9Y3i7HD40?si=dMmkjAmtq6UzP4Jphttps://youtu.be/MsPPeoeukoU?si=fnGo7bbkwpDVgl00')


GO

