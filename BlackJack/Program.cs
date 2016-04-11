using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    static class Program
    {
        public static int POINTS_TO_WIN = 21;
        public static bool createNewGame = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            do
            {
                Application.Run(new Form_main());
            } while (createNewGame);
        }
    }
}
