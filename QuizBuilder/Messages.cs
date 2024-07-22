using System;

namespace QuizMaker
{
    public class Messages
    {
        public static string MENU_STRING = $"----Quiz Maker----\nEnter {Constants.CREATE_QUIZ} to Create a Quiz\nEnter {Constants.TAKE_QUIZ} to Take a Quiz\nEnter {Constants.QUIT_QUIZ_MAKER} to Quit";
        public static string MENU_INPUT_ERROR_STRING = $"Invalid Input\nPlease Enter {Constants.CREATE_QUIZ} to Create a Quiz, {Constants.TAKE_QUIZ} to Take a Quiz or {Constants.QUIT_QUIZ_MAKER} to Quit";
        public const string COLON_STRING = ": ";
        public const string INPUT_NUMBER_OF_QUESTIONS_STRING = "How Many Questions will the Quiz Contain: ";
        public static string INPUT_NUMBER_OF_QUESTIONS_ERROR_STRING = $"Value Must be Between {Constants.MIN_QUESTIONS} and {Constants.MAX_QUESTIONS}";
        public const string INPUT_QUESTION_STRING = "Enter your Question: ";
        public const string INPUT_OPTION_STRING = "Enter Option";
        public const string INPUT_NUMBER_OF_OPTIONS_STRING = "Please the Number of Possible Answers: ";
        public const string INPUT_CORRECT_ANSWER_STRING = "Is this The Correct Answer (True or False)? ";
        public const string INPUT_CORRECT_ANSWER_ERROR_STRING = "Enter True or False";
        public const string INPUT_ANSWER_SELECTION = "Enter the Correct Answers Separated by a Comma: ";
        public const string INPUT_ANSWER_SELECTION_ERROR = "Selection Invalid, Please Enter Using the Following Format A or A,B,C";
        public const string FILE_DOES_NOT_EXIST_ERROR_STRING = "File Does Not Exist! \nPlease Select Option C to Create a Quiz";
        public const string CONTINUE_STRING = "Press any key to continue";

    }
}