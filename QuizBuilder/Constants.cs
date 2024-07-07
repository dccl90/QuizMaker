using System;

namespace QuizMaker
{
    public class Constants
    {
        public const string FILE_PATH = @"./Quiz.xml";
        public const int MIN_QUESTIONS = 1;
        public const int MAX_QUESTIONS = 5;
        public const int MIN_OPTIONS = 4;
        public const int MAX_OPTIONS = 6;
        public const char CREATE_QUIZ = 'C';
        public const char TAKE_QUIZ = 'T';
        public const char QUIT_QUIZ_MAKER = 'Q';
        public const string MENU_STRING = "----Quiz Maker----\nEnter C to Create a Quiz\nEnter T to Take a Quiz\nEnter Q to Quit";
        public const string MENU_INPUT_ERROR_STRING = "Invalid Input\nPlease Enter C to Create a Quiz, T to Take a Quiz or Q to Quit";
        public const string COLON_STRING = ": ";

        public const string INPUT_NUMBER_OF_QUESTIONS_STRING = "How Many Questions will the Quiz Contain: ";
        public const string INPUT_NUMBER_OF_QUESTIONS_ERROR_STRING = $"Value Must be Between 1 and 5";
        public const string INPUT_QUESTION_STRING = "Enter your Question: ";
        public const string INPUT_OPTION_STRING = "Enter Option";
        public const string INPUT_NUMBER_OF_OPTIONS_STRING = "Please the Number of Possible Answers: ";
        public const string INPUT_NUMBER_OF_OPTIONS_ERROR_STRING = $"Value Must be Between 1 and 4";
        public const string INPUT_CORRECT_ANSWER_STRING = "Is this The Correct Answer (True or False)? ";
        public const string INPUT_CORRECT_ANSWER_ERROR_STRING = "Enter True or False";

        public const string INPUT_ANSWER_SELECTION = "Enter the Correct Answers Separated by a Comma: ";
        public const string INPUT_ANSWER_SELECTION_ERROR = "Selection Invalid, Please Enter Using the Following Format A or A,B,C";
        public const string CONTINUE_STRING = "Press any key to continue";
        public static string[] OPTIONS = new string[] { "A", "B", "C", "D", "E", "F" };

    }
}