-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: coin_db
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `dai`
--

DROP TABLE IF EXISTS `dai`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dai` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Slug` varchar(30) DEFAULT NULL,
  `Market` varchar(30) DEFAULT NULL,
  `Last` float DEFAULT NULL,
  `PercentChange` float DEFAULT NULL,
  `BaseVolume24` float DEFAULT NULL,
  `QuoteVolume24` float DEFAULT NULL,
  `BaseVolume` float DEFAULT NULL,
  `QuoteVolume` float DEFAULT NULL,
  `HighestBid24` float DEFAULT NULL,
  `LowestAsk24` float DEFAULT NULL,
  `Hwap` float DEFAULT NULL,
  `LowestAsk` float DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dai`
--

LOCK TABLES `dai` WRITE;
/*!40000 ALTER TABLE `dai` DISABLE KEYS */;
INSERT INTO `dai` VALUES (1,'dai','dai_brl',5.73,0,0,0,0,0,5.73,5.73,5.55,5.76,'2020-10-29 21:29:58'),(2,'dai','dai_brl',5.73,0,0,0,0,0,0,0,5.55,5.76,'2020-10-31 09:42:15'),(3,'dai','dai_brl',5.76,0.35,1.042,6,1.042,6,5.76,5.74,5.55,5.76,'2020-11-04 20:34:45'),(4,'dai','dai_brl',5.49,-1.08,125.373,688.359,125.373,688.359,5.55,5.49,5.42,5.7,'2020-11-05 22:32:25'),(5,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.43,5.62,'2020-11-07 00:42:53'),(6,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.62,'2020-11-07 11:39:19'),(7,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.62,'2020-11-07 12:59:21'),(8,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.62,'2020-11-07 13:16:34'),(9,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.62,'2020-11-07 13:47:15'),(10,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.61,'2020-11-08 09:24:51'),(11,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.61,'2020-11-08 09:26:07'),(12,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.61,'2020-11-08 09:36:19'),(13,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.61,'2020-11-08 09:46:56'),(14,'dai','dai_brl',5.49,0,0,0,0,0,0,0,5.37,5.61,'2020-11-08 09:54:23'),(15,'dai','dai_brl',5.49,0,1.002,5.5,1.002,5.5,5.49,5.49,5.36,5.59,'2020-11-10 19:40:58'),(16,'dai','dai_brl',5.49,0,1.002,5.5,1.002,5.5,5.49,5.49,5.36,5.59,'2020-11-10 19:53:29'),(17,'dai','dai_brl',5.49,0,1.002,5.5,1.002,5.5,5.49,5.49,5.36,5.59,'2020-11-10 21:00:50'),(18,'dai','dai_brl',5.45,0,0,0,0,0,5.45,5.45,5.45,5.57,'2020-11-15 15:33:28'),(19,'dai','dai_brl',5.45,0,0,0,0,0,5.45,5.45,5.45,5.57,'2020-11-15 15:43:08'),(20,'dai','dai_brl',5.45,0,0,0,0,0,5.45,5.45,5.45,5.57,'2020-11-15 15:49:26'),(21,'dai','dai_brl',5.45,0,0,0,0,0,0,0,5.45,5.58,'2020-11-17 20:54:50');
/*!40000 ALTER TABLE `dai` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-17 21:16:54
