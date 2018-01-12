using System;

namespace FindCapitalByState
{
    class Program
    {
        /// <summary>
        /// The findStateLogic 
        /// </summary>
        private static readonly FindByStateBusinessLogic findStateLogic = new FindByStateBusinessLogic();

        /// <summary>
        /// The Main 
        /// </summary>
        /// <param name="args">the args</param>
        static void Main(string[] args)
        {
            string input = string.Empty;
            do
            {
                Console.WriteLine("********************************************************************");
                Console.WriteLine("Input state name/abbreviation to search, type 'exit' to close application");
                Console.Write("Input : ");
                input = Console.ReadLine();

                var result = findStateLogic.FindCityByState(input);

                var resultMessage = string.IsNullOrWhiteSpace(result.ErrorMessage) ? $"Largest City : { result.LargestCity }, Capital : { result.Capital }" : $"Error : { result.ErrorMessage }";
                Console.WriteLine(resultMessage);

            } while (!input.Equals("exit", StringComparison.OrdinalIgnoreCase));
        }
    }
}
