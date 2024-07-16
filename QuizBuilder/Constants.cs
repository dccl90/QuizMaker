using System;

namespace QuizMaker
{
    public class Constants
    {
        public const string COMMA = ",";
        public const string FILE_PATH = @"./Quiz.xml";
        public const int MIN_QUESTIONS = 1;
        public const int MAX_QUESTIONS = 5;
        public const int MIN_OPTIONS = 4;
        public const int MAX_OPTIONS = 6;
        public const char CREATE_QUIZ = 'C';
        public const char TAKE_QUIZ = 'T';
        public const char QUIT_QUIZ_MAKER = 'Q';
        public static string[] OPTIONS = new string[] { "A", "B", "C", "D", "E", "F" };

    }
}