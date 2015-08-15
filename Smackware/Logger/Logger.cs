using System;
using System.Collections.Generic;



namespace Smackware.Logging
{ 
    public enum LogLevel
    {                                
        Error,
        Warn,
        Info,
        Debug,
    }

	public class SubLogger
	{
		public readonly string Name;
		public LogLevel Level = LogLevel.Debug;

		public SubLogger(string name)
		{
			Name = name;
		}

		private void _log(Action<string> logFunc, LogLevel level, string text, params object[] values)
		{
			if (Level >= level)
			{
				logFunc(Name + ": " + level.ToString() + ": " + String.Format(text, values));
			}
		}

		public void Log(LogLevel level, string text, params object[] values)
		{
			_log(UnityEngine.Debug.Log, level, text, values);
		}

		public void Debug(string text, params object[] values)
		{
			Log(LogLevel.Debug, text, values);
		}
		
		public void Info(string text, params object[] values)
		{
			Log(LogLevel.Info, text, values);
		}

		public void Warn(string text, params object[] values)
		{
			Log(LogLevel.Warn, text, values);
		}

		public void Error(string text, params object[] values)
		{
			Log(LogLevel.Error, text, values);
		}
	}

	/// <summary>
	/// Singleton that manages loggers.
	/// </summary>
    public static class Logger
	{
		public static LogLevel DefaultLogLevel = LogLevel.Debug;

		public static Dictionary<string, SubLogger> _loggerIndex = new Dictionary<string, SubLogger>();

		/// <summary>
		/// Get a logger with a specific name, if the logger doesn't exist it will be automagically created with 
		/// a LogLevel of Logger.DefaultLogLevel
		/// </summary>
		/// <param name="name">Name of the logger</param>
		public static SubLogger GetLogger(string name)
		{
			SubLogger logger;
			if (!_loggerIndex.TryGetValue(name, out logger))
			{
				logger = new SubLogger(name);
				logger.Level = DefaultLogLevel;
				_loggerIndex[name] = logger;
			}
			return logger;
		}

		/// <summary>
		/// Sets the DefaultLogLevel and the log level for all existing loggers 
		/// </summary>
		/// <param name="level">LogLevel</param>
		public static void SetLogLevelForAllLoggers(LogLevel level)
		{
			DefaultLogLevel = level;
			foreach (SubLogger logger in _loggerIndex.Values)
			{
				logger.Level = level;
			}
		}

		/// <summary>
		/// Log a debug to the Main logger
		/// </summary>
		/// <param name="text">String.Format template</param>
		/// <param name="values">String.Format params</param>
		public static void Debug(string text, params object[] values)
		{
			Logger.GetLogger("Main").Debug(text, values);
		}

		/// <summary>
		/// Log an info to the Main logger
		/// </summary>
		/// <param name="text">String.Format template</param>
		/// <param name="values">String.Format params</param>
		public static void Info(string text, params object[] values)
		{
			Logger.GetLogger("Main").Info(text, values);
		}

		/// <summary>
		/// Log a warning to the Main logger
		/// </summary>
		/// <param name="text">String.Format template</param>
		/// <param name="values">String.Format params</param>
		public static void Warn(string text, params object[] values)
		{
			Logger.GetLogger("Main").Warn(text, values);
		}

		/// <summary>
		/// Log an error to the Main logger
		/// </summary>
		/// <param name="text">String.Format template</param>
		/// <param name="values">String.Format params</param>
		public static void Error(string text, params object[] values)
		{
			Logger.GetLogger("Main").Error(text, values);
		}
    }

}