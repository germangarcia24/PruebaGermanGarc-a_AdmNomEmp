using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaGermanGarcía_AdmNomEmp.Models.ViewModels
{
    public class EmpleadoVM
    {
        public TblEmpleado oEmpleado { get; set; }

        public List<SelectListItem> oListaDepartamento { get; set; }

        public double SalarioQuincenal { get; set; }

        public double DeduccionIMSS {  get; set; }

        public double DeduccionISR { get; set; }
        public double SalarioNeto { get; set; }
    }
}
