using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace e34
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {


        private Fragment _currentLoginFragment;

        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            LoginFragment lFrag = LoginFragment.NewInstance();
            lFrag.OnLoginCorrect += OnLogin;
            _currentLoginFragment = lFrag;


            // Attach event handler to BottomNavigationView
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            // Create your fragment here
            
        }

        private void OnLogin() {

            _currentLoginFragment = DevFragment.NewInstance();
            FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, _currentLoginFragment).Commit();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, CarFragment.NewInstance()).Commit();
                    return true;
                case Resource.Id.navigation_dashboard:
                    FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, _currentLoginFragment).Commit();
                    return true;
                case Resource.Id.navigation_notifications:
                    FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame,InfoFragment.NewInstance()).Commit();
                    return true;
            }
            return false;
        }

        public void OnClick(View v)
        {
            
        }
    }
}

