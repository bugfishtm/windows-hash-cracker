using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Security.Policy;
using System.Media;
using System.Security.Principal;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Linq;
using System.Numerics;
using System.Reflection;
using hashcracker.Properties;
using System.Drawing;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

////////////////////////////////////////////////////////////
/// Main Namespace and Form
////////////////////////////////////////////////////////////
namespace hashcracker
{
    public partial class Interface : Form
    {
        ////////////////////////////////////////////////////////////
        /// Resizing/Moving (No Save, Not Related to Purpose)
        ////////////////////////////////////////////////////////////
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private Point offset;
        private int previousheight;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        // Debug Console
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        // Form Styling
        private int borderWidth = 5;
        private Color borderColor = Color.FromArgb(0x32, 0x32, 0x32);
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnClose;

        ////////////////////////////////////////////////////////////
        /// Software Version (Save)
        ////////////////////////////////////////////////////////////
        const string SF_VERSION_CR = "1.0";
        private CancellationTokenSource opcanceltoken;

        ////////////////////////////////////////////////////////////
        /// Interface Function
        ////////////////////////////////////////////////////////////
        public Interface()
        {
            ////////////////////////////////////////////////////////////
            /// Form Settings
            ////////////////////////////////////////////////////////////
            /// Enable Double Buffering (to prevent glitches on richtextboxes for example)
           // this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //this.UpdateStyles();
            /// Initialize Component
            InitializeComponent();
            /// Set Form Title
            this.Text = "Hash Cracker";
            Label_Version.Text = "Version: " + SF_VERSION_CR;
            // Setup Window Icon
            this.Icon = new Icon(new MemoryStream(Properties.Resources.favicon));
            // Form Style Adjustments
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderWidth);
            this.Padding = new Padding(5);
            this.Paint += new PaintEventHandler(CustomUI_Interface_Paint);
            this.Resize += CustomUI_Interface_Resize;
            this.FormClosing += CustomUI_FormClosing;
            // Init Top Buttons
            btnMinimize = new System.Windows.Forms.Button
            {
                Text = "_",
                Size = new Size(30, 30),
                Location = new Point(this.Width - 100, 0),
                BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF),
                FlatStyle = FlatStyle.Flat
            };
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.Click += CustomUI_BtnMinimize_Click;
            btnMinimize.ForeColor = Color.FromArgb(0x00, 0x00, 0x00);
            btnMinimize.BringToFront();
            tooltip_frame.SetToolTip(btnMinimize, "Minimize");
            btnMaximize = new System.Windows.Forms.Button
            {
                Text = "O",
                Size = new Size(30, 30),
                Location = new Point(this.Width - 70, 0),
                BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF),
                FlatStyle = FlatStyle.Flat
            };
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.Click += CustomUI_BtnMaximize_Click;
            btnMaximize.ForeColor = Color.FromArgb(0x00, 0x00, 0x00);
            btnMaximize.BringToFront();
            tooltip_frame.SetToolTip(btnMaximize, "Maximize");
            btnClose = new System.Windows.Forms.Button
            {
                Text = "X",
                Size = new Size(30, 30),
                Location = new Point(this.Width - 40, 0),
                BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF),
                FlatStyle = FlatStyle.Flat
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += CustomUI_BtnClose_Click;
            btnClose.ForeColor = Color.FromArgb(0x00, 0x00, 0x00);
            btnClose.BringToFront();
            tooltip_frame.SetToolTip(btnClose, "Close");
            Panel_Top.Controls.Add(btnMaximize);
            Panel_Top.Controls.Add(btnMinimize);
            Panel_Top.Controls.Add(btnClose);

            // List Columns
            listHistory.View = View.Details;
            listHistory.Columns.Add("Hash");
            listHistory.Columns.Add("Plaintext");
            listHistory.Columns.Add("Type");
            listHistory.Columns.Add("Status");
            listHistory.MouseClick += listView1_MouseClick;
            contextMenuStrip1.Click += copyToolStripMenuItem_Click;

            // Default Checked Buttons
            radioTypeEncode.Checked = true;
            radioMd5.Checked = true;
            labelStatus.Text = "Awaiting operation.";

            listHistory.MouseClick += listView1_MouseClick;
            // Init Interface
            functionsetinit();
        }

        ////////////////////////////////////////////////////////////
        /// Setup Interfaces Groups
        ////////////////////////////////////////////////////////////
        private void functionsetinit()
        {
            if (radioTypeEncode.Checked)
            {
                groupEncode.Visible = true;
                groupDecode.Visible = false;
                groupBChar.Visible = false;
            }
            else
            {
                groupEncode.Visible = false;
                groupDecode.Visible = true;
                groupBChar.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////
        // Hash Algorithm Enum
        ////////////////////////////////////////////////////////////
        public enum HashAlgorithm { MD5, SHA1, SHA256, SHA512, Bcrypt, PreMySQL, MySQLSHA }

        ////////////////////////////////////////////////////////////
        // Helper method to re-enable controls after operation
        ////////////////////////////////////////////////////////////
        private void EnableControls()
        {
            groupType.Enabled = true;
            groupHash.Enabled = true;
            groupEncode.Enabled = true;
            groupDecode.Enabled = true;

            checkboxCustom.AutoCheck = true;
            checkboxNumeric.AutoCheck = true;
            checkboxSmall.AutoCheck = true;
            checkBoxCapital.AutoCheck = true;

            checkboxCustomText.ReadOnly = false;
            textDecodeString.ReadOnly = false;

            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }
        private void DisableControls()
        {
            labelStatus.Text = "Decoding String...";
            groupType.Enabled = false;
            groupHash.Enabled = false;
            groupEncode.Enabled = false;
            groupDecode.Enabled = true;

            checkboxCustom.AutoCheck = false;
            checkboxNumeric.AutoCheck = false;
            checkboxSmall.AutoCheck = false;
            checkBoxCapital.AutoCheck = false;

            checkboxCustomText.ReadOnly = true;
            textDecodeString.ReadOnly = true;

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        ////////////////////////////////////////////////////////////
        // Bruteforce Functionalitites
        ////////////////////////////////////////////////////////////
        private async void button1_Click(object sender, EventArgs e)
        {
            // Disable relevant controls to prevent changes during operation
            DisableControls();

            // Build charset from selected checkboxes
            string charset = "";
            if (checkboxCustom.Checked)
            {
                charset += checkboxCustomText.Text;
            }
            if (checkboxNumeric.Checked)
            {
                charset += "0123456789";
            }
            if (checkboxSmall.Checked)
            {
                charset += "abcdefghijklmnopqrstuvwxyz";
            }
            if (checkBoxCapital.Checked)
            {
                charset += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if (string.IsNullOrEmpty(charset))
            {
                MessageBox.Show("Please select at least one character set.");
                EnableControls();
                return;
            }

            HashAlgorithm algorithm = HashAlgorithm.MD5;
            if (radioMd5.Checked)
            {
                algorithm = HashAlgorithm.MD5;
            }

            if (radioSHA1.Checked)
            {
                algorithm = HashAlgorithm.SHA1;
            }

            if (radioSHA256.Checked)
            {
                algorithm = HashAlgorithm.SHA256;
            }

            if (radioSHA512.Checked)
            {
                algorithm = HashAlgorithm.SHA512;
            }

            if (radioBcrypt.Checked)
            {
                algorithm = HashAlgorithm.Bcrypt;
            }

            if (radioPreMySQL.Checked)
            {
                algorithm = HashAlgorithm.PreMySQL;
            }

            if (radioMysqlSHA.Checked)
            {
                algorithm = HashAlgorithm.MySQLSHA;
            }

            // Get target hash from textbox
            string targetHash = textDecodeString.Text.Trim();
            if (string.IsNullOrEmpty(targetHash))
            {
                MessageBox.Show("Please enter a hash value.");
                EnableControls();
                return;
            }

            // Validate hash format for the selected algorithm
            if (!ValidateHashFormat(targetHash, algorithm))
            {
                MessageBox.Show("Invalid hash format for selected algorithm.");
                EnableControls();
                return;
            }

            // Prepare for cancellation
            opcanceltoken = new CancellationTokenSource();

            try
            {
                await BruteForceAsync(targetHash, charset, algorithm, opcanceltoken.Token);
            }
            catch (OperationCanceledException)
            {
                labelStatus.Text = "Operation canceled.";
            }
            finally
            {
                EnableControls();
            }
        }

        private IEnumerable<string> GetCombinations(string charset, int length)
        {
            if (length == 0)
            {
                yield return "";
                yield break;
            }
            foreach (var c in charset)
            {
                foreach (var suffix in GetCombinations(charset, length - 1))
                {
                    yield return c + suffix;
                }
            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            opcanceltoken?.Cancel();
        }

        private bool ValidateHashFormat(string hash, HashAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case HashAlgorithm.Bcrypt:
                    // Bcrypt hashes start with $2a$, $2b$, or $2y$
                    return hash.StartsWith("$2a$") || hash.StartsWith("$2b$") || hash.StartsWith("$2y$");
                case HashAlgorithm.PreMySQL:
                    return hash.Length == 16 && IsHex(hash);
                case HashAlgorithm.MySQLSHA:
                    return hash.Length == 40 && IsHex(hash);
                case HashAlgorithm.MD5:
                    return hash.Length == 32 && IsHex(hash);
                case HashAlgorithm.SHA1:
                    return hash.Length == 40 && IsHex(hash);
                case HashAlgorithm.SHA256:
                    return hash.Length == 64 && IsHex(hash);
                case HashAlgorithm.SHA512:
                    return hash.Length == 128 && IsHex(hash);
                default:
                    return false;
            }
        }

        private bool IsHex(string input)
        {
            return input.All(c => "0123456789abcdefABCDEF".Contains(c));
        }

        private int GetDefaultHashLength(HashAlgorithm algorithm)
        {
            return algorithm switch
            {
                HashAlgorithm.MD5 => 32,
                HashAlgorithm.SHA1 => 40,
                HashAlgorithm.SHA256 => 64,
                HashAlgorithm.SHA512 => 128,
                _ => 0
            };
        }

        private async Task BruteForceAsync(string targetHash, string charset, HashAlgorithm algorithm, CancellationToken token)
        {
            int maxLen = 128; // You can make this configurable
            var startTime = DateTime.Now;
            int attempts = 0;

            for (int length = 1; length <= maxLen; length++)
            {
                foreach (var candidate in GetCombinations(charset, length))
                {
                    token.ThrowIfCancellationRequested();
                    attempts++;

                    bool isMatch = false;
                    try
                    {
                        isMatch = algorithm switch
                        {
                            HashAlgorithm.Bcrypt => BCrypt.Net.BCrypt.Verify(candidate, targetHash),
                            HashAlgorithm.PreMySQL => OldMySQLPassword(candidate).Equals(targetHash, StringComparison.OrdinalIgnoreCase),
                            HashAlgorithm.MySQLSHA => NewMySQLPassword(candidate).Equals(targetHash, StringComparison.OrdinalIgnoreCase),
                            _ => ComputeHash(candidate, algorithm).Equals(targetHash, StringComparison.OrdinalIgnoreCase)
                        };
                    }
                    catch
                    {
                        // Optionally log or handle errors here
                    }

                    int attemcount = 1000;
                    if(radioBcrypt.Checked)
                    {
                        attemcount = 5;
                    } 

                    // Update UI every 1000 attempts
                    if (attempts % attemcount == 0)
                    {
                        Invoke(new Action(() =>
                        {
                            labelStatus.Text = $"Current Length: {length} - Attempts: {attempts} - Current: {candidate}";
                        }));
                        await Task.Delay(1); // Yield to UI thread
                    }

                    if (isMatch)
                    {
                        Invoke(new Action(() =>
                        {
                            labelStatus.Text = $"Found: {candidate} in {attempts} attempts, Duration: {(DateTime.Now - startTime).TotalSeconds:F2}s";
                            listHistory.Items.Add(new ListViewItem(new[] { targetHash, candidate, algorithm.ToString(), "Decrypted" }));
                            listHistory.SelectedItems.Clear();
                            int lastIndex = listHistory.Items.Count - 1;
                            listHistory.Items[lastIndex].Selected = true;
                            listHistory.Items[lastIndex].EnsureVisible();
                        }));
                        return;
                    }
                }
            }

            // Not found
            Invoke(new Action(() =>
            {
                labelStatus.Text = "No match found.";
                listHistory.Items.Add(new ListViewItem(new[] { targetHash, "", algorithm.ToString(), "Failed Attempt" }));
                listHistory.SelectedItems.Clear();
                int lastIndex = listHistory.Items.Count - 1;
                listHistory.Items[lastIndex].Selected = true;
                listHistory.Items[lastIndex].EnsureVisible();
            }));
        }

        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = algorithm switch
            {
                HashAlgorithm.MD5 => MD5.Create().ComputeHash(bytes),
                HashAlgorithm.SHA1 => SHA1.Create().ComputeHash(bytes),
                HashAlgorithm.SHA256 => SHA256.Create().ComputeHash(bytes),
                HashAlgorithm.SHA512 => SHA512.Create().ComputeHash(bytes),
                _ => throw new NotSupportedException()
            };
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        private string NewMySQLPassword(string password)
        {
            using SHA1 sha = SHA1.Create();
            byte[] firstHash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] secondHash = sha.ComputeHash(firstHash);
            return BitConverter.ToString(secondHash).Replace("-", "").ToLower();
        }

        //////////////////////////////////////////////////////////////////////////////////
        /// Encoding and Checkbox Change
        //////////////////////////////////////////////////////////////////////////////////
        private void radioTypeDecode_CheckedChanged(object sender, EventArgs e)
        {
            functionsetinit();
        }

        private void radioTypeEncode_CheckedChanged(object sender, EventArgs e)
        {
            functionsetinit();
        }

        private void radioMd5_CheckedChanged(object sender, EventArgs e)
        {

            functionsetinit();
        }

        private void radioSHA1_CheckedChanged(object sender, EventArgs e)
        {

            functionsetinit();
        }

        private void radioSHA256_CheckedChanged(object sender, EventArgs e)
        {

            functionsetinit();
        }

        private void radioSHA512_CheckedChanged(object sender, EventArgs e)
        {

            functionsetinit();
        }

        private void radioBcrypt_CheckedChanged(object sender, EventArgs e)
        {

            functionsetinit();
        }

        private void radioScrypt_CheckedChanged(object sender, EventArgs e)
        {

            functionsetinit();
        }

        private void radioArgon2_CheckedChanged(object sender, EventArgs e)
        {
            functionsetinit();
        }

        private void radioPbkdf2_CheckedChanged(object sender, EventArgs e)
        {
            functionsetinit();
        }

        private void radioPreMySQL_CheckedChanged(object sender, EventArgs e)
        {
            functionsetinit();
        }

        private void radioMysqlSHA_CheckedChanged(object sender, EventArgs e)
        {
            functionsetinit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string input = textEncodeString.Text;
            string output = "";
            string type = "";
            labelStatus.Text = "Encoding String...";
            groupType.Enabled = false;
            groupHash.Enabled = false;
            groupEncode.Enabled = false;
            groupDecode.Enabled = false;

            if (radioMd5.Checked)
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                    output = Convert.ToHexString(hash);
                }
                type = "MD5";
            }

            if (radioSHA1.Checked)
            {
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                    output = Convert.ToHexString(hash);
                }
                type = "SHA1";
            }

            if (radioSHA256.Checked)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                    output = Convert.ToHexString(hash);
                }
                type = "SHA256";
            }

            if (radioSHA512.Checked)
            {
                using (SHA512 sha512 = SHA512.Create())
                {
                    byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
                    output = Convert.ToHexString(hash);
                }
                type = "SHA512";
            }

            if (radioBcrypt.Checked)
            {
                output = BCrypt.Net.BCrypt.HashPassword(input);
                type = "BCrypt";
            }

            if (radioPreMySQL.Checked)
            {
                output = OldMySQLPassword(input);
                type = "PreMySQL";
            }

            if (radioMysqlSHA.Checked)
            {
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hash1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                    byte[] hash2 = sha1.ComputeHash(hash1);
                    output = "*" + BitConverter.ToString(hash2).Replace("-", "").ToUpper();
                }
                type = "MySQLSHA";
            }

            groupType.Enabled = true;
            groupEncode.Enabled = true;
            groupDecode.Enabled = true;
            groupHash.Enabled = true;
            labelStatus.Text = "String encoded!";
            listHistory.Items.Add(new ListViewItem(new[] { output, input, type, "Encoded" }));

            listHistory.SelectedItems.Clear();
            int lastIndex = listHistory.Items.Count - 1;
            listHistory.Items[lastIndex].Selected = true;
            listHistory.Items[lastIndex].EnsureVisible();
        }

        private string OldMySQLPassword(string password)
        {
            unchecked
            {
                uint nr = 1345345333;
                uint add = 7;
                uint nr2 = 0x12345671;

                foreach (char c in password)
                {
                    if (c == ' ' || c == '\t') continue;
                    uint tmp = (uint)c;

                    nr ^= (((nr & 63) + add) * tmp) + (nr << 8);
                    nr2 += (nr2 << 8) ^ nr;

                    add += tmp;
                }

                uint first = nr & 0x7FFFFFFF;
                uint second = nr2 & 0x7FFFFFFF;

                return string.Format("{0:X8}{1:X8}", first, second);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var info = listHistory.HitTest(e.Location);
                if (info.Item != null && info.SubItem != null)
                {
                    // Store the clicked subitem text for copying
                    listHistory.Tag = info.SubItem.Text;
                    contextMenuStrip1.Show(listHistory, e.Location);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listHistory.Tag is string text)
            {
                Clipboard.SetText(text);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////
        /// General Styling Functions
        //////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////
        /// Exit Function
        //////////////////////////////////////////////////////////////////////////////////
        private void CustomUI_app_exit(bool header_press)
        {
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////
        /// Close Window to Tray or Close Completely
        ////////////////////////////////////////////////////////////
        private void CustomUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("You have unsaved changes. Are you sure you want to exit? Any unsaved data will be lost.", "Confirm Termination", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //if (result != DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }

        ////////////////////////////////////////////////////////////
        /// Drag Window by Holding on Header
        ////////////////////////////////////////////////////////////
        private void CustomUI_Header_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.WindowState != FormWindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        ////////////////////////////////////////////////////////////
        /// Maximize Button Click Functionality
        ////////////////////////////////////////////////////////////
        private void CustomUI_BtnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Height = previousheight;
            }
            else
            {
                previousheight = this.Height;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        ////////////////////////////////////////////////////////////
        /// Allow for resizing by overriding WndProc
        ////////////////////////////////////////////////////////////
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int WM_GETMINMAXINFO = 0x24;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if (this.WindowState == FormWindowState.Maximized) { return; }
                    base.WndProc(ref m);

                    Point pos = PointToClient(new Point(m.LParam.ToInt32()));
                    if (pos.X < borderWidth && pos.Y < borderWidth)
                    {
                        m.Result = (IntPtr)HTTOPLEFT;
                    }
                    else if (pos.X > Width - borderWidth && pos.Y < borderWidth)
                    {
                        m.Result = (IntPtr)HTTOPRIGHT;
                    }
                    else if (pos.X < borderWidth && pos.Y > Height - borderWidth)
                    {
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    }
                    else if (pos.X > Width - borderWidth && pos.Y > Height - borderWidth)
                    {
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    }
                    else if (pos.X < borderWidth)
                    {
                        m.Result = (IntPtr)HTLEFT;
                    }
                    else if (pos.X > Width - borderWidth)
                    {
                        m.Result = (IntPtr)HTRIGHT;
                    }
                    else if (pos.Y < borderWidth)
                    {
                        m.Result = (IntPtr)HTTOP;
                    }
                    else if (pos.Y > Height - borderWidth)
                    {
                        m.Result = (IntPtr)HTBOTTOM;
                    }
                    else
                    {
                        m.Result = (IntPtr)HTCLIENT;
                    }
                    CustomUI_interface_reinit();
                    return;

                case WM_GETMINMAXINFO:
                    if (this.WindowState == FormWindowState.Maximized) { return; }
                    CustomUI_MINMAXINFO minMaxInfo = (CustomUI_MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(CustomUI_MINMAXINFO));
                    minMaxInfo.ptMinTrackSize.X = 600; // Minimum width
                    minMaxInfo.ptMinTrackSize.Y = 500; // Minimum height
                    Marshal.StructureToPtr(minMaxInfo, m.LParam, true);
                    CustomUI_interface_reinit();
                    break;
            }
            base.WndProc(ref m);
        }

        ////////////////////////////////////////////////////////////
        /// Extra Function for Minimum Resizing in Width and Height to not make the Window Disappear
        ////////////////////////////////////////////////////////////
        [StructLayout(LayoutKind.Sequential)]
        public struct CustomUI_MINMAXINFO
        {
            public Point ptReserved;
            public Point ptMaxSize;
            public Point ptMaxPosition;
            public Point ptMinTrackSize;
            public Point ptMaxTrackSize;
        }

        ////////////////////////////////////////////////////////////
        /// Interface Paint Functionality
        ////////////////////////////////////////////////////////////
        private void CustomUI_Interface_Paint(object sender, PaintEventArgs e)
        {
            // Draw the custom border
            using (Pen borderPen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            }
        }

        ////////////////////////////////////////////////////////////
        /// Update button locations on resize
        ////////////////////////////////////////////////////////////
        private void CustomUI_Interface_Resize(object sender, EventArgs e)
        {
            btnMinimize.Location = new Point(this.Width - 100, 0);
            btnMaximize.Location = new Point(this.Width - 70, 0);
            btnClose.Location = new Point(this.Width - 40, 0);
        }

        ////////////////////////////////////////////////////////////
        /// Close Window to Tray or Close Completely
        ////////////////////////////////////////////////////////////
        private void CustomUI_BtnClose_Click(object sender, EventArgs e)
        {
            CustomUI_app_exit(true);
        }

        ////////////////////////////////////////////////////////////
        /// Minimize Button Click to Minimize Current Form
        ////////////////////////////////////////////////////////////
        private void CustomUI_BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            CustomUI_interface_reinit();
        }

        ////////////////////////////////////////////////////////////
        /// ReInitialize Border and Buttons
        ////////////////////////////////////////////////////////////
        private void CustomUI_interface_reinit()
        {
            btnClose.Location = new Point(this.Width - 40, 0);
            btnMaximize.Location = new Point(this.Width - 70, 0);
            btnMinimize.Location = new Point(this.Width - 100, 0);
            btnClose.BringToFront();
            btnMaximize.BringToFront();
            btnMinimize.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listHistory.SelectedItems.Clear();
            listHistory.Items.Clear();
        }
    }
}
