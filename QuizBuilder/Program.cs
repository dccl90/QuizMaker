using System;
using System.Reflection.Metadata;

namespace QuizMaker
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            QuestionList ql = new QuestionList();

            ui.ClearConsole();
            ui.PrintMessage(Constants.MENU_STRING);
            char menuInput = ui.SetUserInputChar(Constants.COLON_STRING, Constants.MENU_INPUT_ERROR_STRING);

            if(menuInput == Constants.CREATE_QUIZ)
            {
                
                List<Question> questionsList = new List<Question>();

                ui.ClearConsole();
                int numberOfQuestions = ui.SetIntInput(
                    Constants.INPUT_NUMBER_OF_QUESTIONS_STRING,
                    Constants.MIN_QUESTIONS,
                    Constants.MAX_QUESTIONS
                );

                for(int i = 0; i < numberOfQuestions; i++)
                {
                    List<Option> optionsList = new List<Option>();
                    string question = ui.SetStringInput(Constants.INPUT_QUESTION_STRING);
                    int numberOfOption = ui.SetIntInput(
                        Constants.INPUT_NUMBER_OF_OPTIONS_STRING,
                        Constants.MIN_OPTIONS, 
                        Constants.MAX_OPTIONS
                    );

                    for(int j = 0; j < numberOfOption; j++)
                    {
                        string option = ui.SetStringInput($"{Constants.INPUT_OPTION_STRING} {j+1}: ");
                        bool correctAnswer = ui.SetBoolInput(Constants.INPUT_CORRECT_ANSWER_STRING);
                        optionsList.Add(new Option { CorrectAnswer = correctAnswer , Answer = option });
                    }
                    ui.ClearConsole();

                    questionsList.Add(new Question {QuizQuestion = question, Options=optionsList});
                }

                ql.WriteXmlFile(questionsList);

            }

            if(menuInput == Constants.TAKE_QUIZ)
            {
                ql.ReadXmlFile();
            }
        }
    }
}