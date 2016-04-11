using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ProxyManager.Model
{
	[StructLayout(LayoutKind.Sequential)]
	public struct SP_DEVICE_INTERFACE_DATA
	{
		public int cbSize;
		public Guid InterfaceClassGuid;
		public uint Flags;
		public IntPtr Reserved;
	}

	class DeviceOperater
	{
		public const int DIGCF_PROFILE = 0x00000008;
		public const int DIGCF_DEVICEINTERFACE = 0x00000010;
		public const int INVALID_HADLE_VALUE = -1;

		[DllImport(@"hid.dll", SetLastError = true)]
		public static extern void HidD_GetHidGuid(ref Guid HidGuid);

		[DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, int Enummerator, IntPtr hwndParent, UInt32 Flags);

		[DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern Boolean SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, UInt32 memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

		public void GetDevices()
		{
			Guid guid = new Guid();

			DeviceOperater.HidD_GetHidGuid(ref guid);

			IntPtr hDevInfo = SetupDiGetClassDevs(ref guid, 0, IntPtr.Zero, DIGCF_PROFILE | DIGCF_DEVICEINTERFACE);

			if(hDevInfo.ToInt32()!=INVALID_HADLE_VALUE)
			{
				bool success = true;
				uint i = 0;

				while (success)
				{
					SP_DEVICE_INTERFACE_DATA dia = new SP_DEVICE_INTERFACE_DATA();
					dia.cbSize = Marshal.SizeOf(dia);

					success = SetupDiEnumDeviceInterfaces(hDevInfo, IntPtr.Zero, ref guid, i, ref dia);

					Console.WriteLine("SetupDiEnumDeviceInterfaces Saccess:"+success.ToString());

					if(success)
					{

					}
				}
			}
		}
	}
}
