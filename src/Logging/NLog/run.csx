#load "../../../packages.csx"

using NLog;
using NLog.Config;
using NLog.Targets;

var consoleTarget = new ConsoleTarget("console");
consoleTarget.Layout = "${longdate} ${level:uppercase=true} - ${message} ${exception:format=ToString}";

var config = new LoggingConfiguration();
config.AddTarget(consoleTarget);
config.AddRuleForAllLevels(consoleTarget);

LogManager.Configuration = config;

var logger = LogManager.GetCurrentClassLogger();

logger.Trace("This is a trace message");
logger.Debug("This is a debug message");
logger.Info("This is an information message");
logger.Warn("This is a warning message");
logger.Error("This is an error message");
logger.Fatal("This is a fatal message");
