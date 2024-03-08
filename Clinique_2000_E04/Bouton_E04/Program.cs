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
        private static GpioPin _btnRouge;
        private static GpioPin _btnBleu;
        private static GpioPin _btnVert;
        private static GpioPin _btnNoir;

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
            _btnRouge = controller.OpenPin(23, PinMode.Input);
            _btnBleu = controller.OpenPin(22, PinMode.Input);
            _btnVert = controller.OpenPin(21, PinMode.Input);
            _btnNoir = controller.OpenPin(19, PinMode.Input);
            _del1Rouge = controller.OpenPin(4, PinMode.Output);
            _del1Vert = controller.OpenPin(0, PinMode.Output);
            _del2Rouge = controller.OpenPin(2, PinMode.Output);
            _del2Vert = controller.OpenPin(15, PinMode.Output);

            _del1Rouge.Write(PinValue.Low);
            _del1Vert.Write(PinValue.Low);
            _del2Rouge.Write(PinValue.Low);
            _del2Vert.Write(PinValue.Low);

            kbd.Initialize();
            _del1Rouge.Write(PinValue.High);
            kbd.Advertise();
            _del2Rouge.Write(PinValue.High);


            while (true)
            {
                if (_btnRouge.Read() == PinValue.Low)
                {
                    _del1Rouge.Write(PinValue.High);
                    _del1Vert.Write(PinValue.Low);
                }
                else
                {
                    _del1Rouge.Write(PinValue.Low);
                    _del1Vert.Write(PinValue.High);
                }

                if (_btnBleu.Read() == PinValue.Low)
                {
                    _del2Rouge.Write(PinValue.High);
                    _del2Vert.Write(PinValue.Low);
                }
                else
                {
                    _del2Rouge.Write(PinValue.Low);
                    _del2Vert.Write(PinValue.High);
                }

                _del1Rouge.Write(PinValue.Low);
                _del1Vert.Write(PinValue.High);

                if (!kbd.IsConnected)
                {
                    _del2Rouge.Write(PinValue.Low);
                    _del2Vert.Write(PinValue.High);
                    Thread.Sleep(100);
                    continue;
                }

                Thread.Sleep(5000);

                kbd.Send(Keys.Modifiers.LeftGUI, Keys.Alphabet.R);
                KeyboardUtilities.TypeText(kbd, "Notepad");
                kbd.Send(Keys.Control.Return);

                // wait a bit for notepad to launch
                Thread.Sleep(1000);

                KeyboardUtilities.TypeText(kbd, "Hello, World. I want to play a game.");
            }
        }
    }
}
