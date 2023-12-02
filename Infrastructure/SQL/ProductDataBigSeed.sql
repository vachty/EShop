declare @createdBy NVARCHAR(50) = 'systemseed'
declare @updatedBy NVARCHAR(50) = 'systemseed'
declare @createdOn datetime2(7) = getdate()
declare @updatedOn datetime2(7) = getdate()

BEGIN TRY
		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(), 'Product2', 'product2/fsgsg/image.jpg', 1500, '', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(),  'Product3', 'product3/fsgsg/image.jpg', 2999, 'Product3 description', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(),  'Product4', 'product4/fsgsg/image.jpg', 999, '', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(),  'Product5', 'product5/fsgsg/image.jpg', 999, 'Fifth product', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(), 'Product6', 'product6/fsgsg/image.jpg', 1999, 'Sixth product', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(),  'Product7', 'product7/fsgsg/image.jpg', 99, 'Seventh product', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(),  'Product8', 'product8/fsgsg/image.jpg', 99, '', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(),  'Product9', 'product9/fsgsg/image.jpg', 99999, 'Too expensive product', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(),  'Product10', 'product10/fsgsg/image.jpg', 9, 'Too cheap product', @createdOn, @createdBy, @updatedOn, @updatedBy)

		INSERT INTO dbo.Products(Id, Name, ImgUri, Price, Description, CreatedOn, CreatedBy, UpdatedOn,UpdatedBy)
		VALUES (newid(), 'Product11', 'product4/fsgsg/image.jpg', 999999, 'Only for chosen people product', @createdOn, @createdBy, @updatedOn, @updatedBy)
END TRY
BEGIN CATCH
	PRINT ERROR_MESSAGE();
END CATCH