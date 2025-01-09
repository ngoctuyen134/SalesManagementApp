-- Tạo cơ sở dữ liệu
CREATE DATABASE QLBanHangg
GO
USE QLBanHangg
GO

-- Bảng ProductOrigin: Lưu trữ thông tin nguồn gốc sản phẩm
CREATE TABLE ProductOrigin
(
    OriginID CHAR(10) PRIMARY KEY,           
    OriginCountry NVARCHAR(50) NOT NULL               
);


-- Bảng ProductType: Lưu trữ các loại sản phẩm
CREATE TABLE ProductType
(
    ProductTypeID CHAR(10) PRIMARY KEY NOT NULL,      
    ProductTypeName NVARCHAR(50) NOT NULL       -- Tên loại sản phẩm (Văn phòng phẩm, đồ ăn,...)
);

-- Bảng Supplier: Lưu trữ thông tin nhà cung cấp
CREATE TABLE Supplier
(
    SupplierID CHAR(10) PRIMARY KEY NOT NULL,         
    SupplierName NVARCHAR(100) NOT NULL,              
    Supp_Address NVARCHAR(200),                            
    Supp_Phone NVARCHAR(15) NOT NULL                       
);

-- Bảng Product: Lưu trữ thông tin sản phẩm
CREATE TABLE Product
(
    ProductID CHAR(10) PRIMARY KEY NOT NULL,          
    ProductName NVARCHAR(100) NOT NULL DEFAULT N'Product name required!', 
    OriginID CHAR(10) NOT NULL,                       
    ProductTypeID CHAR(10) NOT NULL,                  
    SupplierID CHAR(10) NOT NULL,                     
    Quantity INT CHECK (Quantity > 0) NOT NULL,                
    PurchasePrice DECIMAL(18, 2) CHECK(PurchasePrice >= 0), -- Giá nhập
    SalePrice DECIMAL(18, 2) CHECK(SalePrice >= 0),   -- Giá bán
    Pro_Image NVARCHAR(MAX),                              
    Notes NVARCHAR(MAX),                        -- Mô tả sản phẩm
    FOREIGN KEY (OriginID) REFERENCES ProductOrigin(OriginID),
    FOREIGN KEY (ProductTypeID) REFERENCES ProductType(ProductTypeID),
    FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID)
);


ALTER TABLE Product
ALTER COLUMN Quantity INT NOT NULL;




select *from Product
set dateformat dmy;
-- Bảng Employee: Lưu trữ thông tin nhân viên
CREATE TABLE Employee
(
    EmployeeID CHAR(10) PRIMARY KEY NOT NULL,   
	EmployeeFamily NVARCHAR(100) NOT NULL,
    EmployeeName NVARCHAR(100) NOT NULL,              
    BirthDate DATE NOT NULL,                          
    Gender NVARCHAR(10) NOT NULL CHECK(Gender IN (N'Male', N'Female', N'Other')), 
    Phone NVARCHAR(15) NOT NULL, 
    Emp_Address NVARCHAR(200)                             
);

-- Bảng Account: Lưu trữ thông tin tài khoản của nhân viên
CREATE TABLE Account
(
    EmployeeID CHAR(10) PRIMARY KEY  NOT NULL,         
    Username NVARCHAR(50) UNIQUE NOT NULL,            
    Acc_Password NVARCHAR(MAX) NOT NULL,                  
    Acc_Role NVARCHAR(50) NOT NULL,     -- Chức vụ
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);

-- Bảng Customer: Lưu trữ thông tin khách hàng
CREATE TABLE Customer
(
    CustomerID CHAR(10) PRIMARY KEY NOT NULL,   
	CustomerFamily NVARCHAR(100) NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,              
    BirthDate DATE NOT NULL,                          
    Gender NVARCHAR(10) NOT NULL CHECK(Gender IN (N'Male', N'Female', N'Other')), 
    Email NVARCHAR(100) NOT NULL,                     
    Phone NVARCHAR(15) NOT NULL,                      
    Cus_Address NVARCHAR(200)                         
);

-- Bảng PurchaseOrder: Lưu trữ thông tin phiếu nhập hàng
CREATE TABLE PurchaseOrder
(
    OrderID CHAR(10) PRIMARY KEY NOT NULL,            
    EmployeeID CHAR(10) NOT NULL,                     
    OrderDate DATE NOT NULL DEFAULT GETDATE(),        -- Ngày lập phiếu mặc định là ngày hiện tại
    TotalAmount DECIMAL(18, 2) NOT NULL CHECK(TotalAmount >= 0), -- Tổng tiền
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);

-- Bảng PurchaseOrderDetail: Lưu trữ chi tiết phiếu nhập hàng
CREATE TABLE PurchaseOrderDetail
(
    OrderID CHAR(10) NOT NULL,                        
    ProductID CHAR(10) NOT NULL,                      
    Quantity INT NOT NULL CHECK(Quantity > 0),        
    PurchasePrice DECIMAL(18, 2) NOT NULL CHECK(PurchasePrice >= 0), 
    TotalPrice DECIMAL(18, 2) NOT NULL CHECK(TotalPrice >= 0), 
    FOREIGN KEY (OrderID) REFERENCES PurchaseOrder(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    PRIMARY KEY (OrderID, ProductID)
);

-- Bảng Invoice: Lưu trữ thông tin hóa đơn bán hàng
CREATE TABLE Invoice
(
    InvoiceID CHAR(10) PRIMARY KEY NOT NULL,          
    EmployeeID CHAR(10) NOT NULL,                     
    CustomerID CHAR(10) NOT NULL,                    
    InvoiceDate DATE NOT NULL DEFAULT GETDATE(),      -- Ngày lập hóa đơn mặc định là ngày hiện tại
    TotalAmount DECIMAL(18, 2) NOT NULL CHECK(TotalAmount >= 0), -- Tổng tiền
    --PaymentMethod NVARCHAR(50) NOT NULL,              -- Hình thức thanh toán (tiền mặt, chuyển khoản, Momo)
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
INSERT INTO Invoice (InvoiceID, EmployeeID, CustomerID, InvoiceDate, TotalAmount)
VALUES 
('HD001', 'E001', 'KH001', '2024-10-04', 35000),
('HD002', 'E001', 'KH002', '2024-10-04', 160000),
('HD003', 'E001', 'KH003', '2024-10-04', 300000);
-- Bảng InvoiceDetail: Lưu trữ chi tiết hóa đơn bán hàng
CREATE TABLE InvoiceDetail
(
    InvoiceID CHAR(10) NOT NULL,                      
    ProductID CHAR(10) NOT NULL,                      
    Quantity INT NOT NULL CHECK(Quantity > 0),        
    TotalPrice DECIMAL(18, 2) NOT NULL CHECK(TotalPrice >= 0), -- Thành tiền
    FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
    PRIMARY KEY (InvoiceID, ProductID)
);
GO
INSERT INTO InvoiceDetail (InvoiceID, ProductID, Quantity, TotalPrice)
VALUES 
('HD001', 'SP001', 5 , 30000),
('HD001', 'SP002', 1 , 5000),
('HD002', 'SP003', 2 , 160000),
('HD003', 'SP004', 3 , 300000);
--Bảng Depot: Lưu trữ Kho hàng số lượng tồn kho
CREATE TABLE Depot
(
	ProductID CHAR(10),
	Quantity INT NOT NULL
	FOREIGN KEY (ProductID) REFERENCES Product(ProductID),
);
GO

INSERT INTO Depot (ProductID, Quantity)
VALUES 
('SP001', 1000),
('SP002', 500),
('SP003', 600),
('SP004', 1000),
('SP005', 500);

DELETE FROM Depot
WHERE ProductID IN ('SP001', 'SP002', 'SP003', 'SP004', 'SP005');


select * from Depot

INSERT INTO Employee (EmployeeID, EmployeeFamily, EmployeeName, BirthDate, Gender, Phone, Emp_Address)
VALUES 
('E001', N'Nguyễn Văn', N'Anh', '1999-05-10', N'Male', '0909123456', N'123 Nguyễn Văn Công'),
('E002', N'Lê Thị', N'Lan', '2005-07-15', N'Female', '0909345678', N'456 Lê Lợi'),
('E003', N'Lê Minh', N'Mẫn', '2003-07-19', N'Male', '0909345987', N'12 Nguyễn Tri Phương');


INSERT INTO Account (EmployeeID, Username, Acc_Password, Acc_Role)
VALUES 
('E001', N'Admin', N'Abc123', N'Admin'), 
('E002', N'NV001', N'Abc456', N'Nhân viên'),
('E003', N'NV002', N'Abc345', N'Kho');

GO
INSERT INTO ProductOrigin(OriginID, OriginCountry)
VALUES 
('NG001', N'Văn phòng phẩm Sang Hà'),
('NG002', N'Việt Nam')
GO
INSERT INTO ProductType(ProductTypeID, ProductTypeName)
VALUES 
('VPP001', N'Văn phòng phẩm');
GO
INSERT INTO Supplier(SupplierID, SupplierName, Supp_Phone, Supp_Address)
VALUES 
('NCC001', N'Văn phòng phẩm Sang Hà', '0812599938', N'465 Nguyễn Văn Công');
GO
--Tạo proc lưu trữ tài khoản

drop proc usp_Login
CREATE PROC USP_Login
    @Username NVARCHAR(50),
	@Acc_Password NVARCHAR(MAX)
	
AS
BEGIN
    SELECT * FROM Account WHERE Username = @username AND Acc_Password = @Acc_Password
END;

EXEC USP_Login @Username = 'Admin', @Acc_Password = 'Abc123';
EXEC USP_Login @Username = 'NV001', @Acc_Password = 'Abc456';


select * from Account

--Quản Lý Sản Phẩm
--Thêm sản phẩm
CREATE PROC PROC_AddProduct
	@ProductID CHAR(10), 
	@ProductName NVARCHAR(100), 
	@OriginID CHAR(10), 
	@ProductTypeID CHAR(10), 
	@SupplierID CHAR(10), 
	@Quantity INT, 
	@PurchasePrice DECIMAL(18, 2), 
	@SalePrice DECIMAL(18, 2),
	@Pro_Image NVARCHAR(MAX),
	@Notes NVARCHAR(MAX)
AS
BEGIN 
	INSERT INTO Product(ProductID, ProductName, OriginID, ProductTypeID, SupplierID, Quantity, PurchasePrice, SalePrice, Pro_Image, Notes) 
	VALUES (@ProductID, @ProductName, @OriginID, @ProductTypeID, @SupplierID, @Quantity, @PurchasePrice, @SalePrice, @Pro_Image, @Notes)
END

EXEC PROC_AddProduct
	@ProductID = 'SP001', 
	@ProductName = N'Bút bi Deli', 
	@OriginID = 'NG001', 
	@ProductTypeID = N'VPP001', --N'Văn phòng phẩm
	@SupplierID = N'NCC001', --N'Văn phòng phầm Sang Hà'
	@Quantity = 100, 
	@PurchasePrice = 3500, 
	@SalePrice = 6000,
	@Pro_Image = ' ',
	@Notes = ' '

--Select ProductID as [Mã sản phẩm], ProductName as [Tên sản phẩm], B.OriginID as [Nguồn gốc],
--	ProductTypeID as [Loại hàng], SupplierID as [Nhà cung cấp], 
--	   Quantity as [Số lượng], PurchasePrice as [Giá nhập], SalePrice as [Giá bán], 
--	   Pro_Image as [Hình ảnh], Notes as [Ghi Chú] from Product A join ProductOrigin B on A.OriginID = B.OriginID

SELECT A.ProductID as [Mã sản phẩm], 
       A.ProductName as [Tên sản phẩm], 
       B.OriginID as [Nguồn gốc],
       A.ProductTypeID as [Loại hàng], 
       A.SupplierID as [Nhà cung cấp], 
       D.Quantity as [Số lượng],    -- Lấy số lượng từ bảng Depot
       A.PurchasePrice as [Giá nhập], 
       A.SalePrice as [Giá bán], 
       A.Pro_Image as [Hình ảnh], 
       A.Notes as [Ghi chú]
FROM Product A
JOIN ProductOrigin B ON A.OriginID = B.OriginID
JOIN Depot D ON A.ProductID = D.ProductID;  -- Tham gia bảng Depot để lấy Quantity

select * from depot

--Cập nhật/Sửa Sản phẩm
CREATE PROC PROC_EditProduct
	@ProductID CHAR(10), 
	@ProductName NVARCHAR(100), 
	@OriginID CHAR(10), 
	@ProductTypeID CHAR(10), 
	@SupplierID CHAR(10), 
	@Quantity INT, 
	@PurchasePrice DECIMAL(18, 2), 
	@SalePrice DECIMAL(18, 2),
	@Pro_Image NVARCHAR(MAX),
	@Notes NVARCHAR(MAX)
AS
BEGIN 
	UPDATE Product
	SET ProductName=@ProductName, OriginID=@OriginID, ProductTypeID=@ProductTypeID, SupplierID=@SupplierID, 
		Quantity=@Quantity, PurchasePrice=@PurchasePrice, SalePrice=@SalePrice, Pro_Image=@Pro_Image, Notes=@Notes
	WHERE ProductID = @ProductID
END
DROP PROC PROC_EditProduct
--SELECT ProductID FROM Product WHERE ProductID= 'SP001'

--Quản Lý Nguồn Gốc
--Thêm Nguồn gốc
CREATE PROC PROC_AddOrigin
	@OriginID char(10), 
	@OriginCountry nvarchar(50)
AS
BEGIN 
	INSERT INTO ProductOrigin(OriginID, OriginCountry) 
	VALUES (@OriginID, @OriginCountry)
END
EXEC PROC_AddOrigin @OriginID = 'NG003', @OriginCountry = N'Mỹ';

select * from ProductOrigin

--Cập nhật nguồn gốc
CREATE PROC PROC_EditOrigin
	@OriginID char(10), 
	@OriginCountry nvarchar(50)
AS
BEGIN 
	UPDATE ProductOrigin
	SET OriginCountry = @OriginCountry
	WHERE OriginID = @OriginID
END
EXEC PROC_EditOrigin 'NG001', N'Việt Nam';

--Quản lý Loại sản phẩm
--Thêm Loại Sản phẩm
CREATE PROC PROC_AddProductType
	@ProductTypeID char(10), 
	@ProductTypeName nvarchar(50)
AS
BEGIN 
	INSERT INTO ProductType (ProductTypeID, ProductTypeName) 
	VALUES (@ProductTypeID, @ProductTypeName)
END
EXEC  PROC_AddProductType @ProductTypeID = 'BE001', @ProductTypeName = N'Gấu bông '

--Cập nhật thông tin loại sản phẩm
CREATE PROC PROC_EditProductType
	@ProductTypeID char(10), 
	@ProductTypeName nvarchar(50)
AS
BEGIN 
	UPDATE ProductType
	SET ProductTypeName = @ProductTypeName
	WHERE ProductTypeID = @ProductTypeID
END
EXEC  PROC_EditProductType @ProductTypeID = 'BE001', @ProductTypeName = N'Gấu bông 1'
select * from ProductType

--Quản lý Nhà cung cấp
--Thêm Nhà cung cấp
CREATE PROC PROC_AddSupplier
	@SupplierID char(10), 
	@SupplierName nvarchar(100),
	@Supp_Address nvarchar(200),
	@Supp_Phone nvarchar(15)

AS
BEGIN 
	INSERT INTO Supplier (SupplierID, SupplierName, Supp_Address, Supp_Phone) 
	VALUES (@SupplierID, @SupplierName, @Supp_Address, @Supp_Phone)
END

--Cập nhật Nhà cung cấp
CREATE PROC PROC_EditSupplier
	@SupplierID char(10), 
	@SupplierName nvarchar(100),
	@Supp_Address nvarchar(200),
	@Supp_Phone nvarchar(15)
AS
BEGIN 
	UPDATE Supplier
	SET SupplierName = @SupplierName, Supp_Address = @Supp_Address, Supp_Phone = @Supp_Phone
	WHERE SupplierID = @SupplierID
END

--Quản lý Nhân viên
--Thêm Nhân viên
CREATE PROC PROC_AddEmployee
	@EmployeeID char(10), 
	@EmployeeFamily nvarchar(100),
	@EmployeeName nvarchar(100),
	@BirthDate date,
	@Gender nvarchar(10),
	@Phone nvarchar(15),
	@Emp_Address nvarchar(200)
AS
BEGIN 
	INSERT INTO Employee (EmployeeID, EmployeeFamily, EmployeeName, BirthDate, Gender, Phone, Emp_Address) 
	VALUES (@EmployeeID, @EmployeeFamily, @EmployeeName, @BirthDate, @Gender, @Phone, @Emp_Address)
END

Select A.EmployeeID as [Mã nhân viên], EmployeeFamily as [Họ nhân viên], 
   EmployeeName as [Tên nhân viên], B.Acc_Role as [Chức vụ], BirthDate as [Ngày sinh], 
   Gender as [Giới tính], Phone as [Số điện thoại], Emp_Address as [Địa chỉ] from Employee A  JOIN Account B on B.EmployeeID = A.EmployeeID
  


--Cập nhật nhân viên
CREATE PROC PROC_EditEmployee
	@EmployeeID char(10), 
	@EmployeeFamily nvarchar(100),
	@EmployeeName nvarchar(100),
	@BirthDate date,
	@Gender nvarchar(10),
	@Phone nvarchar(15),
	@Emp_Address nvarchar(200)
AS
BEGIN 
	UPDATE Employee
	SET  EmployeeFamily = @EmployeeFamily, EmployeeName = @EmployeeName, BirthDate = @BirthDate, 
		Gender = @Gender, Phone = @Phone, Emp_Address = @Emp_Address
	WHERE EmployeeID = @EmployeeID
END




--Quản lý Acccount
--Thêm Account
CREATE PROC PROC_AddAccount
	@EmployeeID char(10), 
	@Username nvarchar(50),
	@Acc_Password nvarchar(MAX),
	@Acc_Role nvarchar(50)
AS
BEGIN 
	INSERT INTO Account (Username, EmployeeID, Acc_Password, Acc_Role) 
	VALUES (@Username, @EmployeeID, @Acc_Password, @Acc_Role)
END
 select * from Account

DROP PROC PROC_EditAccount
--Cập nhập Account
CREATE PROC PROC_EditAccount
	@EmployeeID char(10), 
	@Username nvarchar(50),
	@Acc_Password nvarchar(MAX),
	@Acc_Role nvarchar(50)
AS
BEGIN 
	UPDATE Account
	SET EmployeeID = @EmployeeID, Username = @Username, Acc_Password = @Acc_Password, Acc_Role = @Acc_Role
	WHERE EmployeeID = @EmployeeID AND Username = @Username
END

--Quản Lý Khách hàng
--Thêm Khách hàng
CREATE PROC PROC_AddCustomer
	@CustomerID CHAR(10),   
	@CustomerFamily NVARCHAR(100),
    @CustomerName NVARCHAR(100),              
    @BirthDate DATE,                          
    @Gender NVARCHAR(10), 
    @Email NVARCHAR(100),                     
    @Phone NVARCHAR(15),                      
    @Cus_Address NVARCHAR(200) 
AS
BEGIN 
	INSERT INTO Customer (CustomerID, CustomerFamily, CustomerName, BirthDate, Gender, Email, Phone, Cus_Address) 
	VALUES (@CustomerID, @CustomerFamily, @CustomerName, @BirthDate, @Gender, @Email, @Phone, @Cus_Address)
END

--Cập nhật Khách hàng
CREATE PROC PROC_EditCustomer
	@CustomerID CHAR(10),   
	@CustomerFamily NVARCHAR(100),
    @CustomerName NVARCHAR(100),              
    @BirthDate DATE,                          
    @Gender NVARCHAR(10), 
    @Email NVARCHAR(100),                     
    @Phone NVARCHAR(15),                      
    @Cus_Address NVARCHAR(200)
AS
BEGIN 
	UPDATE Customer
	SET CustomerFamily = @CustomerFamily, CustomerName = @CustomerName, BirthDate = @BirthDate, 
	Gender = @Gender, Email = @Email, Phone = @Phone, Cus_Address = @Cus_Address
	WHERE CustomerID = @CustomerID
END

--Quản lý Phiếu nhập
--Thêm Phiếu nhập
CREATE PROC PROC_AddOrder
	@OrderID CHAR(10),            
    @EmployeeID CHAR(10),                     
    @OrderDate DATE, 
    @TotalAmount DECIMAL(18, 2) 
AS
BEGIN 
	INSERT INTO PurchaseOrder (OrderID, EmployeeID, OrderDate, TotalAmount) 
	VALUES (@OrderID, @EmployeeID, @OrderDate, @TotalAmount) 
END

--Cập nhật Phiếu nhập
CREATE PROC PROC_EditOrder
	@OrderID CHAR(10),            
    @EmployeeID CHAR(10),                     
    @OrderDate DATE, 
    @TotalAmount DECIMAL(18, 2) 
AS
BEGIN 
	UPDATE PurchaseOrder
	SET  EmployeeID = @EmployeeID, OrderDate = @OrderDate, TotalAmount = @TotalAmount
	WHERE OrderID = @OrderID
END


--Quản lý CTPN
--Thêm CTPN
CREATE PROC PROC_AddOrderDetail
	@OrderID char(10),            
    @ProductID char(10),                     
    @Quantity int, 
	@PurchasePrice decimal(18,2),
    @TotalPrice decimal(18, 2) 
AS
BEGIN 
	INSERT INTO PurchaseOrderDetail (OrderID, ProductID, Quantity, PurchasePrice, TotalPrice) 
	VALUES (@OrderID, @ProductID, @Quantity, @PurchasePrice, @TotalPrice) 
END

--Cập nhật CTPN
CREATE PROC PROC_EditOrderDetail
	@OrderID char(10),            
    @ProductID char(10),                     
    @Quantity int, 
	@PurchasePrice decimal(18,2),
    @TotalPrice decimal(18, 2) 
AS
BEGIN 
	UPDATE PurchaseOrderDetail
	SET Quantity = @Quantity, PurchasePrice = @PurchasePrice, TotalPrice = @TotalPrice
	WHERE OrderID = @OrderID AND ProductID = @ProductID
END

	   
--Quản lý Hóa đơn
--Thêm hóa đơn
CREATE PROC PROC_AddInvoice
	@InvoiceID CHAR(10),          
    @EmployeeID CHAR(10),                     
    @CustomerID CHAR(10),                    
    @InvoiceDate DATE,      
    @TotalAmount DECIMAL(18, 2)
AS
BEGIN 
	INSERT INTO Invoice (InvoiceID, EmployeeID, CustomerID, InvoiceDate, TotalAmount) 
	VALUES (@InvoiceID, @EmployeeID, @CustomerID, @InvoiceDate, @TotalAmount) 
END


Select InvoiceID as [Mã hóa đơn], CustomerID as [Mã Khách hàng], EmployeeID as [Mã Nhân viên], InvoiceDate as [Ngày lập], TotalAmount as [Tổng tiền] from Invoice ;

--Cập nhật hóa đơn
CREATE PROC PROC_EditInvoice
	@InvoiceID CHAR(10),          
    @EmployeeID CHAR(10),                     
    @CustomerID CHAR(10),                    
    @InvoiceDate DATE,      
    @TotalAmount DECIMAL(18, 2) 
AS
BEGIN 
	UPDATE Invoice
	SET EmployeeID = @EmployeeID, CustomerID = @CustomerID, 
		InvoiceDate = @InvoiceDate, TotalAmount = @TotalAmount
	WHERE InvoiceID = @InvoiceID
END
Select * from Invoice
-- Chạy thủ tục lưu trữ
EXEC PROC_EditInvoice 'HD001', 'E001', 'KH004', '2024-10-04', '35000.00';

drop proc PROC_EditInvoice
--Xem CTHD
Select InvoiceID as [Mã hóa đơn], A.ProductID as [Mã sách], ProductName as [Tên sách], A.Quantity as [Số lượng], 
A.Quantity*A.SalePrice as [Tổng tiền] from InvoiceDetail A join Product B on A.ProductID = B.ProductID

--Quản lý CTHD
--Thêm CTHD
CREATE PROC PROC_AddInvoiceDetail
	@InvoiceID CHAR(10),                      
    @ProductID CHAR(10),                      
    @Quantity INT,        
    @TotalPrice DECIMAL(18, 2)
AS
BEGIN 
	INSERT INTO InvoiceDetail (InvoiceID, ProductID, Quantity, TotalPrice) 
	VALUES (@InvoiceID, @ProductID, @Quantity, @TotalPrice) 
END


--Cập nhật CTHD
CREATE PROC PROC_EditInvoiceDetail
	@InvoiceID CHAR(10),                      
    @ProductID CHAR(10),                      
    @Quantity INT,        
    @TotalPrice DECIMAL(18, 2) 
AS
BEGIN 
	UPDATE InvoiceDetail
	SET  Quantity = @Quantity, 
		TotalPrice = @Quantity * (SELECT SalePrice FROM Product WHERE ProductID = @ProductID)
	WHERE InvoiceID = @InvoiceID AND ProductID = @ProductID
END

select * from InvoiceDetail


DROP PROC PROC_EditDepot
--Cập nhật kho
CREATE PROC PROC_EditDepot
    @ProductID CHAR(10),
    @Quantity INT
AS
BEGIN
        UPDATE Product
        SET Quantity =@Quantity
        WHERE ProductID = @ProductID;
END
select *from Invoice
SELECT TOP 1 InvoiceID FROM Invoice ORDER BY CAST(SUBSTRING(InvoiceID, 3, LEN(InvoiceID)-2) AS INT) DESC
EXEC PROC_EditDepot @ProductID = 'SP001', @Quantity = 10;
SELECT * FROM DEPOT
----In báo cáo
--In báo cáo
CREATE PROC PROC_PrintReport
	@start date,
	@end date
as
begin
	Select Product.ProductID, Product.ProductName, SUM(InvoiceDetail.Quantity) as [Soluong], SUM(InvoiceDetail.Quantity * Product.SalePrice) AS [Tongtien]
	from Invoice, InvoiceDetail, Product
	where Invoice.InvoiceDate BETWEEN @start And @end and InvoiceDetail.ProductID = Product.ProductID and Invoice.InvoiceID = InvoiceDetail.InvoiceID
	group by Product.ProductID, Product.ProductName
end

--In Hóa Đơn

CREATE PROC PROC_PrintHD
@InvoiceID CHAR(10)
AS
BEGIN
		declare @tong float;
		set @tong = 0;

		Select @tong = Sum(InvoiceDetail.Quantity * Product.SalePrice)
		from InvoiceDetail, Product
		where InvoiceID = @InvoiceID and Product.ProductID = InvoiceDetail.ProductID

		Select @InvoiceID as InvoiceID, InvoiceDetail.ProductID, Product.ProductName, 
		InvoiceDetail.Quantity, Product.SalePrice, InvoiceDetail.TotalPrice, Invoice.InvoiceDate, Customer.CustomerName, Employee.EmployeeName, Invoice.TotalAmount

		from InvoiceDetail, Product, Invoice, Customer, Employee
		where InvoiceDetail.ProductID = Product.ProductID and InvoiceDetail.InvoiceID = @InvoiceID and Invoice.InvoiceID = InvoiceDetail.InvoiceID and Invoice.CustomerID = Customer.CustomerID and Invoice.EmployeeID = Employee.EmployeeID
end

drop procedure PROC_PrintHD
exec PROC_PrintHD @InvoiceID = 'HD009'

select * from Supplier
select * from ProductOrigin
select * from account
