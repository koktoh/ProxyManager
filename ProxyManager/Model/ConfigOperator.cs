using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ProxyManager.Model
{
	public class ConfigOperator
	{
		private string _savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProxyManager");
		private string _configFile;

		private List<ConfigData> _configDataList = new List<ConfigData>();

		public List<ConfigData> ConfigDataList { get; set; }

		public ConfigOperator()
		{
			if (!Directory.Exists(_savePath))
			{
				Directory.CreateDirectory(_savePath);
			}

			_configFile = Path.Combine(_savePath, "config.json");
		}

		public void SaveConfig()
		{
			using (var sw = new StreamWriter(_configFile, false))
			{
				sw.Write(JsonConvert.SerializeObject(ConfigDataList));
			}
		}

		public void LoadConfig()
		{
			using (var sr = new StreamReader(_configFile))
			{
				ConfigDataList = JsonConvert.DeserializeObject<List<ConfigData>>(sr.ReadToEnd());
			}
		}
	}
}
