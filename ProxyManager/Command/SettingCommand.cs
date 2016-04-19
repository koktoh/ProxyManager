using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProxyManager.Model;
using ProxyManager.ViewModel;

namespace ProxyManager.Command
{
	class SettingCommand : ICommand
	{
		private MainViewModel mainViewModel;

		public event EventHandler CanExecuteChanged;

		public SettingCommand(MainViewModel model)
		{
			mainViewModel = model;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

		}
	}
}
