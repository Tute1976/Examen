using Examen.Suport.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Examen.Suport.Controls
{
    public enum Colors
    {
        Blanc,
        Blau,
        Correcte,
        Vermell,
        VermellFosc,
        Defecte
    }

    public enum Imatge
    {
        Nou = 1,
        Atencio = 2,
        Vell = 3,
        Defecte = 0
    }

    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    public class InfoEstacio(EstacioAlumne estacioAlumne, int interval) : UserControl
    {
        protected bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        public EstacioAlumne EstacioAlumne { get; set; } = estacioAlumne;
        public List<AplicacioEnUs> AplicacionsEnUs { get; set; }

        // Contracte comú
        public virtual bool Pitar { get; set; }
        public virtual bool Bloquejar { get; set; }
        public virtual bool Aturar { get; set; }
        public virtual bool MostrarBotons { get; set; }
        public virtual bool Tancar { get; set; }
        public virtual string Estat { get; set; }

        public virtual DateTime Data { get; set; }

        public virtual Colors Color { get; set; }

        public virtual Imatge Imatge { get; set; }

        protected TimeSpan Temps => DateTime.Now - (EstacioAlumne.DataInici ?? DateTime.Now);
        public bool Caducada => (DateTime.Now - (EstacioAlumne.DataDarreraConnexio ?? DateTime.Now)).TotalSeconds > interval;

        public InfoEstacio() : this(new EstacioAlumne("", Guid.Empty), 5)
        {
        }
    }
}
