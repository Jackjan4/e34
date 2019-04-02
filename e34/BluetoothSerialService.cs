using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace e34
{
    public class BluetoothSerialService
    {

        // HC-05 UUID  "00001101-0000-1000-8000-00805F9B34FB"
        public static readonly UUID HC05_UUID_SECURE = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");
        public static readonly UUID HC05_UUID_INSECURE = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");

        public static BluetoothSerialService Instance = new BluetoothSerialService();

        private BluetoothSocket _pairedSocket;

        public bool IsConnected {
            get {
                if (_pairedSocket == null)
                {
                    return false;
                }
                return _pairedSocket.IsConnected;
            }

        }
        private readonly BluetoothAdapter _adapter;



        /// <summary>
        /// 
        /// </summary>
        public BluetoothSerialService()
        {
            _adapter = BluetoothAdapter.DefaultAdapter;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BluetoothDevice GetPairedDevice(string name)
        {
            ICollection<BluetoothDevice> pairedColl = _adapter.BondedDevices;

            BluetoothDevice e34Device = pairedColl.Where(dev => dev.Name == name).FirstOrDefault();

            if (e34Device != null)
            {
                return e34Device;
            }

            return null;
        }



        /// <summary>
        /// Returns true if an paired BT device exists on the phone with the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool PairedDeviceExists(string name)
        {
            ICollection<BluetoothDevice> pairedColl = _adapter.BondedDevices;

            BluetoothDevice device = pairedColl.Where(dev => dev.Name == name).FirstOrDefault();

            if (device != null)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="uuid"></param>
        public void ConnectToPairedDevice(string name, UUID uuid)
        {
            BluetoothDevice device = GetPairedDevice(name);

            if (device != null)
            {
                BluetoothSocket socket = device.CreateInsecureRfcommSocketToServiceRecord(uuid);
                socket.Connect();
                _pairedSocket = socket;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public bool WriteSerial(string msg)
        {
            if (IsConnected)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                _pairedSocket.OutputStream.Write(bytes, 0, bytes.Length);
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool InputAvailable()
        {
            if (!IsConnected)
            {
                return false;
            }
            return _pairedSocket.InputStream.Length > 0;
        }
    }
}