using System;
using Android.App;
using Android.Content;

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
    }
}
