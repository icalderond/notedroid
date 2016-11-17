
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

        Activity activity;
        AppPersistence persistencia;
        public override void OnCreate(Bundle savedInstanceState) => base.OnCreate(savedInstanceState);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.NotaLayout, container, false);

            etTitulo = view.FindViewById<EditText>(Resource.Id.etTitulo);
            etContenido = view.FindViewById<EditText>(Resource.Id.etContenido);
            btnGuardar = view.FindViewById<Button>(Resource.Id.btnGuardar);

            persistencia = new AppPersistence(activity);

            btnGuardar.Click += (s, _) =>
            {
                var titulo = etTitulo.Text;
                var contenido = etContenido.Text;
                var fecha = DateTime.Now;

                var lista = persistencia.ListaNotas;

                if (PosicionNota == -1)
                    lista.Add(new Nota() { Titulo = titulo, Contenido = contenido, FechaEdicion = fecha });
                else {
                    lista[PosicionNota].Titulo = titulo;
                    lista[PosicionNota].Contenido = contenido;
                    lista[PosicionNota].FechaEdicion = fecha;
                }

                persistencia.ListaNotas = lista;

                var notaFragment = new NotasFragment();
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
