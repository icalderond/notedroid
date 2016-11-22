
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
using notelite.ServiceNotas;

namespace notelite
{
    public class NotasFragment : Fragment
    {
        View view;
        ListView lvNotas;
        ImageView btnNuevaNota;

        Activity activity;
        AppPersistence persistencia;

        LogicaNotas service;
        public override void OnCreate(Bundle savedInstanceState) => base.OnCreate(savedInstanceState);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.NotasLayout, container, false);

            lvNotas = view.FindViewById<ListView>(Resource.Id.lvNotas);
            btnNuevaNota = view.FindViewById<ImageButton>(Resource.Id.btnNuevaNota);

            persistencia = new AppPersistence(activity);
            service = new LogicaNotas();
            lvNotas.ItemClick += (s, a) =>
            {
                var notaFragment = new NotaFragment(a.Position);
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

            service.GetNotasCompleted += (s, a) =>
            {
                persistencia.ListaNotas = a.Result.ToList();
                lvNotas.Adapter = new NotaAdapter(activity, persistencia.ListaNotas);
            };
            service.AddNoteCompleted += (s, a) =>
            {

                //Agregado correctamente
            };
            service.DeleteNotaCompleted += (s, a) =>
            {
                //Borrado correctamente
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
            service.GetNotasAsync();
            base.OnStart();
        }
    }
}