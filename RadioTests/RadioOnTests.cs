using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RadioApp;

namespace RadioTests
{
    class RadioOnTests
    {
        private RadioCode _radio;
        [SetUp]
        public void Setup()
        {
            _radio = new RadioCode();
            _radio.TurnOn();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ChangeToValidChannelTest(int newChannel)
        {
            _radio.Channel = newChannel;
            Assert.AreEqual(newChannel, _radio.Channel);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        public void ChangeToInvalidChannelTest(int newChannel)
        {
            // arrange
            _radio.Channel = 2;
            // act
            _radio.Channel = newChannel;
            // assert
            Assert.AreEqual(2, _radio.Channel);
        }
        [Test]
        public void PlayTest()
        {
            // arrange
            _radio.Channel = 4;
            // act
            var message = _radio.PlayN();
            // assert
            Assert.AreEqual("Playing channel 4", message);

        }

        [Test]
        public void TurnOffTest()
        {
            _radio.TurnOff();
            Assert.AreEqual("Radio is off", _radio.PlayN());
        }
    }
}
