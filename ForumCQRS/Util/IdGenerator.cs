using System;

namespace Forum.CQRS.Util
{
    public interface IIdGenerator
    {
        string CreateNew();
    }

    public class IdGenerator
    {
        public static string CreateNew() {
            var defaultGenerator = new DateTimeIdGenerator();
            return defaultGenerator.CreateNew();
        }
    }

    public class DateTimeIdGenerator : IIdGenerator
    {
        public string CreateNew() {
            DateTime now = DateTime.Now;
            int sequence = (int)(now.Ticks % 10000);
            string id = string.Format("{0}{1}{2}{3}{4}{5}{6}", now.Year, now.Month.ToString().PadLeft(2, '0'),
                                      now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                                      now.Minute.ToString().PadLeft(2, '0'),
                                      now.Second.ToString().PadLeft(2, '0'), sequence.ToString().PadLeft(5, '0'));
            return id;
        }
    }
}
