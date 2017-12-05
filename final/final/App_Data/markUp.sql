/*Mark UP*/

/*STEPS: 
		
	2) INSERT INTO <tablename> (<col1>, <col2>,...)
		VALUES (
			<col1 data>, <col2 data>, ...
		};*/

	CREATE TABLE dbo.Buyer(
		BuyerID		int		NOT NULL	PRIMARY KEY,
		Name		nvarchar(50)	NOT NULL, 
	);

	CREATE TABLE dbo.Seller(
		SellerID		int		NOT NULL	PRIMARY KEY,
		Name		nvarchar(50)	NOT NULL, 
	);

	CREATE TABLE dbo.Item(
		ItemID		int		NOT NULL	PRIMARY KEY,
		SellerID	int		NOT NULL,
		Name		nvarchar(50)	NOT NULL, 
		Description	nvarchar(250)	NOT NULL,
		FOREIGN KEY ([SellerID]) REFERENCES [dbo].[Seller] ([SellerID])
			ON UPDATE CASCADE
			ON DELETE CASCADE
	);

	CREATE TABLE dbo.Bid(
		BidID		int		NOT NULL	PRIMARY KEY,
		BuyerID		int		NOT NULL,
		ItemID		int		NOT NULL,
		Price		int		NOT NULL, 
		TimeStamp	DATETIME2	NOT NULL,
		FOREIGN KEY (BuyerID) REFERENCES dbo.Buyer(BuyerID),
		FOREIGN KEY (ItemID) REFERENCES dbo.Item(ItemID)
			ON UPDATE CASCADE
			ON DELETE CASCADE
	);

	/*------------------SEED DATA---------------------*/

	INSERT INTO Buyer (BuyerID, Name)
		VALUES 
		(1, 'Jane Stone'),
		(2, 'Tom McMasters'),
		(3, 'Otto Vanderwall');

	INSERT INTO Seller (SellerID, Name)
		VALUES
		(1, 'Gale Hardy'),
		(2, 'Lyle Banks'),
		(3, 'Pearl Greene');

	INSERT INTO Item (ItemID, SellerID, Name, Description)
		VALUES
		(1001, 3, 'Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln'),
		(1002, 1, 'Albert Einsten Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927'),
		(1003, 2, 'Bob Dylan Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan');

	INSERT INTO Bid (BidID, BuyerID, ItemID, Price, TimeStamp)
		VALUES
		(1, 3, 1001, 250000, '12/04/2017 09:04:22'),
		(2, 1, 1003, 95000, '12/04/2017 08:44:03');