using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Tabs;
using System;

namespace tablayout
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TabLayout _tabLayout;
        private TextView _textView;

        public EventHandler<TabLayout.TabSelectedEventArgs> TabLayout_TabSelected { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            _textView = FindViewById<TextView>(Resource.Id.textView);
            SetTabTitle();
            _tabLayout.TabSelected += _tabLayout_TabSelected;
        }



        private void _tabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    _textView.SetText(Resource.String.home);
                    break;
                case 1:
                    _textView.SetText(Resource.String.dashboard);
                    break;
                case 2:
                    _textView.SetText(Resource.String.notification);
                    break;
            }
        }

        private void SetTabTitle()
        {
            _tabLayout.AddTab(_tabLayout.NewTab().SetText(Resource.String.home));
            _tabLayout.AddTab(_tabLayout.NewTab().SetText(Resource.String.dashboard));
            _tabLayout.AddTab(_tabLayout.NewTab().SetText(Resource.String.notification));

        }

        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}