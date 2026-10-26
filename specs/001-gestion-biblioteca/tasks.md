# TAREAS PROPUESTAS (BACKLOG) — Biblioteca UTMACH

**Fuente:** `spec.md` (Fase 2) y `plan.md` (Fase 3).  
**Estado:** descomposición manual preliminar; no equivale a haber ejecutado `/speckit-tasks`.

> Estas tareas se convierten en Issues y se asignan cuando el equipo apruebe el plan. Mantener estados mediante PR y comprobaciones reales, sin marcarlas como terminadas antes de ejecutarlas.

## Preparación del entorno
- [ ] T-001 — Revisar D-01 a D-06, confirmar reglas con el equipo y actualizar `spec.md`.
- [ ] T-002 — Crear repo GitHub, configurar `main`, .gitignore e invitar compañeros.
- [ ] T-003 — Incorporar constitución, `spec.md` y `plan.md` en Git, evitando afirmar que Spec Kit fue ejecutado.
- [ ] T-004 — Inicializar GitHub Spec Kit con integración Copilot y revisar comandos disponibles.
- [ ] T-005 — Crear solución `BibliotecaUTMACH.sln` con proyectos Core, WinForms y Tests.

## Usuarios (HU-01)
- [ ] T-006 — Crear `Persona`, `Estudiante`, `Docente` según especificación.
- [ ] T-007 — Implementar listas y validación de unicidad en `ServicioUsuarios`.
- [ ] T-008 — Crear pruebas para registro, cédula duplicada, filtros y desactivación.
- [ ] T-009 — Diseñar `frmAdminUsuarios` y `frmEditUsuario` con los nombres de controles del plan.

## Libros (HU-02)
- [ ] T-010 — Crear `Libro` y reglas de inventario.
- [ ] T-011 — Implementar servicios y cálculo de disponibilidad derivada de préstamos.
- [ ] T-012 — Crear pruebas de código duplicado, disponibilidad y disminución inválida de stock.
- [ ] T-013 — Diseñar `frmAdminLibros` y `frmEditLibro`.

## Préstamos (HU-03/HU-04)
- [ ] T-014 — Crear `Prestamo` y cálculo de estados por fecha de consulta.
- [ ] T-015 — Implementar validaciones de préstamos en `ServicioPrestamos`.
- [ ] T-016 — Implementar devolución única sin eliminación histórica.
- [ ] T-017 — Probar sin stock, cupo, vencidos, duplicados y fecha de devolución.
- [ ] T-018 — Diseñar `frmAdminPrestamos`, `frmEditPrestamo` y controles de selección por objeto.

## Reportes y calidad (HU-05/HU-06)
- [ ] T-019 — Implementar consultas LINQ e informes RF-015 a RF-019.
- [ ] T-020 — Diseñar `frmReportes` y filtros de período.
- [ ] T-021 — Añadir `.github/workflows/ci.yml` y comprobar que build/tests pasan en GitHub.
- [ ] T-022 — Crear PR de integración con revisión de otro integrante.
- [ ] T-023 — Registrar capturas, pruebas, decisiones y conclusiones en documentación.

**Prioridad inicial:** T-001 a T-005 antes de escribir lógica; luego HU-01 y HU-02 antes de HU-03, ya que préstamo depende de libros y usuarios.
