using System;
using System.Drawing;
using System.Windows.Forms;

namespace PySangamamTimer
{
    public partial class MainForm : Form
    {
        private int START_TIME_IN_MINS;
        private int TICK_INTERVAL_IN_MINS;

        private int _timeLeftInMins;
        private TimerState _timerState;


        public MainForm(int startTime, int interval)
        {
            START_TIME_IN_MINS = startTime;
            TICK_INTERVAL_IN_MINS = interval;

            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            RefreshLayout();

            InitTimer();
            StopTimer();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _timeLeftInMins = _timeLeftInMins - TICK_INTERVAL_IN_MINS;

            var labelText = $"{_timeLeftInMins}M";

            if (_timeLeftInMins <= 0)
            {
                StopTimer();
                labelText = "TIME";

                _timerState = TimerState.Finished;
            }

            timeleftLabel.Text = labelText;

            RefreshLayout();
        }

        private void RefreshLayout()
        {
            timeleftLabel.Left = (this.ClientSize.Width - timeleftLabel.Width) / 2;
            timeleftLabel.Top = (this.ClientSize.Height - timeleftLabel.Height) / 2;

            Application.DoEvents();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            RefreshLayout();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            switch (_timerState)
            {
                case TimerState.Running:
                    StopTimer();
                    break;
                case TimerState.Stopped:
                    StartTimer();
                    break;
                case TimerState.Finished:
                    InitTimer();
                    StartTimer();
                    break;
            }
        }

        private void InitTimer()
        {
            _timeLeftInMins = START_TIME_IN_MINS;
            timer.Interval = TICK_INTERVAL_IN_MINS * 100;// * 60 * 1000;
        }

        private void StartTimer()
        {
            timeleftLabel.ForeColor = Color.White;
            timer.Start();

            _timerState = TimerState.Running;
        }

        private void StopTimer()
        {
            timeleftLabel.ForeColor = Color.Red;
            timer.Stop();

            _timerState = TimerState.Stopped;
        }

        enum TimerState
        {
            Stopped,
            Running,
            Finished
        }
    }
}
