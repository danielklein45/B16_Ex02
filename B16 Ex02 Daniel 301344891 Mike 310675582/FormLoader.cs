using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    public partial class FormLoader : Form

    {
        public FormLoader()
        {
            InitializeComponent();
        }

        public void FinishLoading()
        {
            this.Visible = false;
            this.Close();
        }
        
        public string LoadingLabel 
        { 
            get 
            { 
                return lblLoading.Text; 
            } 
            set 
            {
                lblLoading.Text = value;
            } 
        }
    }
}
