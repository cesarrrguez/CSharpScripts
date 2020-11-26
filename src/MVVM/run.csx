#load "viewModels.csx"

using System.ComponentModel;

var vm = new MainViewModel();

if (vm.CanExecuteRun())
    vm.ExecuteRun();

var args = new CancelEventArgs();
if (vm.CanExecuteClose(args))
    vm.ExecuteClose(args);
