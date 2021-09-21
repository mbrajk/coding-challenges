using System;
using System.Collections.Generic;
using System.Linq;

namespace FindWinner
{
    public class Solution
    {
        public string Tictactoe(int[][] moves)
        {
            var board = new Board();
            var result = "Pending";
            
            foreach (var move in moves)
            {
                result = board.UpdateCellOwner(move[0], move[1]);
            }

            return result;
        }
    }

    public class Board
    {
        private readonly Dictionary<Cell, Player> _cells;
        private Player _nextPlayer = Player.A;
        private int _remainingMoves = 9;

        private string Status => _remainingMoves == 0 ? "Draw" : "Pending";
        
        public Board()
        {
            _cells = Enumerable.Range(0, 3)
                .SelectMany(x =>
                    Enumerable.Range(0, 3)
                        .Select(y => 
                           new KeyValuePair<Cell,Player>(new Cell(x, y), Player.None)
                        )
                ).ToDictionary(a => a.Key, b => b.Value);
        }

        public string UpdateCellOwner(int x, int y)
        {
            _remainingMoves--;
            var cellToUpdate = new Cell(x, y);
            _cells[cellToUpdate] = _nextPlayer;
            
            if (_remainingMoves < 6)
            {
                var cellsByPlayers = _cells
                    .Where(c => c.Value != Player.None)
                    .GroupBy(a => a.Value);

                foreach (var cellsByPlayer in cellsByPlayers)
                {
                    var thePlayer = cellsByPlayer.Key;
                    var theCellsForThisPlayer = cellsByPlayer.Select(c => c.Key);
                    
                    foreach (var winCondition in WinConditions)
                    {
                        var winner = winCondition.All(wc => theCellsForThisPlayer.Contains(wc));
                        if (winner)
                        {
                            return thePlayer.ToString();
                        }
                    }
                }
            }
                        
            _nextPlayer = _nextPlayer == Player.A ? Player.B : Player.A;
            return Status;
        }
        
        private static readonly List<List<Cell>> WinConditions = new List<List<Cell>>
        {
            new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(0, 2)
            },
            new List<Cell>
            {
                new Cell(1, 0),
                new Cell(1, 1),
                new Cell(1, 2)
            },
            new List<Cell>
            {
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2)
            },
            new List<Cell>
            {
                new Cell(0, 0),
                new Cell(1, 0),
                new Cell(2, 0)
            },
            new List<Cell>
            {
                new Cell(0, 1),
                new Cell(1, 1),
                new Cell(2, 1)
            },
            new List<Cell>
            {
                new Cell(0, 2),
                new Cell(1, 2),
                new Cell(2, 2)
            },
            new List<Cell>
            {
                new Cell(0, 0),
                new Cell(1, 1),
                new Cell(2, 2)
            },
            new List<Cell>
            {
                new Cell(0, 2),
                new Cell(1, 1),
                new Cell(2, 0)
            },
        };
        
        class Cell : IEquatable<Cell>
        {
            public int X { get; }
            public int Y { get; }

            public Cell(int x, int y)
            {
                X = x;
                Y = y;
            }
            
            public bool Equals(Cell other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return X == other.X && Y == other.Y;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Cell) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }
    
        enum Player
        {
            A,
            B,
            None
        }
    }
}