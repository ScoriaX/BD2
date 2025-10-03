# BD2: practica 5

Fecha de creación: 3 de octubre de 2025 13:46

# Laboratorio N°5 – Transacciones en PostgreSQL

## Introducción

- **Contexto:** las transacciones son fundamentales en el manejo de bases de datos para garantizar la consistencia y confiabilidad de la información.
- **Objetivo:** aplicar transacciones en escenarios de banca y e-commerce, demostrando el uso de `BEGIN`, `COMMIT` y `ROLLBACK`.
- **Herramientas:** PostgreSQL, cliente SQL.

---

## 1. Configuración inicial

### 1.1.1 Preparación del entorno

- Creación de la base de datos `laboratorio_transacciones`.

### 1.1.2 Crear las tablas necesarias

- Definición de tablas principales:
    - `cuentas` (cuentas bancarias).
    - `movimientos` (registro de transferencias).
    - `productos` (inventario e-commerce).
    - `pedidos` (cabecera de pedidos).
    - `detalle_pedidos` (detalle de productos por pedido).

### 1.1.3 Inserción de datos de prueba

- Cuentas iniciales con saldos: Juan Pérez, María García, Carlos López, Ana Martínez, Luis Torres.
- Productos iniciales: Laptop, Mouse, Teclado, Monitor, Webcam.
- Verificación de registros insertados con `SELECT COUNT(*)`.

![image.png](image.png)

---

## 1.2. Transacciones bancarias

### 1.2.1 Transferencia con COMMIT

- Estado inicial de las cuentas `CTA-001` y `CTA-002`.

![image.png](image%201.png)

- Transferencia de **$500** de Juan Pérez a María García.
- Registro en la tabla `movimientos`.
- Verificación del saldo antes y después de `COMMIT`.

![image.png](image%202.png)

### 1.2.2 Transacción sin COMMIT

- Débito de **$100** en la cuenta `CTA-003`.
- Verificación de visibilidad en la misma sesión vs. otra sesión.

![image.png](image%203.png)

![image.png](image%204.png)

- Uso de `ROLLBACK` para revertir la operación.
- Confirmación de saldo restaurado.

![image.png](image%205.png)

---

## 1.3. Transacciones en E-commerce

### 1.3.1 Creación de un pedido

![image.png](image%206.png)

### 1.3.2 Operaciones en la transacción

- Inserción del pedido en la tabla `pedidos`.
- Inserción de detalles en `detalle_pedidos`.
- Actualización de stock en `productos`.
- Cálculo y actualización del total del pedido.
- Verificación de datos antes y después del `COMMIT`.

![image.png](image%207.png)

![image.png](image%208.png)

---

## 2. Propiedades ACID en la práctica

### 2.1 Atomicidad

**Transferencia fallida por saldo insuficiente:** 

![image.png](image%209.png)

![image.png](image%2010.png)

![image.png](image%2011.png)

- **Rollback manual:** en un pedido de prueba se insertaron registros en varias tablas, pero al detectarse un error de negocio, se ejecutó `ROLLBACK`. Como resultado, ninguno de los cambios se guardó, demostrando el control manual de la atomicidad.

![image.png](image%2012.png)

![image.png](image%2013.png)

---

### 2.2 Consistencia

- **Restricciones de integridad:** al intentar crear una cuenta con saldo negativo, la base de datos rechazó la operación gracias a la restricción `CHECK`.

![image.png](image%2014.png)

- **Integridad referencial:** se intentó registrar un detalle de pedido con un pedido inexistente. La base de datos lo rechazó automáticamente, garantizando consistencia en las relaciones entre tablas.

![image.png](image%2015.png)

---

### 2.3 Aislamiento

- **Escenario de concurrencia:**

![image.png](image%2016.png)

---

![image.png](image%2017.png)

![image.png](image%2018.png)

## 3. Manejo de errores y rollback

### 3.1 Tipos de errores en transacciones

- **Error por restricción CHECK:** no se permitió asignar un saldo negativo a una cuenta.

![image.png](image%2019.png)

- **Error por restricción UNIQUE:** la base de datos rechazó la creación de una cuenta duplicada.

![image.png](image%2020.png)

- **Error por restricción FOREIGN KEY:** no fue posible registrar un detalle de pedido para un pedido inexistente.

![image.png](image%2021.png)

- **Manejo programático:** mediante bloques de excepción, se identificaron errores como cuentas inexistentes o saldo insuficiente y se aplicaron rollbacks controlados.

---

### 3.2 Rollback manual vs automático

- **Uso de SAVEPOINT:** se realizaron varias operaciones dentro de una transacción. Al fallar una de ellas, se aplicó `ROLLBACK TO SAVEPOINT`, lo que permitió conservar los cambios válidos y corregir solo la parte errónea.
- **Falla simulada del sistema:** se provocó un error intencional en medio de una transacción. PostgreSQL aplicó un **rollback automático**, garantizando que la base de datos no quedara en un estado inconsistente.
    
    ![image.png](image%2022.png)
    

![image.png](image%2023.png)

---

## 5. Conclusiones

- Las transacciones aseguran **atomicidad, consistencia, aislamiento y durabilidad (ACID)**.
- El uso de `COMMIT` confirma los cambios de forma permanente, mientras que `ROLLBACK` permite deshacer errores.
- Los ejemplos bancarios y de e-commerce muestran escenarios prácticos de uso en sistemas reales.

---