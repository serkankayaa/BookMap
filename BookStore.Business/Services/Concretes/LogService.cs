using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Business.Services.Abstracts;
using BookStore.Entity.Context;
using BookStore.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookStore.Business.Services.Concretes
{
    public class LogService : ILogService
    {
        private readonly BookDbContext _context;

        public LogService(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Log>> Get()
        {
            var items = _context.Log.OrderByDescending(x => x.RequestTime).ToListAsync();
            return await items;
        }

        public async Task Log(Log model)
        {
            _context.Log.Add(model);
            await _context.SaveChangesAsync();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            throw new NotImplementedException();
        }

        public async Task LogError(ErrorLog model)
        {
            _context.ErrorLog.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ErrorLog>> GetErrorLogs()
        {
            var items = _context.ErrorLog.OrderByDescending(x => x.ErrorTime).ToListAsync();
            return await items;
        }
    }
}