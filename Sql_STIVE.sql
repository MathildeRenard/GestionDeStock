#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------

#------------------------------------------------------------
# Table: Role
#------------------------------------------------------------

CREATE TABLE Role(
        ID  Int  Auto_increment  NOT NULL ,
        Name Varchar (50) NOT NULL
	,CONSTRAINT Role_PK PRIMARY KEY (ID)
)ENGINE=InnoDB;

#------------------------------------------------------------
# Table: User
#------------------------------------------------------------

CREATE TABLE stive.User(
        ID        Int  Auto_increment  NOT NULL ,
        Login          Varchar (50) NOT NULL ,
        Password       Varchar (50) NOT NULL ,
        LastName       Varchar (50) NOT NULL ,
        FirstName      Varchar (50) NOT NULL ,
        Adress         Varchar (100) NOT NULL ,
        Phone          Int NOT NULL ,
        Mail           Varchar (100) NOT NULL,
        ID_Role        Int NOT NULL
	,CONSTRAINT User_PK PRIMARY KEY (ID)
        ,CONSTRAINT User0_FK FOREIGN KEY (ID_Role) REFERENCES Role(ID)
)ENGINE=InnoDB;

#------------------------------------------------------------
# Table: Provider
#------------------------------------------------------------

CREATE TABLE Provider(
        ID      Int  Auto_increment  NOT NULL ,
        Name     Varchar (50) NOT NULL ,
        Adress   Varchar (100) NOT NULL ,
        Mail     Varchar (100) NOT NULL
	,CONSTRAINT Provider_PK PRIMARY KEY (ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Family
#------------------------------------------------------------

CREATE TABLE Family(
        ID  Int  Auto_increment  NOT NULL ,
        Name Varchar (50) NOT NULL
	,CONSTRAINT Family_PK PRIMARY KEY (ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Home
#------------------------------------------------------------

CREATE TABLE Home(
        ID   Int  Auto_increment  NOT NULL ,
        Name  Varchar (50) NOT NULL
	,CONSTRAINT Home_PK PRIMARY KEY (ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Order
#------------------------------------------------------------

CREATE TABLE stive.Order(
        ID             Int  Auto_increment  NOT NULL ,
        Date           Date NOT NULL ,
        Total          decimal NOT NULL,
        ID_User        Int NOT NULL
	,CONSTRAINT Order_PK PRIMARY KEY (ID)

	,CONSTRAINT Order_User_FK FOREIGN KEY (ID_User) REFERENCES User(ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Warehouse
#------------------------------------------------------------

CREATE TABLE Warehouse(
        ID      Int  Auto_increment  NOT NULL ,
        Name    Varchar (50) NOT NULL ,
        Adress  Varchar (100) NOT NULL
	,CONSTRAINT Warehouse_PK PRIMARY KEY (ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Product
#------------------------------------------------------------

CREATE TABLE Product(
        ID                       Int  Auto_increment  NOT NULL ,
        Name                     Varchar (50) NOT NULL ,
        Description              Varchar (50) NOT NULL ,
        Quantity                 Int NOT NULL ,
        Available                Bit NOT NULL ,
        Product_year             Int NOT NULL ,
        Auto_replenishment       Bit NOT NULL ,
        Unit_price               Decimal NOT NULL ,
        Lot_Price                Decimal NOT NULL ,
        Quantity_lot             Int NOT NULL ,
        URL_Photo                Text NOT NULL,
        ID_Home                  Int NOT NULL ,
        ID_Warehouse             Int NOT NULL ,
        ID_Family                Int NOT NULL
	,CONSTRAINT Product_PK PRIMARY KEY (ID)
	,CONSTRAINT Product_Home_FK FOREIGN KEY (ID_Home) REFERENCES Home(ID)
	,CONSTRAINT Product_Warehouse0_FK FOREIGN KEY (ID_Warehouse) REFERENCES Warehouse(ID)
	,CONSTRAINT Product_Family1_FK FOREIGN KEY (ID_Family) REFERENCES Family(ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: OrderForm
#------------------------------------------------------------

CREATE TABLE OrderForm(
        ID             Int  Auto_increment  NOT NULL ,
        date           Date NOT NULL ,
        ID_Warehouse   Int NOT NULL ,
        ID_Provider    Int NOT NULL
	,CONSTRAINT OrderForm_PK PRIMARY KEY (ID)

	,CONSTRAINT OrderForm_Warehouse_FK FOREIGN KEY (ID_Warehouse) REFERENCES Warehouse(ID)
	,CONSTRAINT OrderForm_Provider0_FK FOREIGN KEY (ID_Provider) REFERENCES Provider(ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: ProductOrder
#------------------------------------------------------------

CREATE TABLE ProductOrder(
        ID          Int NOT NULL ,
        ID_Order    Int NOT NULL ,
        ID_Product  Int NOT NULL ,
        Quantity    Int NOT NULL,
        Total       Decimal NOt NULL
	,CONSTRAINT ProductOrder_PK PRIMARY KEY (ID)

	,CONSTRAINT ProductOrder_Product_FK FOREIGN KEY (ID_Product) REFERENCES Product(ID)
	,CONSTRAINT ProductOrder_Order0_FK FOREIGN KEY (ID_Order) REFERENCES stive.Order(ID)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: ProductOrderForm
#------------------------------------------------------------

CREATE TABLE ProductOrderForm(
        ID                 Int NOT NULL ,
        ID_OrderForm       Int NOT NULL ,
        ID_Product         Int NOT NULL ,
        Quantity           Int NOT NULL
	,CONSTRAINT ProductOrderForm_PK PRIMARY KEY (ID)

	,CONSTRAINT ProductOrderForm_Product_FK FOREIGN KEY (ID_Product) REFERENCES Product(ID)
	,CONSTRAINT ProductOrderForm_OrderForm0_FK FOREIGN KEY (ID_OrderForm) REFERENCES OrderForm(ID)
)ENGINE=InnoDB;

