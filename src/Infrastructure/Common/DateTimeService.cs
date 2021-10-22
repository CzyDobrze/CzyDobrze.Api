using System;
using CzyDobrze.Application.Common.Interfaces;

namespace CzyDobrze.Infrastructure.Common
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow;
    }
}