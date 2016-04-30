using UnityEngine;
using System.Collections;

namespace Gameplay
{
	public class Cell  
	{

		public Player Owner { get; private set;}

		public Cell(Player owner)
		{
			Owner = owner;
		}
	}

}
