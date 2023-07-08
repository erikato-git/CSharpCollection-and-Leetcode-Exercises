namespace Performant_Logging
{
    public static partial class Log
    {
        [LoggerMessage(20, LogLevel.Information, "Weather forecast requested at {date}")]
        public static partial void WeatherForecastRequested(this ILogger logger, DateTime date);

    }
}
