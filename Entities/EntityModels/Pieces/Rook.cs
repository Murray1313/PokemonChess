using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using PokemonChess;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces
{
  public abstract class Rook : ChessPiece
  {
    public Rook(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Rook(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, pieceSide)
                                                              : new Location(Enums.BoardRows.One, pieceSide);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Rook; } }

    #region IMoveMech implementation
    public override IEnumerable<Location> GetMovableSpaces(Board board)
    {
      List<Location> returnList = new List<Location>();
      General.RecursiveGetLeft(board, this.Location, this.Side, returnList);
      General.RecursiveGetUp(board, this.Location, this.Side, returnList);
      General.RecursiveGetRight(board, this.Location, this.Side, returnList);
      General.RecursiveGetDown(board, this.Location, this.Side, returnList);
      return returnList;
    }

    public override void SetMovableSpaces(Board board)
    {
      General.RecursiveSetLeft(board, this.Location, this.Side);
      General.RecursiveSetUp(board, this.Location, this.Side);
      General.RecursiveSetRight(board, this.Location, this.Side);
      General.RecursiveSetDown(board, this.Location, this.Side);
    }
    #endregion
  }
}
