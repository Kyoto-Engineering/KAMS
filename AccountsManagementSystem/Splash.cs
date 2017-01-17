using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountsManagementSystem
{
    public partial class Splash : Form
    {
        int numUpdates = 0;

        /// <summary>
        /// Time between screen updates (ms)
        /// </summary>
        int timerInterval_ms = 0;

        public Splash(int timerInterval)
        {
            // Store the timer interval
            timerInterval_ms = timerInterval;
            

            InitializeComponent();
        }
        public int GetUpMilliseconds()
        {
            return numUpdates * timerInterval_ms;
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Your background task goes here
            for (int i = 0; i <= 20; i++)
            {
                // Report progress to 'UI' thread
                backgroundWorker1.ReportProgress(i);
                // Simulate long task
                System.Threading.Thread.Sleep(100);
            }
        }
        // Back on the 'UI' thread so we can update the progress bar
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy == true)
            {
                MessageBox.Show("Please Wait ", "Wait", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
                // To report progress from the background worker we need to set this property
                backgroundWorker1.WorkerReportsProgress = true;
                // This event will be raised on the worker thread when the worker starts
                backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                // This event will be raised when we call ReportProgress
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            }
           
        }
        public void KillMe(object o, EventArgs e)
        {
            // Stop the timer first so there are no racing issues
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();

            // Shut down the form
            this.Close();
        }
    }
}
