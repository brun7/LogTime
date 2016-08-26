using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LogTime
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IUserSettingsRepository _userSettingsRepository;

        public MainPage()
        {
            this.InitializeComponent();
            _userSettingsRepository = new UserSettingsRepository();
        }

        private void TimeInButton_Click( object sender, RoutedEventArgs e )
        {
            //DateTimeProvider.DateProvider = () => new DateTime( 2016, 7, 20, 4, 30, 0 );
            _userSettingsRepository.TimeIn =  DateTimeProvider.Now;
            TimeInTextBlock.Text = _userSettingsRepository.TimeIn.Value.ToString();
        }

        private void TimeOutButton_Click( object sender, RoutedEventArgs e )
        {
            if( _userSettingsRepository.TimeIn != null )
            {
                TimeSpan duration = DateTime.Now - (DateTime)_userSettingsRepository.TimeIn;

                HoursCalculatedTextBlock.Text = $"{duration.Hours.ToString()} Hours : {duration.Minutes} Minutes";
                TimeInTextBlock.Text = _userSettingsRepository.TimeIn.Value.ToString();
            }
        }
    }
}
