
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

namespace notelite
{
    public class NotasFragment : Fragment
    {
        View view;
        ListView lvNotas;
        ImageView btnNuevaNota;

        Activity activity;

        List<string> listaNotas = new List<string>();
        public override void OnCreate(Bundle savedInstanceState) => base.OnCreate(savedInstanceState);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.NotasLayout, container, false);

            lvNotas = view.FindViewById<ListView>(Resource.Id.lvNotas);
            btnNuevaNota = view.FindViewById<ImageButton>(Resource.Id.btnNuevaNota);

            lvNotas.ItemClick += (s, a) =>
            {
                var notaFragment = new NotaFragment(a.Position)
                var fragmentManager = FragmentManager.BeginTransaction();
                fragmentManager.Replace(Resource.Id.fragment_container, notaFragment);
                fragmentManager.Commit();
            };
            btnNuevaNota.Click += (s, a) =>
            {
                var notaFragment = new NotaFragment();
                var fragmentManager = FragmentManager.BeginTransaction();
                fragmentManager.Replace(Resource.Id.fragment_container, notaFragment);
                fragmentManager.Commit();
            };
            return view;
        }
        public override void OnAttach(Activity activity)
        {
            this.activity = activity;
            base.OnAttach(activity);
        }
        public override void OnStart()
        {
            for (int i = 0; i < 15; i++)
                listaNotas.Add($"Esta es la nota {i}");

            lvNotas.Adapter = new ArrayAdapter<string>(activity, Android.Resource.Layout.SimpleListItem1, listaNotas);
            base.OnStart();
        }
    }
}