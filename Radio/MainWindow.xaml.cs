using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RadioApp;
using System.IO;

namespace Radio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RadioCode r = new RadioCode();
       
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(@"C:\Users\TECH-W150birm\Documents\Lyrics\RadioInfo.json"))
            { 
                r.Read();
            }
            else
            {
                r.Write();
            }
            r.Read();
            Player.Volume = r.VolumeChange();
            VolumeNumber.Text = $"{r.Volume}";
            RadioStatus.Text = $"{r.RadioStatus()}";
            ChannelStatus.Text = $"{r.PlayN()}";
        }
        //if (File.Exists(@"C:\Users\TECH-W150birm\Documents\Lyrics\RadioInfo.json"))
        //    {               
        //        r.Read();
        //    }
        private void PowerButton_Click_1(object sender, RoutedEventArgs e)
        {

            if (r.RadioStatus() == "Radio is on")
            {
                OnSlider.Visibility = Visibility.Collapsed;
                OffSlider.Visibility = Visibility.Visible;               
                //PowerButton.ImageSource = new BitmapImage(new Uri("trainblue.gif", UriKind.Relative));
                ;
                r.TurnOff();
                Player.Stop();
                ChannelStatus.Text = $"{r.PlayN()}";
                //r.Write();
            }

            else if (r.RadioStatus() == "Radio is off")
            {
                OffSlider.Visibility = Visibility.Collapsed;
                OnSlider.Visibility = Visibility.Visible;
                r.TurnOn();
                ChannelStatus.Text = $"{r.PlayN()}";
                //r.Write();
            }

            RadioStatus.Text = $"{r.RadioStatus()}";

        }

        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{

        //}

        private void Channel1Radio_Checked(object sender, RoutedEventArgs e)
        {

            r.Channel = 1;
            ChannelStatus.Text = $"{r.PlayN()}";
            // BBC 5 News
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio5live_mf_p", UriKind.RelativeOrAbsolute);
            //Player.Play();
            PlayerOnOff();
            
        }

        private void Channel2Radio_Checked(object sender, RoutedEventArgs e)
        {

            r.Channel = 2;
            //r.Play();
            // BBC 5 Sports Extra
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio5extra_mf_p", UriKind.RelativeOrAbsolute);
            PlayerOnOff();
            ChannelStatus.Text = $"{r.PlayN()}";
            
        }

        private void Channel3Radio_Checked(object sender, RoutedEventArgs e)
        {

            r.Channel = 3;
            ChannelStatus.Text = $"{r.PlayN()}";
            // BBC World Service
            Player.Source = new Uri("http://wsdownload.bbc.co.uk/worldservice/meta/live/shoutcast/mp3/eieuk.pls", UriKind.RelativeOrAbsolute);
            PlayerOnOff();
            
        }

        private void Channel4Radio_Checked(object sender, RoutedEventArgs e)
        {

            r.Channel = 4;
            ChannelStatus.Text = $"{r.PlayN()}";
            // BBC 6 Music
            Player.Source = new Uri("http://bbcmedia.ic.llnwd.net/stream/bbcmedia_6music_mf_p", UriKind.RelativeOrAbsolute);
            PlayerOnOff();
            

        }

        private void VolumeUpButton_Click(object sender, RoutedEventArgs e)
        {

            r.Volume++;
            Player.Volume++;
            VolumeNumber.Text = $"{r.Volume}";
        }

        private void VolumeDownButton_Click(object sender, RoutedEventArgs e)
        {

            r.Volume--;
            Player.Volume--;
            VolumeNumber.Text = $"{r.Volume}";

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            r.Write();
        }

        private void PlayerOnOff()
        {
            if(r.PlayerOnOff() == true)
            {
                Player.Play();
            }
            else if(r.PlayerOnOff() == false)
            {
                Player.Stop();
            }
                
        }

        //private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    Player.Volume = (double)r.Volume;

        //}
    }

        //private void PowerButton_Click_2(object sender, RoutedEventArgs e)
        //{

        //}

        //private void PowerButton_Click(object sender, RoutedEventArgs e)
        //{

        //    MessageBox.Show("Hello");

        //}

        //private void PowerButton_Click_1(object sender, RoutedEventArgs e)
        //{

        //}
}


