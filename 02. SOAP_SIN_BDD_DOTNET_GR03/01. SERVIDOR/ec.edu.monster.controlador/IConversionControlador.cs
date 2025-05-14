using _01.SERVIDOR.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _01.SERVIDOR.ec.edu.monster.controlador
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IConversionControlador" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IConversionControlador
    {
        [OperationContract]
        Response convertir( Request _request);
    }
}
