namespace ClickerGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new CheckForUpdates());
            //Application.Run(new Form1());
            //Application.Run(new MemoryGame());
            //Application.Run(new FireGame());
            //Application.Run(new FindCorrectPoints());
            //Application.Run(new Notif());
        }
    }
}