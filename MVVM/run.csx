// Model–view–viewmodel (MVVM)
// --------------------------------------------------------------
// Software architectural pattern that facilitates the separation 
// of the the view from the business logic (the model).
// --------------------------------------------------------------

#load "viewModels.csx"

using System.ComponentModel;

var vm = new MainViewModel();

if (vm.CanExecuteRun())
    vm.ExecuteRun();

var args = new CancelEventArgs();
if (vm.CanExecuteClose(args))
    vm.ExecuteClose(args);
