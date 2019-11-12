using IObjectBuilder.Base;
using ObjectBuilder.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiDirmod.Models;
using System.Web.Http.Cors;

namespace WebApiDirmod.Controllers
{
    public class CotizacionController : ApiController
    {
        #region Variables
        private readonly ICambioBuilder _iRules = new CambioBuilder();
        #endregion

        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 11-11-2019
        /// Descripción: Metodo para la cotizacion en dolares
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Api/cotizacion/dolar")]
        public IHttpActionResult Dolar()
        {
            try
            {
               return Ok(_iRules.SearchDolar());
            }
            catch (Exception e)
            {
                HashSet<format> data = new HashSet<format>();
                data.Add(new format { precio = 0, moneda = "Error"+e.Message });
                return Ok(data);
                throw;
            }
        }

        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 11-11-2019
        /// Descripción: Metodo para la cotizacion en dolares
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Api/cotizacion/real")]
        public JsonResult<HashSet<format>> Real()
        {
            try
            {
                return Json(_iRules.SearchDolar());
            }
            catch (Exception e)
            {
                HashSet<format> data = new HashSet<format>();
                data.Add(new format { precio = 0, moneda = "Error" + e.Message });
                return Json(data);
                throw;
            }
        }


        /// <summary>
        /// Autor: Enderson Namias
        /// Fecha: 11-11-2019
        /// Descripción: Metodo para la cotizacion en dolares
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Api/cotizacion/euro")]
        public JsonResult<HashSet<format>> Euro()
        {
            try
            {
                return Json(_iRules.SearchEuro());
            }
            catch (Exception e)
            {
                HashSet<format> data = new HashSet<format>();
                data.Add(new format { precio = 0, moneda = "Error" + e.Message });
                return Json(data);
                throw;
            }
        }


    }
}