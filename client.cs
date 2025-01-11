using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RivalsTweakingUti
{
    internal class client
    {
        public static void UnRar(string SRC, string DEST)
        {
            ZipFile.ExtractToDirectory(SRC, DEST);
        }

        public static string GetRobloxDirectory()
        {
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string bloxstrapPath = Path.Combine(localAppDataPath, "Bloxstrap");

            if (Directory.Exists(bloxstrapPath))
            {
                return Path.Combine(bloxstrapPath, "Modifications");
            }

            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Versions\\";
        }



        public static string GetRobloxClientName()
        {
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string bloxstrapPath = Path.Combine(localAppDataPath, "Bloxstrap");

            if (Directory.Exists(bloxstrapPath))
            {
                return "Bloxstrap";
            }

            return "Roblox";
        }

        public static string GetRobloxVersion()
        {
            foreach (var flds in Directory.GetDirectories(GetRobloxDirectory()))
            {
                // most likely wont happen, but just to make sure. 
                var i = new DirectoryInfo(flds);
                if (i.GetFiles().Length == 0 || i.GetDirectories().Length == 0)
                {
                }

                if (i.GetFiles().Length != 0)
                {
                    // Checks for builtinplugins, it's a folder, when that roblox ver is outdated
                    foreach (var fe in Directory.GetFiles(i.FullName))
                    {
                        var fileInfo1 = new FileInfo(fe);
                        if (Directory.Exists(i.FullName + "BuiltInPlugins"))
                        {
                        }
                    }
                }

                if (File.Exists(i.FullName + "\\RobloxPlayerBeta.exe"))
                {
                    return i.FullName;
                }
            }

            return null;
        }

        public static void AddFFlag(string fflag, string value)
        {
            if (GetRobloxClientName() == "Roblox")
            {
                if (!Directory.Exists(GetRobloxVersion() + "\\ClientSettings"))
                {
                    Directory.CreateDirectory(GetRobloxVersion() + "\\ClientSettings");
                    File.WriteAllText(GetRobloxVersion() + "\\ClientSettings\\ClientAppSettings.json", "");
                }

                string jsonContent = File.ReadAllText(GetRobloxVersion() + "\\ClientSettings\\ClientAppSettings.json");
                JObject jsonObject = JObject.Parse(jsonContent);

                jsonObject[fflag] = value;

                string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(GetRobloxVersion() + "\\ClientSettings\\ClientAppSettings.json", updatedJsonContent);
            }

            if (GetRobloxClientName() == "Bloxstrap")
            {

                string jsonContent = File.ReadAllText(GetRobloxDirectory() + "\\ClientSettings\\ClientAppSettings.json");
                JObject jsonObject = JObject.Parse(jsonContent);

                jsonObject[fflag] = value;

                string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(GetRobloxDirectory() + "\\ClientSettings\\ClientAppSettings.json", updatedJsonContent);
            }
        }

        public static void GraphicsPerformance(string exePath, int gpuPreference)
        {
            try
            {
                // Registry key path, this should work tho
                string registryPath = @"Software\Microsoft\DirectX\UserGpuPreferences";
                string exeName = System.IO.Path.GetFileName(exePath);

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true))
                {
                    if (key == null)
                    {
                    }

                    string value = $"AutoHDREnable=1;GpuPreference={gpuPreference};";

                    key.SetValue(exePath, value, RegistryValueKind.String);

                    MessageBox.Show("Roblox has been set to GPUPriority 2 - High performance", "Celeste Softworks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void RemoveFFlag(string propertyKey)
        {
            string filePathr = GetRobloxVersion() + "\\ClientSettings\\ClientAppSettings.json";
            string filePath = GetRobloxDirectory() + "\\ClientSettings\\ClientAppSettings.json";

            if (GetRobloxClientName() == "Roblox")
            {
                if (!Directory.Exists(GetRobloxVersion() + "\\ClientSettings"))
                {
                    Directory.CreateDirectory(GetRobloxVersion() + "\\ClientSettings");
                }

                string jsonContent = File.ReadAllText(filePathr);
                JObject jsonObject = JObject.Parse(jsonContent);

                if (jsonObject.ContainsKey(propertyKey))
                {
                    jsonObject.Property(propertyKey).Remove();

                    string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);

                    File.WriteAllText(filePathr, updatedJsonContent);

                }
                else
                {
                }
            }

            if (GetRobloxClientName() == "Bloxstrap")
            {

                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);

                if (jsonObject.ContainsKey(propertyKey))
                {
                    jsonObject.Property(propertyKey).Remove();

                    string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);

                    File.WriteAllText(filePath, updatedJsonContent);

                }
                else
                {
                }
            }

        }

        public static void onload()
        {
            if (GetRobloxClientName() == "Bloxstrap")
            {
                if (!Directory.Exists(GetRobloxVersion() + "\\ClientSettings"))
                {
                    Directory.CreateDirectory(GetRobloxVersion() + "\\ClientSettings");
                }
            }

            if (GetRobloxClientName() == "Roblox")
            {
                Directory.CreateDirectory(GetRobloxVersion() + "\\ClientSettings");
                File.WriteAllText(GetRobloxVersion() + "\\ClientSettings\\ClientAppSettings.json", "");


            }

        }
    }
}
