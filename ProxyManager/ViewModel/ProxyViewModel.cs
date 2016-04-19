using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProxyManager.Model;
using ProxyManager.Command;
using ProxyManager.View;

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
		private string _guid;

		private ConfigData _data = new ConfigData();

		public ConfigData Data
		{
			set
			{
				if (value == null) return;

				_data = value;

				this.Name = _data.Name;
				this.Device = _data.Device;
				this.GUID = _data.GUID;
				this.Proxy = _data.Proxy;
				this.Port = _data.Port;
				this.AuthName = _data.AuthName;
				this.AuthPassword = _data.AuthPassword;
			}
		}

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
				_authPassword = value;
				RaisePropertyChanged("AuthPassword");
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

		public string GUID
		{
			get
			{
				return _guid;
			}

			set
			{
				_guid = value;
			}
		}

		private bool canExcute = false;
		public bool CanExcute
		{
			get
			{
				return canExcute;
			}
		}

		private SetAdapterCommand excute;

		public SetAdapterCommand ExcuteCommand
		{
			get
			{
				return excute ?? (excute = new SetAdapterCommand(this));
			}
		}

		public ProxyViewModel() { }

		public ProxyViewModel(ConfigData cd)
		{
			Data = cd;
		}

		protected virtual void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}

			if (propertyName == "Device")
			{
				var device = DeviceOperator.ListUpDevices().Where(x => string.Equals(x.Properties["Name"].Value, this.Device)).First();
				canExcute = !(bool)device.Properties["NetEnabled"].Value;
			}
		}
	}
}
