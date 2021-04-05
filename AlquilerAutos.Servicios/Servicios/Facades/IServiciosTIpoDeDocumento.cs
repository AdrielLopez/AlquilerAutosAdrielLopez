using System.Collections.Generic;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.Servicios.Servicios.Facades
{
    public interface IServiciosTIpoDeDocumento
    {
        List<TipoDeDocumento> GetTipoDeDeDocumentos();
        TipoDeDocumento GetTipoDeDocumentoPorId(int id);
        void Guardar(TipoDeDocumento documento);
        void Borrar(TipoDeDocumento documento);
        bool Existe(TipoDeDocumento documento);
        bool EstaRelacionado(TipoDeDocumento documento);
        void Editar(TipoDeDocumento documento);
    }
}