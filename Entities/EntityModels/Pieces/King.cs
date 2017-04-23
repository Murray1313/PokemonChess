using Entities.Interfaces;
using System.Collections.Generic;
using PokemonChess;
using Entities.SharedEnums;
using System;

namespace Entities.EntityModels.Pieces
{
  public abstract class King : ChessPiece
  {
    public King(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public King(Enums.BlackOrWhite teamSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, Enums.BoardColumns.E)
                                                              : new Location(Enums.BoardRows.One, Enums.BoardColumns.E);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.King; } }

    #region IMoveMech implementation
    public override IEnumerable<Location> GetMovableSpaces(Board board)
    {
      List<Location> returnList = new List<Location>();
      General.GetLeft(board, this.Location, this.Side, returnList);
      General.GetUp(board, this.Location, this.Side, returnList);
      General.GetRight(board, this.Location, this.Side, returnList);
      General.GetDown(board, this.Location, this.Side, returnList);
      General.GetUpperLeft(board, this.Location, this.Side, returnList);
      General.GetUpperRight(board, this.Location, this.Side, returnList);
      General.GetLowerLeft(board, this.Location, this.Side, returnList);
      General.GetLowerRight(board, this.Location, this.Side, returnList);
      return returnList;
    }

    public override void SetMovableSpaces(Board board)
    {
      General.SetLeft(board, this.Location, this.Side);
      General.SetUp(board, this.Location, this.Side);
      General.SetRight(board, this.Location, this.Side);
      General.SetDown(board, this.Location, this.Side);
      General.SetUpperLeft(board, this.Location, this.Side);
      General.SetUpperRight(board, this.Location, this.Side);
      General.SetLowerLeft(board, this.Location, this.Side);
      General.SetLowerRight(board, this.Location, this.Side);
    }
    #endregion
  }
}
