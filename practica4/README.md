# Implementación y Análisis de Particionamiento en PostgreSQL

## Introducción

- **Contexto:** importancia de la optimización en bases de datos con grandes volúmenes de datos.
- **Objetivo:** demostrar las ventajas del particionamiento frente a tablas no particionadas.
- **Herramientas:** PostgreSQL, extensiones `pg_stat_statements`, `pgcrypto`.

### 1. Configuración inicial del sistema

### 1.1 Extensiones habilitadas

- `pg_stat_statements` (monitoreo de consultas).
- `pgcrypto` (funciones criptográficas).

### 1.2 Parámetros de logging

- `log_min_duration_statement = 1000` (registrar consultas >1s).
- `log_statement = 'all'` (registro completo de consultas).

---

## 2. Creación de datos de prueba

### 2.1 Tabla sin particionamiento

- Definición de la tabla `ventas_sin_particion`.
- Índices creados: por `fecha_venta` y `cliente_id`.

### 2.2 Generación masiva de datos

- Función `generar_ventas_masivas(num_registros)` para insertar registros aleatorios.
- Inserción de **2 millones de registros**.

### 2.3 Análisis inicial de rendimiento

- Consultas de estadísticas (`pg_stat_user_tables`).

![image.png](attachment:71bd3f77-cd3b-4c90-9e86-92822c13c60c:image.png)

- Medición de tamaño (`pg_size_pretty`).

![image.png](attachment:47644289-f1e4-48cc-bf34-567e9e3152b9:image.png)

---

## 3. Particionamiento por rango

### 3.1 Creación de tabla particionada

- Definición de `ventas_particionada` con particiones por año (2020–2024).

### 3.2 Índices en particiones

- Índices en `cliente_id`, `producto_id`, `sucursal_id`.

![image.png](attachment:6d162cb1-c1e4-44f5-95a8-7c3dbc21e00c:image.png)

### 3.3 Migración de datos

- Inserción de datos desde `ventas_sin_particion` a `ventas_particionada`.
- Verificación de distribución de registros.

![image.png](attachment:4283e7a2-fa2b-450e-b995-72742646ea21:image.png)

---

## 4. Particionamiento híbrido (rango + hash)

### 4.1 Definición de tabla híbrida

- Tabla `ventas_hibrida` con partición por rango y subparticiones hash en 2024.

### 4.2 Subparticiones hash

- Creación de subparticiones:
    - `ventas_2024_he`
    - `ventas_2024_h1`
    - `ventas_2024_h2`
    - `ventas_2024_h3`

### 4.3 Carga de datos

- Inserción de datos correspondientes al año 2024.
- Validación de distribución en subparticiones.

![image.png](attachment:c06ccfa6-3c76-40a7-a3a5-fabac3939726:image.png)

---

## 5. Análisis comparativo de rendimiento

### 5.1 Consultas por rango de fechas

- Comparación entre tabla sin partición y particionada.

![image.png](attachment:2da9f525-495d-4441-a1ba-81709c3b3ee6:image.png)

![image.png](attachment:db5b2e65-dadd-4693-a573-a6f1d4f74b88:image.png)

### 5.2 Consultas específicas por cliente

- Comparación entre tabla sin partición y tabla híbrida (hash).

![image.png](attachment:f105d924-17cf-4591-8472-8a398ef8fdf6:image.png)

![image.png](attachment:7dd16d86-9f46-4d6b-99d9-f2335a6e7bf9:image.png)

### 5.3 Partition pruning

- Verificación del uso de `partition pruning`.

![image.png](attachment:48a7674c-dc2f-4f3b-872e-9ccadf6ce3c0:image.png)

![image.png](attachment:9d1a5442-26d0-407c-ac5b-41e8c92d08d8:image.png)

### 5.4 Registro de métricas

- Creación de tabla `metricas_rendimiento`.
- Función `medir_consulta` para almacenar resultados.

---

## 6. Mantenimiento automatizado

### 6.1 Creación automática de particiones

- Función `crear_particion_mensual(tabla, año, mes)`.

### 6.2 Limpieza de particiones antiguas

- Función `limpiar_particiones_antiguas(tabla, meses_retener)`.

---

## 7. Conclusiones

- Beneficios observados del particionamiento en consultas de grandes volúmenes.
- Comparación de tiempos entre tablas normales, particionadas y particionadas híbridas.
