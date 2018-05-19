using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APLI_INTRO.Models
{
    //L22c1a definimos variables que va a tener del desplegable
    public enum ResultOpeDropDownList
    {
        Aprobado=1,
        Rechazado=2,
        [Description("Pendiente Aprobacion")]
        PendienteAprobacion=3 //como ten espacios nn podemos/queremos mostrar este nome polo que crearemos unha descripcion
    }
}