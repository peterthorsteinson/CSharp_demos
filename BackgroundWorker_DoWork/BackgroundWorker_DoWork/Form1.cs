using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BackgroundWorker_DoWork
{
    public partial class Form1 : Form
    {
        //following are defined in Form1.Designer.cs...
        //  BackgroundWorker backgroundWorker1 and related event handlers...
        // -> backgroundWorker1_DoWork
        // -> backgroundWorker1_ProgressChanged
        // -> backgroundWorker1_RunWorkerCompleted

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void btnStartAsync_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                //start asynchronous operation
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnCancelAsync_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                //cancel asynchronous operation
                backgroundWorker1.CancelAsync();
            }
        }

        //time-consuming work
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 10; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //perform time consuming operation and report progress
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(i * 10);
                }
            }
        }

        //event handler updates progress
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
        }

        //event handler deals with results of background operation
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
            }
        }
    }
}

