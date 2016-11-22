using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using notelite.ServiceNotas;

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
				return ListaNotas.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position) => ListaNotas[position].ToString();

		public override long GetItemId(int position) => ListaNotas[position].GetHashCode();

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = activity.LayoutInflater.Inflate(Resource.Layout.ItemNotaTemplate, null);

			var tvTitulo = view.FindViewById<TextView>(Resource.Id.tvTitulo);
			var tvContenido = view.FindViewById<TextView>(Resource.Id.tvContenido);
			var tvFecha = view.FindViewById<TextView>(Resource.Id.tvFecha);

			var currentNote = ListaNotas[position];

			tvTitulo.Text = currentNote.Titulo;
			tvContenido.Text = currentNote.Contenido;
			tvFecha.Text = currentNote.Fecha.Value.ToString("F");

			return view;
		}
	}
}