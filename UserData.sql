#CREATING THE BASIC DATABASE FOR BOSS FIHGT

CREATE DATABASE IF NOT EXISTS erinwaldram;
USE erinwaldram;

CREATE TABLE BOSSFIGHTUSERS (
	user_id			INTEGER		AUTO_INCREMENT	PRIMARY KEY,
	username		VARCHAR(200),
	password			VARCHAR(200),
	screenname 	VARCHAR(200)	
);

#CREATE TABLE USERSCORE(
	#user_id 			INTEGER			PRIMARY KEY,
   # score_1			INTEGER,
  #  score_2			INTEGER,
  #  score_3			INTEGER
#);

##CREATE TABLE LEADERBOARD(
	#user_id			INTEGER			PRIMARY KEY,
    #top_score		INTEGER
#);

SELECT * FROM BOSSFIGHTUSERS;

DROP TABLE BOSSFIGHTUSERS;
