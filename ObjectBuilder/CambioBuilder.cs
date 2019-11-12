using Common.Extensions;
using commons;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utilities;
using WebApiDirmod.Models;
using IObjectBuilder.Base;

namespace ObjectBuilder.Base
{
    public class CambioBuilder : Finalize, ICambioBuilder
    {
        #region Variables
        private invoker _invoke;
        #endregion

        #region dolar
            #region SearchDolar
                /// <summary>
                /// Autor: Enderson Namias
                /// Fecha: 11-11-2019
                /// Descripción: Metodo que permite consultar la cotizacion de los dolares
                /// </summary>
                /// <param name="academic">Parametros filtros para la busqueda de informacion</param>
                /// <returns>Clase con la información encontrada</returns>
                public HashSet<format> SearchDolar()
                {
                       
                            var Request = new HttpRequestWrapper(HttpContext.Current.Request);
                            var headers = HeaderExtensions.CopyHeadersFrom(Request);
                            _invoke = new commons.invoker(headers);
                            var invokeSelect = (ResultCambioModel)_invoke.get("/v1/quotes/USD/ARS/json" , typeof(ResultCambioModel));
                            HashSet<format> data = new HashSet<format>( );
                            data.Add(new format{ precio = Convert.ToDecimal(invokeSelect.result.value), moneda = "Dolar" });
                            return data;
                        
                }
                #endregion
        #endregion
        #region Euro
            #region SearchEuro
                    /// <summary>
                    /// Autor: Enderson Namias
                    /// Fecha: 11-11-2019
                    /// Descripción: Metodo que permite consultar la cotizacion de los Euros
                    /// </summary>
                    /// <param name="academic">Parametros filtros para la busqueda de informacion</param>
                    /// <returns>Clase con la información encontrada</returns>
                    public HashSet<format> SearchEuro()
                    {

                        var Request = new HttpRequestWrapper(HttpContext.Current.Request);
                        var headers = HeaderExtensions.CopyHeadersFrom(Request);
                        _invoke = new commons.invoker(headers);
                        var invokeSelect = (ResultCambioModel)_invoke.get("/v1/quotes/EUR/ARS/json", typeof(ResultCambioModel));
                        HashSet<format> data = new HashSet<format>();
                        data.Add(new format { precio = Convert.ToDecimal(invokeSelect.result.value), moneda = "Dolar" });
                        return data;

                    }
                    #endregion
        #endregion
        #region Real
            #region SearchReal
                    /// <summary>
                    /// Autor: Enderson Namias
                    /// Fecha: 11-11-2019
                    /// Descripción: Metodo que permite consultar la cotizacion de los Reales
                    /// </summary>
                    /// <param name="academic">Parametros filtros para la busqueda de informacion</param>
                    /// <returns>Clase con la información encontrada</returns>
                    public HashSet<format> SearchReal()
                    {

                        var Request = new HttpRequestWrapper(HttpContext.Current.Request);
                        var headers = HeaderExtensions.CopyHeadersFrom(Request);
                        _invoke = new commons.invoker(headers);
                        var invokeSelect = (ResultCambioModel)_invoke.get("/v1/quotes/BRL/ARS/json", typeof(ResultCambioModel));
                        HashSet<format> data = new HashSet<format>();
                        data.Add(new format { precio = Convert.ToDecimal(invokeSelect.result.value), moneda = "Dolar" });
                        return data;

                    }
                    #endregion
        #endregion
    }
}
