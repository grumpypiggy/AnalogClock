using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AnalogClock
{
    public struct ClockArm
    {
        public PointF ptStart;
        public PointF ptEnd;
        public int nStart;
        public Pen pen;
        public Pen eraser;
        public int nValue;
        public float fArmLength;
        public PointF GetEndPoint()
        {
            return new PointF(ptStart.X, ptStart.Y - fArmLength);
        }
    };
    public partial class Form1 : Form
    {
        private PointF ptAnchor;
        private PointF ptAnchorStopWatch;
        private Graphics graph;
        private ClockArm hourArm, minuteArm, secondArm, milSecArm;
        private Pen penStopWatch;

        public Form1()
        {
            InitializeComponent();
            SetupClockArm();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timerClock.Enabled = true;
        }

        //setup clock arm
        private void SetupClockArm()
        {
            graph = Graphics.FromHwnd(this.Handle);

            ptAnchor = new PointF(this.Width / 2.0F, this.Height / 4.0F);
            ptAnchorStopWatch = new PointF(ptAnchor.X, ptAnchor.Y - 30);

            //draw arm for milSec
            milSecArm.nStart = 0;
            milSecArm.eraser = new Pen(Brushes.LightGray, 1.0f);
            milSecArm.pen = new Pen(Brushes.Black, 1.0f);

            //draw arm for second
            secondArm.pen = new Pen(Brushes.DimGray, 2.0f);
            secondArm.eraser = new Pen(Brushes.LightGray, 2.0f);
            secondArm.ptStart = secondArm.ptEnd = ptAnchor;
            secondArm.fArmLength = 100;

            //draw arm for minute
            minuteArm.eraser = new Pen(Brushes.LightGray, 3.0f);
            minuteArm.pen = new Pen(Brushes.Orange, 3.0f);
            minuteArm.ptStart = minuteArm.ptEnd = ptAnchor;
            minuteArm.fArmLength = 80;

            //draw arm for hour
            hourArm.eraser = new Pen(Brushes.LightGray, 5.0f);
            hourArm.pen = new Pen(Brushes.Teal, 5.0f);
            hourArm.ptStart = hourArm.ptEnd = ptAnchor;
            hourArm.fArmLength = 50;
            //threadClock = new Thread(UpdateClock);

            AdjustClockArmWithCurrentTime();
            penStopWatch = new Pen(Brushes.Red, 3.0F);
        }

        //align clock arm with the current time
        private void AdjustClockArmWithCurrentTime()
        {
            if (DateTime.Now.Hour == 0)
            {
                hourArm.nStart = hourArm.nValue = 0;

            }
            else if (DateTime.Now.Hour > 12)
            {
                hourArm.nStart = (DateTime.Now.Hour - 12) * 30;
                hourArm.nValue = DateTime.Now.Hour - 12;
            }
            else if (DateTime.Now.Hour < 12)
            {
                hourArm.nStart = DateTime.Now.Hour * 30;
                hourArm.nValue = DateTime.Now.Hour;
            }

            minuteArm.nStart = DateTime.Now.Minute * 6;
            minuteArm.nValue = DateTime.Now.Minute;
            secondArm.nStart = DateTime.Now.Second * 6;
            secondArm.nValue = DateTime.Now.Second - 1;
        }

        //create watch face
        private void CreateFaceWatch(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.LightGray, new RectangleF(ptAnchor.X - (250 / 2), ptAnchor.Y - (250 / 2), 250, 250));
            e.Graphics.DrawEllipse(new Pen(Brushes.Gray, 10.0F), new RectangleF(ptAnchor.X - (250 / 2), ptAnchor.Y - (250 / 2), 250, 250));

            PointF ptTarget = new PointF(ptAnchor.X, ptAnchor.Y - 100);
            int _hour = 0;
            for (int i = 0; i < 360; i += 6)
            {
                PointF ptTrajectory = GetTrajectoryPoint(ptAnchor, ptTarget, i);

                PointF ptTarget2 = new PointF(ptTrajectory.X, ptTrajectory.Y - 10);
                PointF ptTrajectory2 = GetTrajectoryPoint(ptTrajectory, ptTarget2, i);

                PointF ptTarget3 = new PointF(ptTrajectory2.X, ptTrajectory2.Y - 15);
                PointF ptTrajectory3 = GetTrajectoryPoint(ptTrajectory2, ptTarget3, i);

                PointF ptTarget4 = new PointF(ptTrajectory2.X, ptTrajectory2.Y - 5);
                PointF ptTrajectory4 = GetTrajectoryPoint(ptTrajectory2, ptTarget4, i);

                if (i % 30 == 0)
                {
                    e.Graphics.DrawLine(new Pen(Brushes.Orange, 1.0f), ptTrajectory2, ptTrajectory3);
                    if (_hour == 0)
                    {
                        e.Graphics.DrawString(12.ToString(), this.Font, Brushes.Navy, new PointF(ptTrajectory4.X - this.Font.SizeInPoints / 2, ptTrajectory4.Y - this.Font.SizeInPoints / 2));
                    }
                    else
                    {
                        e.Graphics.DrawString(_hour.ToString(), this.Font, Brushes.Navy, new PointF(ptTrajectory4.X - this.Font.SizeInPoints / 2, ptTrajectory4.Y - this.Font.SizeInPoints / 2));
                    }
                    _hour++;

                }
                else
                {
                    e.Graphics.DrawLine(new Pen(Brushes.Teal, 1.0f), ptTrajectory2, ptTrajectory3);
                }
            }
        }

        private void btnStopWatch_CheckedChanged(object sender, EventArgs e)
        {
            if (btnStopWatch.Checked)
            {
                hourArm.nStart = hourArm.nValue = 0;
                minuteArm.nStart = minuteArm.nValue = 0;
                secondArm.nStart = secondArm.nValue = 0;
                milSecArm.nStart = milSecArm.nValue = 0;
                lblStopWatch.Text = GetStopWatchLabel(hourArm.nValue, minuteArm.nValue, secondArm.nValue, milSecArm.nValue, true);
                RefreshClock(true);
                timerClock.Enabled = false;
                groupStopWatch.Enabled = true;

            }
        }

        private void btnAnalogClock_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAnalogClock.Checked)
            {
                AdjustClockArmWithCurrentTime();
                timerClock.Enabled = true;

                groupStopWatch.Enabled = false;

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //face watch
            CreateFaceWatch(e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timerClock.Start();
            timerStopWatch.Start();
            btnStart.Enabled = false;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            listBox.Items.Add(GetStopWatchLabel(hourArm.nValue, minuteArm.nValue, secondArm.nValue, milSecArm.nValue, true));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetStopWatch();
            RefreshClock(true);
            listBox.Items.Clear();
        }

        private void RefreshClock(bool bForStopWatch)
        {
            graph.DrawLine(secondArm.eraser, secondArm.ptStart, secondArm.ptEnd);
            graph.DrawLine(minuteArm.eraser, minuteArm.ptStart, minuteArm.ptEnd);
            graph.DrawLine(hourArm.eraser, hourArm.ptStart, hourArm.ptEnd);

            PointF ptSecondEndPoint = GetTrajectoryPoint(secondArm.ptStart, secondArm.GetEndPoint(), secondArm.nStart);
            PointF ptMinuteEndPoint = GetTrajectoryPoint(minuteArm.ptStart, minuteArm.GetEndPoint(), minuteArm.nStart);
            PointF ptHourEndPoint = GetTrajectoryPoint(hourArm.ptStart, hourArm.GetEndPoint(), hourArm.nStart);

            graph.DrawEllipse(secondArm.eraser, secondArm.ptEnd.X - 2.5F, secondArm.ptEnd.Y - 2.5F, 5, 5);

            secondArm.ptEnd = ptSecondEndPoint;
            minuteArm.ptEnd = ptMinuteEndPoint;
            hourArm.ptEnd = ptHourEndPoint;
            graph.DrawLine(secondArm.pen, secondArm.ptStart, ptSecondEndPoint);
            graph.DrawLine(minuteArm.pen, minuteArm.ptStart, ptMinuteEndPoint);
            graph.DrawLine(hourArm.pen, hourArm.ptStart, ptHourEndPoint);

            graph.DrawEllipse(secondArm.pen, ptSecondEndPoint.X - 2.5F, ptSecondEndPoint.Y - 2.5F, 5, 5);

            //arm movement
            secondArm.nStart += 6;
            if (secondArm.nStart >= 360)
            {
                secondArm.nStart = 0;
                minuteArm.nStart += 6;
                if (minuteArm.nStart >= 360)
                {
                    minuteArm.nStart = 0;
                    hourArm.nStart += 30;
                    if (hourArm.nStart >= 360)
                    {
                        hourArm.nStart = 0;
                    }
                }
            }

            //track timing
            if (!bForStopWatch)
            {
                secondArm.nValue++;
            }
            if (secondArm.nValue > 60)
            {
                secondArm.nValue = 0;
                minuteArm.nValue++;
                if (minuteArm.nValue > 60)
                {
                    minuteArm.nValue = 0;
                    hourArm.nValue++;
                    if (hourArm.nValue > 60)
                    {
                        hourArm.nValue++;
                        if (hourArm.nValue > 12)
                        {
                            hourArm.nValue = 0;
                        }
                    }
                }

            }
            if (!bForStopWatch)
            {
                lblStopWatch.Text = GetStopWatchLabel(hourArm.nValue, minuteArm.nValue, secondArm.nValue, milSecArm.nValue, false);
            }
        }

        private void timerStopWatch_Tick(object sender, EventArgs e)
        {
            RunStopWatch();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            RefreshClock(false);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerStopWatch.Enabled = false;
            timerClock.Enabled = false;
            btnStart.Enabled = true;
        }

        private string GetStopWatchLabel(int hour, int minute, int second, int milsec, bool bStopWatch)
        {

            string _hour, _minute, _second, _milsec;
            if (hour < 10)
            {
                _hour = "0" + hour;
            }
            else
            {
                _hour = hour.ToString();
            }

            if (minute < 10)
            {
                _minute = "0" + minute;
            }
            else
            {
                _minute = minute.ToString();
            }
            if (second < 10)
            {
                _second = "0" + second;
            }
            else
            {
                _second = second.ToString();
            }

            if (milsec < 10)
            {
                _milsec = "0" + milsec;
            }
            else
            {
                _milsec = milsec.ToString();
            }

            if (bStopWatch)
            {
                return _hour + ":" + _minute + ":" + _second + ":" + _milsec;
            }
            else
            {
                return _hour + ":" + _minute + ":" + _second;
            }
        }

        private void ResetStopWatch()
        {
            hourArm.nStart = hourArm.nValue = 0;
            minuteArm.nStart = minuteArm.nValue = 0;
            secondArm.nStart = secondArm.nValue = 0;
            milSecArm.nStart = milSecArm.nValue = 0;
            CreateGraphics().DrawArc(new Pen(Brushes.Gray, 10.0F), new RectangleF(ptAnchor.X - (250 / 2), ptAnchor.Y - (250 / 2), 250, 250), -90.0F, 360.0F);
            lblStopWatch.Text = GetStopWatchLabel(hourArm.nValue, minuteArm.nValue, secondArm.nValue, milSecArm.nValue, true);
        }

        private void RunStopWatch()
        {
            PointF ptMilSecEndPoint = GetTrajectoryPoint(milSecArm.ptStart, milSecArm.GetEndPoint(), milSecArm.nStart);
            milSecArm.ptEnd = ptMilSecEndPoint;

            milSecArm.nStart += 6;
            milSecArm.nValue++;
            CreateGraphics().DrawArc(penStopWatch, new RectangleF(ptAnchor.X - (250 / 2), ptAnchor.Y - (250 / 2), 250, 250), -90.0F, milSecArm.nStart);


            if (milSecArm.nStart >= 360)
            {
                milSecArm.nStart = 0;
                if (secondArm.nValue % 2 == 0)
                {
                    penStopWatch.Brush = Brushes.Gray;
                }
                else
                {
                    penStopWatch.Brush = Brushes.Red;
                }
            }
            if (milSecArm.nValue > 60)
            {
                milSecArm.nValue = 0;
            }
            lblStopWatch.Text = GetStopWatchLabel(hourArm.nValue, minuteArm.nValue, secondArm.nValue, milSecArm.nValue, true);
        }

        //return trajectory point based on anchorPoint
        public PointF GetTrajectoryPoint(PointF anchorPoint, PointF targetPoint, double dRotation)
        {
            PointF ptNew = new PointF();
            PointF ptShift = new PointF(targetPoint.X - anchorPoint.X, targetPoint.Y - anchorPoint.Y);
            ptNew.X = anchorPoint.X - (ptShift.X * ((float)Math.Cos(dRotation * Math.PI / 180.0)) + ptShift.Y * ((float)Math.Sin(dRotation * Math.PI / 180.0)));
            ptNew.Y = anchorPoint.Y - (ptShift.X * (float)Math.Sin(dRotation * Math.PI / 180.0) - ptShift.Y * (float)Math.Cos(dRotation * Math.PI / 180.0));
            return ptNew;
        }
    }


}
