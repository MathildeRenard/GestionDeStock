-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : dim. 10 avr. 2022 à 15:00
-- Version du serveur : 10.4.21-MariaDB
-- Version de PHP : 8.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `stive`
--

-- --------------------------------------------------------

--
-- Structure de la table `family`
--

CREATE TABLE `family` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `family`
--

INSERT INTO `family` (`ID`, `Name`) VALUES
(1, 'Vin Rouge'),
(2, 'Vin Blanc'),
(4, 'Vin Rosé'),
(5, 'Vin Pétillants'),
(6, 'Vin Digestifs');

-- --------------------------------------------------------

--
-- Structure de la table `home`
--

CREATE TABLE `home` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `home`
--

INSERT INTO `home` (`ID`, `Name`) VALUES
(1, 'Maison de Lille'),
(3, 'Maison d\'Arras'),
(4, 'Maison de Paris'),
(5, 'Maison de bordeaux');

-- --------------------------------------------------------

--
-- Structure de la table `order`
--

CREATE TABLE `order` (
  `ID` int(11) NOT NULL,
  `Date` datetime NOT NULL,
  `Total` decimal(10,0) NOT NULL,
  `ConfirmOrder` tinyint(1) NOT NULL DEFAULT 0,
  `ID_User` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `order`
--

INSERT INTO `order` (`ID`, `Date`, `Total`, `ConfirmOrder`, `ID_User`) VALUES
(22, '2022-04-10 14:58:32', '0', 0, 1);

-- --------------------------------------------------------

--
-- Structure de la table `orderform`
--

CREATE TABLE `orderform` (
  `ID` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `ConfirmOrder` tinyint(4) NOT NULL,
  `ID_Provider` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Structure de la table `product`
--

CREATE TABLE `product` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Description` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Available` bit(1) NOT NULL,
  `Product_year` int(11) NOT NULL,
  `Auto_replenishment` bit(1) NOT NULL,
  `Unit_price` decimal(10,0) NOT NULL,
  `Lot_Price` decimal(10,0) NOT NULL,
  `Quantity_lot` int(11) NOT NULL,
  `URL_Photo` text NOT NULL,
  `ID_Home` int(11) NOT NULL,
  `ID_Warehouse` int(11) NOT NULL,
  `ID_Family` int(11) NOT NULL,
  `ID_Provider` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `product`
--

INSERT INTO `product` (`ID`, `Name`, `Description`, `Quantity`, `Available`, `Product_year`, `Auto_replenishment`, `Unit_price`, `Lot_Price`, `Quantity_lot`, `URL_Photo`, `ID_Home`, `ID_Warehouse`, `ID_Family`, `ID_Provider`) VALUES
(2, 'Vin de Lille', 'Vin de Lille', 555, b'1', 1997, b'0', '400', '5000', 15, 'https://www.cdiscount.com/pdt2/e/1/6/1/700x700/chlafitte16/rw/chateau-lafitte-2016-cotes-de-bordeaux-vin-rouge.jpg', 1, 1, 1, 1),
(3, 'Vin d\'Arras', 'Vin d\'Arras', 100, b'1', 1997, b'1', '25', '200', 10, 'http://cdn.shopify.com/s/files/1/1860/3211/products/chateau_des_karantes_rouge_9f0d88e8-aa2f-4456-a589-1f5873ef498c_1200x.jpg?v=1590151533', 3, 3, 1, 1),
(10, 'Vin de Paris', 'Vin de Paris', 300, b'1', 1995, b'0', '1000', '4500', 5, 'https://www.gallician.com/wp-content/uploads/sites/11/2019/09/Gallician-chateau-laval-min.png', 4, 5, 1, 1),
(11, 'Vin de Paris', 'Vin de Paris', 300, b'1', 1995, b'0', '1000', '4500', 5, 'https://www.gallician.com/wp-content/uploads/sites/11/2019/09/Gallician-chateau-laval-min.png', 4, 5, 4, 1);

-- --------------------------------------------------------

--
-- Structure de la table `productorder`
--

CREATE TABLE `productorder` (
  `ID` int(11) NOT NULL,
  `ID_Order` int(11) NOT NULL,
  `ID_Product` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Total` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Structure de la table `productorderform`
--

CREATE TABLE `productorderform` (
  `ID` int(11) NOT NULL,
  `ID_OrderForm` int(11) NOT NULL,
  `ID_Product` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

-- --------------------------------------------------------

--
-- Structure de la table `provider`
--

CREATE TABLE `provider` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Adress` varchar(100) NOT NULL,
  `Mail` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `provider`
--

INSERT INTO `provider` (`ID`, `Name`, `Adress`, `Mail`) VALUES
(1, 'Au Gré du Vin et des Saveurs Gourmandes', 'Rue de Lille', 'saveursgourmandes@mail.fr'),
(2, 'Caves Bérigny', 'Rue de Lille', 'cavesberigny@mail.fr'),
(4, 'Caves Paris', 'Rue de Paris', 'cavesparis@mail.fr');

-- --------------------------------------------------------

--
-- Structure de la table `role`
--

CREATE TABLE `role` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `role`
--

INSERT INTO `role` (`ID`, `Name`) VALUES
(1, 'Admin'),
(2, 'Client');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `Login` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `Adress` varchar(100) NOT NULL,
  `Phone` varchar(10) NOT NULL,
  `Mail` varchar(100) NOT NULL,
  `ID_Role` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`ID`, `Login`, `Password`, `LastName`, `FirstName`, `Adress`, `Phone`, `Mail`, `ID_Role`) VALUES
(1, 'Admin', '8gFXxFI0/tZwWCcjpwNa0jJ/SmIMSU8D4m17/NnC8OS446/F', 'test', 'test', 'test', '01212121212', 'test@test.fr', 1),
(2, 'test', 'HDzYreflaTlM290PIFDyydNGI0eRdicnmr1G4XmtmvhJNxS3', 'test', 'test', 'test', '0606060606', 'test@test.fr', 2),
(3, 'test2', '4jatEc8VrnSeUsj4B8bryMemPP3G3sQdJ0ZagvtfRX51Ai6R', 'test2', 'test2', 'test', '0909090909', 'test2@mzil.fr', 2),
(4, 'test3', '3uq5HZx/qX4IXN2CLQYDV6RJfLy6Bdk6MIC2IuKrTFDABPW8', 'test3', 'test3', 'test', '0', 'test3@mail.fr', 2),
(5, 'test42', '+9ckNTQsxM3eDsWz/zz5AtB0zxoHwRaTzavmcMW0U/sFwqUD', 'test42', 'test42', 'test2', '0808080808', 'test4@mail.fr2', 2),
(6, 'test4', 'K0FQPiDzvFyqZ2D+wkST3nc8xh53Cq8qysb5UTZ4JbBiTJGi', 'test4', 'test4', 'test', '0808080808', 'test4@mail.com', 1);

-- --------------------------------------------------------

--
-- Structure de la table `warehouse`
--

CREATE TABLE `warehouse` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Adress` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf32;

--
-- Déchargement des données de la table `warehouse`
--

INSERT INTO `warehouse` (`ID`, `Name`, `Adress`) VALUES
(1, 'Entrepôt de Lille', 'Rue de Lille'),
(3, 'Entrepôt d\'Arras', 'Rue d\'Arras'),
(4, 'Entrepôt de Bordeaux', 'Rue de Bordeaux'),
(5, 'Entrepôt de Paris', 'Rue de Paris');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `family`
--
ALTER TABLE `family`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `home`
--
ALTER TABLE `home`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Order_User_FK` (`ID_User`);

--
-- Index pour la table `orderform`
--
ALTER TABLE `orderform`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `OrderForm_Provider0_FK` (`ID_Provider`);

--
-- Index pour la table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `Product_Home_FK` (`ID_Home`),
  ADD KEY `Product_Warehouse0_FK` (`ID_Warehouse`),
  ADD KEY `Product_Family1_FK` (`ID_Family`),
  ADD KEY `Product_Provider2_FK` (`ID_Provider`);

--
-- Index pour la table `productorder`
--
ALTER TABLE `productorder`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ProductOrder_Product_FK` (`ID_Product`),
  ADD KEY `ProductOrder_Order0_FK` (`ID_Order`);

--
-- Index pour la table `productorderform`
--
ALTER TABLE `productorderform`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ProductOrderForm_Product_FK` (`ID_Product`),
  ADD KEY `ProductOrderForm_OrderForm0_FK` (`ID_OrderForm`);

--
-- Index pour la table `provider`
--
ALTER TABLE `provider`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `User0_FK` (`ID_Role`);

--
-- Index pour la table `warehouse`
--
ALTER TABLE `warehouse`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `family`
--
ALTER TABLE `family`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `home`
--
ALTER TABLE `home`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `order`
--
ALTER TABLE `order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT pour la table `orderform`
--
ALTER TABLE `orderform`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT pour la table `product`
--
ALTER TABLE `product`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT pour la table `productorder`
--
ALTER TABLE `productorder`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT pour la table `productorderform`
--
ALTER TABLE `productorderform`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT pour la table `provider`
--
ALTER TABLE `provider`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `role`
--
ALTER TABLE `role`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `warehouse`
--
ALTER TABLE `warehouse`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `Order_User_FK` FOREIGN KEY (`ID_User`) REFERENCES `user` (`ID`);

--
-- Contraintes pour la table `orderform`
--
ALTER TABLE `orderform`
  ADD CONSTRAINT `OrderForm_Provider0_FK` FOREIGN KEY (`ID_Provider`) REFERENCES `provider` (`ID`);

--
-- Contraintes pour la table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `Product_Family1_FK` FOREIGN KEY (`ID_Family`) REFERENCES `family` (`ID`),
  ADD CONSTRAINT `Product_Home_FK` FOREIGN KEY (`ID_Home`) REFERENCES `home` (`ID`),
  ADD CONSTRAINT `Product_Provider2_FK` FOREIGN KEY (`ID_Provider`) REFERENCES `provider` (`ID`),
  ADD CONSTRAINT `Product_Warehouse0_FK` FOREIGN KEY (`ID_Warehouse`) REFERENCES `warehouse` (`ID`);

--
-- Contraintes pour la table `productorder`
--
ALTER TABLE `productorder`
  ADD CONSTRAINT `ProductOrder_Order0_FK` FOREIGN KEY (`ID_Order`) REFERENCES `order` (`ID`),
  ADD CONSTRAINT `ProductOrder_Product_FK` FOREIGN KEY (`ID_Product`) REFERENCES `product` (`ID`);

--
-- Contraintes pour la table `productorderform`
--
ALTER TABLE `productorderform`
  ADD CONSTRAINT `ProductOrderForm_OrderForm0_FK` FOREIGN KEY (`ID_OrderForm`) REFERENCES `orderform` (`ID`),
  ADD CONSTRAINT `ProductOrderForm_Product_FK` FOREIGN KEY (`ID_Product`) REFERENCES `product` (`ID`);

--
-- Contraintes pour la table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `User0_FK` FOREIGN KEY (`ID_Role`) REFERENCES `role` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
