using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace e34 {
    public class DevFragment : Fragment {



        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);


        }

        public static DevFragment NewInstance() {
            var frag = new DevFragment { Arguments = new Bundle() };
            return frag;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="inflater"></param>
        /// <param name="container"></param>
        /// <param name="savedInstanceState"></param>
        /// <returns></returns>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_dev, container, false);

            view.FindViewById<Button>(Resource.Id.btnTest).Click += delegate {
                OnTestClick();
            };
            view.FindViewById<Button>(Resource.Id.btnStresstest).Click += delegate {
                OnStressTestClick();
            };

            return view;
        }

        private void OnStressTestClick() {
            BluetoothSerialService.Instance.WriteSerial("7");
        }

        private void OnTestClick() {
            BluetoothSerialService.Instance.WriteSerial("6");
        }
    }
}