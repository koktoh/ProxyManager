using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ProxyManager.Model
{
	public static class ProxyOperator
	{
		static ProxyOperator() { }

		public static void SetProxy(ConfigData data)
		{
			WebProxy proxy = null;

			if (!string.IsNullOrWhiteSpace(data.Proxy))
			{
				proxy = new WebProxy(data.Proxy);

				if (!string.IsNullOrWhiteSpace(data.AuthName))
				{
					proxy.Credentials = new NetworkCredential(data.AuthName, data.AuthPassword);
				}
			}

			WebRequest.DefaultWebProxy = proxy;
		}
	}
}
