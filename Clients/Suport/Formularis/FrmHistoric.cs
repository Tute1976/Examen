using Examen.Suport.Controls;
using Examen.Suport.Funcions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Examen.Suport.Formularis
{
    public partial class FrmHistoric : FormAdv
    {
        public FrmHistoric(IEnumerable<ListViewItem> items)
        {
            InitializeComponent();

            llistaHistoric.Items.Clear();
            llistaHistoric.Items.AddRange(items.ToArray());

            lTitol.Text = @"Històric d'accions realitzades";
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llistaHistoric_DoubleClick(object sender, EventArgs e)
        {
            if (llistaHistoric.SelectedItems is not { Count: > 0 })
                return;

            var linies = new List<string>();
            string txt;
            foreach (ListViewItem item in llistaHistoric.SelectedItems)
            {
                txt = $"{item.SubItems[1].Text}     {item.SubItems[2].Text}";
                linies.Add(txt);
            }

            var nl = Environment.NewLine;
            var txts = string.Join($"{nl}", linies);
            txt = $"{txts}{nl}{nl}{nl}Vols copiar el text al portapapers?";
            if (txt.Mostrar(MostrarIcon.Question, MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            Clipboard.SetText(txts);
        }
    }
}
