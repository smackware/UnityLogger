using UnityEngine;
using System.Collections;

namespace Smackware.Logging
{
	public static class MonoBehaviourExtensions
	{
		public static string GetLoggerName(this MonoBehaviour monoBehaviour)
		{
			return monoBehaviour.GetType().Name;
		}

		public static SubLogger GetLogger(this MonoBehaviour monoBehaviour)
		{
			var loggerName = GetLoggerName(monoBehaviour);
			return Logger.GetLogger(loggerName);
		}
	}
}