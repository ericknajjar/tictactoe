using UnityEngine;
using System.Collections;
using u3dExtensions.Engine.Runtime;
using u3dExtensions.IOC;
using u3dExtensions.IOC.extensions;


namespace View
{
	public class GlobalContext
	{

		static GlobalContext s_instance;


		private GlobalContext()
		{
			var bindings = new ReflectiveBindingFinder(typeof(GlobalContext).Assembly);
			Context = new ReflectiveBindingContextFactory(bindings).CreateContext();
		}

		public IBindingContext Context
		{
			get;
			private set;
		}

		public static GlobalContext Instance
		{
			get {
				if(s_instance == null)
					s_instance = new GlobalContext();

				return s_instance;
			}
		}
			
	}
}
