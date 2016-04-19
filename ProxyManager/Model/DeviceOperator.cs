using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Management;

namespace ProxyManager.Model
{
	static class DeviceOperator
	{
		public static List<ManagementObject> ListUpDevices()
		{
			var adapterList = new List<ManagementObject>();

			try
			{
				ObjectQuery oq = new ObjectQuery("select * from Win32_NetworkAdapter Where NetConnectionID IS NOT NULL");
				ManagementObjectSearcher mos = new ManagementObjectSearcher(oq);
				foreach (ManagementObject mo in mos.Get())
				{
					adapterList.Add(mo);
				}
			}
			catch (Exception)
			{
				throw;
			}

			return adapterList;
		}
	}
}
