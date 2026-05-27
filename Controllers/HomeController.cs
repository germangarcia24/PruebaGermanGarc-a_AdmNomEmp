using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using PruebaGermanGarcía_AdmNomEmp.Models;
using PruebaGermanGarcía_AdmNomEmp.Models.ViewModels;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PruebaGermanGarcía_AdmNomEmp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DB_GestionEmpleadosNominasContext _DBContext;

        public HomeController(DB_GestionEmpleadosNominasContext context )
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<TblEmpleado> list = _DBContext.TblEmpleados.Include(c => c.Departamento).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Empleado_Detalle(int idEmpleado)
        {
            EmpleadoVM oEmpleadoVW = new EmpleadoVM() { 
            
                oEmpleado = new TblEmpleado(),
                oListaDepartamento = _DBContext.TblDepartamentos.Select(dep => new SelectListItem()
                {
                    Text = dep.Nombre,
                    Value = dep.Id.ToString()
                }).ToList()
            };

            if (idEmpleado != 0)
            {
                oEmpleadoVW.oEmpleado = _DBContext.TblEmpleados.Find(idEmpleado);
                clsNomina clsnom = new clsNomina();
                clsnom.INominaService(oEmpleadoVW);
            }
            return View(oEmpleadoVW);
        }

        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVM oEmpleadoVM)
        {
            if (oEmpleadoVM.oEmpleado.Id == 0)
            {
                int maxId = _DBContext.TblEmpleados.Max(e => (int?)e.Id) ?? 0;
                oEmpleadoVM.oEmpleado.NumeroEmpleado = "EMP-000" + maxId;
                oEmpleadoVM.oEmpleado.FechaIngreso = DateTime.Now;
                oEmpleadoVM.oEmpleado.Activo = true;

                _DBContext.TblEmpleados.Add(oEmpleadoVM.oEmpleado);

            }

            _DBContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }

    }
}
