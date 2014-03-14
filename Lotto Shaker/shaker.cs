using Microsoft.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lotto_Shaker
{
    class shaker
    {
        public Accelerometer accelerometer;
        private AccelerometerReading lastReading;  // store last value of accelerometer data
        const float ReadingThreshold = 0.1f; // threshold to determine how much we shake
        public event EventHandler Shook; // hold the shaker event we will send to the ui

        public shaker()
        {
            if (!Accelerometer.IsSupported)
                MessageBox.Show("Accelerometer not supported");
        }

        public void StartAccelerometer()
        {
            if (accelerometer == null)
            {
                accelerometer = new Accelerometer();
                accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(500); // how fast to retrieve the data
                accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
            }
            try
            {
                accelerometer.Start();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("failed to start accel.");
            }
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            if (Math.Abs(lastReading.Acceleration.X - e.SensorReading.Acceleration.X) > ReadingThreshold)
            {
                if (Shook != null)
                {
                    Shook(this, e); // call ui shook event
                }
            }

            lastReading = e.SensorReading;
        }

        public void StopAccelerometer()
        {
            if (accelerometer != null)
            {
                accelerometer.Stop();
            }
        }
    }
}
