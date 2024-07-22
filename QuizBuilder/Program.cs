using System;
using System.Reflection.Metadata;

namespace QuizMaker
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            QuizLogic ql = new QuizLogic();
            char menuInput = ui.GetMenuInput();
            

            while(true)
            {  
                if(menuInput == Constants.CREATE_QUIZ)
                {
                    int numberOfQuestions = ui.GetNumberOfQuestions();
                    List<Question> questionsList = ui.GetListOfQuestions(numberOfQuestions);
                    ql.WriteXmlFile(questionsList);
                }

                if(menuInput == Constants.TAKE_QUIZ)
                {
                    int points = ql.GetPoints();
                    
                    var questionList = ql.ReadXmlFile();
                    if(questionList is null)
                    {
                        ui.PrintFileDoesNotExistError();
                        menuInput = ui.GetMenuInput();
                        continue;
                    }

                    int numberOfQuestions = questionList.Count;
                    foreach(var question in questionList)
                    {
                        
                        ui.PrintQuizHeader(numberOfQuestions, points);
                        UserInterface.PrintQuestion(question.QuizQuestion);
                        UserInterface.PrintOptions(question.Options);
                        

                        string selection = ui.CollectUserAnswers();
                        bool isAnswerCorrect = ql.IsCorrectAnswer(selection, question.Options);
                        points = ql.AddPoints(isAnswerCorrect);
                    }

                    ui.PrintFinalScore(numberOfQuestions, points);
                    ql.ResetPoints();

                }

                if(menuInput == Constants.QUIT_QUIZ_MAKER)
                {
                    break;
                }

                menuInput = ui.GetMenuInput();

            }


        }
    }
}