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


        private Fragment loginFragment;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            loginFragment = LoginFragment.NewInstance();


            // Attach event handler to BottomNavigationView
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            // Create your fragment here
            
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
                    FragmentManager.BeginTransaction().Replace(Resource.Id.content_frame, LoginFragment.NewInstance()).Commit();
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

