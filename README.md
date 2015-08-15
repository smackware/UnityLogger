# UnityLogger
A simple python-like logger for Unity

Example:
```
using UnityEngine;
using Smackware.Logging;

public class LoggerExample : MonoBehaviour 
{
    // Accessing this MonoBehaviour's logger using the extensions
    private void Start()
    {
        // Using the logger of this specific monobehaviour. Log output will be prefixed by "LoggerExample"
        this.GetLogger().Level = LogLevel.Debug;

        // Outputs: "LoggerExample: Info: Starting logger for LoggerExample"
        this.GetLogger().Info("Starting logger for {0}!", this.GetType().Name);

        // Outputs: "LoggerExample: Warn: This goes the the same logger as the previous line"
        Logger.GetLogger("LoggerExample").Warn("This goes the the same logger as the previous line");
        this.DoSomething1();
    }

    // Accessing Loggers from anywhere, regardless of MonoBehaviours
    public static void DoSomething()
    {
        // Outputs: "Main: Info: this goes to the main logger!"
        Logger.Info ("This goes to the main logger");

        // --- Accessing other loggers: ---
        // This logger will only log errors
        Logger.GetLogger("AnotherLogger").Level = LogLevel.Error; 

        // Outputs: "AnotherLogger: Error: This goes to another logger!"
        Logger.GetLogger("AnotherLogger").Error("This goes to another logger");

        // Outputs nothing, the log level is not high enough
        Logger.GetLogger("AnotherLogger").Debug("This won't be logged because this logger's minimum level is Error");
    }

    public void DoSomething1()
    {
        // Outputs: "LoggerExample: Debug: Doing something!"
        this.GetLogger().Debug("Doing something!");
    }
}
```
