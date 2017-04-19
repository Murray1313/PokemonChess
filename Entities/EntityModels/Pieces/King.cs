using Entities.Interfaces;
using System.Collections.Generic;
using PokemonChess;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces
{
  public abstract class King : ChessPiece, IMoveMechanics
  {
    public King(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public King(Enums.BlackOrWhite teamSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, Enums.BoardColumns.E)
                                                              : new Location(Enums.BoardRows.One, Enums.BoardColumns.E);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.King; } }

    #region IMoveMech implementation
    public IEnumerable<Location> GetKingMovableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      General.GetLeft(board, piece.Location, piece.Side, returnList);
      General.GetUp(board, piece.Location, piece.Side, returnList);
      General.GetRight(board, piece.Location, piece.Side, returnList);
      General.GetDown(board, piece.Location, piece.Side, returnList);
      General.GetUpperLeft(board, piece.Location, piece.Side, returnList);
      General.GetUpperRight(board, piece.Location, piece.Side, returnList);
      General.GetLowerLeft(board, piece.Location, piece.Side, returnList);
      General.GetLowerRight(board, piece.Location, piece.Side, returnList);
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      General.SetLeft(board, piece.Location, piece.Side);
      General.SetUp(board, piece.Location, piece.Side);
      General.SetRight(board, piece.Location, piece.Side);
      General.SetDown(board, piece.Location, piece.Side);
      General.SetUpperLeft(board, piece.Location, piece.Side);
      General.SetUpperRight(board, piece.Location, piece.Side);
      General.SetLowerLeft(board, piece.Location, piece.Side);
      General.SetLowerRight(board, piece.Location, piece.Side);
    }
    #endregion
  }
}
