CREATE TABLE KdkComputer(
	kdkComId int NOT NULL primary key,
	kdkComName nvarchar(10) NOT NULL,
	kdkComPrice money NULL,
	kdkComImage [nvarchar](100) NULL,
	kdkComStatus Bit default 1 
	)


insert into KdkComputer(kdkComId,kdkComName,kdkComPrice,kdkComImage,kdkComStatus)
values
(1,N'AcerNitro',100000,N'acer.jpg',1),
(2,N'Dell',200000,N'dell.jpg',1),
(3,N'Victus16',30000,N'victus.jpg',1)