#load "entities.csx"

// Build the chain of responsibility
Logger logger = new ConsoleLogger(LogLevel.All)
                 .SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError))
                 .SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));

// Handled by ConsoleLogger
logger.Message("Entering function ProcessOrder().", LogLevel.Debug);
logger.Message("Order record retrieved.", LogLevel.Info);

WriteLine();

// Handled by ConsoleLogger and FileLogger
logger.Message("Customer Address details missing in Branch DataBase.", LogLevel.Warning);
logger.Message("Customer Address details missing in Organization DataBase.", LogLevel.Error);

WriteLine();

// Handled by ConsoleLogger and EmailLogger
logger.Message("Unable to Process Order ORD1 Dated D1 For Customer C1.", LogLevel.FunctionalError);
logger.Message("Order Dispatched.", LogLevel.FunctionalMessage);
