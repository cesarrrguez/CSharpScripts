// ISP (Interface Segregation Principle)
// ------------------------------------------------------------------------------
// Many client-specific interfaces are better than one general-purpose interface.
// ------------------------------------------------------------------------------

#load "no.csx"
#load "yes.csx"

// No
var allInOnePrinter = new AllInOnePrinter();
allInOnePrinter.Print();

var economicPrinter = new EconomicPrinter();
economicPrinter.Print();

// Yes
var allInOnePrinter_ISP = new AllInOnePrinter_ISP();
allInOnePrinter_ISP.Print();

var economicPrinter_ISP = new EconomicPrinter_ISP();
economicPrinter_ISP.Print();
