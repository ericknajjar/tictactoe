using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gameplay
{
	
public class GameState 
{

		public GameState(Player player)
		{

		}

		public IList<object> PossibleMoves
		{
			get{return new List<object>{1,1,1,1,1,1,1,1,1};}
		}
	
}

}
