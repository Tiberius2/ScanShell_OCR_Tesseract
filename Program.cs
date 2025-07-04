﻿using DynamicDOTNET;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace ScanShell_OCR
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
