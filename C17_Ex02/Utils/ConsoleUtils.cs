using System;
using C17_Ex02.BasicDataTypes;

namespace C17_Ex02.Utils
{
    class ConsoleUtils
    {
        public const char k_ColumnsDelimiter = '|';
        public const char k_SpaceChar = ' ';
        public const char k_BorderUnitSign = '=';


        public static void PrintBorder(char i_BorderUnitSign, uint i_NumberOfUnits, string i_MarginStr)
        {
            //todo ?!
            Console.WriteLine();
            PrintMargins(i_MarginStr);
            for (int i = 0; i < i_NumberOfUnits; i++)
            {
                Console.Write(i_BorderUnitSign);
            }
            Console.WriteLine();
        }

        public static void PrintNumericMargins(string i_MarginStr, int i_RowNumber)
        {
            PrintMargins(String.Format(i_MarginStr, i_RowNumber));
        }

        public static void PrintMargins(string i_MarginStr)
        {
            Console.Write(i_MarginStr);
        }


        public static uint GetPositiveNumberFromUser(String i_MessageForUser, uint i_MinValidInput, uint i_MaxValidInput)
        {
            string userInputStr = string.Empty;
            uint userInput;
            bool isValidInput;

            System.Console.WriteLine(String.Format(i_MessageForUser, i_MinValidInput, i_MaxValidInput));
            do
            {
                userInputStr = System.Console.ReadLine();
                isValidInput = (uint.TryParse(userInputStr, out userInput) &&
                    (userInput >= i_MinValidInput) &&
                    (userInput <= i_MaxValidInput));
                if (!isValidInput)
                {
                    System.Console.WriteLine("Invalid input! Please try again:");
                }
            }
            while (!isValidInput);

            return userInput;
        }

        public static bool IsStringNumeric(string i_Str)
        {
            bool IsNumeric = true;

            for (int i = 0; (i < i_Str.Length) && IsNumeric; i++)
            {
                IsNumeric = char.IsDigit(i_Str[i]);
            }

            return IsNumeric;
        }

        public static Point GetPointFromUser(String i_MessageForUser, Point i_MinValidInput, Point i_MaxValidInput)
        {
            uint row = GetPositiveNumberFromUser("Insert Row Number: ({0}-{1})",
                i_MinValidInput.Y,
                i_MaxValidInput.Y);
            uint col = GetPositiveNumberFromUser("Insert Col Number: ({0}-{1})",
                i_MinValidInput.X,
                i_MaxValidInput.X);

            return new Point(col, row);
        }

    }
}
