
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

namespace notelite.Fragments
{
    public class LoginFragment : Fragment
    {
        const string usuarioCorrecto = "usuario";
        const string claveCorrecta = "clave";

        View view;
        EditText etUsuario;
        EditText etClave;
        Button btnEntrar;

        Activity activity;

        public override void OnCreate(Bundle savedInstanceState) => base.OnCreate(savedInstanceState);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.LoginLayout, container, false);
            etUsuario = view.FindViewById<EditText>(Resource.Id.etUsuario);
            etClave = view.FindViewById<EditText>(Resource.Id.etClave);
            btnEntrar = view.FindViewById<Button>(Resource.Id.btnEntrar);

            btnEntrar.Click += (s, _) =>
            {
                var usuario = etUsuario.Text;
                var clave = etClave.Text;

                if (usuario == usuarioCorrecto)
                    if (clave == claveCorrecta)
                    {
                        var fragment = new NotasFragment();
                        var fragmentManager = FragmentManager.BeginTransaction();
                        fragmentManager.Replace(Resource.Id.fragment_container, fragment);
                        fragmentManager.Commit();
                    }
                    else
                        Toast.MakeText(activity, "La clave es incorrecta", ToastLength.Long).Show();
                else
                    Toast.MakeText(activity, "El usuario es incorrecta", ToastLength.Long).Show();
            };

            return view;
        }
        public override void OnAttach(Activity activity)
        {
            this.activity = activity;
            base.OnAttach(activity);
        }
    }
}
