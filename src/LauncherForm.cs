
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UltiLaunch2
{
    public partial class LauncherForm : Form
    {
        readonly string[] args;
        readonly Ultimate ult = new();

        string currentDir;
        FileSystemWatcher watcher;

        public LauncherForm(string[] args)
        {
            this.args = args;
            InitializeComponent();
        }

        void CheckError(Action thing, string msg)
        {
            try
            {
                thing();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{msg}: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void OnPath(string path)
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), path);

            if (Directory.Exists(path))
                tbDirectory.Text = path;
            else
            {
                var dir = Path.GetDirectoryName(path);
                if (Directory.Exists(dir))
                    tbDirectory.Text = dir;
            }

            if (File.Exists(path))
                CheckError(() => ult.Mount(path, true), "Can't run");
        }

        void UpdateHostLabel()
        {
            if (String.IsNullOrEmpty(ult.hostName))
                lHostname.Text = "Host name not configured";
            else
                lHostname.Text = $"Using Ultimate @ {ult.hostName}:{ult.port}";
        }

        protected override void OnClosed(EventArgs e)
        {
            watcher?.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == COPYDATASTRUCT.WM_COPYDATA)
            {
                var data = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                if (data.dwData == (IntPtr)31337)
                {
                    OnPath(data.lpData);
                    this.Activate();
                }
                return;
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\UltiLaunch");
            ult.hostName = key.GetValue("Hostname") as string;
            UpdateHostLabel();
            if (String.IsNullOrEmpty(ult.hostName))
                bConfig_Click(sender, e);

            OnPath(args.Length > 0 ? args[0] : "");
        }

        private void bSelectDir_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbDirectory.Text = dialog.SelectedPath;
            }
        }

        private void bMount_Click(object sender, EventArgs e)
        {
            var item = lbFiles.SelectedItem as string;
            if (item != null)
                CheckError(() => ult.Mount(Path.Combine(currentDir, item), false), "Can't mount");
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            var item = lbFiles.SelectedItem as string;
            if (item != null)
                CheckError(() => ult.Mount(Path.Combine(currentDir, item), true), "Can't run");
        }

        private void tbDirectory_TextChanged(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            var dir = tbDirectory.Text;

            if (dir != currentDir)
            {
                watcher?.Dispose();
                watcher = null;
                currentDir = dir;
            }

            if (Directory.Exists(dir))
            {
                lbFiles.Items.AddRange(Directory.EnumerateFiles(dir)
                    .Where(fn => Ultimate.extensions.Contains(Path.GetExtension(fn).ToLowerInvariant()))
                    .Select(Path.GetFileName)
                    .OrderBy(fn => fn, StringComparer.OrdinalIgnoreCase)
                    .ToArray());

                if (watcher == null)
                {
                    watcher = new FileSystemWatcher(dir)
                    {
                        NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName,
                        EnableRaisingEvents = true
                    };

                    watcher.Created += (s, e) => BeginInvoke(() => tbDirectory_TextChanged(s, e));
                    watcher.Deleted += (s, e) => BeginInvoke(() => tbDirectory_TextChanged(s, e));
                    watcher.Renamed += (s, e) => BeginInvoke(() => tbDirectory_TextChanged(s, e));
                }
            }

            lbFiles_SelectedIndexChanged(sender, e);
        }

        private void bConfig_Click(object sender, EventArgs e)
        {
            var dlg = new SettingsDialog
            {
                Hostname = ult.hostName
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ult.hostName = dlg.Hostname;
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\UltiLaunch");
                key.SetValue("Hostname", ult.hostName);
                UpdateHostLabel();
            }

        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = lbFiles.SelectedItem as string;
            if (item != null && !String.IsNullOrEmpty(ult.hostName))
            {
                switch (Path.GetExtension(item.ToLowerInvariant()))
                {
                    case ".d64":
                        bMount.Text = "Mount";
                        bMount.Enabled = true;
                        bRun.Enabled = true;
                        break;
                    case ".prg":
                        bMount.Text = "DMA Load";
                        bMount.Enabled = true;
                        bRun.Enabled = true;
                        break;
                    case ".crt":
                        bMount.Enabled = false;
                        bRun.Enabled = true;
                        break;
                }
            }
            else
            {
                bMount.Enabled = false;
                bRun.Enabled = false;
            }
        }
    }
}