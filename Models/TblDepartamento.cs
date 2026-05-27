using System;
using System.Collections.Generic;

namespace PruebaGermanGarcía_AdmNomEmp.Models
{
    public partial class TblDepartamento
    {
        public TblDepartamento()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
    }
}
