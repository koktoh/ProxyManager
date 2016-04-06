using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProxyManager.ViewModel
{
	public class ProxyViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _name;
		private string _device;
		private string _proxy;
		private string _port;
		private string _authName;
		private string _authPassword;

		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
				RaisePropertyChanged("Name");
			}
		}

		public string Device
		{
			get
			{
				return _device;
			}

			set
			{
				_device = value;
				RaisePropertyChanged("Device");
			}
		}

		public string Proxy
		{
			get
			{
				return _proxy;
			}

			set
			{
				_proxy = value;
				RaisePropertyChanged("Proxy");
			}
		}

		public string Port
		{
			get
			{
				return _port;
			}

			set
			{
				_port = value;
				RaisePropertyChanged("Port");
			}
		}

		public string AuthName
		{
			get
			{
				return _authName;
			}

			set
			{
				_authName = value;
				RaisePropertyChanged("AuthName");
			}
		}

		public string AuthPassword
		{
			get
			{
				return _authPassword;
			}

			set
			{
				var str = new string('*', value.Length);
				_authPassword = str;
				RaisePropertyChanged("AuthPassword");
			}
		}



		protected virtual void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
