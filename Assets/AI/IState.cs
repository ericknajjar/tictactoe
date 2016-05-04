using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AI
{
	
	public interface IState<Move>
	{
		int Score{ get;}
		IList<Move> AllMoves{get;}
		IState<Move> Pick(Move move);
		bool IsEndState{ get;}
		bool Min{ get;}
	}
}