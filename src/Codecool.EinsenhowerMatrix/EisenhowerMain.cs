using System;


namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Main class for program
    /// </summary>
    public class EisenhowerMain
    {
        /// <summary>
        /// Runs program with basic user UI
        /// </summary>
        public void Run()
        {
            TodoMatrix matrix = new  TodoMatrix();
            matrix.AddItem("title", new DateTime(2023, 2, 28));
            Console.WriteLine(matrix.ToString());
        }
    }
}
