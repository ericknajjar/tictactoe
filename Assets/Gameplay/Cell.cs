using UnityEngine;
using System.Collections;

namespace Gameplay
{
	public struct Cell  
	{
		Player m_owner;
		public Player Owner { get{ return m_owner;}}

		public Cell(Player owner)
		{
			m_owner = owner;
		}
	}

}
