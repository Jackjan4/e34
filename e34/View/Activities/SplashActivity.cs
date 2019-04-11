using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Threading;
using System.Timers;

namespace e34
{
    [Activity(MainLauncher = true, Theme = "@style/SplashTheme", NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_splashscreen);
        }

        protected override void OnResume()
        {
            base.OnResume();

            BluetoothSerialService btService = BluetoothSerialService.Instance;

            if (btService.PairedDeviceExists("e34"))
            {
                btService.ConnectToPairedDevice("e34", BluetoothSerialService.HC05_UUID_INSECURE);
                StartActivity(typeof(MainActivity));
            } else
            {
                
            TextView txtStatus = FindViewById<TextView>(Resource.Id.txtStatus);
            txtStatus.Text = "Fahrzeug nicht gekoppelt! Überprüfe deine Bluetooth-Einstellungen.";
                StartActivity(typeof(MainActivity));
            }
        }
    }
}