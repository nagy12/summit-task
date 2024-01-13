using System.Collections.Generic;

namespace MovieApplication.DataAccess
{
    public class DataAccessResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public DataAccessResult()
        {
            Success = false;
            Message = string.Empty;
            ErrorCode = 500;
        }
    }
    public class DataAccessResults<TEntity> : DataAccessResult where TEntity : class, new()
    {
        public IList<TEntity> Entities { get; set; }
    }
}
