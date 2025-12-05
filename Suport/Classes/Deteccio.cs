namespace Examen.Suport.Classes
{
    public class Deteccio (EstacioAlumne estacioAlumne, Aplicacio aplicacio, bool aturada)
    {
        public EstacioAlumne EstacioAlumne { get; set; } = estacioAlumne;
        public Aplicacio Aplicacio { get; set; } = aplicacio;
        public bool Aturada { get; set; } = aturada;
    }
}
