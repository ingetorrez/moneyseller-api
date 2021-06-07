# MoneySeller 
## API, para obtener cambio de peso Argentino a dolar o real y poder comprar

source : http://www.bancoprovincia.com.ar/Principal/Dolar

## Principales caracteristicas

- Obtener el cambio del peso Argentino a Dólar
- Obtener el cambio del peso Argentino al Real Brasileño
- Permite comprar dólares 
- Poder comprar reales 
- Restrinción de limite para compra (200 dólares y 300 reales), por usuario, mes y moneda

> Nota: Si intentas obtener el cambio de otra moneda que no sea dólar o real, no es permitido al igual si intentas comprarla

## Sobre la tecnología

A continuación te presento la tecnología utilizada

- MS SQL Server
- C#
- Dapper
- .Net Core
- MS Test
- NLog
- External API http://www.bancoprovincia.com.ar/Principal/Dolar


## Montaje/Lanzamiento

#### Prerequisitos
- Motor de base de datos SQL Server
- Visual Studio 2019+

#### Base de datos
- Corre el script de la base de datos ubicado en ..\Database\script db\virtualmindDB.sql. Tambien puede hacer la comparación de esquema desde el proyecto para crearla.
- Cambio la configuración de tu cadena de conexión en el appsettings.json

```
"ConnectionStrings": {
    "Default": "Server=.;User Id=username;Password=pwd;Database=NameDB;"
  }
```
#### Run it
Luego que descargues/clones el repositorio puedes lanzarlo desde visual studio
