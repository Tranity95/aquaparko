--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.391.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 02.05.2023 9:57:39
-- Версия сервера: 10.3.38
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
USE aquaparko;

--
-- Удалить таблицу `attraction`
--
DROP TABLE IF EXISTS attraction;

--
-- Удалить таблицу `sauna`
--
DROP TABLE IF EXISTS sauna;

--
-- Удалить таблицу `productfood`
--
DROP TABLE IF EXISTS productfood;

--
-- Удалить таблицу `productprovider`
--
DROP TABLE IF EXISTS productprovider;

--
-- Удалить таблицу `product`
--
DROP TABLE IF EXISTS product;

--
-- Удалить таблицу `provider`
--
DROP TABLE IF EXISTS provider;

--
-- Удалить таблицу `food`
--
DROP TABLE IF EXISTS food;

--
-- Удалить таблицу `type`
--
DROP TABLE IF EXISTS type;

--
-- Удалить таблицу `ticket`
--
DROP TABLE IF EXISTS ticket;

--
-- Удалить таблицу `user`
--
DROP TABLE IF EXISTS user;

--
-- Удалить таблицу `role`
--
DROP TABLE IF EXISTS role;

--
-- Установка базы данных по умолчанию
--
USE aquaparko;

--
-- Создать таблицу `role`
--
CREATE TABLE role (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 3,
AVG_ROW_LENGTH = 8192,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `user`
--
CREATE TABLE user (
  id int(11) NOT NULL AUTO_INCREMENT,
  FirstName varchar(255) DEFAULT NULL,
  LastName varchar(255) DEFAULT NULL,
  SurName varchar(255) DEFAULT NULL,
  RoleId int(11) DEFAULT NULL,
  Login varchar(255) DEFAULT NULL,
  Password varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE user
ADD CONSTRAINT FK_user_roleId FOREIGN KEY (RoleId)
REFERENCES role (id) ON DELETE NO ACTION;

--
-- Создать таблицу `ticket`
--
CREATE TABLE ticket (
  id int(11) NOT NULL AUTO_INCREMENT,
  date datetime DEFAULT NULL,
  userId int(11) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE ticket
ADD CONSTRAINT FK_ticket_userId FOREIGN KEY (userId)
REFERENCES user (id) ON DELETE NO ACTION;

--
-- Создать таблицу `type`
--
CREATE TABLE type (
  Id int(11) NOT NULL AUTO_INCREMENT,
  Title varchar(255) DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 3,
AVG_ROW_LENGTH = 8192,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `food`
--
CREATE TABLE food (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  type int(11) DEFAULT NULL,
  price int(11) DEFAULT NULL,
  image varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 6,
AVG_ROW_LENGTH = 3276,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE food
ADD CONSTRAINT FK_food_type FOREIGN KEY (type)
REFERENCES type (Id) ON DELETE NO ACTION;

--
-- Создать таблицу `provider`
--
CREATE TABLE provider (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 5,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `product`
--
CREATE TABLE product (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 10,
AVG_ROW_LENGTH = 1820,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `productprovider`
--
CREATE TABLE productprovider (
  productId int(11) NOT NULL,
  providerId int(11) NOT NULL,
  PRIMARY KEY (productId, providerId)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 1170,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE productprovider
ADD CONSTRAINT FK_productprovider_productId FOREIGN KEY (productId)
REFERENCES product (id) ON DELETE NO ACTION;

--
-- Создать внешний ключ
--
ALTER TABLE productprovider
ADD CONSTRAINT FK_productprovider_providerId FOREIGN KEY (providerId)
REFERENCES provider (id) ON DELETE NO ACTION;

--
-- Создать таблицу `productfood`
--
CREATE TABLE productfood (
  foodId int(11) NOT NULL,
  productId int(11) NOT NULL,
  PRIMARY KEY (foodId, productId)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 2048,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE productfood
ADD CONSTRAINT FK_productfood_foodId FOREIGN KEY (foodId)
REFERENCES food (id) ON DELETE NO ACTION;

--
-- Создать внешний ключ
--
ALTER TABLE productfood
ADD CONSTRAINT FK_productfood_productId FOREIGN KEY (productId)
REFERENCES product (id) ON DELETE NO ACTION;

--
-- Создать таблицу `sauna`
--
CREATE TABLE sauna (
  id int(11) NOT NULL AUTO_INCREMENT,
  title varchar(255) DEFAULT NULL,
  temperature varchar(255) DEFAULT NULL,
  humidity varchar(255) DEFAULT NULL,
  price int(11) DEFAULT NULL,
  image varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 5,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

--
-- Создать таблицу `attraction`
--
CREATE TABLE attraction (
  id int(11) NOT NULL,
  title varchar(255) DEFAULT NULL,
  scaryLvl int(11) DEFAULT NULL,
  description varchar(255) DEFAULT NULL,
  image varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AVG_ROW_LENGTH = 2730,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_general_ci;

-- 
-- Вывод данных для таблицы role
--
INSERT INTO role VALUES
(1, 'Клиент'),
(2, 'Администратор');

-- 
-- Вывод данных для таблицы type
--
INSERT INTO type VALUES
(1, 'Еда'),
(2, 'Напиток');

-- 
-- Вывод данных для таблицы user
--
INSERT INTO user VALUES
(1, 'Александр', 'Глушенко', 'Владимирович', 1, '1', '1'),
(2, 'Игорь', 'Гофман', 'Авраалович', 1, '2', '2'),
(3, 'Руслан', 'Русланов', 'Русланович', 2, '3', '3'),
(4, 'Начо', 'Варга', 'Мануэлевич', 2, '4', '4'),
(5, 'Лало', 'Саламанка', 'Гекторович', 2, '5', '5');

-- 
-- Вывод данных для таблицы provider
--
INSERT INTO provider VALUES
(1, 'ООО "Макфа"'),
(2, 'АО "Добрый"'),
(3, 'ООО "Еда-продукт"'),
(4, 'ОАО "Oz_dy food"');

-- 
-- Вывод данных для таблицы product
--
INSERT INTO product VALUES
(1, 'Говядина'),
(2, 'Сасиска салёни'),
(3, 'Соль'),
(4, 'Кока-кола'),
(5, 'Размарин'),
(6, 'Мука'),
(7, 'Дрожжи'),
(8, 'Кокос'),
(9, 'Этиловый спирт');

-- 
-- Вывод данных для таблицы food
--
INSERT INTO food VALUES
(1, 'Стейк', NULL, 700, '\\images\\steak.jpg'),
(2, 'Пина-колада', 2, 900, '\\images\\pina_colada.jpg'),
(3, 'Яичница с беконом', 1, 600, '\\images\\bacon_egg.jpg'),
(4, 'Кола', 2, 80, '\\images\\ola.png'),
(5, 'Вода', 2, 50, '\\images\\water.jpg');

-- 
-- Вывод данных для таблицы ticket
--
-- Таблица aquaparko.ticket не содержит данных

-- 
-- Вывод данных для таблицы sauna
--
INSERT INTO sauna VALUES
(1, 'Русская баня', '70', '75', 1000, '~\\..\\images\\russian.jpg'),
(2, 'Финская сауна', '90', '10', 1100, '~\\..\\images\\finnish.jpg'),
(3, 'Турецкий хамам', '45', '90', 1200, '~\\..\\images\\turkish.jpg'),
(4, 'Инфракрасная сауна', '40', '50', 1300, '~\\..\\images\\infra.jpg');

-- 
-- Вывод данных для таблицы productprovider
--
INSERT INTO productprovider VALUES
(1, 3),
(1, 4),
(2, 4),
(3, 1),
(3, 3),
(4, 2),
(5, 3),
(6, 1),
(7, 1),
(7, 3),
(8, 2),
(8, 3),
(9, 2),
(9, 4);

-- 
-- Вывод данных для таблицы productfood
--
INSERT INTO productfood VALUES
(1, 1),
(1, 3),
(2, 8),
(2, 9),
(3, 1),
(3, 2),
(4, 4),
(5, 6);

-- 
-- Вывод данных для таблицы attraction
--
INSERT INTO attraction VALUES
(1, 'Детская горка\r\n', 1, 'Горка для ваших детей. Самая безопасная и обыкновенная.', '\\images\\kid.jpg'),
(2, 'Прямая горка\r\n', 2, 'Горка с прямым спуском. Не очень страшная.', '\\images\\straight.jpg'),
(3, 'Поворотная горка\r\n', 4, 'Горка с поворотом. Чуть страшнее.', '\\images\\turn.jpg'),
(4, 'Горка-трамплин', 10, 'После резкого спуска будьте готовы взлететь!', '\\images\\trampoline.jpg'),
(5, 'Монстр-горка', 9, 'Спуск под углом 80 градусов.', '\\images\\monster.jpg'),
(6, 'Горка-туннель', 6, 'Горка с крутым спуском в туннеле. Страшно.', '\\images\\tunnel.jpg');

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;