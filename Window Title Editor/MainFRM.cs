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



        private void KillTaskManager()
        {
        Start:
            try { Process[] proc = Process.GetProcessesByName("taskmgr"); foreach (Process p in proc) { p.Kill(); } } catch { goto Start; }
        }



        private void EditWindowTitle(string App, string Title)
        {
            Process[] proc = Process.GetProcessesByName(App); //process name
            foreach (Process p in proc) //loop
            {
             
                IntPtr windowHandle = p.MainWindowHandle; //gets hid from process               
                SetWindowText(windowHandle, Title); //sets name of all processes
            }   
        }

        private void GetProcName()
        {
            //clears, gets and stores names in combobox
            ProcessList.Items.Clear();
            Process[] proc = Process.GetProcesses();
            for (int i = 0; i < proc.Length; i++) ProcessList.Items.Add(proc[i].ProcessName);

        }


        private void MainFRM_Load(object sender, EventArgs e)
        {
            //Loads Event To get Processnames
         
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            //TOCALL: Calls the main function to edit the process's window title by name
            EditWindowTitle(ProcessList.Text, titleBox.Text);           
        }

        private void refreshListF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetProcName();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app was made to demonstrate how you\nedit the window title of a running process\n\n~ Joshua", "About Us?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
