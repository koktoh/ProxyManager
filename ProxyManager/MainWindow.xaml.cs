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
using ProxyManager.View;
using ProxyManager.ViewModel;
using ProxyManager.Model;

namespace ProxyManager
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, EventArgs e)
		{
			var list = ConfigOperator.LoadConfig();

			if (list == null) return;	

			for (int i = 0; i < list.Count; i++)
			{
				var item = list[i];
				var view = new ProxyView();
				view.Data = item;
				view.SetValue(Grid.RowProperty, i);
				grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
				grid.Children.Add(view);
			}
		}
	}
}
