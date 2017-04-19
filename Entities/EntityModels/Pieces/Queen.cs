using Entities.Interfaces;
using System.Collections.Generic;
using PokemonChess;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces
{
  public abstract class Queen : ChessPiece, IMoveMechanics
  {
    public Queen(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Queen(Enums.BlackOrWhite teamSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, Enums.BoardColumns.D)
                                                              : new Location(Enums.BoardRows.One, Enums.BoardColumns.D);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Queen; } }

    #region IMoveMechs implementation
    public IEnumerable<Location> GetQueenConquerableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      General.RecursiveGetLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetUp(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetRight(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetDown(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetLowerLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetUpperLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetLowerRight(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetUpperRight(board, piece.Location, piece.Side, returnList);
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      General.RecursiveSetLeft(board, piece.Location, piece.Side);
      General.RecursiveSetUp(board, piece.Location, piece.Side);
      General.RecursiveSetRight(board, piece.Location, piece.Side);
      General.RecursiveSetDown(board, piece.Location, piece.Side);
      General.RecursiveSetUpperLeft(board, piece.Location, piece.Side);
      General.RecursiveSetUpperRight(board, piece.Location, piece.Side);
      General.RecursiveSetLowerLeft(board, piece.Location, piece.Side);
      General.RecursiveSetLowerRight(board, piece.Location, piece.Side);
    }
    #endregion
  }
}
