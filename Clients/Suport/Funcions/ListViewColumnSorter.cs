using System;
using System.Collections;
using System.Windows.Forms;

namespace Examen.Suport.Funcions
{
    public class ListViewColumnSorter(int columna, SortOrder ordre) : IComparer
    {
        public int Compare(object x, object y)
        {
            var itemX = (ListViewItem)x;
            var itemY = (ListViewItem)y;

            if (itemX == null || itemY == null) 
                return 0;
            
            var textX = itemX.SubItems[columna].Text;
            var textY = itemY.SubItems[columna].Text;

            if (double.TryParse(textX, out var numX) && double.TryParse(textY, out var numY))
            {
                var result = numX.CompareTo(numY);
                return ordre == SortOrder.Ascending ? result : -result;
            }
            else if (DateTime.TryParse(textX, out var datetimeX) && DateTime.TryParse(textY, out var datetimeY))
            {
                var result = datetimeX.CompareTo(datetimeY);
                return ordre == SortOrder.Ascending ? result : -result;
            }
            else
            {
                var result = string.Compare(textX, textY, StringComparison.CurrentCultureIgnoreCase);
                return ordre == SortOrder.Ascending ? result : -result;
            }

        }
    }
}
