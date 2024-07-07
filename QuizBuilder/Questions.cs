using System;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class Question
    {
        public string QuizQuestion { get; set; }
        public List<Option> Options { get; set; }
        
    }

    public class Option 
    {
         [XmlAttribute("correctAnswer")]
         public bool CorrectAnswer { get; set; }
        [XmlAttribute("selector")]
         public string OptionSelector { get; set; }
         [XmlText]
         public string Answer { get; set; }

    }
}