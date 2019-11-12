using System;
using Interfaces;


namespace Utilities
{
    public class Finalize : IFinalize
    {
        /// <summary>
        /// Método para borrar de memmoria
        /// los objetos y clases
        /// en el mismo momento que dejan de ser utilizados.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
