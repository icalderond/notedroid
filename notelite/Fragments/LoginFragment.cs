
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
        View view;
        EditText etUsuario;
        EditText etClave;
        Button btnEntrar;
        public override void OnCreate(Bundle savedInstanceState) => base.OnCreate(savedInstanceState);


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.LoginLayout, container, false);
            etUsuario = view.FindViewById<EditText>(Resource.Id.etUsuario);
            etClave = view.FindViewById<EditText>(Resource.Id.etClave);
            btnEntrar = view.FindViewById<Button>(Resource.Id.btnEntrar);


            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}
