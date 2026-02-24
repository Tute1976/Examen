using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        public List<CategoriaAplicacions> CategoriesAplicacions { get; set; } = [];

        [Browsable(false)]
        public List<Aplicacio> TotesSenseIgnorades
        {
            get
            {
                var ret = new List<Aplicacio>();
                foreach (var categoria in CategoriesAplicacions.Where(categoria => categoria?.Aplicacions != null))
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

        [Browsable(false)]
        public List<Aplicacio> Totes
        {
            get
            {
                var ret = new List<Aplicacio>();
                foreach (var categoria in CategoriesAplicacions.Where(categoria => categoria?.Aplicacions != null))
                {
                    foreach (var aplicacioClonada in categoria.Aplicacions.Select(aplicacio => aplicacio.Clonar()))
                    {
                        aplicacioClonada.CalAturar |= categoria.CalAturar;
                        aplicacioClonada.Ignorar |= categoria.Ignorar;
                        aplicacioClonada.Categoria = categoria.Nom;

                        ret.Add(aplicacioClonada);
                    }
                }

                return ret;
            }
        }

        [Browsable(false)]
        public Dictionary<string, Bitmap> Icones
        {
            get
            {
                var ret = new Dictionary<string, Bitmap>();

                foreach (var categoria in CategoriesAplicacions.Where(categoria => categoria?.Aplicacions != null))
                {
                    foreach (var aplicacio in categoria.Aplicacions)
                        ret.Add(aplicacio.Nom, aplicacio.Icona);
                }

                return ret;
            }
        }

        [Browsable(false)]
        public List<string> Categories => [.. CategoriesAplicacions.Select(c => c.Nom).OrderBy(c => c)];

        public bool AplicaIcones(List<AplicacioEnUs> aplicacionsEnUs)
        {
            var desar = false;

            if (aplicacionsEnUs.Count == 0)
                return false;

            var aplicacionsEnUsAgrupades = aplicacionsEnUs.GroupBy(a => a.ExecutableCurt.ToLower()).ToDictionary(a => a.Key, a => a.First());

            foreach (var categoriaAplicacions in CategoriesAplicacions)
            {
                foreach (var aplicacio in categoriaAplicacions.Aplicacions)
                {
                    if (!string.IsNullOrEmpty(aplicacio.ImatgeEnBase64))
                        continue;

                    if (!aplicacionsEnUsAgrupades.ContainsKey(aplicacio.ExecutableCurt.ToLower()))
                        continue;

                    var aplicacioEnUs = aplicacionsEnUsAgrupades[aplicacio.ExecutableCurt.ToLower()];

                    aplicacio.Icona = aplicacioEnUs.Icona;
                    desar = true;
                }

            }

            return desar;
        }
    }
}
