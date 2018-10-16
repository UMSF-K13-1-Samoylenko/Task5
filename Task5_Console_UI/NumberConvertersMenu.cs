// <copyright file="NumberConvertersMenu.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task5_Console_UI
{
    using System;
    using Task5_Lib;

    /// <summary>
    /// Menu class for demonstrating work with number converter
    /// </summary>
    public class NumberConvertersMenu
    {
       /// <summary>
       /// Console menu
       /// </summary>
       /// <param name="args">Command line args</param>
        public void ConsoleMenu(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    if (int.TryParse(args[0], out int n))
                    {
                        try
                        {
                            Console.WriteLine(NumberConverters.IntToString(n));
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    break;
                default:
                    this.Instruction();
                    break;
            }
        }

        /// <summary>
        /// Console instruction for program
        /// </summary>
        private void Instruction()
        {
            Console.WriteLine("Program assignment" + Environment.NewLine +
                "Converting int number to its string view" + Environment.NewLine +
                "Launch example: Task5_Console_UI.exe 123" + Environment.NewLine);
        }
    }
}