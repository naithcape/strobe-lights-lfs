namespace LFSStrobeTKbyAnton
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Set up the application to use visual styles and compatible text rendering.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the main form of the application.
            Application.Run(new Form1());
        }
    }
}
