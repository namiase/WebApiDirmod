using System.Collections.Generic;


namespace Interfaces
{
    /// <summary>
    /// Autor: Enderson Namias
    /// Fecha: 27/04/2015
    /// Detalle: CRUD generico, Representacion
    /// </summary>
    /// <typeparam name="TEntity">Tipo de Entidad</typeparam>
    public interface IBase<TEntity>
    {
        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 13/12/2015
        /// Detalle: Metodo Generico de Busqueda por Parametro
        /// </summary>
        /// <returns>Lista del Tipo Especificado</returns>
        List<TEntity> Search();

        /// <summary>
        /// Autor:Enderson Namias
        /// Fecha: 13/12/2015
        /// Detalle: Metodo Generico de Busqueda General
        /// </summary>
        /// <param name="tEntity">Parametro Tipo Objeto</param>
        /// <returns>Retorna el tipo de Valo Suministrado</returns>
        TEntity Search(TEntity tEntity);


        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 13/12/2015
        /// Detalle: Metodo Generico de Insertar
        /// </summary>
        /// <param name="tEntity">Parametro Tipo Objeto</param>
        /// <returns>Retorna bool</returns>
        bool Insert(TEntity tEntity);

        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 13/12/2015
        /// Detalle: Metodo Generico de Modificar
        /// </summary>
        /// <param name="tEntity">Parametro Tipo Objeto</param>
        /// <returns>Retorna bool</returns>
        bool Update(TEntity tEntity);

        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 13/12/2015
        /// Detalle: Metodo Generico de Actualizar
        /// </summary>
        /// <param name="tEntity">Parametro Tipo Objeto</param>
        /// <returns>Retorna bool</returns>
        bool Delete(TEntity tEntity);

    }
}

