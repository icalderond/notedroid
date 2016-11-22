using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Newtonsoft.Json;
using notelite.ServiceNotas;

namespace notelite
{
	public class AppPersistence
	{
		Activity activity;
		public ISharedPreferences preferencias;//Obtiene las preferencias
		public ISharedPreferencesEditor editor_preferencias;//Habilita la opcion para editar las preferencias

		public AppPersistence(Activity _activity)
		{
			this.activity = _activity;
			preferencias = activity.GetSharedPreferences("NOTEDROID_PREF", FileCreationMode.Private);
			editor_preferencias = preferencias.Edit();
		}

		public List<Nota> ListaNotas
		{
			get
			{
				var valueString = preferencias.GetString("LISTA_NOTAS", "");
				if (valueString != "")
					return JsonConvert.DeserializeObject<List<Nota>>(valueString);
				return new List<Nota>();
			}
			set
			{
				editor_preferencias.PutString("LISTA_NOTAS", JsonConvert.SerializeObject(value));
				editor_preferencias.Commit();
			}
		}
	}
}
