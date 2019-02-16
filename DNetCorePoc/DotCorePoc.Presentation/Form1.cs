﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotCorePoc.Presentation.UploadService;
namespace DotCorePoc.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
            };

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string fileName = openFileDialog.FileName;
            }
        }

        private async Task Submit()

        {
            using (ExcelUploadServicecsClient uploadServicecsClient = new ExcelUploadServicecsClient())
            {
                await uploadServicecsClient.UploadAsync(new ExcelUploadModel() { Name = "est", Content = null });
            }
        }
    }
}
