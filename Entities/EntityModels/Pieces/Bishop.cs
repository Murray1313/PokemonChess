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
  public abstract class Bishop : ChessPiece, IMoveMechanics
  {
    public Bishop(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }
    public Bishop(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, pieceSide)
                                                              : new Location(Enums.BoardRows.One, pieceSide);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Bishop; } }

    #region IMoveMech Implementation
    public IEnumerable<Location> GetBishopsConquerableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      General.RecursiveGetUpperLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetUpperRight(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetLowerLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetLowerRight(board, piece.Location, piece.Side, returnList);
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      General.RecursiveSetUpperLeft(board, piece.Location, piece.Side);
      General.RecursiveSetUpperRight(board, piece.Location, piece.Side);
      General.RecursiveSetLowerLeft(board, piece.Location, piece.Side);
      General.RecursiveSetLowerRight(board, piece.Location, piece.Side);
    }
    #endregion
  }
}
