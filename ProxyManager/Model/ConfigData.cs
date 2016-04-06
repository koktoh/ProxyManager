﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyManager.Model
{
	public class ConfigData
	{
		public string Name { get; set; }
		public string Device { get; set; }
		public string HostName { get; set; }
		public string HostPassword { get; set; }
		public string Proxy { get; set; }
		public string Port { get; set; }
		public string AuthName { get; set; }
		public string AuthPassword { get; set; }
	}
}
