using AutoMapper;
using QuizProject.Domain.Entities.Answers;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Entities.Quizs;
using QuizProject.Domain.Entities.Users;
using QuizProject.Service.DTOs.Answers;
using QuizProject.Service.DTOs.Attachment;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.DTOs.Questions;
using QuizProject.Service.DTOs.Quizes;
using QuizProject.Service.DTOs.QuizResults;
using QuizProject.Service.DTOs.Users;

namespace QuizProject.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region User mapp
            CreateMap<User, UserForCreateDTOs>().ReverseMap();
            CreateMap<User, UserForUpdateDTOs>().ReverseMap();
            CreateMap<User, UserForViewDTOs>().ReverseMap();
            #endregion

            #region Ansver mapp
            CreateMap<Answer, AnswerForCreateDTOs>().ReverseMap();
            CreateMap<Answer, AnswerForViewDTOs>().ReverseMap();
            #endregion

            #region Attachment Mapp
            CreateMap<Attachment, AttachmentForCreateDtos>().ReverseMap();
            CreateMap<Attachment, AttachmentForViewDTOs>().ReverseMap();
            #endregion

            #region Courses map
            CreateMap<Course, CourseForCreateDTOs>().ReverseMap();
            CreateMap<Course, CourseForViewDTOs>().ReverseMap();
            #endregion

            #region Cuestions Mapp
            CreateMap<Question, QuestionForCreateDTOs>().ReverseMap();
            CreateMap<Question, QuestionForViewDTOs>().ReverseMap();
            #endregion

            #region Quizes Mapp
            CreateMap<Quiz, QuizeForCreateDTOs>().ReverseMap();
            CreateMap<Quiz, QuizeForViewDTOs>().ReverseMap();
            #endregion

            #region QuizResult Mapp
            CreateMap<QuizResult, QuizResultForCreateDTOs>().ReverseMap();
            CreateMap<QuizResult, QuizResultForViewDTOs>().ReverseMap();
            #endregion
        }
    }
}
