using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repositories.Abstractions
{
    /// <summary>
    /// This interface includes custom queries for exam entity.
    /// </summary>
    public interface IExamRepository : IBaseRepository<Exam>
    {
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
        Task<Exam> BeginExamForUserAsync(string examId, User user);

        /// <summary>
        /// Answer the question.
        /// </summary>
        /// <typeparam name="T">
        /// IAnswerModel inherited answer model entity.
        /// </typeparam>
        /// <param name="examId">
        /// Exam documentId.
        /// </param>
        /// <param name="questionId">
        /// Question documentId.
        /// </param>
        /// <param name="answer">
        /// Answer model.
        /// </param>
        Task AnswerQuestionAsync(string examId, string questionId,string userId ,UserExam userExam);
    }
}
