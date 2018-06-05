namespace ApplicationFramework.Logging
{
    public interface ILogger
    {
        void Info(object message);

        void Warning(object message);

        void Error(object message);
    }
}
