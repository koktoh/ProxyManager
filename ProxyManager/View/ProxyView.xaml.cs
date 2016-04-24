using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProxyManager.Model;
using System.IO;
using System.Diagnostics;

namespace ProxyManager.View
{
	/// <summary>
	/// ProxyView.xaml の相互作用ロジック
	/// </summary>
	public partial class ProxyView : UserControl
	{
		private ConfigData data;

		public ConfigData Data
		{
			get
			{
				return data;
			}

			set
			{
				if (value == null) return;

				data = value;

				Name.Text = data.Name;
				Device.Text = data.Device;
				GUID.Text = data.GUID;
				Proxy.Text = data.Proxy;
				Port.Text = data.Port;
				User.Text = data.AuthName;
				Password.Text = data.AuthPassword;
			}
		}

		public ProxyView()
		{
			InitializeComponent();
		}
	}
}
