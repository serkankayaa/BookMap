using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Entity.Models;
using Microsoft.Extensions.Logging;

namespace BookStore.Business.Services.Abstracts
{
    public interface ILogService : ILogger
    {
        Task Log(Log model);
        Task<IEnumerable<Log>> Get();

        Task LogError(ErrorLog model);

        Task<IEnumerable<ErrorLog>> GetErrorLogs();
    }
}