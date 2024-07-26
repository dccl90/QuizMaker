using System;
using System.Reflection.Metadata;

namespace QuizMaker
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            char menuInput = UserInterface.GetMenuInput();
            

            while(true)
            {  
                if(menuInput == Constants.CREATE_QUIZ)
                {
                    int numberOfQuestions = UserInterface.GetNumberOfQuestions();
                    List<Question> questionsList = UserInterface.GetListOfQuestions(numberOfQuestions);
                    QuizLogic.WriteXmlFile(questionsList);
                }

                if(menuInput == Constants.TAKE_QUIZ)
                {
                    int points = QuizLogic.GetPoints();
                    
                    var questionList = QuizLogic.ReadXmlFile();
                    if(questionList is null)
                    {
                        UserInterface.PrintFileDoesNotExistError();
                        menuInput = UserInterface.GetMenuInput();
                        continue;
                    }

                    int numberOfQuestions = questionList.Count;
                    foreach(var question in questionList)
                    {
                        
                        UserInterface.PrintQuizHeader(numberOfQuestions, points);
                        UserInterface.PrintQuestion(question.QuizQuestion);
                        UserInterface.PrintOptions(question.Options);
                        

                        string selection = UserInterface.CollectUserAnswers();
                        bool isAnswerCorrect = QuizLogic.IsCorrectAnswer(selection, question.Options);
                        points = QuizLogic.AddPoints(isAnswerCorrect);
                    }

                    UserInterface.PrintFinalScore(numberOfQuestions, points);
                    QuizLogic.ResetPoints();

                }

                if(menuInput == Constants.QUIT_QUIZ_MAKER)
                {
                    break;
                }

                menuInput = UserInterface.GetMenuInput();

            }


        }
    }
}