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
                    int numberOfQuestions = questionList.Count;
                    foreach(var question in questionList)
                    {
                        
                        ui.PrintQuizHeader(numberOfQuestions, points);
                        ui.PrintQuestion(question.QuizQuestion);
                        ui.PrintOptions(question.Options);
                        

                        string selection = ui.SetUserInputSelection();
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