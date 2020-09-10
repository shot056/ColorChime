using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Xml.Schema;

namespace ColorChime
{
    public partial class MainForm : Form
    {
        private static Timer timer = new Timer();
        private Color targetColor = Color.FromArgb(0,0,0);
        private System.Media.SoundPlayer player = null;
        private string configPath;
        public MainForm()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(watchTimer_Tick);
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string parentPath = System.IO.Directory.GetParent(appPath).FullName;
            configPath = parentPath + "\\config.xml";
        }



        private static Image CaptureActiveWindowWithPrtScr()
        {
            SendKeys.SendWait("%{PRTSC}");
            IDataObject d = Clipboard.GetDataObject();
            if( d != null )
            {
                Image img = (Image)d.GetData(DataFormats.Bitmap);
                if( img != null )
                {
                    return img;
                }
            }
            return null;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(configPath))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ColorChimeConfig));
                System.IO.StreamReader sr = new System.IO.StreamReader(configPath, new System.Text.UTF8Encoding(false));
                ColorChimeConfig config = (ColorChimeConfig)serializer.Deserialize(sr);
                sr.Close();

                txtWavFilePath.Text      = config.waveFilePath;
                numUDWatchInterval.Value = config.watchInterval;
                numUD_ax.Value           = config.pointAx;
                numUD_ay.Value           = config.pointAy;
                numUD_bx.Value           = config.pointBx;
                numUD_by.Value           = config.pointBy;
                txtTargetColor.Text      = config.watchColor;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ColorChimeConfig config = new ColorChimeConfig();
            config.waveFilePath = txtWavFilePath.Text;
            config.watchInterval = (int)numUDWatchInterval.Value;
            config.pointAx = (int)numUD_ax.Value;
            config.pointAy = (int)numUD_ay.Value;
            config.pointBx = (int)numUD_bx.Value;
            config.pointBy = (int)numUD_by.Value;
            config.watchColor = txtTargetColor.Text;


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

        private void watchTimer_Tick(object sender, EventArgs e)
        {
            using (var img = CaptureActiveWindowWithPrtScr())
            {
                img.Save(System.IO.Path.GetTempPath() + "\\ColorChime_full.png", ImageFormat.Png);
                int ax = (int)numUD_ax.Value;
                int ay = (int)numUD_ay.Value;
                int bx = (int)numUD_bx.Value;
                int by = (int)numUD_by.Value;
                Rectangle srcRect = new Rectangle(ax, ay, bx-ax, by-ay );
                Bitmap dest = new Bitmap(srcRect.Width, srcRect.Height);
                using (Graphics g = Graphics.FromImage(dest))
                {
                    g.DrawImage(img, new Rectangle(0, 0, srcRect.Width, srcRect.Height), srcRect, GraphicsUnit.Pixel);
                    dest.Save(System.IO.Path.GetTempPath() + "\\ColorChime_trimed.png", ImageFormat.Png);
                    g.Dispose();
                    if( findColorInImage( dest, targetColor ) )
                    {
                        player.PlaySync();
                        Debug.WriteLine("find color");
                    }
                }
                Debug.WriteLine("save img");
            }
        }

        private Boolean findColorInImage( Bitmap bmp, Color color)
        {
            Debug.WriteLine(color);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color c = bmp.GetPixel(x, y);
                    Debug.WriteLine("{0} : {1}", color, c);
                    if ( c == color )
                    {
                        return true;
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
                targetColor = dlg.Color;
                txtTargetColor.Text = String.Format("#{0:X2}{1:X2}{2:X2}", dlg.Color.R, dlg.Color.G, dlg.Color.B);
            }
        }

        private void txtTargetColor_TextChanged(object sender, EventArgs e)
        {
            if (txtTargetColor.Text.Length == 7)
            {
                Debug.WriteLine(String.Format("{0} = {1} : {2} : {3}", txtTargetColor.Text,
                                                                       txtTargetColor.Text.Substring(1, 2),
                                                                       txtTargetColor.Text.Substring(3, 2),
                                                                       txtTargetColor.Text.Substring(5, 2)));
                int red   = Convert.ToInt32(txtTargetColor.Text.Substring(1, 2),16);
                int green = Convert.ToInt32(txtTargetColor.Text.Substring(3, 2),16);
                int blue  = Convert.ToInt32(txtTargetColor.Text.Substring(5, 2),16);
                Color color = Color.FromArgb(red, green, blue);
                targetColor = color;
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
    }

    public class ColorChimeConfig
    {
        private static int _watchInterval;
        private static String _waveFilePath;
        private static int _pointAx;
        private static int _pointAy;
        private static int _pointBx;
        private static int _pointBy;
        private static String _watchColor;

        public int watchInterval
        {
            get { return _watchInterval;  }
            set { _watchInterval = value; }
        }
        public String waveFilePath
        {
            get { return _waveFilePath; }
            set { _waveFilePath = value; }
        }
        public int pointAx
        {
            get { return _pointAx; }
            set { _pointAx = value; }
        }
        public int pointAy
        {
            get { return _pointAy; }
            set { _pointAy = value; }
        }
        public int pointBx
        {
            get { return _pointBx; }
            set { _pointBx = value; }
        }
        public int pointBy
        {
            get { return _pointBy; }
            set { _pointBy = value; }
        }
        public String watchColor
        {
            get { return _watchColor; }
            set { _watchColor = value; }
        }
    }
}
