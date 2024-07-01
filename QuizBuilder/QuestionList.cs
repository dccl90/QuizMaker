using System;
using System.Reflection;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuestionList
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

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

         public void WriteXmlFile(List<Question> questionList)
         {
            using (FileStream f = File.Create(Constants.FILE_PATH))
            {
                serializer.Serialize(f, questionList);
            }
         }
        
    }
}