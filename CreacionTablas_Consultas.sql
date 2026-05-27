




CREATE TABLE Tbl_Departamentos(
Id int primary key identity (1,1),
Nombre varchar (100),
Activo bit
)

--select * from  Tbl_Departamentos 


CREATE TABLE Tbl_Empleados(
Id int primary key identity (1,1),
NumeroEmpleado varchar (10),
Nombre varchar (100) unique,
FechaIngreso date,
SalarioMensual decimal(12,2),
DepartamentoId int,
Activo bit
constraint FK_Dep foreign key (DepartamentoId) references Tbl_Departamentos (Id)
)

--select * from  Tbl_Empleados

--Inserciones 
INSERT INTO Tbl_Departamentos VALUES ('Recursos Humanos',1)
INSERT INTO Tbl_Departamentos VALUES ('Sistemas',1)

INSERT INTO Tbl_Empleados VALUES ('EMP-0001','German Garcia','2024-05-26',18000.00,2,1)
INSERT INTO Tbl_Empleados VALUES ('EMP-0002','Moises Lopez','2025-10-01',7000.00,1,1)
INSERT INTO Tbl_Empleados VALUES ('EMP-0003','Ivan Morales','2023-03-15',10000.00,2,1)



-- Consultas

--A)
SELECT e.NumeroEmpleado,e.Nombre,d.Nombre AS NombreDepartamento,e.SalarioMensual,DATEDIFF(month, e.FechaIngreso, GETDATE()) AS AntiguedadMeses
FROM Tbl_Empleados e
INNER JOIN Tbl_Departamentos d ON e.DepartamentoId = d.Id
WHERE e.Activo = 1
ORDER BY AntiguedadMeses DESC

--B)

SELECT 
    e.NumeroEmpleado,e.Nombre,e.SalarioMensual,e.SalarioMensual / 2 AS SalarioQuincenal,e.SalarioMensual / 2 * 0.03 AS DeduccionIMSS,
    CASE 
        WHEN e.SalarioMensual / 2 <= 7500 THEN (e.SalarioMensual / 2) * 0.09
        WHEN e.SalarioMensual / 2 BETWEEN 7501 AND 15000 THEN (e.SalarioMensual / 2) * 0.16
        WHEN e.SalarioMensual / 2 > 15000 THEN (e.SalarioMensual / 2) * 0.25
    END AS DeduccionISR,
    (e.SalarioMensual / 2) - (e.SalarioMensual / 2 * 0.03) - CASE 
															WHEN e.SalarioMensual / 2 <= 7500 THEN (e.SalarioMensual / 2) * 0.09
															WHEN e.SalarioMensual / 2 BETWEEN 7501 AND 15000 THEN (e.SalarioMensual / 2) * 0.16
															WHEN e.SalarioMensual / 2 > 15000 THEN (e.SalarioMensual / 2) * 0.25
    END AS TotalNeto
FROM Tbl_Empleados e
WHERE e.Activo = 1

--C)

SELECT d.Id,d.Nombre AS Departamento,
    SUM(
        (e.SalarioMensual / 2) 
        - (e.SalarioMensual / 2 * 0.03)
        - CASE 
            WHEN e.SalarioMensual / 2 <= 7500 THEN (e.SalarioMensual / 2) * 0.09
            WHEN e.SalarioMensual / 2 <= 15000 THEN (e.SalarioMensual / 2) * 0.16
            ELSE (e.SalarioMensual / 2) * 0.25
          END
    ) AS TotalNominaQuincenal
FROM Tbl_Empleados e
INNER JOIN Tbl_Departamentos d ON e.DepartamentoId = d.Id
WHERE e.Activo = 1
GROUP BY d.Id, d.Nombre


