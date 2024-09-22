using System;
using System.Management;

namespace OperatingSystemInfoApp
{
    internal static class Program
    {
        // This variable will hold the last boot-up time.
        public static DateTime LastBootUpTime { get; private set; }

        // The method to get the OS info
        private static void GetOperatingSystemInfo(string name, string userName, string password)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            ManagementScope scope;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var options = new ConnectionOptions
                {
                    Username = userName,
                    Password = password
                };
                scope = new ManagementScope("\\\\" + name + "\\root\\cimv2", options);
            }
            else
            {
                scope = new ManagementScope("\\\\" + name + "\\root\\cimv2");
            }
            scope.Connect();
            var query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            using (var searcher = new ManagementObjectSearcher(scope, query))
            {
                using (var collection = searcher.Get())
                {
                    foreach (var o in collection)
                    {
                        var tempNetworkAdapter = (ManagementObject)o;
                        if (tempNetworkAdapter.Properties["LastBootUpTime"].Value != null)
                        {
                            LastBootUpTime = ManagementDateTimeConverter.ToDateTime(tempNetworkAdapter.Properties["LastBootUpTime"].Value.ToString());
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            // Example usage of the method
            try
            {
                Program.GetOperatingSystemInfo("localhost", null, null); // Use appropriate machine name and credentials
                Console.WriteLine("Last Boot Up Time: " + LastBootUpTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
