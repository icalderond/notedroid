using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace notelite
{
    public class NotaAdapter : BaseAdapter
    {
        Activity activity;
        List<Nota> ListaNotas;
        public NotaAdapter(Activity _activity, IEnumerable<Nota> _listaNotas)
        {
            activity = _activity;
            ListaNotas = _listaNotas.ToList();
        }

        public override int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = activity.LayoutInflater.Inflate(Resource.Layout.ItemNotaTemplate, null);

            var tvTitulo = view.FindViewById<EditText>(Resource.Id.tvTitulo);
            var tvContenido = view.FindViewById<EditText>(Resource.Id.tvTitulo);
            var tvFecha = view.FindViewById<EditText>(Resource.Id.tvFecha);

            var currentNote = ListaNotas[position];

            tvTitulo.Text = currentNote.Titulo;
            tvContenido.Text = currentNote.Contenido;
            tvFecha.Text = currentNote.FechaEdicion.ToString("F");

            return view;
        }
    }
}
