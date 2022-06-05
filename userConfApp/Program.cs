using System;
using System.Runtime.InteropServices;

namespace userConfApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        //For adding Console to the program, was used for temp Sanity-Check
        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();*/
        [STAThread]
       
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //For adding Console to the program, was used for temp Sanity-Check #2
            /*AllocConsole();*/
            //Console.WriteLine("Hello");
            Application.Run(new mainWindow());
        }
    }
}