# PLAN TÉCNICO — Biblioteca UTMACH

**Código:** PLAN-BIB-001  
**Versión:** 1.0, propuesta para revisión  
**Fecha:** 25 de octubre de 2026  
**Documento de origen:** `spec.md`, SPEC-BIB-001 (Fase 2)  
**Naturaleza:** prototipo académico, sin integración con la Biblioteca UTMACH real.  
**Estado:** plan redactado manualmente; NO generado ni ejecutado aún por GitHub Spec Kit.

## 1. Objetivo y decisiones por confirmar

Implementar un prototipo de escritorio C# para que un operador gestione estudiantes, docentes, libros, préstamos, devoluciones y reportes de acuerdo con RF-001 a RF-019. El equipo validará antes de codificar las decisiones D-01 a D-06 de `spec.md`, especialmente límites de préstamos, bloqueo por atraso y persistencia.

**Tecnologías propuestas:** Visual Studio 2026; C#; .NET 10; Windows Forms con diseñador visual; biblioteca de clases .NET 10 para lógica; `List<T>` en memoria para versión inicial; LINQ para consultas; proyecto de pruebas xUnit; Git, GitHub, GitHub Actions y GitHub Copilot. No se elige SQL Server para el MVP. Archivo JSON persistente queda como ampliación condicionada al tiempo y a aprobación del equipo (D-03).

## 2. Solución y separación de responsabilidades

```text
BibliotecaUTMACH.sln
├── BibliotecaUTMACH.Core/                 [Biblioteca de clases .NET 10]
│   ├── Entidades/
│   │   ├── Persona.cs                   [abstracta]
│   │   ├── Estudiante.cs                [hereda Persona]
│   │   ├── Docente.cs                   [hereda Persona]
│   │   ├── Libro.cs
│   │   └── Prestamo.cs
│   ├── Controlador/
│   │   └── TLista.cs                    [List<Persona>, List<Libro>, List<Prestamo>]
│   └── Servicios/
│       ├── ServicioUsuarios.cs          [altas, cambios, desactivación, unicidad]
│       ├── ServicioLibros.cs            [altas, existencias, búsquedas]
│       ├── ServicioPrestamos.cs         [validación, registro, devolución]
│       └── ServicioReportes.cs          [LINQ, consultas]
├── BibliotecaUTMACH.WinForms/             [Windows Forms App, .NET 10]
│   ├── Program.cs
│   └── Formularios/
│       ├── frmPrincipal.cs
│       ├── frmAdminUsuarios.cs
│       ├── frmEditUsuario.cs
│       ├── frmAdminLibros.cs
│       ├── frmEditLibro.cs
│       ├── frmAdminPrestamos.cs
│       ├── frmEditPrestamo.cs
│       └── frmReportes.cs
└── BibliotecaUTMACH.Tests/                [Pruebas xUnit, .NET 10]
    ├── PruebasUsuarios.cs
    ├── PruebasLibros.cs
    └── PruebasPrestamos.cs
```

**Dependencias:** WinForms -> Core; Tests -> Core. Core nunca hace referencia a WinForms, `MessageBox` ni controles visuales.

## 3. Entidades y relaciones

- `Persona` abstracta: `IdUsuario`, `Cedula`, `Nombres`, `Apellidos`, `Correo`, `Activo`; propiedad abstracta o virtual `TipoUsuario`, `LimitePrestamos`, `PlazoDias` para expresar comportamiento por tipo sin repetir cadenas. **Reglas propuestas:** estudiante 2/7; docente 3/14, pendientes de aprobación.
- `Estudiante : Persona`: `Matricula`, `Carrera`.
- `Docente : Persona`: `CodigoDocente`, `Facultad`.
- `Libro`: `IdLibro`, `CodigoLibro`, `ISBN`, `Titulo`, `Autor`, `Categoria`, `AnioPublicacion`, `EjemplaresTotales`, `Activo`.
- `Prestamo`: `IdPrestamo`, referencia `Persona Usuario`, referencia `Libro LibroPrestado`, `FechaPrestamo`, `FechaVencimiento`, `DateTime? FechaDevolucion`. Se pueden mostrar `IdUsuario`/`IdLibro` como propiedades derivadas. `Estado` se calcula a partir de las fechas y del día de consulta, no con un campo fijo.

Relaciones: Estudiante -> Persona; Docente -> Persona; Prestamo -> 1 Persona; Prestamo -> 1 Libro; Libro puede estar en varios préstamos históricos.

**Decisión de consistencia:** `EjemplaresDisponibles` no se modifica manualmente: se consulta como `EjemplaresTotales - cantidad de préstamos sin devolución` (tanto activos como vencidos). Esto impide descontar dos veces al prestar o devolver. Las modificaciones de inventario validan RN-05.

**Identificadores:** códigos y cédulas únicos; búsqueda por identificador, nunca por la posición visual de un `DataGridView` filtrado. No reutilizar IDs dentro de la sesión. Si se incorpora persistencia, guardar también el contador/criterio de asignación.

## 4. Reglas de negocio en servicios (no formularios)

1. `ServicioUsuarios`: validar campos, cédula única, matrícula/código único; desactivar sin borrar historial (RN-01, RN-02, RN-13).
2. `ServicioLibros`: validar código único, año válido, totales >= préstamos no devueltos; desactivar sin perder historial (RN-03, RN-05, RN-13).
3. `ServicioPrestamos`: confirmar usuario y libro activos, cupo, no vencidos previos, existencia, préstamo no duplicado; registrar fecha y vencimiento; devolver solo una vez y con fecha válida (RN-04 a RN-12).
4. `ServicioReportes`: consultas LINQ de disponibilidad, préstamos activos, vencidos, por tipo y resumen general (RF-015 a RF-019).
5. Validar fechas con días de calendario (`DateTime.Date`). Para pruebas de vencimientos, permitir indicar la fecha de consulta mediante parámetro en lugar de depender siempre de `DateTime.Now`.

Regla de resultado: operaciones devuelven un resultado con `Exito`, `Mensaje` y, cuando corresponda, objeto creado; interfaz muestra mensajes, Core no abre cuadros de diálogo.

## 5. Formularios y controles del diseñador visual

| Formulario | Función | Controles principales propuestos |
|---|---|---|
| `frmPrincipal` | Navegación principal | `btnUsuarios`, `btnLibros`, `btnPrestamos`, `btnReportes` |
| `frmAdminUsuarios` | Listar, filtrar, insertar, modificar, desactivar | `dgvUsuarios`, `cboTipo`, `txtBuscar`, `btnInsertar`, `btnModificar`, `btnDesactivar` |
| `frmEditUsuario` | Capturar datos del estudiante o docente | `txtCedula`, `txtNombres`, `txtApellidos`, `txtCorreo`, `cboTipoUsuario`, `txtDatoEspecifico1`, `txtDatoEspecifico2`, `btnGuardar`, `btnCancelar` |
| `frmAdminLibros` | Gestionar catálogo | `dgvLibros`, `txtBuscar`, `cboDisponibilidad`, `btnInsertar`, `btnModificar`, `btnDesactivar` |
| `frmEditLibro` | Capturar datos del libro | `txtCodigo`, `txtIsbn`, `txtTitulo`, `txtAutor`, `txtCategoria`, `nudAnio`, `nudEjemplares`, `btnGuardar`, `btnCancelar` |
| `frmAdminPrestamos` | Consultar préstamos y registrar devoluciones | `dgvPrestamos`, `cboEstado`, `btnPrestar`, `btnDevolver` |
| `frmEditPrestamo` | Registrar préstamo seleccionando objetos de listas | `cboUsuario`, `cboLibro`, `dtpFechaPrestamo`, `lblVencimiento`, `btnGuardar`, `btnCancelar` |
| `frmReportes` | Mostrar los reportes RF-015–RF-019 | `cboReporte`, `dgvResultados`, `dtpDesde`, `dtpHasta`, `btnConsultar` |

Todos los formularios serán creados desde **Agregar > Windows Form** y configurados mediante las ventanas **Diseño**, **Cuadro de herramientas** y **Propiedades**. No construir toda la interfaz en métodos de código; Visual Studio administra cada `.Designer.cs`.

## 6. Secuencia principal de préstamo

1. El operador abre `frmAdminPrestamos` y pulsa `btnPrestar`.
2. `frmEditPrestamo` obtiene de `TLista` los usuarios y libros activos para sus ComboBox.
3. Al guardar, `ServicioPrestamos` evalúa RN-04 a RN-10 sin modificar datos ante errores.
4. Si es válido, crea el préstamo y calcula `FechaVencimiento = FechaPrestamo + PlazoDias`.
5. El préstamo entra en `List<Prestamo>`; la disponibilidad se recalcula sin restar manualmente una segunda vez.
6. En devolución, el servicio valida RN-11 y asigna `FechaDevolucion` una sola vez.
7. Los listados se actualizan y la historia permanece disponible.

## 7. Plan de pruebas (vinculado con Fase 2)

| Prueba prevista | Regla/Criterio | Resultado esperado |
|---|---|---|
| Registrar estudiante con cédula nueva | CA-01.1 | Usuario agregado |
| Rechazar cédula duplicada | CA-01.2 | Sin cambio en la lista |
| Rechazar libro duplicado | CA-02.2 | No se inserta |
| Mostrar 1 disponible al prestar 1 de 2 | CA-02.3 | Disponibles = 1 |
| Rechazar stock menor que préstamos pendientes | CA-02.4 | Inventario sin cambios |
| Rechazar préstamo cuando no hay stock | CA-03.2 | No se crea |
| Rechazar tercer préstamo de estudiante | CA-03.3 | No se crea |
| Aceptar tercer préstamo de docente | CA-03.4 | Fecha +14 días |
| Rechazar préstamo duplicado sin devolver | CA-03.6 | No se crea |
| Registrar devolución una sola vez | CA-04.1, CA-04.2 | Disponible aumenta solo una vez |
| Distinguir vencido de préstamo con fecha límite hoy | CA-05.1, CA-05.2 | Estado correcto |
| Consultas vacías | CA-06.3 | Sin excepción; muestra 0/lista vacía |

Estas son **pruebas planificadas**, no se han ejecutado. El pipeline real deberá compilar y ejecutar pruebas automáticas en GitHub Actions sobre Windows.

## 8. Git y flujo de trabajo propuesto

- Repositorio: `Biblioteca-UTMACH-SDD` (se creará en GitHub cuando el equipo lo decida).
- Rama principal: `main`; ramas cortas: `feature/usuarios`, `feature/libros`, `feature/prestamos`, `feature/reportes`.
- Cada tarea se documenta con Issue, se implementa en una rama y se integra mediante Pull Request revisado por un compañero.
- Requisitos de aprobación del PR: cumplimiento de `spec.md`, compilación, pruebas, revisión de nombres/validaciones y ausencia de datos personales reales.
- CI planificada: `.github/workflows/ci.yml`, eventos `push` y `pull_request`, `runs-on: windows-latest`, SDK .NET 10, `dotnet restore`, `dotnet build`, `dotnet test`.
- Evidencias a guardar: capturas del tablero, historial de commits, ramas, Pull Request, pestaña Actions y resultados de pruebas.

## 9. Decisiones abiertas y riesgos

| ID | Decisión/risgo | Tratamiento |
|---|---|---|
| D-01 | Límites y plazos no oficiales | Confirmar o modificar antes de implementar |
| D-02 | Bloquear usuario con vencidos | Confirmar con equipo |
| D-03 | Almacenamiento persistente | Primera demostración en memoria; JSON optativo si queda tiempo, documentando que reiniciar vacía datos |
| D-04 | Acceso | Único operador local, sin autenticación (MVP) |
| D-05 | Ejemplares por título | Sin identificación física individual |
| D-06 | Correo | Opcional, validar si se introduce |
| R-01 | Se elimina usuario/libro con historial | Desactivar, nunca borrar físicamente |
| R-02 | Botón devuelve dos veces el mismo libro | Bloquear operación repetida |
| R-03 | Formularios contienen toda la lógica | Servicios de Core; UI solo muestra/captura |
| R-04 | Pipeline no compila WinForms en Linux | Utilizar `windows-latest` |

## 10. Etapas de implementación

1. Aprobar este plan y resolver decisiones D-01 a D-06.
2. Crear solución y proyectos Core, WinForms y Tests en Visual Studio (etapa siguiente).
3. Crear entidades y listas con Copilot a partir de `spec.md` y este `plan.md`.
4. Implementar validaciones y pruebas de usuarios y libros.
5. Implementar flujo préstamos/devoluciones con pruebas.
6. Diseñar formularios **en el diseñador**, conectar servicios y reportes.
7. Crear ramas, Issues, PR y ejecutar CI real en GitHub Actions.
8. Documentar resultados, capturas y decisiones.

## 11. Reglas de código del equipo

Todos los métodos tendrán variables locales declaradas al inicio; booleanos también. Usar identificadores semánticos, `if/else` explícitos, manejar nulos, un solo `return` al final cuando se devuelve valor, sin `break` ni `return;`. Las reglas se implementan en servicios y las colecciones `List<T>`; no confundir índices de un DataGridView filtrado con índices de las listas.

## 12. Aprobación del plan

**Pendiente:** nombres de integrantes, decisión final sobre D-01/D-02/D-03 y firma o aceptación del equipo. Este documento no demuestra que GitHub Spec Kit haya sido ejecutado; al integrarlo más adelante, comparar los planes que genere la herramienta con este plan y actualizar lo que corresponda.
