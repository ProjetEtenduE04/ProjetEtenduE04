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
            Console.WriteLine("Clavier créé avec succès");

            // Création d'un objet GpioController
            var controller = new GpioController();
            Console.WriteLine("GpioController créé avec succès");

            // Association des broches aux alias
            // Ce bloc de broches gère les boutons
            _btn1 = controller.OpenPin(23, PinMode.Input);
            _btn2 = controller.OpenPin(22, PinMode.Input);
            _btn3 = controller.OpenPin(21, PinMode.Input);
            _btn4 = controller.OpenPin(19, PinMode.Input);
            Console.WriteLine("Boutons associés avec succès");

            // Ce bloc de broches gère les DELs
            _del1Rouge = controller.OpenPin(4, PinMode.Output);
            _del1Vert = controller.OpenPin(16, PinMode.Output);
            _del2Rouge = controller.OpenPin(2, PinMode.Output);
            _del2Vert = controller.OpenPin(15, PinMode.Output);
            Console.WriteLine("DELs associées avec succès");

            // Mise à l'état bas des DELs
            _del1Rouge.Write(PinValue.Low);
            _del1Vert.Write(PinValue.Low);
            _del2Rouge.Write(PinValue.Low);
            _del2Vert.Write(PinValue.Low);
            Console.WriteLine("DELs à l'état bas");

            // Initialisation du clavier
            kbd.Initialize();
            Console.WriteLine("Clavier initialisé avec succès");
            kbd.Advertise();
            Console.WriteLine("Clavier en mode publicité");

            // String utilisé pour le debounce
            // Empèche la répétition de l'envoi de la touche
            string debounce = null;

            // Si le clavier n'est pas connecté, la DEL1 est rouge
            Console.WriteLine("Clavier non connecté");
            while (!kbd.IsConnected)
            {
                //Thread.Sleep(100);
                _del1Rouge.Write(PinValue.High);
                _del1Vert.Write(PinValue.Low);
                _del2Rouge.Write(PinValue.Low);
                _del2Vert.Write(PinValue.Low);
                continue;
            }

            // Si le clavier est connecté, la DEL1 est verte
            if (kbd.IsConnected)
            {
                Console.WriteLine("Clavier connecté");
                //Thread.Sleep(100);
                _del1Rouge.Write(PinValue.Low);
                _del1Vert.Write(PinValue.High);
                _del2Rouge.Write(PinValue.Low);
                _del2Vert.Write(PinValue.High);
            }

            // Boucle principale
            Console.WriteLine("Début de la boucle principale");
            while (true)
            {
                


                // Prochain patient
                if (_btn1.Read() == PinValue.High && debounce != "btn1")
                {
                    Console.WriteLine("Bouton 1 pressé");
                    kbd.Send(Keys.Numeric.Keyboard1);
                    //debounce = "btn1";
                    _del2Rouge.Write(PinValue.High);
                    _del2Vert.Write(PinValue.Low);
                }

                // Début de la consultation
                // Pas présentement géré par le site
                if (_btn2.Read() == PinValue.High && debounce != "btn2")
                {
                    Console.WriteLine("Bouton 2 pressé");
                    kbd.Send(Keys.Numeric.Keyboard2);
                    //debounce = "btn2";
                    _del2Rouge.Write(PinValue.High);
                    _del2Vert.Write(PinValue.Low);
                }

                // Fin de la consultation
                if (_btn3.Read() == PinValue.High && debounce != "btn3")
                {
                    Console.WriteLine("Bouton 3 pressé");
                    kbd.Send(Keys.Numeric.Keyboard3);
                    //debounce = "btn3";
                    _del2Rouge.Write(PinValue.Low);
                    _del2Vert.Write(PinValue.High);
                }

                // Fin de la consultation et appel du prochain patient
                if (_btn4.Read() == PinValue.High && debounce != "btn4")
                {
                    Console.WriteLine("Bouton 4 pressé");
                    kbd.Send(Keys.Numeric.Keyboard4);
                    //debounce = "btn4";
                    _del2Rouge.Write(PinValue.High);
                    _del2Vert.Write(PinValue.Low);
                }
            }
        }
    }
}
