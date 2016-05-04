using System;
using System.Collections.Generic;
using UnityEngine;
namespace Gameplay
{

	public class BoardVictoryAnalyser
	{
		List<VictoryPatternStrategy> m_strategies = new List<VictoryPatternStrategy>(4);

		static VictoryPatternStrategy[] s_rows;
		static VictoryPatternStrategy[] s_columns;

		static BoardVictoryAnalyser()
		{
			FirstRow = new VictoryPatternStrategy (VictoryPattern.FirstRow);
			 SecondRow = new VictoryPatternStrategy (VictoryPattern.SecondRow);
			 ThirdRow = new VictoryPatternStrategy (VictoryPattern.ThirdRow);
			
			 FirstColumn = new VictoryPatternStrategy (VictoryPattern.FirstColumn);
			 SecondColumn = new VictoryPatternStrategy (VictoryPattern.SecondColumn);
			 ThirdColumn = new VictoryPatternStrategy (VictoryPattern.ThirdColumn);
			
			
			 LeftRightDiagonal = new VictoryPatternStrategy (VictoryPattern.LeftRightDiagonal);
			 RightLeftDiagonal = new VictoryPatternStrategy (VictoryPattern.RightLeftDiagonal);

			s_rows = new VictoryPatternStrategy[]{FirstRow,SecondRow,ThirdRow};
			s_columns = new VictoryPatternStrategy[]{FirstColumn,SecondColumn,ThirdColumn};
		}

		public bool Contains(VictoryPatternStrategy strategie)
		{
			return m_strategies.Contains (strategie);
		}

		public VictoryState Check(IBoard board)
		{
			for(int i=0;i<m_strategies.Count;++i)
			{
				var strategie = m_strategies [i];
				var checkResult = strategie.Check (board);
		
				if (!checkResult.Equals (Player.None))
					return new VictoryState (checkResult, strategie.Pattern);
		
			}

			return VictoryState.Indetermined;
		}

		public BoardVictoryAnalyser(Point p)
		{
			
			m_strategies.Add (s_rows[p.Y]);
			m_strategies.Add (s_columns[p.X]);

			if (p.X == p.Y)
			{
				
				m_strategies.Add (LeftRightDiagonal);

				if(p.X == 1)
					m_strategies.Add (RightLeftDiagonal);
			}

			if(Math.Abs(p.X-p.Y) == 2 && !m_strategies.Contains(RightLeftDiagonal))
				m_strategies.Add (RightLeftDiagonal);
		
		}

		public static VictoryPatternStrategy FirstRow; 
		public static VictoryPatternStrategy SecondRow;
		public static VictoryPatternStrategy ThirdRow; 

		public static VictoryPatternStrategy FirstColumn; 
		public static VictoryPatternStrategy SecondColumn;
		public static VictoryPatternStrategy ThirdColumn; 


		public static VictoryPatternStrategy LeftRightDiagonal;
		public static VictoryPatternStrategy RightLeftDiagonal;

			
		public static IList<VictoryPatternStrategy> All
		{
			get {
				return new List<VictoryPatternStrategy>{ 
					FirstRow,SecondRow,ThirdRow, FirstColumn,SecondColumn,
					ThirdColumn, LeftRightDiagonal,RightLeftDiagonal,
				};
			}
		}
	}
}

