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
-- Table structure for table `tusd`
--

DROP TABLE IF EXISTS `tusd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tusd` (
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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tusd`
--

LOCK TABLES `tusd` WRITE;
/*!40000 ALTER TABLE `tusd` DISABLE KEYS */;
INSERT INTO `tusd` VALUES (1,'tusd','tusd_brl',5.87,5.58,0,0,0,0,5.87,5.56,5.5,5.88,'2020-10-29 21:30:48'),(2,'tusd','tusd_brl',5.87,0,0,0,0,0,0,0,5.5,5.88,'2020-10-31 09:42:50'),(3,'tusd','tusd_brl',5.5,-21.2,0,0,0,0,6.98,5.5,5.5,6,'2020-11-04 20:35:20'),(4,'tusd','tusd_brl',5.5,0,0,0,0,0,5.5,5.5,5.5,6,'2020-11-07 00:43:38'),(5,'tusd','tusd_brl',5.5,0,0,0,0,0,0,0,5.5,6,'2020-11-07 11:40:03'),(7,'tusd','tusd_brl',5.5,0,0,0,0,0,0,0,5.5,6,'2020-11-07 13:16:34'),(8,'tusd','tusd_brl',5.5,0,0,0,0,0,0,0,5.5,6,'2020-11-07 13:47:15'),(9,'tusd','tusd_brl',5.5,0,31.091,171,31.091,171,5.5,5.5,5.5,5.99,'2020-11-08 09:24:51'),(10,'tusd','tusd_brl',5.5,0,31.091,171,31.091,171,5.5,5.5,5.5,5.99,'2020-11-08 09:26:07'),(11,'tusd','tusd_brl',5.5,0,31.091,171,31.091,171,5.5,5.5,5.5,5.99,'2020-11-08 09:36:19'),(12,'tusd','tusd_brl',5.5,0,31.091,171,31.091,171,5.5,5.5,5.5,5.99,'2020-11-08 09:46:56'),(13,'tusd','tusd_brl',5.5,0,31.091,171,31.091,171,5.5,5.5,5.5,5.99,'2020-11-08 09:54:23'),(14,'tusd','tusd_brl',5.99,0,3.339,20,3.339,20,5.99,5.99,5.46,5.65,'2020-11-10 19:40:58'),(15,'tusd','tusd_brl',5.99,0,3.339,20,3.339,20,5.99,5.99,5.46,5.65,'2020-11-10 19:53:29'),(16,'tusd','tusd_brl',5.99,0,3.339,20,3.339,20,5.99,5.99,5.46,5.65,'2020-11-10 21:00:50'),(17,'tusd','tusd_brl',5.99,0,0,0,0,0,0,0,5.46,5.62,'2020-11-15 15:33:28'),(18,'tusd','tusd_brl',5.99,0,0,0,0,0,0,0,5.46,5.62,'2020-11-15 15:43:08'),(19,'tusd','tusd_brl',5.99,0,0,0,0,0,0,0,5.46,5.62,'2020-11-15 15:49:26'),(20,'tusd','tusd_brl',5.99,0,0,0,0,0,0,0,5.05,5.62,'2020-11-17 20:54:50');
/*!40000 ALTER TABLE `tusd` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-17 23:23:14
