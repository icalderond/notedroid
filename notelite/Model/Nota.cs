using System;
namespace notelite
{
	public class sssNota
	{
		public string IdNota
		{
			get;
			private set;
		} = Guid.NewGuid().ToString();
		public string Titulo
		{
			get;
			set;
		}
		public string Contenido
		{
			get;
			set;
		}
		public DateTime FechaEdicion
		{
			get;
			set;
		}
		public override string ToString() => $"{Titulo}";
	}
}
