using System;
using System.Collections.Generic;

namespace Mysoft.Business.Validation.Entity
{
    public class Result
    {
        public Result(string title, string message, Level level, Type validation)
        {
            Level = level;
            Message = message;
            Title = title;
            Validation = validation;
        }

        public Level Level { get; set; }

        public Type Validation { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }

    [Flags]
    public enum Level
    {
        Success = 0,
        Message = 1,
        Warn = 2,
        Error = 4
    }

    public class PageResult
    {
        public PageResult()
        {
            Results = new List<Result>();
        }

        public string Xml { get; set; }

        public List<Result> Results { get; set; }

        public List<PageResult> SubPages { get; set; }
    }
}