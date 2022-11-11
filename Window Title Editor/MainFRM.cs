using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Window_Title_Editor
{
    public partial class MainFRM : Form
    {
        public MainFRM()
        {
            InitializeComponent();
        }
        
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        private void TitleEditor(string input, ComboBox combo, string processName = "", string Title = "")
        {
            switch (input)
            {
                case "List":
                    Process[] pList = Process.GetProcesses();
                    for (int i = 0; i < pList.Length; i++) combo.Items.Add(pList[i].ProcessName);
                    break;
                case "Edit":
                    Process[] proc = Process.GetProcessesByName(processName);
                    foreach(Process p in proc) { IntPtr windowHandle = p.MainWindowHandle;  SetWindowText(windowHandle, Title); }
                    break;
            }
        }

        private void MainFRM_Load(object sender, EventArgs e)
        {
            //Loads Event To get Processnames
            TitleEditor("List", ProcessList);
        }

        private void BTN_Click(object sender, EventArgs e)
        {
           //edit title of selected process
           TitleEditor("Edit", ProcessList, ProcessList.Text, titleBox.Text);
        }

        private void refreshListF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //get Processnames
            TitleEditor("List", ProcessList);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app was made to demonstrate how you\nedit the window title of a running process\n\n~ Joshua", "About Us?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
