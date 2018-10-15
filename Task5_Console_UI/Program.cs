// <copyright file="Program.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task5_Console_UI
{
    /// <summary>
    /// Main class of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">Args of command line</param>
        private static void Main(string[] args)
        {
            NumberConvertersMenu convertersMenu = new NumberConvertersMenu();
            convertersMenu.ConsoleMenu(args);
        }
    }
}
