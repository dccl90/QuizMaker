using System;

namespace QuizMaker
{
    public class Constants
    {
        public const string FILE_PATH = "./QuizBuilder/Quiz.xml";
        public const int MIN_QUESTIONS = 1;
        public const int MAX_QUESTIONS = 5;
        public const int MIN_OPTIONS = 4;
        public const int MAX_OPTIONS = 6;
        public const char CREATE_QUIZ = 'C';
        public const char TAKE_QUIZ = 'T';
        public const string MENU_STRING = "----Quiz Maker----\nEnter C to Create a Quiz\nEnter T to Take a Quiz";
        public const string MENU_INPUT_ERROR_STRING = "Invalid Input\nPlease Enter C to Create a Quiz or T to Take a Quiz";
        public const string COLON_STRING = ": ";

        public const string INPUT_NUMBER_OF_QUESTIONS_STRING = "How Many Questions will the Quiz Contain: ";
        public const string INPUT_NUMBER_OF_QUESTIONS_ERROR_STRING = $"Value Must be Between 1 and 5";
        public const string INPUT_QUESTION_STRING = "Enter your Question: ";
        public const string INPUT_OPTION_STRING = "Enter Option";
        public const string INPUT_NUMBER_OF_OPTIONS_STRING = "Please the Number of Possible Answers: ";
        public const string INPUT_NUMBER_OF_OPTIONS_ERROR_STRING = $"Value Must be Between 1 and 4";
        public const string INPUT_CORRECT_ANSWER_STRING = "Is this The Correct Answer (True or False)? ";

    }
}