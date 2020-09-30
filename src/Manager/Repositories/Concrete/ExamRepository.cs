using Entities.Models;
using Manager.Context;
using Manager.Exceptions;
using Manager.Repositories.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
    }
}
