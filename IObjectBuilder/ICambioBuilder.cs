using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using IObjectBuilder.Base;
using WebApiDirmod.Models;

namespace IObjectBuilder.Base
{
    public interface ICambioBuilder : IFinalize
    {
        #region SearchDolar
        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 11-11-2019
        /// Descripción: Metodo que permite consultar la cotizacion en dolares
        /// </summary>
        /// <param name="academic">Parametros filtros para la busqueda de informacion</param>
        /// <returns>Clase con la información encontrada</returns>
        HashSet<format> SearchDolar();
        #endregion

        #region SearchEuros
        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 11-11-2019
        /// Descripción: Metodo que permite consultar la cotizacion en Euros
        /// </summary>
        /// <param name="academic">Parametros filtros para la busqueda de informacion</param>
        /// <returns>Clase con la información encontrada</returns>
        HashSet<format> SearchEuro();
        #endregion

        #region SearchReal
        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 11-11-2019
        /// Descripción: Metodo que permite consultar la cotizacion en Real
        /// </summary>
        /// <param name="academic">Parametros filtros para la busqueda de informacion</param>
        /// <returns>Clase con la información encontrada</returns>
        HashSet<format> SearchReal();
        #endregion
    }
}
