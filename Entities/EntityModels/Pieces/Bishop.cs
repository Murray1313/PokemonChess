using Entities.Interfaces;
using System.Collections.Generic;
using PokemonChess;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces
{
  public abstract class Bishop : ChessPiece
  {
    public Bishop(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }
    public Bishop(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, pieceSide)
                                                              : new Location(Enums.BoardRows.One, pieceSide);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Bishop; } }

    #region IMoveMech Implementation
    public override IEnumerable<Location> GetMovableSpaces(Board board)
    {
      List<Location> returnList = new List<Location>();
      General.RecursiveGetUpperLeft(board, this.Location, this.Side, returnList);
      General.RecursiveGetUpperRight(board, this.Location, this.Side, returnList);
      General.RecursiveGetLowerLeft(board, this.Location, this.Side, returnList);
      General.RecursiveGetLowerRight(board, this.Location, this.Side, returnList);
      return returnList;
    }

    public override void SetMovableSpaces(Board board)
    {
      General.RecursiveSetUpperLeft(board, this.Location, this.Side);
      General.RecursiveSetUpperRight(board, this.Location, this.Side);
      General.RecursiveSetLowerLeft(board, this.Location, this.Side);
      General.RecursiveSetLowerRight(board, this.Location, this.Side);
    }
    #endregion
  }
}
