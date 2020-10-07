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
            var exam = await FindActiveExamAsync(examId);
            if (exam.StartDate > DateTime.UtcNow)
                throw new ExamNotStartException(nameof(Exam));
            if (exam.EndDate < DateTime.UtcNow)
                throw new AlreadyDoneExamException(nameof(Exam));
            if (user.UserExams.Count() > 0)
                throw new FlowException(nameof(UserExam));
            exam.Users.Add(user);
            await base.UpdateAsync(exam);
            return exam;
        }

        /// <summary>
        /// Document active rules for exam entity.
        /// </summary>
        /// <returns>
        /// Queryable Exam.
        /// </returns>
        public override IQueryable<Exam> GetActiveRules()
        {
            return base.GetActiveRules().Where(x => !x.IsDeleted);
        }

        /// <summary>
        /// Set Answer question.
        /// </summary>
        /// <param name="examId">
        /// Exam document id.
        /// </param>
        /// <param name="questionId">
        /// Question document id.
        /// </param>
        /// <param name="userId">
        /// User document id.
        /// </param>
        /// <param name="userExam">
        /// User Exam entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        public async Task SetAnswerQuestionAsync(string examId, string questionId, string userId, UserExam userExam)
        {
            var exam = await FindActiveExamAsync(examId);
            if (exam.Questions.Any(x => x.Id == questionId))
            {
                var user = exam.Users.FirstOrDefault(x => x.Id == userId) ?? throw new EntityNotFoundException(nameof(Exam));
                if (!user.UserExams.Any(x => x.QuestionId == questionId))
                {
                    user.UserExams.Add(userExam);
                    await base.ReplaceAsync(exam);
                }
            }
            else
                throw new EntityNotFoundException(nameof(Question));
        }

        /// <summary>
        /// Find exam with examId.
        /// </summary>
        /// <param name="examId">
        /// Document id.
        /// </param>
        /// <returns>
        /// Exam entity.
        /// </returns>
        private async Task<Exam> FindActiveExamAsync(string examId)
        {
            return base.GetActiveRules().FirstOrDefault(x => x.Id == examId) ?? throw new EntityNotFoundException(nameof(Exam));
        }
    }
}
