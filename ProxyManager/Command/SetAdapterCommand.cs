using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProxyManager.ViewModel;
using System.IO;
using System.Diagnostics;

namespace ProxyManager.Command
{
	public class SetAdapterCommand : ICommand
	{
		private ProxyViewModel proxyViewModel;

		public event EventHandler CanExecuteChanged;

		public SetAdapterCommand(ProxyViewModel viewModel)
		{
			proxyViewModel = viewModel;

			proxyViewModel.PropertyChanged += (sender, e) =>
			  {
				  if (CanExecuteChanged != null)
				  {
					  CanExecuteChanged(sender, e);
				  }
			  };
		}

		public bool CanExecute(object parameter)
		{
			return proxyViewModel.CanExcute;
		}

		public void Execute(object parameter)
		{
			var fileName = Path.Combine(Environment.CurrentDirectory, "DeviceManager.exe");

			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException();
			}

			var psi = new ProcessStartInfo();

			psi.FileName = fileName;
			psi.Arguments = string.Concat("\"", proxyViewModel.Device, "\"");

			try
			{
				var p = Process.Start(psi);
				p.WaitForExit();
			}
			catch
			{
				throw;
			}
		}
	}
}
