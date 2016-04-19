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
		public ConfigData Data
		{
			set
			{
				if (value == null) return;

				Name.Text = value.Name;
				Device.Text = value.Device;
				Proxy.Text = value.Proxy;
				Port.Text = value.Port;
				User.Text = value.AuthName;
				Password.Text = value.AuthPassword;
			}
		}

		public ProxyView()
		{
			InitializeComponent();
		}
	}
}
