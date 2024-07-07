using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks.Dataflow;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuestionList
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
        int points = 0;

        /// <summary>
        /// The number of points or correct answers
        /// </summary>
        /// <returns>The number of points scored by the user</returns>
        public int GetPoints()
        {
            return points;
        }

        /// <summary>
        /// Resets the points back to 0
        /// </summary>
        public void ResetPoints()
        {
            points = 0;
        }

        /// <summary>
        /// Checks the correct answers for a question
        /// </summary>
        /// <param name="options">The options selected by the user</param>
        /// <returns>A list of correct answers for the question</returns>
        private List<string> GetCorrectAnswersList(List<Option> options)
        {
            List<string> correctAnswersList = new List<string>();
            foreach( var option in options)
            {
                if(option.CorrectAnswer == true)
                {
                    correctAnswersList.Add(option.OptionSelector);
                }
            }
            return correctAnswersList;
        }

        /// <summary>
        /// Returns the options selected by the user as a list
        /// </summary>
        /// <param name="selections">A string options selected by the user</param>
        /// <returns>A list of the options selected by the user</returns>
        private List<string> GetInputSelectionsList(string selections)
        {   
            List<string> inputSelectionsList = new List<string>();
            string[] inputSelectionsArray = selections.Split(',');
            foreach(string selection in inputSelectionsArray)
            {
                inputSelectionsList.Add(selection.Trim().ToUpper());
            }
            return inputSelectionsList;
        }

        /// <summary>
        /// Checks if the user has answered the question correctly
        /// </summary>
        /// <param name="selections">A string options selected by the user</param>
        /// <param name="options">The options selected by the user</param>
        /// <returns>A boolean determining if the user got the answer correct</returns>

        public bool IsCorrectAnswer(string selections, List<Option> options)
        {
            List<string> inputSelectionsList = GetInputSelectionsList(selections);
            List<string> correctAnswersList = GetCorrectAnswersList(options);

            if(inputSelectionsList.Count != correctAnswersList.Count)
            {
                return false;
            }

            foreach (string answer in correctAnswersList)
            {
                if(!inputSelectionsList.Contains(answer))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Adds a point to the users score if the answer is correct
        /// </summary>
        /// <param name="isAnswerCorrect">A true or flase value that determines if the users answer was correct</param>
        /// <returns>The updated points</returns>
        public int AddPoints(bool isAnswerCorrect)
        {
            if(isAnswerCorrect)
            {
                points++;
            }
            return points;
        }

        /// <summary>
        /// Reads an XML file into a list of questions
        /// </summary>
        /// <returns>A List of Questions</returns>
        public List<Question> ReadXmlFile()
        {
            var questionList = new List<Question>();
            if (!File.Exists(Constants.FILE_PATH))
            {
                return null; 
            }

            using (FileStream file = File.OpenRead(Constants.FILE_PATH))
            {
                questionList = serializer.Deserialize(file) as List<Question>;
            }
            return questionList;
        }

        /// <summary>
        /// Writes a list of questions to an XML file
        /// </summary>
        /// <param name="questionList">A list of questions and answers provided by the user</param>
         public void WriteXmlFile(List<Question> questionList)
         {
            using (FileStream f = File.Create(Constants.FILE_PATH))
            {
                serializer.Serialize(f, questionList);
            }
         }
        
    }
}