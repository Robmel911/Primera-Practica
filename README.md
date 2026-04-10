# 🛒 SistemaColmado

Sistema de gestión integral para colmados desarrollado en **C# / WinForms** con **SQL Server**, implementando arquitectura en 3 capas.

---

## 📌 Descripción

SistemaColmado es una aplicación de escritorio para la administración completa de un colmado. Permite gestionar productos, clientes, ventas, usuarios y auditoría del sistema, con soporte de roles de acceso (Administrador / Cajero).

---

## 🏗️ Arquitectura

El proyecto está dividido en **3 capas** independientes:

```
Primera-Practica/
├── CapaDatos/              # Capa de acceso a datos (SQL Server)
│   ├── Conexion.cs         # Clase de conexión + interfaz IMostrarTabla + clase abstracta CD_Base
│   ├── CD_Usuarios.cs      # CRUD de usuarios + autenticación async
│   ├── CD_Clientes.cs      # CRUD de clientes
│   ├── CD_Productos.cs     # CRUD de productos
│   ├── CD_Ventas.cs        # Registro y historial de ventas (transacciones)
│   └── CD_Auditoria.cs     # Registro de auditoría
│
├── CapaNegocios/           # Capa de lógica de negocio
│   ├── CN_Usuarios.cs      # Login async + clase estática Sesion
│   ├── CN_Clientes.cs      # Reglas de negocio de clientes
│   ├── CN_Colmado.cs       # Ventas, reportes y búsquedas
│   ├── CN_Producto.cs      # Hereda CN_Colmado, gestión de productos
│   ├── CN_Auditoria.cs     # Registro y consulta de auditoría
│   └── Validaciones.cs     # Clases de validación con herencia (ValidacionBase, ValidacionTexto, ValidacionNumero)
│
└── Primera Practica/       # Capa de presentación (WinForms)
    ├── Program.cs          # Punto de entrada
    ├── Principal.cs        # Formulario principal (menú lateral con animación)
    ├── Login.cs            # Formulario de autenticación
    ├── Menu_Ventas.cs      # Formulario de registro de ventas (carrito)
    ├── Menu_auxiliar.cs    # Formulario auxiliar (reactivar productos / agregar saldo)
    └── Creditos.cs         # Formulario "Acerca de" con participantes
```

---

## 🗄️ Base de Datos

**Nombre:** `SistemaColmado`  
**Motor:** SQL Server (Integrated Security)

### Tablas

| Tabla | Descripción |
|-------|-------------|
| `Usuarios` | Credenciales y roles del sistema |
| `Clientes` | Registro de clientes con saldo |
| `Productos` | Inventario con stock y código |
| `Ventas` | Cabecera de ventas (contado/crédito) |
| `VentaDetalle` | Líneas de detalle de cada venta |
| `Auditoria` | Log de acciones del sistema |

### Relaciones (FK)
- `VentaDetalle.IdProducto → Productos.IdProducto`
- `VentaDetalle.IdVenta → Ventas.IdVenta`
- `Ventas.IdCliente → Clientes.IdCliente`
- `Auditoria.IdUsuario → Usuarios.IdUsuario`

### Stored Procedures
El sistema cuenta con **36 stored procedures** que cubren todas las operaciones CRUD, validaciones y reportes. No se usa SQL inline (excepto el descuento de stock en ventas).

---

## 🔑 Características Técnicas

| Característica | Implementación |
|----------------|----------------|
| **Arquitectura en capas** | 3 proyectos: CapaDatos, CapaNegocios, CapaPresentacion |
| **Interfaz** | `IMostrarTabla` en `Conexion.cs` |
| **Clase abstracta** | `CD_Base`, `ValidacionBase` |
| **Herencia** | `CD_Usuarios/Clientes/Productos/Ventas/Auditoria : CD_Base`; `CN_Producto : CN_Colmado`; `ValidacionTexto/Numero : ValidacionBase` |
| **Métodos abstractos** | `MostrarT()`, `Validar()` |
| **Métodos virtuales** | `MostrarTabla()`, `MostrarTablaDesactivada()`, `MostrarError()`, `EditarUsuario()`, `EliminarUsuario()` |
| **Async/Await** | Login, carga de clientes, conexión BD |
| **Try-Catch** | En toda la capa de datos y presentación |
| **Comentarios TODO** | En todos los archivos del proyecto |
| **Transacciones SQL** | Registro de ventas con rollback automático |

---

## 🖥️ Formularios

| Formulario | Función |
|------------|---------|
| `Login` | Autenticación con contraseña oculta y validación async |
| `Principal` | Menú lateral animado con 7 secciones |
| `Menu_Ventas` | Carrito de compras con búsqueda por código |
| `Menu_auxiliar` | Reactivar productos / Agregar saldo a clientes |
| `Creditos` | Participantes del proyecto |

---

## 🚀 Configuración y Ejecución

### Requisitos
- Visual Studio 2019 o superior
- SQL Server (instancia local `.`)
- .NET Framework 4.7.2+

### Pasos

1. **Clonar el repositorio:**
   ```bash
   git clone --branch robmel https://github.com/Robmel911/Primera-Practica.git
   cd Primera-Practica
   ```

2. **Crear la base de datos:**
   - Abrir SQL Server Management Studio
   - Ejecutar el script `SQLQuery.sql` completo

3. **Configurar la conexión:**
   - La cadena de conexión está en `CapaDatos/Conexion.cs`:
     ```csharp
     private string cadenaConexion = "Server=.;Database=SistemaColmado;Integrated Security=True";
     ```
   - Modificar `Server=.` si tu instancia tiene un nombre diferente

4. **Compilar y ejecutar:**
   - Abrir `Primera Practica.sln` en Visual Studio
   - Compilar con `Ctrl+Shift+B`
   - Ejecutar con `F5`

5. **Usuario por defecto:**
   ```
   Usuario:    admin1
   Contraseña: 12345
   Rol:        Administrador
   ```

---

## 👥 Autores

Ver formulario **Acerca de** dentro del sistema (Menú → Acerca de).

---

## 🌿 Rama

Este proyecto se encuentra en la rama `robmel`.

```
https://github.com/Robmel911/Primera-Practica/tree/robmel
```
