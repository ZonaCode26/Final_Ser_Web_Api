use negocios2017
go

CREATE PROCEDURE USP_LISTACLIENTEF
AS

SELECT C.idcliente,C.nombrecia,C.direccion,P.nombrepais,C.telefono 
FROM TB_CLIENTES C
INNER JOIN TB_PAISES P
ON C.IDPAIS=P.IDPAIS

GO

CREATE PROCEDURE USP_AGREGARCLIENTEF
@id as varchar(5),
@nom as varchar(50),
@dir as varchar(100),
@idp as char(3),
@tel as varchar(20)
AS
insert into tb_clientes values(@id,@nom,@dir,@idp,@tel) 
GO


CREATE PROCEDURE USP_LISTAPAISESF
AS
SELECT * FROM TB_PAISES
GO

CREATE PROCEDURE USP_ELIMINARF
@id as varchar(5)
AS
DELETE FROM TB_CLIENTES
WHERE IDCLIENTE=@id
GO

SELECT * FROM TB_CLIENTES
go
