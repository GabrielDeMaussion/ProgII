CREATE DATABASE [VeterinariaApp]

USE [VeterinariaApp]

--Comandos
--Drop de tablas
DROP TABLE ATENCIONES
DROP TABLE MASCOTAS
DROP TABLE CLIENTES
DROP TABLE TIPOS

--Cambio de formatos
set dateformat dmy




--Creacion de tablas (por orden)
-- ========================================================================================================================================== --
--N# de Orden: 1
CREATE TABLE TIPOS
(id_tipo int,
tipo varchar(50)
CONSTRAINT pk_id_tipo PRIMARY KEY (id_tipo))


CREATE TABLE CLIENTES
(codigo int,
nombre varchar(50),
sexo varchar(50)
CONSTRAINT pk_codigo PRIMARY KEY (codigo))



--N# de Orden: 2
CREATE TABLE MASCOTAS
(id_mascota int,
nombre varchar(50),
edad int,
id_tipo int,
cliente int
CONSTRAINT pk_id_mascota PRIMARY KEY (id_mascota),
CONSTRAINT fk_id_tipo FOREIGN KEY (id_tipo)
REFERENCES TIPOS (id_tipo),
CONSTRAINT fk_mascotas_x_clientes FOREIGN KEY (cliente)
REFERENCES CLIENTES (codigo))



--N# de Orden: 3
CREATE TABLE ATENCIONES
(id_atencion int,
fecha datetime,
descripcion varchar(50),
importe money,
mascota int
CONSTRAINT pk_id_atencion PRIMARY KEY (id_atencion),
CONSTRAINT fk_atenciones_x_mascotas FOREIGN KEY (mascota)
REFERENCES MASCOTAS (id_mascota))
-- ========================================================================================================================================== --


--Inserts
-- ========================================================================================================================================== --
--Tabla TIPOS
INSERT INTO TIPOS (id_tipo, tipo) VALUES (1, 'Perro');
INSERT INTO TIPOS (id_tipo, tipo) VALUES (2, 'Gato');
INSERT INTO TIPOS (id_tipo, tipo) VALUES (3, 'Canario');
INSERT INTO TIPOS (id_tipo, tipo) VALUES (4, 'Hamster');
INSERT INTO TIPOS (id_tipo, tipo) VALUES (5, 'Pez');


--Tabla Clientes
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (1, 'Juan Pérez', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (2, 'María González', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (3, 'Pedro Rodríguez', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (4, 'Ana López', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (5, 'José Martínez', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (6, 'Carmen Sánchez', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (7, 'Miguel Fernández', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (8, 'Isabel Torres', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (9, 'David López', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (10, 'Laura Pérez', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (11, 'Javier García', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (12, 'Raquel Díaz', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (13, 'Alberto Ruiz', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (14, 'Elena Navarro', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (15, 'Francisco Jiménez', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (16, 'Sara Pérez', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (17, 'Luis Torres', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (18, 'Natalia García', 'Mujer');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (19, 'Carlos Martínez', 'Hombre');
INSERT INTO CLIENTES (codigo, nombre, sexo) VALUES (20, 'Silvia Rodríguez', 'Mujer');


--Tabla Mascotas
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (1, 'Rex', 3, 1, 1);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (2, 'Buddy', 2, 1, 2);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (3, 'Luna', 4, 2, 3);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (4, 'Whiskers', 3, 2, 4);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (5, 'Piolín', 1, 3, 5);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (6, 'Fluffy', 8, 3, 6);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (7, 'Hammy', 2, 4, 7);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (8, 'Nibbles', 1, 4, 8);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (9, 'Nemo', 3, 5, 9);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (10, 'Dory', 1, 5, 10);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (11, 'Max', 4, 1, 11);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (12, 'Bella', 3, 1, 12);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (13, 'Oliver', 6, 2, 13);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (14, 'Simba', 5, 2, 14);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (15, 'Tweetie', 1, 3, 15);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (16, 'Sunny', 2, 3, 16);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (17, 'Chubby', 2, 4, 17);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (18, 'Paws', 3, 4, 18);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (19, 'Goldie', 1, 5, 19);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (20, 'Bubbles', 2, 5, 20);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (21, 'Rocky', 8, 1, 1);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (22, 'Sophie', 9, 2, 2);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (23, 'Coco', 2, 3, 3);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (24, 'Milo', 3, 4, 4);
INSERT INTO MASCOTAS (id_mascota, nombre, edad, id_tipo, cliente) VALUES (25, 'Sparky', 3, 5, 5);


--Tabla Atenciones
-- Atenciones para perros
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (1, '15/02/2020', 'Chequeo de salud', 50.00, 1);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (2, '10/04/2020', 'Vacunación anual', 35.00, 11);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (3, '20/05/2020', 'Cirugía de esterilización', 150.00, 21);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (4, '08/07/2020', 'Corte de pelo', 25.00, 6);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (5, '12/01/2021', 'Chequeo rutinario', 50.00, 16);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (6, '28/03/2021', 'Vacuna de refuerzo', 35.00, 3);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (7, '05/06/2021', 'Cirugía de fractura', 150.00, 10);

-- Atenciones para gatos
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (8, '22/03/2020', 'Chequeo anual', 45.00, 12);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (9, '15/05/2020', 'Vacunación felina', 30.00, 2);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (10, '30/08/2020', 'Cirugía dental', 120.00, 22);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (11, '05/02/2021', 'Chequeo de salud', 45.00, 17);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (12, '18/04/2021', 'Vacunación felina', 30.00, 7);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (13, '10/07/2021', 'Cirugía de esterilización', 120.00, 13);

-- Atenciones para canarios
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (14, '10/02/2020', 'Chequeo de salud', 20.00, 5);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (15, '05/05/2020', 'Vacunación aviar', 15.00, 15);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (16, '20/08/2020', 'Cirugía de pico', 80.00, 25);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (17, '15/03/2021', 'Chequeo anual', 20.00, 8);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (18, '08/06/2021', 'Vacunación aviar', 15.00, 18);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (19, '20/01/2022', 'Cirugía de alas', 80.00, 4);

-- Atenciones para hámsters
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (20, '12/03/2020', 'Chequeo de salud', 15.00, 9);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (21, '10/06/2020', 'Vacuna para hámster', 10.00, 19);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (22, '25/09/2020', 'Cirugía de patas', 40.00, 14);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (23, '28/02/2021', 'Chequeo de salud', 15.00, 24);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (24, '30/05/2021', 'Vacuna para hámster', 10.00, 1);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (25, '15/02/2022', 'Cirugía de patas', 40.00, 11);

-- Atenciones para peces
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (26, '05/04/2020', 'Chequeo de salud', 10.00, 20);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (27, '20/07/2020', 'Vacunación para pez', 5.00, 10);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (28, '10/10/2020', 'Cirugía de aletas', 30.00, 25);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (29, '02/04/2021', 'Chequeo de salud', 10.00, 15);
INSERT INTO ATENCIONES (id_atencion, fecha, descripcion, importe, mascota) VALUES (30, '05/03/2022', 'Vacunación para pez', 5.00, 5);
-- ========================================================================================================================================== --


--Procedimientos almacenados
-- ========================================================================================================================================== --
--Procedimiento de consulta de todas las mascotas
go
create proc [SP_Consultar_Mascotas]
@nombre varchar(50) = '',
@tipo varchar(50) = '',
@edad int = null
as
SELECT m.id_mascota 'ID', m.nombre 'Nombre', m.edad 'Edad', t.tipo 'Tipo', c.nombre 'Cliente'
FROM MASCOTAS m join TIPOS t on m.id_tipo = t.id_tipo
join CLIENTES c on m.cliente = c.codigo
WHERE (m.nombre like '%' + @nombre + '%' and
         t.tipo like '%' + @tipo + '%') and
        m.edad = isnull(@edad, m.edad)
go
--Ejecutable
exec [SP_Consultar_Mascotas] 'r', '', 3



--Modelo para mas adelante (es para modificar)
go
create proc [SP_Consultar_Tipos]

as
SELECT t.id_tipo 'ID', t.tipo 'Tipo'
FROM TIPOS t
go
--Ejecutable
exec [SP_Consultar_Tipos]


-- ========================================================================================================================================== --
