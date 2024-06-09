namespace SistemaGestionUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static Inicio inicio;
        public static string instancia = string.Empty;
        public static int idSelected = 0;
        public static bool modificar = false;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(inicio = new Inicio());
        }
    }
}