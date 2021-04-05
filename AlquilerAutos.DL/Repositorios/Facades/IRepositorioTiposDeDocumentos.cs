using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerAutos.BL.Entidades;

namespace AlquilerAutos.DL.Repositorios.Facades
{
    public interface IRepositorioTiposDeDocumentos
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
