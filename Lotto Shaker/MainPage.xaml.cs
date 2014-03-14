using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Lotto_Shaker.Resources;

namespace Lotto_Shaker
{
    public enum Lottery { None, lotto649, lottoMax, ont49, qc49, bc49, megaMill };

    public partial class MainPage : PhoneApplicationPage
    {

        public static Lottery chosenLottery;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void lotto649Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            chosenLottery = Lottery.lotto649;

            if (chosenLottery == Lottery.lotto649)
            {
                NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
            }
        }

        private void lottoMaxTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            chosenLottery = Lottery.lottoMax;

            if (chosenLottery == Lottery.lottoMax)
            {
                NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
            }
        }

        private void ont49Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            chosenLottery = Lottery.ont49;

            if (chosenLottery == Lottery.ont49)
            {
                NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
            }
        }

        private void qc49Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            chosenLottery = Lottery.qc49;

            if (chosenLottery == Lottery.qc49)
            {
                NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
            }
        }

        private void bc49Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            chosenLottery = Lottery.bc49;

            if (chosenLottery == Lottery.bc49)
            {
                NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
            }
        }

        private void megaMillTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            chosenLottery = Lottery.megaMill;

            if (chosenLottery == Lottery.megaMill)
            {
                NavigationService.Navigate(new Uri("/page2.xaml", UriKind.Relative));
            }
        }
    }
}