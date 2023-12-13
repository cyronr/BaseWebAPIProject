namespace Application.Common;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    TimeSpan DateDiffrence(DateTime from, DateTime to);
}
