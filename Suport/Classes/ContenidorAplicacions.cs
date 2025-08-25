using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Examen.Suport.Funcions;

namespace Examen.Suport.Classes
{
    [Serializable, Category("Contenidor d'aplicacions"), DisplayName("Contenidor d'aplicacions")]
    public class ContenidorAplicacions
    {
        [Category("Contenidor d'aplicacions"),
         Browsable(true),
         ReadOnly(false),
         DisplayName("Categories"),
         Description("Categories d'aplicacions no permeses")]
        public List<CategoriaAplicacions> CategoriaAplicacions { get; set; } = [];

        [Browsable(false)]
        public List<Aplicacio> Totes
        {
            get
            {
                var ret = new List<Aplicacio>();
                foreach (var categoria in CategoriaAplicacions.Where(categoria => categoria?.Aplicacions != null))
                {
                    foreach (var aplicacioClonada in categoria.Aplicacions.Select(aplicacio => aplicacio.Clonar()))
                    {
                        aplicacioClonada.CalAturar |= categoria.CalAturar;
                        aplicacioClonada.Ignorar |= categoria.Ignorar;

                        if (!aplicacioClonada.Ignorar)
                            ret.Add(aplicacioClonada);
                    }
                }

                return ret;
            }
        }
    }
}
