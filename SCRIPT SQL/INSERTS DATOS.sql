-- INSERTAR LIBROS
INSERT INTO LIBRO (TITULO, EDITORIAL, AREA)
VALUES 
('Libro A', 'Editorial Uno', 'Ciencias'),
('Libro B', 'Editorial Dos', 'Literatura'),
('Libro C', 'Editorial Tres', 'Historia'),
('Libro D', 'Editorial Cuatro', 'Tecnología'),
('Libro E', 'Editorial Cinco', 'Arte'),
('Libro F', 'Editorial Cinco', 'Arte');


--INSERTAR AUTORES
INSERT INTO AUTOR (NOMBRE, NACIONALIDAD)
VALUES 
('Autor 1', 'País A'),
('Autor 2', 'País B'),
('Autor 3', 'País C'),
('Autor 4', 'País D'),
('Autor 5', 'País E');

-- INSERTAR RELACION ENTRE LIBRO Y AUTOR
INSERT INTO LIB_AUTOR (IDAUTOR, IDLIBRO)
VALUES 
(1, 1), -- Autor 1 -> Libro A
(2, 2), -- Autor 2 -> Libro B
(3, 3), -- Autor 3 -> Libro C
(4, 4), -- Autor 4 -> Libro D
(5, 5), -- Autor 5 -> Libro E
(1, 6); -- Autor 1 -> Libro F





----------- INSERTAR ESTUDIANTES ---

INSERT INTO ESTUDIANTE (CI, NOMBRE, DIRECCION, CARRERA, EDAD)
VALUES 
('001', 'Estudiante A', 'Calle 1', 'Ingeniería', 20),
('002', 'Estudiante B', 'Calle 2', 'Ciencias Sociales', 22),
('003', 'Estudiante C', 'Calle 3', 'Biología', 21),
('004', 'Estudiante D', 'Calle 4', 'Arquitectura', 23),
('005', 'Estudiante E', 'Calle 5', 'Economía', 19);


--- REGISTROS DE PRESTAMOS

INSERT INTO PRESTAMO (IDLECTOR, IDLIBRO, FECHAPRESTAMO, DEVUELTO)
VALUES 
(1, 1, '2024-10-01', 1), -- Estudiante A -> Libro A (devuelto)
(1, 2, '2024-10-05', 0), -- Estudiante A -> Libro B (no devuelto)
(1, 3, '2024-10-10', 1), -- Estudiante A -> Libro C (devuelto)
(2, 4, '2024-10-15', 0), -- Estudiante B -> Libro D (no devuelto)
(3, 5, '2024-10-20', 1); -- Estudiante C -> Libro E (devuelto)
