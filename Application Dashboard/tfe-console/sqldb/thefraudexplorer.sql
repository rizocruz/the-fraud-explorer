SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

USE `thefraudexplorer`;

CREATE TABLE IF NOT EXISTS `t_captcha` (
  `captcha` varchar(5) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `t_crypt` (
  `key` varchar(100) DEFAULT NULL,
  `iv` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `t_crypt` (`key`, `iv`, `password`) VALUES
('0uBu8ycVugDIJz60', '0uBu8ycVugDIJz60', 'KGBz77');

CREATE TABLE IF NOT EXISTS `t_agents` (
  `agent` varchar(200) DEFAULT NULL,
  `heartbeat` datetime DEFAULT NULL,
  `system` varchar(20) DEFAULT NULL,
  `version` varchar(15) DEFAULT NULL,
  `status` varchar(15) DEFAULT NULL,
  `name` varchar(200) DEFAULT NULL,
  `owner` varchar(200) DEFAULT NULL,
  `gender` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`agent`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `t_users` (
  `user` varchar(50) NOT NULL DEFAULT '',
  `password` varchar(40) DEFAULT NULL,
  `scope` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`user`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO `t_users` (`user`, `password`) VALUES
('admin', ' ');
