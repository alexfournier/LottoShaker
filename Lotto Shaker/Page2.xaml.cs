using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;
using System.Windows.Media;

namespace Lotto_Shaker
{
    public partial class Page2 : PhoneApplicationPage
    {
        int highestNum;
        int numsToPick;
        List<int> lottoNums;
        Random rdnNumber;
        bool isAccelOn = false;
        
        public Page2()
        {
            InitializeComponent();
            lottoNums = new List<int>();
            rdnNumber = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));

            myShaker = new shaker();

        }

        private void rdmNmTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            setLotteryParam();
            
            if (isAccelOn == false)
            {
                // turn on accelerometer
                rdmNum.Background = new SolidColorBrush(Colors.Red);
                myShaker.StartAccelerometer();
                myShaker.Shook += new EventHandler(ShookDevice);
                isAccelOn = true;
            }
            else
            {
                rdmNum.Background = new SolidColorBrush(Colors.Black);
                myShaker.StopAccelerometer();
                myShaker.Shook -= new EventHandler(ShookDevice);
                isAccelOn = false;
            }
        }

        private void ShookDevice(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(SensorReadingEventArgs<AccelerometerReading>))
            {
                Dispatcher.BeginInvoke(() => UpdateUI());
            }
        }

        void UpdateUI()
        {
            lottoNums.Clear();
            int num;

            for (int i = 0; i < numsToPick; i++)
            {
                do
                {
                    num = rdnNumber.Next(1, highestNum + 1);
                } while (isNumberChosen(num));

                lottoNums.Add(num);
            }
            ShowNumbers();
        }

        void ShowNumbers()
        {
            int blockNum = 1;

            foreach (int num in lottoNums)
            {

                string name = "pickBlock" + blockNum.ToString();
                TextBlock curBlock = (TextBlock)this.FindName(name);
                if (curBlock != null)
                {
                    curBlock.Text = num.ToString();
                }
                blockNum++;

                if (blockNum > 6)
                    break;
            }
        }

        private bool isNumberChosen(int num)
        {
            bool found = false;

            foreach (int number in lottoNums)
            {
                if (number == num)
                {
                    found = true;
                }
            }
            return found;
        }

        void setLotteryParam()
        {
            switch (MainPage.chosenLottery)
            {
                case Lottery.lotto649:
                    highestNum = 49;
                    numsToPick = 6;
                    break;
                case Lottery.lottoMax:
                    highestNum = 46;
                    numsToPick = 6;
                    break;
                case Lottery.ont49:
                    highestNum = 44;
                    numsToPick = 6;
                    break;
                case Lottery.qc49:
                    highestNum = 39;
                    numsToPick = 6;
                    break;
                case Lottery.bc49:
                    highestNum = 49;
                    numsToPick = 6;
                    break;
                case Lottery.megaMill:
                    highestNum = 59;
                    numsToPick = 5;
                    break;
            }
        }

        internal shaker myShaker { get; set; }
    }
}