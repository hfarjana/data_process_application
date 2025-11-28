using FBZapp.Models;
using FBZapp.Services;
using System.Windows.Forms;
using System;
using System.Linq;


namespace FBZapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FantasyBzaarForm());

        }
    }
}

