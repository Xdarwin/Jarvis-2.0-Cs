using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Jarvis_1._0_Main
{
    public partial class Form1 : Form
    {
        private ASR ASR;
        public Form1()
        {
            InitializeComponent();
            ASR = new ASR(ref this.recoText, ref this.affiche);
            this.KeyPress += ActivateASR;
        }


        private void ActivateASR(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                try
                {
                    ASR.ASREngine.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch { }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}