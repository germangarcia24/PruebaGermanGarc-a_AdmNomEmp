El proyecto se creo en base a .Net Core 6, ya que al intentar realizarlo con .Net 8, me estaba causando conflictos, fueron errores que intente solucionar pero no lo logre.
Para ejecutarlo, si es que aparece errores con las librerias instaladas serían:
-Microsoft.EntityFrameworkCore (6.0.4)
-Microsoft.EntityFrameworkCore.SqlServer (6.0.4)
-Microsoft.EntityFrameworkCore.Tools (6.0.4)
Así mismo, se uso Scaffold, para poder manipular todo lo relacionado con BD, dejo el script que se uso:
"Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=DB_GestionEmpleadosNominas;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force"
