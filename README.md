\# Sistema de Gestión de Biblioteca UTMACH



\## Descripción



Prototipo académico desarrollado para la asignatura de Programación Avanzada en C#.



El sistema permite gestionar información bibliográfica, estudiantes, docentes, préstamos, devoluciones y reportes.



El proyecto fue organizado siguiendo el enfoque Spec-Driven Development (SDD).



\## Tecnologías utilizadas



\- C# y .NET 10.

\- Windows Forms.

\- Programación orientada a objetos.

\- Estructuras de datos `List<T>`.

\- Git y GitHub.

\- GitHub Spec Kit.

\- GitHub Actions.

\- xUnit para pruebas automatizadas.



\## Módulos



1\. Administración de libros.

2\. Administración de estudiantes y docentes.

3\. Registro de préstamos.

4\. Registro de devoluciones.

5\. Consultas y reportes.



\## Arquitectura



La solución se divide en tres proyectos:



\- \*\*BibliotecaUTMACH.Core:\*\* entidades, controladores y servicios.

\- \*\*BibliotecaUTMACH.WinForms:\*\* formularios de escritorio.

\- \*\*BibliotecaUTMACH.Tests:\*\* pruebas automatizadas.



\## Ejecutar el proyecto



Abrir `CodigoFuente/BibliotecaUTMACH/BibliotecaUTMACH.slnx` utilizando Visual Studio 2026.



Establecer `BibliotecaUTMACH.WinForms` como proyecto de inicio y ejecutar con F5.



\## Verificación



En la ejecución #5 de GitHub Actions se registraron:



\- 14 pruebas aprobadas.

\- 0 pruebas fallidas.

\- 0 pruebas omitidas.



\## Limitaciones y mejoras pendientes



\- El prototipo utiliza principalmente listas en memoria.

\- Los datos no se conservan automáticamente al cerrar la aplicación.

\- Se identificaron advertencias de compilación que requieren revisión.

\- Las reglas académicas de préstamos son propuestas del proyecto, no reglamentos oficiales verificados de UTMACH.



\## Metodología SDD



El desarrollo se organizó mediante:



1\. Requerimientos.

2\. Especificaciones.

3\. Plan técnico.

4\. Implementación.

5\. Verificación.

6\. Evolución.



Las especificaciones se encuentran en `specs/001-gestion-biblioteca`.



\## Estado



Prototipo académico en proceso de revisión y mejora.

