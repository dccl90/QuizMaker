using System;

namespace QuizMaker
{
    public class UserInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SetStringInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>

        public bool SetBoolInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            bool.TryParse(input, out bool boolean);
            return boolean;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public int SetIntInput(string message, int min, int max)
        {
            bool isValidInput = false;
            int intInput;
            do{
                Console.Write(message);
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out intInput);
                isValidInput = IsValidIntInput(intInput, min, max);
                if(isValidInput)
                {
                    break;
                }

                Console.WriteLine($"Value Must be Between {min} and {max}");
                Console.ReadLine();
                ClearConsole();
            }
            while(!isValidInput);
            return intInput;  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsValidIntInput(int input, int min, int max)
        {
            if(input >= min && input <= max)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public char SetUserInputChar(string message, string errMessage)
        {
            char charInputUpper;
            bool isValidCharInput;
            bool isChar = false;
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();
                isChar = char.TryParse(input, out char charInput);
                charInputUpper = Char.ToUpper(charInput);
                isValidCharInput = IsValidMenuInput(charInputUpper);
                if (isChar && isValidCharInput)
                {
                    break;
                }
                ClearConsole();
                PrintMessage(errMessage);
            } 
            while (!isChar || !isValidCharInput);
            
            return charInputUpper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charInput"></param>
        /// <returns></returns>
        private static bool IsValidMenuInput(char charInput)
        {
            if(
                charInput == Constants.TAKE_QUIZ ||
                charInput == Constants.CREATE_QUIZ
            )
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }
        
    }
}