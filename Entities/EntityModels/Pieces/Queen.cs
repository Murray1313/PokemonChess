using Entities.Interfaces;
using System.Collections.Generic;
using PokemonChess;
using Entities.SharedEnums;
using System;

namespace Entities.EntityModels.Pieces
{
  public abstract class Queen : ChessPiece
  {
    public Queen(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Queen(Enums.BlackOrWhite teamSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, Enums.BoardColumns.D)
                                                              : new Location(Enums.BoardRows.One, Enums.BoardColumns.D);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Queen; } }

    #region IMoveMechs implementation
    public override IEnumerable<Location> GetMovableSpaces(Board board)
    {
      List<Location> returnList = new List<Location>();
      General.RecursiveGetLeft(board, this.Location, this.Side, returnList);
      General.RecursiveGetUp(board, this.Location, this.Side, returnList);
      General.RecursiveGetRight(board, this.Location, this.Side, returnList);
      General.RecursiveGetDown(board, this.Location, this.Side, returnList);
      General.RecursiveGetLowerLeft(board, this.Location, this.Side, returnList);
      General.RecursiveGetUpperLeft(board, this.Location, this.Side, returnList);
      General.RecursiveGetLowerRight(board, this.Location, this.Side, returnList);
      General.RecursiveGetUpperRight(board, this.Location, this.Side, returnList);
      return returnList;
    }

    public override void SetMovableSpaces(Board board)
    {
      General.RecursiveSetLeft(board, this.Location, this.Side);
      General.RecursiveSetUp(board, this.Location, this.Side);
      General.RecursiveSetRight(board, this.Location, this.Side);
      General.RecursiveSetDown(board, this.Location, this.Side);
      General.RecursiveSetUpperLeft(board, this.Location, this.Side);
      General.RecursiveSetUpperRight(board, this.Location, this.Side);
      General.RecursiveSetLowerLeft(board, this.Location, this.Side);
      General.RecursiveSetLowerRight(board, this.Location, this.Side);
    }
    #endregion
  }
}
