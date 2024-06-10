namespace API.Minimal.Utilities
{
    public class LoggerService
    {
        private readonly ILogger _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }
        public void Error(string msg)
        {
            _logger.LogError(msg);
        }
        public void Warning(string msg)
        {
            _logger.LogWarning(msg);
        }
        public void Info(string msg)
        {
            _logger.LogInformation(msg);
        }

    }
}
