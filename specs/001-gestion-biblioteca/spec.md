# Especificación funcional SDD — Sistema de Gestión de Biblioteca UTMACH

**Código:** SPEC-BIB-001  
**Versión:** 1.0 (propuesta inicial para aprobación del equipo)  
**Fecha:** 25 de octubre de 2026  
**Proyecto:** Biblioteca UTMACH (prototipo académico)  
**Responsables:** Equipo de Programación Avanzada (integrantes por registrar)  
**Estado:** Especificación redactada, pendiente de revisión y validación del equipo.

> **Nota importante:** Este proyecto es una simulación académica inspirada en una biblioteca universitaria. Las reglas de préstamos, cupos y plazos descritas aquí son propuestas de diseño para la práctica; **no representan normas oficiales verificadas de la Biblioteca UTMACH**.

## 1. Problema y propósito

La gestión manual o fragmentada de un catálogo, de sus usuarios y de los préstamos dificulta saber cuántos ejemplares están disponibles, quién tiene un libro y cuándo corresponde devolverlo. El prototipo permitirá registrar estudiantes y docentes, administrar un catálogo de libros, gestionar préstamos y devoluciones y consultar resultados verificables. Además, el equipo demostrará un proceso de desarrollo dirigido por especificaciones, con Git, GitHub, revisión de cambios, pruebas y automatización.

**Objetivo general:** Diseñar y construir un prototipo de gestión bibliotecaria que controle usuarios, libros y préstamos de manera consistente, aplicando Spec-Driven Development (SDD) y las prácticas de colaboración y calidad de software solicitadas en la asignatura.

**Objetivos específicos:**
1. Registrar, modificar y consultar estudiantes y docentes sin duplicar identificadores.
2. Mantener un catálogo con disponibilidad calculada a partir de los préstamos activos.
3. Registrar préstamos y devoluciones cumpliendo reglas de plazo, cupos y existencias.
4. Generar consultas y reportes sobre usuarios, libros y préstamos.
5. Comprobar los requisitos mediante pruebas repetibles y evidencias de GitHub.

## 2. Alcance y límites

### Dentro del alcance — versión inicial (MVP)
- Registro, edición, desactivación y listado de **estudiantes** y **docentes**.
- Registro, edición, desactivación y listado de libros y su cantidad total de ejemplares.
- Registro de préstamos por un operador de biblioteca a un estudiante o docente.
- Registro de devoluciones y visualización de préstamos activos, vencidos y devueltos.
- Verificación automática de cupos, fechas, disponibilidad y duplicados.
- Reportes: disponibilidad de libros, préstamos activos, préstamos vencidos y préstamos por tipo de usuario.
- Datos de demostración inventados para reproducir los escenarios de prueba.

### Fuera del alcance (posibles futuras versiones)
- Conexión con sistemas oficiales UTMACH, matrícula o credenciales institucionales.
- Reservas en línea, lectores de códigos de barras, multas y pagos.
- Acceso remoto simultáneo, notificaciones de correo, autenticación institucional.
- Inventario por ejemplar físico con código individual y múltiples sucursales.

## 3. Actores

| Actor | Descripción | Acciones del MVP |
|---|---|---|
| Operador de biblioteca | Persona que utiliza la aplicación de escritorio | Gestionar usuarios y libros; registrar préstamos, devoluciones y reportes |
| Estudiante | Usuario registrado con matrícula y carrera | Recibir préstamos, consultar historial mediante el operador |
| Docente | Usuario registrado con código y facultad | Recibir préstamos, consultar historial mediante el operador |
| Equipo de desarrollo | Estudiantes responsables de construir el prototipo | Gestionar especificaciones, GitHub, PR, CI y pruebas |

**Supuesto operativo:** en el MVP todos los formularios son utilizados por el operador. No se implementa inicio de sesión ni portales separados de estudiante/docente.

## 4. Historias de usuario priorizadas

| ID | Prioridad | Historia | Valor |
|---|---|---|---|
| HU-01 | P1 | Como operador quiero registrar y buscar estudiantes y docentes para identificar a quien solicita un libro. | Gestión de usuarios |
| HU-02 | P1 | Como operador quiero registrar libros y sus ejemplares para conocer la disponibilidad. | Gestión de inventario |
| HU-03 | P1 | Como operador quiero prestar un libro a un usuario válido si existe disponibilidad y no ha superado sus límites. | Préstamos confiables |
| HU-04 | P1 | Como operador quiero registrar una devolución para liberar un ejemplar y conservar su historial. | Trazabilidad |
| HU-05 | P2 | Como operador quiero consultar préstamos activos y vencidos para hacer seguimiento. | Control de vencimientos |
| HU-06 | P2 | Como operador quiero ver reportes por tipo de usuario y libro para evaluar el uso de la biblioteca. | Información para decisiones |

**P1** significa indispensable para demostrar el flujo principal; **P2** significa importante para el alcance completo, implementable después de P1.

## 5. Datos del sistema (modelo de información)

### 5.1 Usuario (concepto general)
- `IdUsuario`: identificador interno único, entero positivo, no reutilizado dentro de la sesión.
- `Cedula`: cadena identificadora única, exactamente 10 dígitos para el prototipo.
- `Nombres`, `Apellidos`: campos obligatorios.
- `Correo`: opcional; si se captura, debe tener formato básico válido.
- `Activo`: indica si está habilitado para nuevos préstamos.
- `TipoUsuario`: Estudiante o Docente, determinado por la clase concreta.

**Estudiante** añade `Matricula` y `Carrera` (ambos obligatorios).  
**Docente** añade `CodigoDocente` y `Facultad` (ambos obligatorios).

### 5.2 Libro
- `IdLibro`: identificador interno único.
- `CodigoLibro`: código único, obligatorio; ejemplo ficticio `LIB-001`.
- `ISBN`: texto opcional para el MVP.
- `Titulo`, `Autor`, `Categoria`: obligatorios.
- `AnioPublicacion`: entero en rango razonable, no superior al año actual.
- `EjemplaresTotales`: entero mayor o igual que cero.
- `Activo`: si puede elegirse para nuevos préstamos.
- `EjemplaresDisponibles`: **valor calculado**, igual a totales menos préstamos activos sobre ese libro.

### 5.3 Préstamo
- `IdPrestamo`: identificador único de la operación.
- `IdUsuario`, `IdLibro`: referencias a entidades existentes (a nivel de objetos en memoria).
- `FechaPrestamo`: fecha de inicio.
- `FechaVencimiento`: calculada con la regla según tipo de usuario.
- `FechaDevolucion`: vacía mientras no se devuelve; asignada al registrar la devolución.
- `Estado`: Activo, Vencido o Devuelto, calculado de forma coherente con fechas y devolución.

**Regla para estados:** si existe FechaDevolucion, está Devuelto; si no existe y la fecha actual supera la fecha de vencimiento, está Vencido; en otro caso está Activo. Los estados Activo y Vencido **ocupan ejemplar** hasta su devolución.

## 6. Reglas del negocio

| ID | Regla verificable |
|---|---|
| RN-01 | No puede existir más de un usuario con la misma cédula, ni identificadores internos duplicados. |
| RN-02 | La matrícula es única entre estudiantes; el código docente es único entre docentes. |
| RN-03 | No puede haber libros con el mismo `CodigoLibro`; el ISBN no se usa como clave principal. |
| RN-04 | Un usuario o libro inactivo no puede participar en préstamos nuevos. |
| RN-05 | El total de ejemplares de un libro no puede ser menor que su número de préstamos no devueltos. |
| RN-06 | No puede registrarse un préstamo si `EjemplaresDisponibles` es cero. |
| RN-07 | Cupos y plazos iniciales **propuestos**: estudiante hasta **2** préstamos no devueltos, por **7 días calendario**; docente hasta **3**, por **14 días calendario**. Son parámetros del prototipo sujetos a aprobación, no política oficial de UTMACH. |
| RN-08 | La fecha de vencimiento es `FechaPrestamo + PlazoDias` del tipo de usuario. |
| RN-09 | No se permite duplicar un préstamo no devuelto del mismo libro para el mismo usuario. |
| RN-10 | Si un usuario tiene un préstamo vencido no devuelto, no podrá realizar préstamos nuevos hasta regularizarlo (política propuesta del prototipo). |
| RN-11 | Una devolución solo se registra una vez y su fecha no puede ser anterior a la fecha del préstamo. |
| RN-12 | Al devolver, el ejemplar vuelve a estar disponible sin alterar el historial. |
| RN-13 | No se eliminan físicamente libros o usuarios con préstamos históricos; se desactivan para preservar las referencias. |
| RN-14 | Un préstamo registrado no se elimina mediante CRUD ordinario; se conserva como evidencia histórica. |
| RN-15 | Los controles muestran mensajes claros ante datos inválidos y no modifican las listas si la operación es rechazada. |
| RN-16 | Se usan fechas locales de calendario sin horas para vencimientos. La fecha de vencimiento aún está dentro de plazo; el préstamo vence a partir del día siguiente. |

## 7. Requisitos funcionales

### Gestión de usuarios
**RF-001 Registrar estudiante.** El operador podrá ingresar cédula, nombres, apellidos, matrícula y carrera; se aplicarán RN-01, RN-02 y RN-15.  
**RF-002 Registrar docente.** El operador podrá ingresar cédula, nombres, apellidos, código docente y facultad; se aplicarán RN-01, RN-02 y RN-15.  
**RF-003 Modificar usuario.** Se permitirán cambios en sus datos sin vulnerar unicidad ni romper historial.  
**RF-004 Desactivar usuario.** Se impedirá usarlo en nuevos préstamos; los préstamos previos quedarán consultables.  
**RF-005 Buscar y listar usuarios.** Se permitirá filtrar por nombre, cédula y tipo (Todos, Estudiantes, Docentes).

### Gestión de libros
**RF-006 Registrar libro.** Se guardarán código, título, autor, categoría, año, ISBN opcional y cantidad total.  
**RF-007 Modificar libro.** Permitirá ajustar datos y cantidad sin establecer menos ejemplares que préstamos no devueltos.  
**RF-008 Desactivar libro.** No se ofrecerá en préstamos futuros, pero mantendrá el historial.  
**RF-009 Buscar y listar libros.** Se mostrará su código, título, autor, cantidad total y cantidad disponible; filtro por disponibilidad.

### Préstamos y devoluciones
**RF-010 Registrar préstamo.** Se seleccionará un usuario y un libro existentes; el sistema verificará las RN-04 a RN-10 antes de guardar.  
**RF-011 Calcular fecha de vencimiento.** El sistema determinará el plazo correspondiente al tipo de usuario.  
**RF-012 Registrar devolución.** Se elegirá un préstamo activo o vencido; se grabará FechaDevolucion una sola vez.  
**RF-013 Consultar historial.** El operador podrá buscar préstamos por usuario, libro y estado.  
**RF-014 Detectar vencimientos.** El estado Vencido se calculará al consultar un préstamo no devuelto después de su fecha límite.

### Consultas y reportes
**RF-015 Reporte de libros.** Mostrar totales y disponibilidad por libro.  
**RF-016 Reporte de préstamos activos.** Mostrar usuario, libro, fecha y vencimiento.  
**RF-017 Reporte de vencidos.** Mostrar todos los préstamos no devueltos cuya fecha límite ya pasó.  
**RF-018 Reporte por tipo.** Contar préstamos por Estudiante y Docente en un rango de fechas seleccionado.  
**RF-019 Resumen general.** Mostrar número de usuarios activos, títulos activos, ejemplares disponibles y préstamos no devueltos.

## 8. Requisitos no funcionales

| ID | Condición comprobable |
|---|---|
| RNF-01 | El prototipo será utilizable mediante interfaz de escritorio en español. |
| RNF-02 | Las validaciones se ejecutarán antes de actualizar las colecciones de datos. |
| RNF-03 | La lógica de préstamo será comprobable sin abrir formularios, mediante pruebas unitarias. |
| RNF-04 | El proyecto y las especificaciones estarán versionados en Git; cada funcionalidad se integrará mediante Pull Request. |
| RNF-05 | Habrá una verificación automatizada de compilación y pruebas asociada a push y/o Pull Request. |
| RNF-06 | Ningún repositorio público incluirá cédulas reales, contraseñas ni datos personales no autorizados. |
| RNF-07 | Los errores controlables mostrarán mensajes comprensibles al operador; no se dependerá exclusivamente de excepciones para validar entradas. |
| RNF-08 | Para una demostración académica con hasta 100 libros, 100 usuarios y 500 préstamos, el listado debe responder de forma fluida en el equipo de prueba. No se afirma un SLA de producción. |
| RNF-09 | El código tendrá nombres semánticos; variables locales y booleanas declaradas al inicio de los métodos, un `return` final cuando corresponda, `if/else` explícitos, sin `break` ni `return` vacío. |

## 9. Criterios de aceptación por historia de usuario

### HU-01 — Gestionar usuarios
- **CA-01.1** Dado un estudiante con matrícula y cédula nuevas, cuando el operador guarda datos válidos, el sistema lo incorpora y aparece en la lista.
- **CA-01.2** Dada una cédula existente, cuando se intenta registrar otro usuario con la misma cédula, se rechaza y no aumenta la cantidad de usuarios.
- **CA-01.3** Dado un docente, cuando se filtra por Docentes, solo aparecen docentes.
- **CA-01.4** Dado un usuario desactivado, cuando se intenta prestarle un libro, el sistema rechaza la operación.

### HU-02 — Gestionar catálogo
- **CA-02.1** Dado un código nuevo, título, autor, categoría y año válidos, cuando se registra, el libro aparece en el catálogo.
- **CA-02.2** Dado un código ya registrado, cuando se intenta registrar otro libro con ese código, se rechaza.
- **CA-02.3** Dado un libro con dos ejemplares y un préstamo activo, la lista muestra un ejemplar disponible.
- **CA-02.4** Dado un libro con dos préstamos no devueltos, si se intenta reducir sus ejemplares totales a uno, se rechaza.

### HU-03 — Registrar préstamos
- **CA-03.1** Dado un estudiante activo sin préstamos y un libro activo con una unidad disponible, cuando registra un préstamo, se crea el registro, se calcula vencimiento a 7 días y la disponibilidad disminuye en uno.
- **CA-03.2** Dado un libro sin ejemplares disponibles, cuando se intenta registrar otro préstamo, no se crea un registro.
- **CA-03.3** Dado un estudiante con dos préstamos no devueltos, cuando intenta un tercero, se rechaza.
- **CA-03.4** Dado un docente con dos préstamos no devueltos y libros disponibles, cuando solicita el tercero, se permite y su fecha límite se calcula a 14 días.
- **CA-03.5** Dado un usuario que ya tiene un préstamo vencido, cuando solicita otro, se rechaza con motivo visible.
- **CA-03.6** Dado un usuario con préstamo no devuelto del mismo libro, se rechaza un préstamo duplicado de ese libro a la misma persona.

### HU-04 — Devoluciones
- **CA-04.1** Dado un préstamo activo, al registrar una devolución válida queda Devuelto y aumenta en uno la disponibilidad del libro.
- **CA-04.2** Dado un préstamo devuelto, cuando se intenta devolver otra vez, se rechaza y la disponibilidad no vuelve a aumentar.
- **CA-04.3** Dada una fecha de devolución anterior al préstamo, la operación se rechaza.
- **CA-04.4** Dado un préstamo vencido, se permite su devolución y se conserva el registro histórico.

### HU-05 — Seguimiento
- **CA-05.1** Dado un préstamo sin devolución cuya fecha límite fue ayer, al consultar hoy aparece Vencido.
- **CA-05.2** Dado un préstamo sin devolución cuya fecha límite es hoy, todavía aparece Activo.

### HU-06 — Reportes
- **CA-06.1** El total de préstamos por tipo es igual a la suma de los registros mostrados para Estudiante y Docente en el período consultado.
- **CA-06.2** La cantidad disponible de cada libro coincide con `EjemplaresTotales - préstamos no devueltos` y nunca es negativa.
- **CA-06.3** Los reportes vacíos muestran 0 o una lista vacía, sin lanzar errores.

## 10. Condiciones de error y casos límite

- **Campos vacíos o espacios:** se rechazan donde son obligatorios.
- **Duplicados:** no se añade registro ni se pierde información existente.
- **Usuario/libro inactivo:** no participa en un préstamo nuevo.
- **Cantidad cero:** libro puede existir, pero no presta hasta que aumente el inventario.
- **Libro agotado:** no se permiten préstamos adicionales.
- **Devolución repetida:** se rechaza sin duplicar el aumento de disponibilidad.
- **Historial:** desactivar un registro no borra sus préstamos.
- **Sin datos:** listas y reportes vacíos son válidos, sin fallos.
- **Fecha cambiante:** la clasificación de vencimiento depende de la fecha en que se consulta, no de una bandera desactualizada.

## 11. Métricas de éxito de la práctica

1. Se ejecutan satisfactoriamente todos los escenarios P1 (registro de usuario, libro, préstamo y devolución).
2. El sistema impide registrar un préstamo si no hay ejemplares o se excede el cupo.
3. El cálculo de disponibilidad mantiene la invariante `0 ≤ disponibles ≤ totales`.
4. El equipo conserva especificación, tareas, PR y evidencia de pruebas en el repositorio.
5. La automatización de compilación y pruebas se ejecuta en GitHub Actions; sus resultados se documentan con evidencia real.

## 12. Decisiones abiertas que el equipo debe validar

| ID | Decisión | Propuesta para comenzar | Impacto si cambia |
|---|---|---|---|
| D-01 | Cupos y plazos por tipo | Estudiante: 2 libros/7 días; Docente: 3 libros/14 días | Reglas y pruebas |
| D-02 | Política por retrasos | Bloquear nuevos préstamos mientras haya vencidos | Elegibilidad de préstamos |
| D-03 | Persistencia entre ejecuciones | Archivo JSON local para demo; si no alcanza el tiempo, modo memoria identificado como limitación | Almacenamiento y pruebas |
| D-04 | Acceso de operadores | Sin autenticación en el MVP; un solo operador local | Seguridad y alcance |
| D-05 | Identificación de ejemplares | Control de existencias por título, sin código individual por copia | Inventario |
| D-06 | Correo de usuario | Opcional para el prototipo | Validación de datos |

> Registrar la decisión adoptada por el equipo antes de iniciar `/speckit.plan`. Si cambia una regla, modificar esta especificación y sus criterios de aceptación antes de cambiar código.

## 13. Definición de terminado (Definition of Done)

Una historia queda terminada cuando: (1) su especificación está aprobada; (2) el código está implementado y revisado; (3) sus criterios de aceptación cuentan con prueba manual o automática reproducible; (4) las pruebas existentes continúan pasando; (5) los cambios están documentados en Pull Request; (6) el pipeline de GitHub Actions muestra resultado satisfactorio en el repositorio real.

## 14. Trazabilidad

La trazabilidad entre historias, reglas, criterios y pruebas está documentada en `docs/matriz-trazabilidad.md`. Es una **planificación de pruebas**, no evidencia de ejecución. Los resultados reales deben registrarse posteriormente.

## 15. Limitaciones y honestidad documental

No se ha integrado un sistema oficial UTMACH ni se han confirmado reglamentos institucionales de préstamo. Esta especificación constituye un diseño propuesto por el equipo. Una vez aprobada, servirá como referencia para elaborar el plan técnico, las tareas y las verificaciones de la fase de implementación.
