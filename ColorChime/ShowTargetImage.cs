﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorChime
{
    public partial class ShowTargetImage : Form
    {
        public ShowTargetImage()
        {
            InitializeComponent();
        }

        public Bitmap renderImage
        {
            set
            {
                if (picBox.Image != null)
                    picBox.Image.Dispose();
                picBox.Image = value;
            }
        }

        private void ShowTargetImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
