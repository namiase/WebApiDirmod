using System;


namespace Interfaces
{
    /// <summary>
    /// Interfaz que hereda el método más general de la clase
    /// System.IDisposable y que permitirá a su implementación
    /// eliminar de memoria los objetos y clases en el mismo
    /// momento que dejen de ser utilizados.
    /// </summary>
    public interface IFinalize : IDisposable
    {
    }
}

