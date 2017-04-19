using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces
{
  public abstract class Knight : ChessPiece, IMoveMechanics
  {
    public Knight(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Knight(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, pieceSide)
                                                              : new Location(Enums.BoardRows.One, pieceSide);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Knight; } }

    #region IMoveMech
    public IEnumerable<Location> GetKnightsConquerableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      // Up 2
      if ((int)piece.Location.XCoord > 1)
      { // Right 1
        if ((int)piece.Location.YCoord < 7 && board.BoardPieces[piece.Location.ArraySpotInt - 15].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt - 15].Location);
        }
        //Left 1
        if ((int)piece.Location.YCoord > 0 && board.BoardPieces[piece.Location.ArraySpotInt - 17].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt - 17].Location);
        }
      }
      // Up 1
      if ((int)piece.Location.XCoord > 0)
      { // Right 2
        if ((int)piece.Location.YCoord < 6 && board.BoardPieces[piece.Location.ArraySpotInt - 6].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt - 6].Location);
        }
        // Left 2
        if ((int)piece.Location.YCoord > 1 && board.BoardPieces[piece.Location.ArraySpotInt - 10].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt - 10].Location);
        }
      }
      // Down 2
      if ((int)piece.Location.XCoord < 6)
      { // Right 1
        if ((int)piece.Location.YCoord < 7 && board.BoardPieces[piece.Location.ArraySpotInt + 17].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt + 17].Location);
        }
        // Left 1
        if ((int)piece.Location.YCoord > 0 && board.BoardPieces[piece.Location.ArraySpotInt + 15].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt + 15].Location);
        }
      }
      // Down 1
      if ((int)piece.Location.XCoord < 7)
      { // Right 2
        if ((int)piece.Location.YCoord < 6 && board.BoardPieces[piece.Location.ArraySpotInt + 10].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt + 10].Location);
        }
        // Left 2
        if ((int)piece.Location.YCoord > 1 && board.BoardPieces[piece.Location.ArraySpotInt + 6].Side != piece.Side)
        {
          returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt + 6].Location);
        }
      }
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      // Up 2
      if ((int)piece.Location.XCoord > 1)
      { // Right 1
        if ((int)piece.Location.YCoord < 7 && board.BoardPieces[piece.Location.ArraySpotInt - 15].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt - 15].IsMovableSpace = true;
        }
        //Left 1
        if ((int)piece.Location.YCoord > 0 && board.BoardPieces[piece.Location.ArraySpotInt - 17].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt - 17].IsMovableSpace = true;
        }
      }
      // Up 1
      if ((int)piece.Location.XCoord > 0)
      { // Right 2
        if ((int)piece.Location.YCoord < 6 && board.BoardPieces[piece.Location.ArraySpotInt - 6].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt - 6].IsMovableSpace = true;
        }
        // Left 2
        if ((int)piece.Location.YCoord > 1 && board.BoardPieces[piece.Location.ArraySpotInt - 10].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt - 10].IsMovableSpace = true;
        }
      }
      // Down 2
      if ((int)piece.Location.XCoord < 6)
      { // Right 1
        if ((int)piece.Location.YCoord < 7 && board.BoardPieces[piece.Location.ArraySpotInt + 17].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt + 17].IsMovableSpace = true;
        }
        // Left 1
        if ((int)piece.Location.YCoord > 0 && board.BoardPieces[piece.Location.ArraySpotInt + 15].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt + 15].IsMovableSpace = true;
        }
      }
      // Down 1
      if ((int)piece.Location.XCoord < 7)
      { // Right 2
        if ((int)piece.Location.YCoord < 6 && board.BoardPieces[piece.Location.ArraySpotInt + 10].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt + 10].IsMovableSpace = true;
        }
        // Left 2
        if ((int)piece.Location.YCoord > 1 && board.BoardPieces[piece.Location.ArraySpotInt + 6].Side != piece.Side)
        {
          board.BoardPieces[piece.Location.ArraySpotInt + 6].IsMovableSpace = true;
        }
      }
    }
    #endregion
  }
}
