using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ColorChime
{
    public partial class MainForm : Form
    {
        private static Timer timer = new Timer();
        private List<ColorItem> targetColors = new List<ColorItem>();
        private System.Media.SoundPlayer player = null;
        private string configPath;
        private TopLevelWindowInfo targetWindow;
        private System.Random rand = new System.Random();
        private ShowCaptureImage showCapImgDlg;
        private ShowTargetImage showTargImgDlg;

        const int CAPMODE_ALT_PS     = 1;
        const int CAPMODE_CTRL_PS    = 2;
        const int CAPMODE_DOTNET_API = 3;

        public MainForm()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(watchTimer_Tick);
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string parentPath = System.IO.Directory.GetParent(appPath).FullName;
            configPath = parentPath + "\\config.xml";

            Dictionary<int, string> capModeItems = new Dictionary<int, string>()
            {
                { CAPMODE_ALT_PS,     "アクティブウィンドウ ( Alt + PrintScreen )" },
                { CAPMODE_CTRL_PS,    "全画面 ( Ctrl + PrintScreen )" },
                { CAPMODE_DOTNET_API, ".NET API ( Graphics.CopyFromScreen )" }
            };

            comboCaptureMode.DataSource    = new BindingSource(capModeItems, null);
            comboCaptureMode.DisplayMember = "Value";
            comboCaptureMode.ValueMember   = "Key";

            showCapImgDlg = new ShowCaptureImage();
            showCapImgDlg.Show();
            showCapImgDlg.Hide();
            showTargImgDlg = new ShowTargetImage();
            showTargImgDlg.Show();
            showTargImgDlg.Hide();
    }


        private Bitmap CaptureImage()
        {
            switch (((KeyValuePair<int, string>)comboCaptureMode.SelectedItem).Key)
            {
                case CAPMODE_ALT_PS:
                    return CaptureActiveWindowWithPrtScr();
                case CAPMODE_CTRL_PS:
                    {
                        Bitmap img = CaptureFullScreenPrtScr();
                        Bitmap trimed = TrimByWindow(img);
                        img.Dispose();
                        return trimed;
                    }
                case CAPMODE_DOTNET_API:
                    {
                        Bitmap img = CaptureDotNetAPI();
                        Bitmap trimed = TrimByWindow(img);
                        img.Dispose();
                        return trimed;
                    }
                default:
                    return null;
            }

        }
        private Bitmap TrimByWindow(Bitmap img)
        {
            if(targetWindow != null)
            {
                return TrimingImage(img, targetWindow.clientTop, targetWindow.clientLeft,targetWindow.clientWidth,targetWindow.clientHeight);
            }
            else {
                return new Bitmap(img);
            }
        }
        private static Bitmap CaptureActiveWindowWithPrtScr()
        {
            SendKeys.SendWait("%{PRTSC}");
            IDataObject d = Clipboard.GetDataObject();
            if (d != null)
            {
                Bitmap img = (Bitmap)d.GetData(DataFormats.Bitmap);
                if (img != null)
                {
                    return img;
                }
                img.Dispose();
            }
            return null;
        }
        private static Bitmap CaptureFullScreenPrtScr()
        {
            SendKeys.SendWait("^{PRTSC}");
            IDataObject d = Clipboard.GetDataObject();
            if (d != null)
            {
                Bitmap img = (Bitmap)d.GetData(DataFormats.Bitmap);
                if (img != null)
                {
                    return img;
                }
                img.Dispose();

            }
            return null;
        }
        private static Bitmap CaptureDotNetAPI()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            if (bmp != null)
            {
                //Graphicsの作成
                Graphics g = Graphics.FromImage(bmp);
                //画面全体をコピーする
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
                //解放
                g.Dispose();
                return bmp;
            }
            else
            {
                bmp.Dispose();
                return null;
            }

        }
        


        private void MainForm_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(configPath))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ColorChimeConfig));
                System.IO.StreamReader sr = new System.IO.StreamReader(configPath, new System.Text.UTF8Encoding(false));
                ColorChimeConfig config = (ColorChimeConfig)serializer.Deserialize(sr);
                sr.Close();

                foreach( var item in comboCaptureMode.Items )
                {
                    if(((KeyValuePair<int, string>)item).Key == config.captureMode )
                    {
                        comboCaptureMode.SelectedItem = item;
                    }
                }
                if (config.captureMode == CAPMODE_CTRL_PS || config.captureMode == CAPMODE_DOTNET_API)
                {
                    if (config.hasTargetWindow)
                    {

                    }
                }
                txtWavFilePath.Text      = config.waveFilePath;
                numUDWatchInterval.Value = config.watchInterval;
                numUD_ax.Value           = config.pointAx;
                numUD_ay.Value           = config.pointAy;
                numUD_bx.Value           = config.pointBx;
                numUD_by.Value           = config.pointBy;
                //txtInputColor.Text      = config.watchColor;
                foreach(ColorItem color in config.watchColors)
                {
                    lsbTargetColors.Items.Add(color);
                    targetColors.Add(color);
                }
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ColorChimeConfig config = new ColorChimeConfig();
            config.captureMode = ((KeyValuePair<int, string>)comboCaptureMode.SelectedItem).Key;
            if (config.captureMode == CAPMODE_CTRL_PS || config.captureMode == CAPMODE_DOTNET_API) {
                if (targetWindow != null)
                {
                    config.targetWindowClass = targetWindow.className;
                    config.targetWindowTitle = targetWindow.windowText;
                }
            }
            config.waveFilePath = txtWavFilePath.Text;
            config.watchInterval = (int)numUDWatchInterval.Value;
            config.pointAx = (int)numUD_ax.Value;
            config.pointAy = (int)numUD_ay.Value;
            config.pointBx = (int)numUD_bx.Value;
            config.pointBy = (int)numUD_by.Value;
            config.watchColors = targetColors;


            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ColorChimeConfig));
            System.IO.StreamWriter sw = new System.IO.StreamWriter(configPath, false, new System.Text.UTF8Encoding(false));
            serializer.Serialize(sw, config);
            sw.Close();
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            timer.Interval = (int)numUDWatchInterval.Value * 1000;
            timer.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnSelectWavFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Wavファイル(*.wav)|*.wav";
            if( dlg.ShowDialog(this) == DialogResult.OK )
            {
                txtWavFilePath.Text = dlg.FileName;
            }
        }

        private static Bitmap TrimingImage(Bitmap img, int top, int left, int width, int height)
        {
            if (img != null && top >= 0 && left >= 0 && width > 0 && height > 0)
            {
                Rectangle targRect = new Rectangle(top, left, width, height);
                Bitmap dest = new Bitmap(targRect.Width, targRect.Height);
                Graphics g = Graphics.FromImage(dest);
                g.DrawImage(img, new Rectangle(0, 0, targRect.Width, targRect.Height), targRect, GraphicsUnit.Pixel);
                g.Dispose();
                return dest;
            }
            else
                return img;

        }

        private void watchTimer_Tick(object sender, EventArgs e)
        {
            Bitmap img = CaptureImage();
            showCapImgDlg.renderImage = new Bitmap(img);
            int ax = (int)numUD_ax.Value;
            int ay = (int)numUD_ay.Value;
            int bx = (int)numUD_bx.Value;
            int by = (int)numUD_by.Value;
            Bitmap trimed = TrimingImage(img, ax, ay, bx - ax, by - ay);
            img.Dispose();
            showTargImgDlg.renderImage = new Bitmap(trimed);
            Task.Run(() =>
            {
                if (findColorInImage(trimed))
                {
                    player.PlaySync();
                    Debug.WriteLine("find color");
                }
                trimed.Dispose();
            });
        }

        private Boolean findColorInImage( Bitmap bmp)
        {
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    foreach (ColorItem colorItem in targetColors)
                    {
                        if (c == colorItem.color)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if( dlg.ShowDialog(this) == DialogResult.OK )
            {
                int rr = rand.Next(10);
                if (rr < 5)
                {
                    txtInputColor.Text = String.Format("#{0:X2}{1:X2}{2:X2}", dlg.Color.R, dlg.Color.G, dlg.Color.B);
                }
                else
                {
                    txtInputColor.Text = String.Format("rgb({0:D},{1:D},{2:D})", dlg.Color.R, dlg.Color.G, dlg.Color.B);
                }
            }
        }

        
        private void txtWavFilePath_TextChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtWavFilePath.Text))
            {
                if (player != null)
                    StopSound();
                player = new System.Media.SoundPlayer(txtWavFilePath.Text);
            }
        }
        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        private void comboCaptureMode_SelectedValueChanged(object sender, EventArgs e)
        {
            int capModeValue = ((KeyValuePair<int, string>)comboCaptureMode.SelectedItem).Key;
            btnSelectWin.Enabled = (capModeValue == CAPMODE_CTRL_PS || capModeValue == CAPMODE_DOTNET_API);

              
                
        }

        private void btnSelectWin_Click(object sender, EventArgs e)
        {
            WindowSelector dlg = new WindowSelector();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                targetWindow = dlg.selectedWindow;
                txtTargetWindow.Text = String.Format("{0} - {1}", targetWindow.windowText, targetWindow.className);
            }
            dlg.Dispose();

        }
        private void btnShowCapImage_Click(object sender, EventArgs e)
        {
            showCapImgDlg.Show();

        }

        private void btnShowTargImage_Click(object sender, EventArgs e)
        {
            showTargImgDlg.Show();
        }

        private static string GetStringFromColor(Color color)
        {
            return String.Format("rgb({0},{1},{2})",color.R, color.G, color.B);
        }
        private static Regex rHEX = new Regex(@"^#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})$", RegexOptions.IgnoreCase);
        private static Regex rRGB = new Regex(@"^rgb\(([0-9]{1,3}),([0-9]{1,3}),([0-9]{1,3})\)$", RegexOptions.IgnoreCase);
        private static Color GetColorFromString(String text)
        {
            Match mHEX = rHEX.Match(text);
            if (mHEX.Success)
            {
                Debug.WriteLine(String.Format("{0} = {1} : {2} : {3}", text,
                                                                       mHEX.Groups[1].Captures[0].Value,
                                                                       mHEX.Groups[2].Captures[0].Value,
                                                                       mHEX.Groups[3].Captures[0].Value));
                int red   = Convert.ToInt32(mHEX.Groups[1].Captures[0].Value, 16);
                int green = Convert.ToInt32(mHEX.Groups[2].Captures[0].Value, 16);
                int blue  = Convert.ToInt32(mHEX.Groups[3].Captures[0].Value, 16);
                return Color.FromArgb(red, green, blue);
            }
            Match mRGB = rRGB.Match(text);
            if (mRGB.Success)
            {
                Debug.WriteLine(String.Format("{0} = {1} : {2} : {3}", text,
                                                                       mRGB.Groups[1].Captures[0].Value,
                                                                       mRGB.Groups[2].Captures[0].Value,
                                                                       mRGB.Groups[3].Captures[0].Value));
                return Color.FromArgb(Convert.ToInt32(mRGB.Groups[1].Captures[0].Value, 10),
                                      Convert.ToInt32(mRGB.Groups[2].Captures[0].Value, 10),
                                      Convert.ToInt32(mRGB.Groups[3].Captures[0].Value, 10));
            }
            return Color.Empty;
        }
        private void btnAddColor_Click(object sender, EventArgs e)
        {
            Color color = GetColorFromString( txtInputColor.Text);
            if(!color.IsEmpty)
            {
                ColorItem colorItem = new ColorItem();
                colorItem.color = color;
                lsbTargetColors.Items.Add(colorItem);
                targetColors.Add(colorItem);
            }

        }

        private void btnDelColor_Click(object sender, EventArgs e)
        {
            List<ColorItem> selColors = new List<ColorItem>();
            foreach(ColorItem selColor in lsbTargetColors.SelectedItems)
            {
                selColors.Add(selColor);
            }
            foreach(ColorItem selColor in selColors)
            {
                targetColors.Remove(selColor);
                lsbTargetColors.Items.Remove(selColor);
            }
        }
        private void txtInputColor_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Enter) && !e.Alt && !e.Control)
            {
                btnAddColor_Click(sender, e);
            }
        }

        private void numUD_ax_ValueChanged(object sender, EventArgs e)
        {
            numUD_bx.Minimum = numUD_ax.Value;
        }

        private void numUD_ay_ValueChanged(object sender, EventArgs e)
        {
            numUD_by.Minimum = numUD_ay.Value;
        }

        public class ColorItem
        {
            [XmlIgnore] // XmlSerializer から隠す
            public Color color { get; set; }
            public string displayColor {
                get { return GetStringFromColor(color); }
                set { color = GetColorFromString(value); }
            }
            public override string ToString()
            {
                return String.Format("#{0:X2}{1:X2}{2:X2} - rgb({3},{4},{5})",
                                     this.color.R, this.color.G, this.color.B,
                                     this.color.R, this.color.G, this.color.B);
            }
        }
        public class ColorChimeConfig
        {
            public int captureMode { get; set; }
            public string targetWindowClass { get; set; }
            public string targetWindowTitle { get; set; }
            public Boolean hasTargetWindow
            {
                get
                {
                    return (this.targetWindowClass != null && this.targetWindowClass.Count() > 0
                          && this.targetWindowTitle != null && this.targetWindowTitle.Count() > 0);
                }
                set { }
            }
            public int watchInterval { get; set; }
            public String waveFilePath { get; set; }
            public int pointAx { get; set; }
            public int pointAy { get; set; }
            public int pointBx { get; set; }
            public int pointBy { get; set; }
            public List<ColorItem> watchColors { get; set; }
        }

    }

}
