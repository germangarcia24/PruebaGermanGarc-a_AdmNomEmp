using System;
using System.Collections.Generic;

namespace PruebaGermanGarcía_AdmNomEmp.Models
{
    public partial class TblEmpleado
    {
        public int Id { get; set; }
        public string? NumeroEmpleado { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public decimal? SalarioMensual { get; set; }
        public int? DepartamentoId { get; set; }
        public bool? Activo { get; set; }

        public virtual TblDepartamento? Departamento { get; set; }
    }
}
