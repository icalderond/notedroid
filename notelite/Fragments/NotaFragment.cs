
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class NotaFragment : Fragment
    {

        int PosicionNota;
        public NotaFragment(int _posicion = -1)
        {
            PosicionNota = _posicion;
        }

        View view;
        EditText etTitulo;
        EditText etContenido;
        Button btnGuardar;
        Button btnBorrar;

        Activity activity;
        AppPersistence persistencia;
        LogicaNotas service;
        public override void OnCreate(Bundle savedInstanceState) => base.OnCreate(savedInstanceState);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.NotaLayout, container, false);

            etTitulo = view.FindViewById<EditText>(Resource.Id.etTitulo);
            etContenido = view.FindViewById<EditText>(Resource.Id.etContenido);
            btnGuardar = view.FindViewById<Button>(Resource.Id.btnGuardar);
            btnBorrar = view.FindViewById<Button>(Resource.Id.btnBorrar);

            service = new LogicaNotas();
            service.AddNoteCompleted += service_AddNoteCompleted;
            service.DeleteNotaCompleted += service_DeleteNotaCompleted;
            service.UpdateNotaCompleted += service_UpdateNotaCompleted;
            persistencia = new AppPersistence(activity);

            btnGuardar.Click += (s, _) =>
            {
                var titulo = etTitulo.Text;
                var contenido = etContenido.Text;
                var fecha = DateTime.Now;

                if (PosicionNota == -1)
                    service.AddNoteAsync(new Nota() { Titulo = titulo, Contenido = contenido, Fecha = fecha });
                else
                    service.UpdateNotaAsync(new Nota()
                    {
                        Id = persistencia.ListaNotas[PosicionNota].Id,
                        Titulo = titulo,
                        Contenido = contenido,
                        Fecha = fecha
                    });
            };
            btnBorrar.Click += (s, a) =>
            {
                var lista = persistencia.ListaNotas;
                //lista.RemoveAt(PosicionNota);
                //persistencia.ListaNotas = lista;
                service.DeleteNotaAsync(lista[PosicionNota].Id);

                var notaFragment = new NotasFragment();
                var fragmentManager = FragmentManager.BeginTransaction();
                fragmentManager.Replace(Resource.Id.fragment_container, notaFragment);
                fragmentManager.Commit();
            };
            if (PosicionNota == -1) btnBorrar.Visibility = ViewStates.Gone;
            return view;
        }

        void service_AddNoteCompleted(object sender, AddNoteCompletedEventArgs e) => setAndNavigate(e.Result);

        void service_DeleteNotaCompleted(object sender, DeleteNotaCompletedEventArgs e) => setAndNavigate(e.Result);

        void service_UpdateNotaCompleted(object sender, UpdateNotaCompletedEventArgs e) => setAndNavigate(e.Result);

        void setAndNavigate(Nota[] result)
        {
            persistencia.ListaNotas = result.ToList();
            var notaFragment = new NotasFragment();
            var fragmentManager = activity.FragmentManager.BeginTransaction();
            fragmentManager.Replace(Resource.Id.fragment_container, notaFragment);
            fragmentManager.Commit();
        }

        public override void OnAttach(Activity activity)
        {
            this.activity = activity;
            base.OnAttach(activity);
        }
        public override void OnStart()
        {
            if (PosicionNota != -1)
            {
                var currentNote = persistencia.ListaNotas[PosicionNota];
                etTitulo.Text = currentNote.Titulo;
                etContenido.Text = currentNote.Contenido;
            }
            base.OnStart();
        }
    }
}
