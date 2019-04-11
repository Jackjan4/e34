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

namespace e34
{
    public class LoginFragment : Fragment, View.IOnClickListener
    {

        public delegate void LoginDelegate();

        public event LoginDelegate OnLoginCorrect;

        private EditText txtPw;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
        }

        public static LoginFragment NewInstance()
        {
            var frag = new LoginFragment { Arguments = new Bundle() };
            return frag;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             View view = inflater.Inflate(Resource.Layout.fragment_login, container, false);

            txtPw = view.FindViewById<EditText>(Resource.Id.txtPw);

            Button btnLogin = view.FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.SetOnClickListener(this);



            return view;
        }



        public void OnClick(View v)
        {
            if (txtPw.Text == "jackjan") {
                OnLoginCorrect();
            }
        }
    }
}