using System;

namespace Gameplay
{
	public interface IBoard
	{
		Cell this [Point p]{ get;}
	}
}

