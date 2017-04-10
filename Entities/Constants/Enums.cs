using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.SharedEnums
{
  public static class Enums
  {

    public enum BlackOrWhite : int
    {
      None = 0,
      White = 1,
      Black = 2
    }

    public enum TeamType : int
    {
      None = 0,
      Water = 1,
      Grass = 2,
      Fire = 3,
      Poison = 4
    }

    public enum BoardRows : int
    {
      One = 0,
      Two = 1,
      Three = 2,
      Four = 3,
      Five = 4,
      Six = 5,
      Seven = 6,
      Eight = 7
    }

    public enum BoardColumns : int
    {
      A = 0,
      B = 1,
      C = 2,
      D = 3,
      E = 4,
      F = 5,
      G = 6,
      H = 7
    }

    public enum Pieces : int
    {
      NA = 0,
      King = 1,
      Queen = 2,
      Rook = 3,
      Bishop = 4,
      Knight = 5,
      Pawn = 6
    }
  }
}
