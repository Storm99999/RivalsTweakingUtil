using RivalsTweakingUti.Properties;
using System.IO.Compression;

namespace RivalsTweakingUti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "White Textures")
            {
                pictureBox1.Image = Resources.hjgjhg;
            }

            if (comboBox1.Text == "Dark Textures")
            {
                pictureBox1.Image = Resources.Screenshot_2025_01_11_142231;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("README.txt"))
            {
                File.Delete(Application.StartupPath + "\\README.txt");
                MessageBox.Show("Greetings, {Environment.UserName}. Make sure every time you launch RTU your roblox is FULLY closed. \nIssues and complains can be boasted about on storm99999.github.io/invite.html \nMay god bless newguy & the celeste team for creating this utility :pray: ", "Celeste Softworks", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            client.onload(); // meh
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "White Textures")
            {
                string zipPath = Path.Combine(Application.StartupPath, "dependencies");
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    Directory.Delete(client.GetRobloxDirectory() + "\\PlatformContent", true);
                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    Directory.Delete(client.GetRobloxVersion() + "\\PlatformContent", true);
                }
                string extractPath = null;
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    extractPath = client.GetRobloxDirectory();
                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    extractPath = client.GetRobloxVersion();
                }

                try
                {
                    MessageBox.Show("Installing", "@celeste softworks - r32", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    try
                    {
                        ZipFile.ExtractToDirectory(zipPath + "\\PC_w.zip", extractPath);
                        MessageBox.Show("Installation complete.", "@celeste softworks - r32", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (InvalidDataException)
                    {
                        MessageBox.Show("The downloaded file is not a valid ZIP archive.", "@celeste softworks - r32", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "@celeste softworks - r32", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (comboBox1.Text == "Dark Textures")
            {
                string zipPath = Path.Combine(Application.StartupPath, "dependencies");
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    Directory.Delete(client.GetRobloxDirectory() + "\\PlatformContent", true);
                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    Directory.Delete(client.GetRobloxVersion() + "\\PlatformContent", true);
                }
                string extractPath = null;
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    extractPath = client.GetRobloxDirectory();
                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    extractPath = client.GetRobloxVersion();
                }

                try
                {
                    MessageBox.Show("Installing", "@celeste softworks - r32", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    try
                    {
                        ZipFile.ExtractToDirectory(zipPath + "\\PC.zip", extractPath);
                        MessageBox.Show("Installation complete.", "celeste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (InvalidDataException)
                    {
                        MessageBox.Show("The downloaded file is not a valid ZIP archive.", "@celeste softworks - r32", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "@celeste softworks - r32", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (comboBox1.Text == "+u NoTexturePerformance")
            {
                pictureBox1.Image = Resources.haaa;
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    File.WriteAllText(client.GetRobloxDirectory() + "\\ClientSettings\\ClientAppSettings.json", File.ReadAllText(Application.StartupPath + "\\dependencies\\NoTexturePerformance.json"));
                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    File.WriteAllText(client.GetRobloxVersion() + "\\ClientSettings\\ClientAppSettings.json", File.ReadAllText(Application.StartupPath + "\\dependencies\\NoTexturePerformance.json"));
                }
            }

            if (comboBox1.Text == "Performance FFlags")
            {
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    File.WriteAllText(client.GetRobloxDirectory() + "\\ClientSettings\\ClientAppSettings.json", File.ReadAllText(Application.StartupPath + "\\dependencies\\Performance.json"));
                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    File.WriteAllText(client.GetRobloxVersion() + "\\ClientSettings\\ClientAppSettings.json", File.ReadAllText(Application.StartupPath + "\\dependencies\\Performance.json"));
                }
            }


            if (comboBox1.Text == "NoAnimation")
            {
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    client.AddFFlag("FFlagProcessAnimationLooped", "false");
                    client.AddFFlag("FFlagReplicateAnimationLooped", "false");

                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    client.AddFFlag("FFlagProcessAnimationLooped", "false");
                    client.AddFFlag("FFlagReplicateAnimationLooped", "false");
                }
            }

            if (comboBox1.Text == "GPUPriority")
            {
                if (client.GetRobloxClientName() == "Bloxstrap")
                {
                    client.GraphicsPerformance(client.GetRobloxVersion() + "\\RobloxPlayerBeta.exe", 2);


                }

                if (client.GetRobloxClientName() == "Roblox")
                {
                    client.GraphicsPerformance(client.GetRobloxVersion() + "\\RobloxPlayerBeta.exe", 2);

                }
            }
        }
    }
}