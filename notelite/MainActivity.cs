using Android.App;
using Android.Widget;
using Android.OS;
using notelite.Fragments;

namespace notelite
{
    [Activity(Label = "notelite", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var fragment = new LoginFragment();
            var fragmentManager = FragmentManager.BeginTransaction();
            fragmentManager.Add(Resource.Id.fragment_container, fragment);
            fragmentManager.Commit();
        }
    }
}

