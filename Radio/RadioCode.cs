using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RadioApp
{
    public class RadioCode

    {
        private int _channel = 1;
        private double _volume;

        string path = @"C:\Users\TECH-W150birm\Documents\Lyrics\RadioInfo.json";
        public double Volume 
        { 
            get { return _volume; } 
            set
            {
                if (value >= 0.00 && value <= 10.00)
                {
                    _volume = value;
                }
                    
            }
        }
        bool _on = false;

        public int Channel
        {
            get { return _channel; }
            set
            {
                if (_on == true)
                {
                    if (value > 0 && value < 5)
                    {
                        _channel = value;
                    }
                }

            }
        }

        public int SavedChannel
        {
            get { return _channel; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _channel = value;
                }
            }
        }

        public string PlayN()
        {
            if (_on == true)
            {
                //if (_channel == 0)
                //{
                //    return "Select Channel";
                //}
                //else
                //{
                    return $"Playing channel {_channel}";
                //}
                
            }
            else
            {
                return "Radio is off";
            }

        }

        


        public string TurnOff()
        {
            _on = false;
            return "Radio is off";
        }

        public string TurnOn()
        {
            _on = true;
            return "Radio is on";
        }

        public string RadioStatus()
        {
            if(_on == true)
            {
                return "Radio is on";
            }

            else
            {
                return "Radio is off";
            }
                
        }

        public double VolumeChange()
        {
            return _volume;
        }

        public void Write()
        {
            // RadioCode RadioInfo = new RadioCode();
            _channel = Channel;
            _volume = Volume;
            //RadioInfo._on = _on;


            string output = JsonConvert.SerializeObject(this);
            //Console.WriteLine(output);

            File.WriteAllText(path, output);

        }

        public void Read()
        {
            string jsonfile = File.ReadAllText(path);
            RadioCode deSerInfo = JsonConvert.DeserializeObject<RadioCode>(jsonfile);
            SavedChannel = deSerInfo.Channel;
            //Channel = deSerInfo.Channel;
            Volume = deSerInfo.Volume;
            // _on = deSerInfo._on;
            //Console.WriteLine($"Name: {deSerInfo.Fullname} Date of Birth: {deSerInfo.Dob} Academy: {deSerInfo.Academy} Age:{deSerInfo.Age}");
        }

        public bool PlayerOnOff()
        {
            if (_on == true)
            {
                return true;
            }
            else if (_on == false)
            {
                return false;
            }
            else
            {
                return false;
            }

        }
    }
}
