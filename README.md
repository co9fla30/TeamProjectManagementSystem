공모전(contest) 을 추가할 때, 이미지를 넣지 않으면 공모전 페이지가 열리지 않는 버그가 있습니다.\
공모전을 추가할 때 꼭 이미지를 첨부해주세요..!\
혹시 넣지 않은 채로, 생성하셨을 시, SQL의 contest 테이블에서 이미지가 없는 데이터를 삭제해주셔야됩니다.

SQL 명령어

create database tpms;

CREATE TABLE `tpms`.`user` (
  `id` VARCHAR(20) NOT NULL,
  `pwd` VARCHAR(20) NOT NULL,
  `name` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`id`));
 
CREATE TABLE `tpms`.`team` (
  `name` VARCHAR(20) NOT NULL,
  `intro` VARCHAR(100) NULL,
  PRIMARY KEY (`name`));

CREATE TABLE `tpms`.`team_member` (
  `user_id` VARCHAR(20) NOT NULL,
  `team_name` VARCHAR(20) NOT NULL,
  percentage INT DEFAULT 0,
  PRIMARY KEY (`user_id`, `team_name`)
);

CREATE TABLE `tpms`.`teamboard` (
  `no` INT NOT NULL AUTO_INCREMENT,
  `team_name` VARCHAR(20) NOT NULL,
  `user_id` VARCHAR(20) NOT NULL,
  `title` VARCHAR(20) NOT NULL,
  `date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `writer` VARCHAR(20) NOT NULL,
  `content` VARCHAR(500) NOT NULL,
PRIMARY KEY (`no`));

CREATE TABLE `tpms`.`memo_schedule` (
  `no` INT AUTO_INCREMENT,
  `type` VARCHAR(10) NOT NULL,
  `team_name` VARCHAR(20) NOT NULL,
  `user_id` VARCHAR(20),
  `date` CHAR(10) NOT NULL,
  `text` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`no`));

CREATE TABLE `tpms`.`todo` (
  `no` INT NOT NULL AUTO_INCREMENT,
  `team_name` VARCHAR(20) NOT NULL,
  `user_id` VARCHAR(20) NOT NULL,
  `text` VARCHAR(40) NOT NULL,
  `done` BOOL DEFAULT FALSE,
  PRIMARY KEY (`no`));

CREATE TABLE `tpms`.`contest` (
  `no` INT NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(30) NOT NULL,
  `s_date` VARCHAR(10) NOT NULL,
  `e_date` VARCHAR(10) NOT NULL,
  `entry` VARCHAR(50) NOT NULL,
  `theme` VARCHAR(50) NOT NULL,
  `host` VARCHAR(10) NOT NULL,
  `site` VARCHAR(50) NOT NULL,
  `image` MEDIUMBLOB NULL,
  PRIMARY KEY (`no`));

CREATE TABLE `tpms`.`post` (
  `no` INT NOT NULL AUTO_INCREMENT,
  `contest_no` INT NOT NULL,
  `writer_id` VARCHAR(20) NOT NULL,
  `writer_name` VARCHAR(5) NOT NULL,
  `title` VARCHAR(30) NOT NULL,
  `content` VARCHAR(200) NOT NULL,
  `date` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`no`));
