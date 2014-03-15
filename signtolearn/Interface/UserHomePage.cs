﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class UserHomePage : Form
    {
        private String UserName;
        public UserHomePage(String _UserName)
        {
            InitializeComponent();
            UserName = _UserName;
            try
            {
                LabelUsername.Text = DAL.User.GetName(UserName);
                int Percent = (int)((double)(DAL.User.GetProgress(UserName) - 65) / 25 * 100);
                labelTrainingProgressPercentage.Text = String.Format("{0}% Complete", Percent);
            }
            catch (Exception x)
            {
                MessageBox.Show(String.Format("Could not connect to database", x.Message));
                this.Close();
            }
        }
        private void buttonTraining_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(() => StartTraining());
            t.Start();
            this.Hide();
            t.Join();
            this.Close();
        }

        void StartTraining()
        {
            Application.Run(new KinectVideoStream(UserName, true));
        }

        private void buttonTesting_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(() => StartTesting());
            t.Start();
            this.Hide();
            t.Join();
            this.Close();
        }

        void StartTesting()
        {
            Application.Run(new KinectVideoStream(UserName, false));
        }
    }
}
