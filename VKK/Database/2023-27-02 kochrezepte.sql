-- ---------------------------------- 
drop database if exists kochrezepte; 
create database kochrezepte; 
use kochrezepte; 

-- ----------------------------------
-- MariaDB dump 10.19  Distrib 10.4.22-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: kochrezepte
-- ------------------------------------------------------
-- Server version	10.4.22-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `color` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Salat',NULL),(2,'Fleisch',NULL),(3,'Vegetarisch',NULL),(4,'Vegan',NULL),(5,'Fisch',NULL),(6,'Dessert',NULL),(7,'Rind',NULL);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredient` (
  `title` varchar(45) NOT NULL,
  `amount` double NOT NULL,
  `unit` varchar(45) NOT NULL,
  `recid` int(11) NOT NULL,
  PRIMARY KEY (`recid`,`title`),
  KEY `fk_ingredient_recipe1_idx` (`recid`),
  CONSTRAINT `fk_ingredient_recipe1` FOREIGN KEY (`recid`) REFERENCES `recipe` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES ('Essig',1,'EL',1),('Gem??sebr??he',1,'TL',1),('Honig',1,'EL',1),('Senf',1,'TL',1),('Wasser',1,'EL',1),('Hartk??se',300,'g',9),('Spaghetti',500,'g',9),('Tomatenso??e',400,'ml',9),('Bl??tterteig',1,'St??ck',10),('Frischk??se',150,'g',10),('Gew??rzmischung Baharat',5,'g',10),('Krustenschinken',200,'g',10),('Senf',1,'EL',10),('Sonnenblumenkerne',10,'g',10),('Zucchini',1,'St??ck',10),('??pfel',3,'St??ck',11),('Backpulver',3,'TL',11),('Butter oder Margarine',150,'g',11),('Eier (M)',2,'St??ck',11),('Mehl',250,'g',11),('Milch',5,'EL',11),('Puddingpulver (Vanille)',1,'St??ck',11),('Puderzucker',50,'g',11),('Salz',1,'Prise',11),('Zucker',150,'g',11),('Bandnudeln',250,'g',12),('Bio Zitrone',1,'St??ck',12),('Brokkoli',500,'g',12),('Butterschmalz',30,'g',12),('Gem??sebr??he',250,'ml',12),('Kleine Zwiebel',1,'St??ck',12),('Lachsfilet',500,'g',12),('Mehl',1,'EL',12),('Schlagsahne',200,'g',12),('Thymianzweige',6,'St??ck',12),('Cayennepfeffer',1,'Prise',13),('Chili',1,'St??ck',13),('Gem??sebr??he',1,'TL',13),('Kidneybohnen',250,'g',13),('Kreuzk??mmel',0.5,'TL',13),('Limette',1,'St??ck',13),('Linsen',400,'g',13),('Mais',285,'g',13),('Raps??l',2,'EL',13),('Salz',1,'Prise',13),('St??ckige Tomaten',800,'g',13),('Wei??e Bohnen',250,'g',13),('Zwiebel',1,'St??ck',13),('Champignons',150,'g',14),('gr??ne Paprikaschoten',150,'g',14),('Petersiliest??ngel',5,'St??ck',14),('Pfeffer',1,'Prise',14),('Rinderbr??he',3,'TL',14),('Rindersteaks',320,'g',14),('rote Paprikaschoten',150,'g',14),('Salz',1,'Prise',14),('Schmand',2,'EL',14),('Senf',1,'TL',14),('Sonnenblumen??l',1,'EL',14),('So??enbinder',20,'g',14),('Wasser',400,'ml',14);
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `pic` varchar(255) DEFAULT NULL,
  `servings` int(11) DEFAULT NULL,
  `time` int(11) DEFAULT NULL,
  `category` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_recipe_category1_idx` (`category`),
  CONSTRAINT `fk_recipe_category1` FOREIGN KEY (`category`) REFERENCES `category` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (1,'Honigdressing','\\Images\\Salatdressing.jpg',4,5,1),(9,'Spaghetti Napoli','\\Images\\Spaghetti.jpg',4,10,3),(10,'Schinken-Zucchini-Strudel','\\Images\\Schinken-Zucchini1.jpg',2,45,2),(11,'Apfelkuchen','\\Images\\Apfelkuchen.jpg',12,60,6),(12,'Lachs-Brokkoli-Nudeln','https://images.lecker.de/lachs-nudelpfanne-mit-brokkoli-rezept,id=90dc4fe0,b=lecker,w=610,cg=c.jpg',4,35,5),(13,'Chili sin carne','https://emmikochteinfach.de/wp-content/uploads/2023/01/Chili-sin-Carne-schnell-und-einfach-1.webp',4,30,4),(14,'Rindfleisch-Gem??se-Pfanne','https://images.aws.nestle.recipes/resized/8129cddb29bf167fd47c098682dff02c_id71528_rindfleischgemuesepfanne1500x700_375_400.jpg',2,25,7);
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `step`
--

DROP TABLE IF EXISTS `step`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `step` (
  `no` int(11) NOT NULL,
  `description` varchar(511) NOT NULL,
  `recid` int(11) NOT NULL,
  PRIMARY KEY (`no`,`recid`),
  KEY `fk_step_recipe_idx` (`recid`),
  CONSTRAINT `fk_step_recipe` FOREIGN KEY (`recid`) REFERENCES `recipe` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `step`
--

LOCK TABLES `step` WRITE;
/*!40000 ALTER TABLE `step` DISABLE KEYS */;
INSERT INTO `step` VALUES (1,'Alles gut vermischen.',1),(1,'Spaghetti kochen',9),(1,'Zucchini grob reiben',10),(1,'??pfel sch??len, vierteln, Kerngeh??use entfernen und in W??rfel schneiden',11),(1,'Brokkoli putzen, waschen und in kleine R??schen teilen. Zwiebel sch??len und fein w??rfeln',12),(1,'Die Bohnen in ein Sieb gie??en, kurz kalt absp??len und gut abtropfen lassen. Ebenso mit den Linsen verfahren. Den Mais dazugeben und ebenfalls abtropfen lassen.',13),(1,'Rindersteaks waschen, trocken tupfen und in Streifen schneiden. Champignons putzen und in Viertel schneiden. Paprikaschoten waschen, Kerne und wei??e Innenh??ute entfernen und in Streifen schneiden. ',14),(2,'Salat damit anmachen',1),(2,'Tomatenso??e unterr??hren',9),(2,'Schinken in ca. 1cm dicke Streifen schneiden',10),(2,'Fett, Zucker und Salz mit den Schneebesen des Handr??hrger??tes wei??cremig aufschlagen',11),(2,'Lachsfilet in gro??e W??rfel schneiden',12),(2,'Die Zwiebel sch??len und fein w??rfeln. Das ??l in einem Topf erhitzen und die Zwiebelw??rfel darin glasig d??nsten. Bohnen, Linsen und Mais hinzuf??gen und kurz and??nsten.',13),(2,'In einer Pfanne THOMY Reines Sonnenblumen??l hei?? werden lassen. Rindersteaksstreifen kr??ftig mit Salz und Pfeffer w??rzen, in der Pfanne anbraten, herausnehmen und beiseite stellen. Im Bratensatz Paprika und Champignons and??nsten.',14),(3,'Fertig :)',1),(3,'Hartk??se reiben',9),(3,'Sonnenblumenkerne ohne Fettzugabe in einer Pfanne anbraten, bis sie leicht braun sind',10),(3,'Eier nacheinander unterr??hren',11),(3,'Thymian waschen, trocken sch??tteln und die Bl??ttchen, bis auf etwas zum Bestreuen, abzupfen',12),(3,'Anschlie??end alles mit den st??ckigen Tomaten abl??schen, verr??hren und aufkochen lassen. Dann Gem??sebr??he anr??hren und mit in den Topf geben. Salz, Pfeffer und Kreuzk??mmel und nach Belieben Chili einr??hren und das Ganze zugedeckt ca. 8 Minuten weiterk??cheln lassen.',13),(3,'Wasser zugie??en und zum Kochen bringen. MAGGI Rinder Bouillon darin aufl??sen und bei mittlerer W??rmezufuhr offen ca. 5 Min. garen. Dabei gelegentlich umr??hren. Mit So??enbinder bis zur gew??nschten S??migkeit binden. Mit Pfeffer abschmecken. ',14),(4,'Hartk??se ??ber Spaghetti streuen',9),(4,'Zucchini hinzu geben und ca. 2-3 min. anbraten',10),(4,'Puddingpulver, Mehl und Backpulver mischen',11),(4,'Nudeln in reichlich kochendem Salzwasser nach Packungsangabe kochen und abtropfen lassen (evtl. etwas Nudelwasser auffangen) ',12),(4,'Zum Schluss das vegane Chili sin Carne mit ein paar Spritzern Limette abschmecken und je nachdem, wie scharf du es magst, noch mit Chili nachw??rzen. Das fertige Gericht nach Belieben mit Jalapenos garnieren.',13),(4,'Petersilie waschen, trocken sch??ttel und grob hacken. Schmand und THOMY Delikatess-Senf mittelscharf unterr??hren. Fleisch wieder in die Sauce geben und mit hei?? werden lassen. Mit Petersilie bestreut servieren. Dazu schmeckt Kartoffel P??ree oder Reis. ',14),(5,'Fertig',9),(5,'Frischk??se, Senf und Gew??rzmischung \"Baharat\" dazugeben und gut umr??hren',10),(5,'Mehl-Mischung und Milch abwechselnd unter den Teig heben',11),(5,'15 g Butterschmalz in einer gro??en Pfanne erhitzen, Lachs darin unter vorsichtigem Wenden 3???4 Minuten anbraten',12),(6,'Schinkenstreifen unterheben',10),(6,'??pfel unter den Teig heben',11),(6,'Mit Salz und Pfeffer w??rzen und aus der Pfanne nehmen',12),(7,'Mit Salz und Pfeffer abschmecken',10),(7,'Teig in eine gefettete, mit Mehl ausgest??ubte Springform (26 cm) geben und glatt streichen',11),(7,'15 g Butterschmalz in die hei??e Pfanne geben. Brokkoli unter Wenden darin anbraten, dabei zum Schluss Zwiebeln zuf??gen und kurz mitbraten',12),(8,'Bl??tterteig halbieren und Pfanneninhalt auf beide H??lften verteilen',10),(8,'Kuchen im vorgeheizten Backofen (E-Herd: 175 ??C/ Umluft: 150 ??C/ Gas: s. Hersteller) ca. 45 Minuten backen',11),(8,'Mit Mehl best??uben, Thymianb??ttchen zuf??gen',12),(9,'Bl??tterteig einfalten',10),(9,'Kuchen aus dem Ofen nehmen, auf einem Kuchengitter ausk??hlen lassen und aus der Form l??sen',11),(9,'Br??he und Sahne angie??en und ca. 3 Minuten k??cheln lassen',12),(10,'Oben ca. 4-5 Schlitze in den Teig machen machen',10),(10,'Mit Puderzucker best??uben',11),(10,'Zitrone hei?? waschen, trocken tupfen und die H??lfte der Schale fein abreiben. 1 Zitronenh??lfte auspressen',12),(11,'Bei 220??C Ober-/Unterhitze ca. 20 min. backen',10),(11,'Fertig',11),(11,'Zitronenschale in die So??e geben und die So??e mit Salz, Pfeffer und 1 EL Zitronensaft abschmecken',12),(12,'Fertig',10),(12,'Lachs in die hei??e So??e geben und kurz darin erhitzen',12),(13,'Abgetropfte Nudeln unterheben (dabei evtl. noch etwas Nudelkochwasser zum Andicken angie??en) und mit dem restlichen Thymian bestreuen',12);
/*!40000 ALTER TABLE `step` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-27 12:43:37
