using Entities.Models;
using Manager.Context;
using Manager.Exceptions;
using Manager.Repositories.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repositories.Concrete
{
    /// <summary>
    /// This class includes custom queries for exam entity.
    /// </summary>
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">
        /// Application dbContext.
        /// </param>
        public ExamRepository(IEasyExamContext context) : base(context)
        {
        }

        /// <summary>
        /// Overrides AddAsync
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        public override Task<Exam> AddAsync(Exam value)
        {
            foreach (var item in value.Questions)
            {
                switch (item.QuestionType)
                {
                    case QuestionType.MultipleChoice:
                        if (item.Answers.GetType() == typeof(List<MultipleChoiceAnswer>)) 
                        { throw new ParameterException("WrongParameter"); }
                        break;
                    case QuestionType.Classical:
                        throw new NotImplementedException();
                    case QuestionType.TrueFalse:
                        throw new NotImplementedException();
                    case QuestionType.GapFill:
                        throw new NotImplementedException();
                    default:
                        throw new NotImplementedException();
                }
            }
            return base.AddAsync(value);
        }

        /// <summary>
        /// Overrides Add.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// Exam entity.
        /// </returns>
        public override Exam Add(Exam value)
        {
            return AddAsync(value).Result;
        }

        /// <summary>
        /// Overrides Insert.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        public override void Insert(Exam value)
        {
            Add(value);
        }

        /// <summary>
        /// Begin exam for single user.
        /// </summary>
        /// <param name="examId">
        /// Document id of exam entity.
        /// </param>
        /// <param name="user">
        /// User entity.
        /// </param>
        /// <returns>
        /// Exam.
        /// </returns>
        public virtual async Task<Exam> BeginExamForUserAsync(string examId, User user)
        {
            var exam = base.GetActiveRules().FirstOrDefault(x => x.Id == examId) ?? throw new EntityNotFoundException(nameof(Exam));
            exam.Users.Add(user);
            if (user.UserExams.Count() > 0)
                throw new FlowException(nameof(UserExam));
            await base.UpdateAsync(exam);
            return exam;
        }

        public override IQueryable<Exam> GetActiveRules()
        {
            return base.GetActiveRules().Where(x=>!x.IsDeleted);
        }
    }
}
