using System;
using System.Threading;
using System.Device.Gpio;
using nanoFramework.Bluetooth.Hid;
using nanoFramework.Bluetooth.Hid.Devices;

namespace Bouton_E04
{
    public class Program
    {
        // Création des alias pour les boutons
        private static GpioPin _btn1;
        private static GpioPin _btn2;
        private static GpioPin _btn3;
        private static GpioPin _btn4;

        // Création des alias pour les DELs
        private static GpioPin _del1Rouge;
        private static GpioPin _del1Vert;
        private static GpioPin _del2Rouge;
        private static GpioPin _del2Vert;

        // Création d'un clavier Bluetooth
        private static Keyboard kbd;

        public static void Main()
        {
            
            // Création d'un clavier Bluetooth
            kbd = new Keyboard(deviceName: "nF BLE Keyboard",
                deviceInfo: new DeviceInformation("nF", "BLEKBD1", "1", "01", "01", "01"),
                protocolMode: ProtocolMode.Report,
                plugAndPlayElements: new PnpElements(sig: 0x02, vid: 0xE502, pid: 0xA111, version: 0x210));

            // Création d'un objet GpioController
            var controller = new GpioController();

            // Association des broches aux alias
            _btn1 = controller.OpenPin(23, PinMode.Input);
            _btn2 = controller.OpenPin(22, PinMode.Input);
            _btn3 = controller.OpenPin(21, PinMode.Input);
            _btn4 = controller.OpenPin(19, PinMode.Input);
            _del1Rouge = controller.OpenPin(4, PinMode.Output);
            _del1Vert = controller.OpenPin(0, PinMode.Output);
            _del2Rouge = controller.OpenPin(2, PinMode.Output);
            _del2Vert = controller.OpenPin(15, PinMode.Output);

            _del1Rouge.Write(PinValue.Low);
            _del1Vert.Write(PinValue.Low);
            _del2Rouge.Write(PinValue.Low);
            _del2Vert.Write(PinValue.Low);

            kbd.Initialize();
            kbd.Advertise();

            string debounce=null;

            while (true)
            {
                if (_btn1.Read() == PinValue.High && debounce != "btn1")
                {
                    KeyboardUtilities.TypeText(kbd, "1");
                    debounce = "btn1";
                    _del1Rouge.Write(PinValue.High);
                    Thread.Sleep(100);
                    _del1Vert.Write(PinValue.Low);
                    Thread.Sleep(100);
                }

                if (_btn2.Read() == PinValue.High && debounce != "btn2")
                {
                    KeyboardUtilities.TypeText(kbd, "2");
                    debounce = "btn2";
                    _del1Rouge.Write(PinValue.Low);
                    Thread.Sleep(100);
                    _del1Vert.Write(PinValue.High);
                    Thread.Sleep(100);
                }

                if (_btn3.Read() == PinValue.High && debounce != "btn3")
                {
                    KeyboardUtilities.TypeText(kbd, "3");
                    debounce = "btn3";
                    _del2Rouge.Write(PinValue.Low);
                    Thread.Sleep(100);
                    _del2Vert.Write(PinValue.High);
                    Thread.Sleep(100);
                }

                if (_btn4.Read() == PinValue.High && debounce != "btn4")
                {
                    KeyboardUtilities.TypeText(kbd, "4");
                    debounce = "btn4";
                    _del1Rouge.Write(PinValue.Low);
                    Thread.Sleep(100);
                    _del1Vert.Write(PinValue.High);
                    Thread.Sleep(100);
                    _del2Rouge.Write(PinValue.Low);
                    Thread.Sleep(100);
                    _del2Vert.Write(PinValue.High);
                    Thread.Sleep(100);
                }

                //if (debounce == "btn1")
                //{
                //    _del1Rouge.Write(PinValue.High);
                //    _del1Vert.Write(PinValue.Low);
                //}

                //if (debounce == "btn2")
                //{
                //    _del1Rouge.Write(PinValue.Low);
                //    _del1Vert.Write(PinValue.High);
                //}

                //if (debounce == "btn3")
                //{
                //    _del2Rouge.Write(PinValue.Low);
                //    _del2Vert.Write(PinValue.High);
                //}

                //if (debounce == "btn4")
                //{
                //    _del1Rouge.Write(PinValue.Low);
                //    _del1Vert.Write(PinValue.High);
                //    _del2Rouge.Write(PinValue.Low);
                //    _del2Vert.Write(PinValue.High);
                //}
            }
        }
    }
}
