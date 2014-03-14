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
    public partial class CreateProfile : Form
    {
        public CreateProfile()
        {
            InitializeComponent();
        }

        private void buttonCancelCreateUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfirmCreateUser_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxUsername.Text))
                MessageBox.Show("Need to enter a username");
            else if (String.IsNullOrEmpty(textBoxFirstName.Text))
                MessageBox.Show("Need to enter a first name");
            else if (String.IsNullOrEmpty(textBoxLastName.Text))
                MessageBox.Show("Need to enter a last name");
            else
            {
                try
                {
                    if (DAL.User.AddProfile(textBoxUsername.Text, textBoxFirstName.Text, textBoxLastName.Text))
                        this.Close();
                    else
                        MessageBox.Show("Username is already taken");
                }
                catch (Exception x)
                {
                    MessageBox.Show(String.Format("Could not connect to database\n {0}", x.Message));
                }
            }
        }
    }
}
