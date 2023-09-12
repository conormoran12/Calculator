using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{


    internal class Program
    {
        public static double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        public static string CalculationReadyConverter()
        {
            string[] characters = { "÷", "x" };
            Console.WriteLine("Enter a calculation:");
            string userCalculation = Console.ReadLine();
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == "x")
                {
                    userCalculation = userCalculation.Replace(characters[i], "*");
                }
                else
                {
                    userCalculation = userCalculation.Replace(characters[i], "/");
                }
            }
            CalculationErrorHandler(userCalculation);
            return userCalculation;
        }

        public static string CalculationErrorHandler(string user_calculation)
        {
            try
            {
                Console.WriteLine($"The answer is: {Evaluate(user_calculation)}");
                return $"The answer is: {Evaluate(user_calculation)}";
            }
            catch (Exception e)
            {
                Console.WriteLine("Syntax Error");
                return CalculationReadyConverter();
            }
        }

        static void Main(string[] args)
        {
            CalculationReadyConverter();
        }
    }
}