using System;

namespace QuizProject.Service.Exceptions
{
    public class QuizProjectException : Exception
    {
        public int Code { get; set; }
        public QuizProjectException(int code, string massage) : base(massage)
        {
            Code = code;
        }
    }
}
