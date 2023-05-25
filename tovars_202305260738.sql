--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 26.05.2023 7:38:40
-- Версия сервера: 8.0.33
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

--
-- Установка базы данных по умолчанию
--
USE tovars;

--
-- Удалить таблицу `category`
--
DROP TABLE IF EXISTS category;

--
-- Удалить таблицу `manufactorer`
--
DROP TABLE IF EXISTS manufactorer;

--
-- Удалить таблицу `product`
--
DROP TABLE IF EXISTS product;

--
-- Установка базы данных по умолчанию
--
USE tovars;

--
-- Создать таблицу `product`
--
CREATE TABLE product (
  id int NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  cost int DEFAULT NULL,
  discount varchar(255) DEFAULT NULL,
  category_id int DEFAULT NULL,
  manufactorer_id int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 21,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_unicode_ci;

--
-- Создать таблицу `manufactorer`
--
CREATE TABLE manufactorer (
  id int NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 20,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_unicode_ci;

--
-- Создать таблицу `category`
--
CREATE TABLE category (
  id int NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 15,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_unicode_ci;

-- 
-- Вывод данных для таблицы product
--
INSERT INTO product VALUES
(1, ' Книга "Гарри Поттер и философский камень"', 500, '0,1', 1, 1),
(2, ' Смартфон iPhone 12 Pro', 99990, '0,05', 2, 2),
(3, ' Ноутбук IdeaPad 3', 44990, '0,15', 2, 3),
(4, ' Кроссовки Gel-Kayano 27', 12990, '0,2', 3, 4),
(5, ' Шоколадная конфета Ferrero Rocher', 150, ' без скидки', 4, 5),
(6, ' Рюкзак Back To School', 2990, '0,1', 5, 6),
(7, ' Кофе в зернах "Arabica"', 700, ' без скидки', 4, 7),
(8, ' Стиральная машина WM 1080', 29990, '0,07', 6, 8),
(9, ' Шампунь "Elseve" для волос', 300, '0,08', 7, 9),
(10, ' Ноутбук MacBook Air', 89990, '0,05', 2, 2),
(11, ' Парфюм "La Vie Est Belle"', 7900, '0,12', 8, 10),
(12, ' Керамическая сковорода "Titanium"', 1590, '0,2', 9, 11),
(13, ' Набор фломастеров "Capitan"', 490, ' без скидки', 10, 12),
(14, ' Чай "Голден Сенча"', 250, '0,15', 4, 13),
(15, ' Монитор UltraSharp 27', 33990, '0,1', 11, 14),
(16, ' Блендер UltraBlend', 5990, ' без скидки', 12, 15),
(17, ' Маршрутизатор RT-AC86U', 16490, '0,05', 11, 16),
(18, ' Колонки Xtreme 3', 14990, '0,1', 13, 17),
(19, ' Гель для душа "Cool Water"', 590, ' без скидки', 8, 18),
(20, ' Лампа настольная "Ella"', 1590, '0,15', 14, 19);

-- 
-- Вывод данных для таблицы manufactorer
--
INSERT INTO manufactorer VALUES
(1, ' Блумсбери'),
(2, ' Apple'),
(3, ' Lenovo'),
(4, ' ASICS'),
(5, ' Ferrero'),
(6, ' Under Armor'),
(7, ' Lavazza'),
(8, ' LG'),
(9, ' L''Oreal'),
(10, ' Lancome'),
(11, ' Tefal'),
(12, ' Koh-I-Noor'),
(13, ' Lipton'),
(14, ' Dell'),
(15, ' Philips'),
(16, ' ASUS'),
(17, ' JBL'),
(18, ' Davidoff'),
(19, ' IKEA');

-- 
-- Вывод данных для таблицы category
--
INSERT INTO category VALUES
(1, ' литература'),
(2, ' техника'),
(3, ' спортивные товары'),
(4, ' продукты питания'),
(5, ' товары для школы'),
(6, ' бытовая техника'),
(7, ' товары для здоровья'),
(8, ' товары для красоты'),
(9, ' товары для кухни'),
(10, ' товары для творчества'),
(11, ' компьютеры и комплектующие'),
(12, ' кухонная техника'),
(13, ' аудиотехника'),
(14, ' товары для дома');

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;