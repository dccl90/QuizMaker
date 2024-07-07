using System;

namespace QuizMaker
{
    public class UserInterface
    {
        /// <summary>
        /// A method for setting the users answers to a question
        /// </summary>
        /// <returns>A string with the users selections</returns>
        public string SetUserInputSelection()
        {
            while (true)
            {
                string selection = SetStringInput(Constants.INPUT_ANSWER_SELECTION);
                if(IsUserInputSelectionValid(selection))
                {
                    return selection;
                }
                else
                {
                    PrintMessage(Constants.INPUT_ANSWER_SELECTION_ERROR);
                }
            }
        }

        /// <summary>
        /// Checks if the answers selected by the user are valid
        /// </summary>
        /// <param name="input">A string of answers</param>
        /// <returns>A true or false value determining if the user input is valid</returns>
        public bool IsUserInputSelectionValid(string input)
        {
            string[] selectionArr = input.Split(',');


            foreach(string selection in selectionArr) 
            {
                if(!Constants.OPTIONS.Contains(selection.ToUpper())){
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The list of questions
        /// </summary>
        /// <param name="numberOfQuestions">The number of questions the quiz will contain</param>
        /// <returns>The list of questions</returns>
        public List<Question> GetListOfQuestions(int numberOfQuestions)
        {
   
            List<Question> questionsList = new List<Question>();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string question = SetStringInput(Constants.INPUT_QUESTION_STRING);
                List<Option> optionsList = GetListOfOptions();
                ClearConsole();

                questionsList.Add(new Question { QuizQuestion = question, Options = optionsList });
            }

            return questionsList;

        }

        /// <summary>
        /// Gets a list of options
        /// </summary>
        /// <returns>A list of options for a question</returns>
        private List<Option> GetListOfOptions()
        {
            List<Option> optionsList = new List<Option>();
            int numberOfOption = GetNumberOfOptions();

                for (int j = 0; j < numberOfOption; j++)
                {
                    string option = SetStringInput($"{Constants.INPUT_OPTION_STRING} {j + 1}: ");
                    bool correctAnswer = SetBoolInput(Constants.INPUT_CORRECT_ANSWER_STRING);
                    optionsList.Add(new Option { CorrectAnswer = correctAnswer, OptionSelector = Constants.OPTIONS[j], Answer = option });
                }

            return optionsList; ;
        }

        /// <summary>
        /// Collects the input for the number of questions
        /// </summary>
        /// <returns>An int that represents the number of questions for a quiz</returns>
        public int GetNumberOfQuestions()
        {
            ClearConsole();
            int numberOfQuestions = SetIntInput(
                    Constants.INPUT_NUMBER_OF_QUESTIONS_STRING,
                    Constants.MIN_QUESTIONS,
                    Constants.MAX_QUESTIONS
                );
            return numberOfQuestions;
        }

        /// <summary>
        /// Collects the input for the number of options
        /// </summary>
        /// <returns>An int that represents the number of answer options for a question</returns>
        private int GetNumberOfOptions()
        {
            int numberOfOption = SetIntInput(
                    Constants.INPUT_NUMBER_OF_OPTIONS_STRING,
                    Constants.MIN_OPTIONS,
                    Constants.MAX_OPTIONS
                );
            return numberOfOption;
        }

        /// <summary>
        /// The menu input
        /// </summary>
        /// <returns>Returns the users input</returns>
        public char GetMenuInput()
        {
            ClearConsole();
            PrintMessage(Constants.MENU_STRING);
            char menuInput = SetUserInputChar(Constants.COLON_STRING, Constants.MENU_INPUT_ERROR_STRING);
            return menuInput;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfQuestions"></param>
        /// <param name="points"></param>
        public void PrintQuizHeader(int numberOfQuestions, int points)
        {
            ClearConsole();
            PrintMessage($"Number of Questions: {numberOfQuestions}  Points: {points}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfQuestions"></param>
        /// <param name="points"></param>
        public void PrintFinalScore(int numberOfQuestions, int points)
        {
            ClearConsole();
            PrintMessage($"You got {points} out of {numberOfQuestions} Questions Correct");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the quiz question to the console
        /// </summary>
        /// <param name="question">A question</param>
        public void PrintQuestion(string question)
        {
            PrintMessage($"Question: {question}");
        }

        /// <summary>
        /// Prints a list of options to the console
        /// </summary>
        /// <param name="options">A list of options to a question</param>
        public void PrintOptions(List<Option> options)
        {
            foreach(var option in options)
            {
                PrintMessage($"({option.OptionSelector}) {option.Answer}");
            }
        }

        /// <summary>
        /// A generic method to prints a message to the console
        /// </summary>
        /// <param name="message">A messag to be printed</param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Collects the users input
        /// </summary>
        /// <param name="message">A message to be printed to the console</param>
        /// <returns>The users input as a string</returns>
        public string SetStringInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Collects the users input and returns it as a bool
        /// </summary>
        /// <param name="message">The message printed to the console</param>
        /// <returns></returns>

        public bool SetBoolInput(string message)
        {
            bool boolean;
            while(true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                bool isBool = bool.TryParse(input, out boolean);

                if(isBool)
                {
                    break;
                }
                else
                {
                    PrintMessage(Constants.INPUT_CORRECT_ANSWER_ERROR_STRING);
                    PrintMessage(Constants.CONTINUE_STRING);
                    Console.ReadLine();
                }
            }
    
            return boolean;
        }

        /// <summary>
        /// Returns the input from the user as an int
        /// </summary>
        /// <param name="message">The message to be printed in the console</param>
        /// <param name="min">The minimum supported int value</param>
        /// <param name="max">The maximum supported int value</param>
        /// <returns>The users input as an int</returns>
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

                PrintMessage($"Value Must be Between {min} and {max}");
                PrintMessage(Constants.CONTINUE_STRING);
                Console.ReadLine();
                ClearConsole();
            }
            while(!isValidInput);
            return intInput;  
        }

        /// <summary>
        /// Validates the integer entered by the user
        /// </summary>
        /// <param name="input">The int entered by the user</param>
        /// <param name="min">The minimum supported int</param>
        /// <param name="max">The maximum supported int</param>
        /// <returns>A true or false value confirming if the int is valid</returns>
        public bool IsValidIntInput(int input, int min, int max)
        {
            if(input >= min && input <= max)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the users input as a char
        /// </summary>
        /// <param name="message">A message to be printed in the console</param>
        /// <param name="errMessage">An error message to be printed if that input is not valid</param>
        /// <returns>The char entered by the user</returns>
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
        /// Validats if the chat enterted by the user is valod
        /// </summary>
        /// <param name="charInput">The users input as a char</param>
        /// <returns>A true or flase value confirming if the menu input is valid</returns>
        private static bool IsValidMenuInput(char charInput)
        {
            if(
                charInput == Constants.TAKE_QUIZ ||
                charInput == Constants.CREATE_QUIZ ||
                charInput == Constants.QUIT_QUIZ_MAKER
            )
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Clears the console
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}