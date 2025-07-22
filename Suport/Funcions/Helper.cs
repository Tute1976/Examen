using System.Runtime.InteropServices;

namespace Examen.Suport.Funcions
{
    public static class Helper
    {
        public static string SyncfusionLicense => Properties.Settings.Default.SyncfusionLicense;

        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
    }
}
