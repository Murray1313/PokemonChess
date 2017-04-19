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
  public abstract class Rook : ChessPiece, IMoveMechanics
  {
    public Rook(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Rook(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, pieceSide)
                                                              : new Location(Enums.BoardRows.One, pieceSide);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Rook; } }

    #region IMoveMech implementation
    public IEnumerable<Location> GetRooksConquerableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      General.RecursiveGetLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetUp(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetRight(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetDown(board, piece.Location, piece.Side, returnList);
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      General.RecursiveSetLeft(board, piece.Location, piece.Side);
      General.RecursiveSetUp(board, piece.Location, piece.Side);
      General.RecursiveSetRight(board, piece.Location, piece.Side);
      General.RecursiveSetDown(board, piece.Location, piece.Side);
    }
    #endregion
  }
}
