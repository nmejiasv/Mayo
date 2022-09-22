namespace ManejoPresupuesto.Models
{
    public class ReporteMensualViewModel
    {
        public IEnumerable<ResultadoObtenerPorMes> TransaccionPorMes { get; set; }
        public decimal Ingresos => TransaccionPorMes.Sum(x => x.Ingreso);
        public decimal Gastos => TransaccionPorMes.Sum(x => x.Gasto);
        public decimal Total => Ingresos - Gastos;
        public int Año { get; set; }
    }
}
