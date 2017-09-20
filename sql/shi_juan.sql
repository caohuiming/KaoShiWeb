/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : shitiku

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2017-09-20 10:18:12
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for shi_juan
-- ----------------------------
DROP TABLE IF EXISTS `shi_juan`;
CREATE TABLE `shi_juan` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '试卷编号',
  `shi_juan_name` varchar(200) NOT NULL COMMENT '试卷名称',
  `is_deleted` int(1) NOT NULL DEFAULT '0' COMMENT '是否已删除1：已删除，0：未删除',
  `c_t` datetime DEFAULT CURRENT_TIMESTAMP,
  `u_t` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of shi_juan
-- ----------------------------
INSERT INTO `shi_juan` VALUES ('1', '五通一错题库-变电运维线下', '0', '2017-09-08 16:16:49', '2017-09-08 16:16:49');
INSERT INTO `shi_juan` VALUES ('2', '五通一错题库-变压器线下', '0', '2017-09-08 18:36:12', '2017-09-08 18:36:12');
INSERT INTO `shi_juan` VALUES ('3', '五通一错题库-开关线下', '0', '2017-09-10 11:48:37', '2017-09-10 11:48:37');
INSERT INTO `shi_juan` VALUES ('4', '五通一错题库-变电管理线下', '0', '2017-09-10 11:49:11', '2017-09-10 11:49:11');
INSERT INTO `shi_juan` VALUES ('5', '五通一错题库-检测线下', '0', '2017-09-10 11:49:39', '2017-09-10 11:49:39');
