
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
        public override void OnCreate(Bundle savedInstanceState) => base.OnCreate(savedInstanceState);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.NotaLayout, container, false);

            return view;
        }
    }
}
