using System.DirectoryServices;

namespace Mysoft.Common.Utility
{
    using Microsoft.Win32;
    using System;
    using System.Management;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Security;

    public class OSHelper
    {
        #region 来自.NET4.5的判断

        [SecurityCritical]
        internal static bool DoesWin32MethodExist(string moduleName, string methodName)
        {
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            if (moduleHandle == IntPtr.Zero)
            {
                return false;
            }
            return (GetProcAddress(moduleHandle, methodName) != IntPtr.Zero);
        }

        [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        internal static extern IntPtr GetCurrentProcess();

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        internal static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32.dll", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string methodName);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool IsWow64Process([In] IntPtr hSourceProcessHandle, [MarshalAs(UnmanagedType.Bool)] out bool isWow64);

        public static bool Is64BitOperatingSystem
        {
            [SecuritySafeCritical]
            get
            {
                bool flag;
                return ((DoesWin32MethodExist("kernel32.dll", "IsWow64Process") && IsWow64Process(GetCurrentProcess(), out flag)) && flag);
            }
        }

        #endregion 

        public static string GetRegKey(string fullKeyName, string valueName)
        {
            return Registry.GetValue(fullKeyName, valueName, "").ToString();
        }

        /// <summary>
        /// 是否64位操作系统，编译方式不能用32位
        /// </summary>
        /// <returns></returns>
        public static bool Is64Bit()
        {
            return (IntPtr.Size == 8);
        }

        /// <summary>
        /// 判断是否64操作系统，有权限问题，且速度较慢
        /// </summary>
        /// <returns></returns>
        public static bool Is64OS()
        {
            ConnectionOptions options = new ConnectionOptions();
            ManagementScope scope = new ManagementScope(@"\\localhost", options);
            ObjectQuery query = new ObjectQuery("select AddressWidth from Win32_Processor");
            ManagementObjectCollection objects = new ManagementObjectSearcher(scope, query).Get();
            string str = null;
            foreach (ManagementObject obj2 in objects)
            {
                str = obj2["AddressWidth"].ToString();
            }
            return !string.IsNullOrEmpty(str) && str.Equals("64");
        }
    }
}

