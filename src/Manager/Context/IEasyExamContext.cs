using Entities.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Context
{
    /// <summary>
    /// This interface includes database entities.
    /// </summary>
    public interface IEasyExamContext
    {
        IMongoCollection<Exam> Exams { get; }

        IMongoCollection<T> Set<T>(string collection = null);

        IMongoDatabase Database { get; }
    }
}
