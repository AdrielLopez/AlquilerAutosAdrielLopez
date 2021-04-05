namespace AlquilerAutos.BL.Entidades
{
    public class Localidad
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public Provincia Provincia { get; set; }
    }
}
