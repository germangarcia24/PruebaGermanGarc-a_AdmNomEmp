namespace PruebaGermanGarcía_AdmNomEmp.Models;
    using PruebaGermanGarcía_AdmNomEmp.Models.ViewModels;

public class clsNomina
{
    public void INominaService(EmpleadoVM empleadoVM)
    {
        //Sueldo quincenal
        double sq = (double)empleadoVM.oEmpleado.SalarioMensual/2;

        //Deduccion IMSS
        double di = sq * 0.03;

        //Deduccion ISR
        double disr = 0;
        if ((double)empleadoVM.oEmpleado.SalarioMensual <= 7500.00)
        {
            disr = sq * 0.09;
        }
        else if ((double)empleadoVM.oEmpleado.SalarioMensual >= 7501.00 && (double)empleadoVM.oEmpleado.SalarioMensual <= 15000.00)
        {
            disr = sq * 0.16;
        }
        else if ((double)empleadoVM.oEmpleado.SalarioMensual > 15000.00 ) {
            disr = sq * 0.25;
        }

        //Salario Neto
        double sn = sq - di - disr;

        //Se pasa datos a View Model
        empleadoVM.SalarioQuincenal = sq;
        empleadoVM.DeduccionIMSS = di;
        empleadoVM.DeduccionISR = disr;
        empleadoVM.SalarioNeto = sn;
    }
}

