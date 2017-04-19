using Entities.EntityModels;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces
{
  public abstract class Pawn : ChessPiece, IMoveMechanics
  {

    #region Constructor

    public Pawn(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Pawn(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Seven, pieceSide)
                                                              : new Location(Enums.BoardRows.Two, pieceSide);
    }

    #endregion

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Pawn; } }


    #region IMoveMechs implementation
    public IEnumerable<Location> GetPawnsConquerableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      if (piece.Side == SharedEnums.Enums.BlackOrWhite.White)
      {
        // One space in front, diagonal left.
        if (piece.Location.ArraySpotInt > 8 && board.BoardPieces[piece.Location.ArraySpotInt - 9].Side == SharedEnums.Enums.BlackOrWhite.Black)
        {
          if ((piece.Location.XCoord - 1) == board.BoardPieces[piece.Location.ArraySpotInt - 9].Location.XCoord)
          {
            returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt - 9].Location);
          }
        }
        // One space in front, diagonal right.
        if (piece.Location.ArraySpotInt > 7 && board.BoardPieces[piece.Location.ArraySpotInt - 7].Side == SharedEnums.Enums.BlackOrWhite.Black)
        {
          if ((piece.Location.XCoord - 1) == board.BoardPieces[piece.Location.ArraySpotInt - 7].Location.XCoord)
          {
            returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt - 7].Location);
          }
        }
      }
      else
      {
        // One space in front, diagonal left.
        if (piece.Location.ArraySpotInt < 55 && board.BoardPieces[piece.Location.ArraySpotInt + 9].Side == SharedEnums.Enums.BlackOrWhite.White)
        {
          if ((piece.Location.XCoord + 1) == board.BoardPieces[piece.Location.ArraySpotInt + 9].Location.XCoord)
          {
            returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt + 9].Location);
          }
        }
        // One space in front, diagonal right.
        if (piece.Location.ArraySpotInt < 57 && board.BoardPieces[piece.Location.ArraySpotInt + 7].Side == SharedEnums.Enums.BlackOrWhite.White)
        {
          if ((piece.Location.XCoord + 1) == board.BoardPieces[piece.Location.ArraySpotInt + 7].Location.XCoord)
          {
            returnList.Add(board.BoardPieces[piece.Location.ArraySpotInt + 7].Location);
          }
        }
      }
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      if (piece.Side == SharedEnums.Enums.BlackOrWhite.White)
      {
        // One space in front.
        if (piece.Location.ArraySpotInt > 7 && board.BoardPieces[piece.Location.ArraySpotInt - 8].Side == SharedEnums.Enums.BlackOrWhite.None)
        {
          board.BoardPieces[piece.Location.ArraySpotInt - 8].IsMovableSpace = true;
        }
        // One space in front, diagonal left.
        if (piece.Location.ArraySpotInt > 8 && board.BoardPieces[piece.Location.ArraySpotInt - 9].Side == SharedEnums.Enums.BlackOrWhite.Black)
        {
          if ((piece.Location.XCoord - 1) == board.BoardPieces[piece.Location.ArraySpotInt - 9].Location.XCoord)
          {
            board.BoardPieces[piece.Location.ArraySpotInt - 9].IsMovableSpace = true;
          }
        }
        // One space in front, diagonal right.
        if (piece.Location.ArraySpotInt > 7 && board.BoardPieces[piece.Location.ArraySpotInt - 7].Side == SharedEnums.Enums.BlackOrWhite.Black)
        {
          if ((piece.Location.XCoord - 1) == board.BoardPieces[piece.Location.ArraySpotInt - 7].Location.XCoord)
          {
            board.BoardPieces[piece.Location.ArraySpotInt - 7].IsMovableSpace = true;
          }
        }
        //Two Spaces forward
        if (piece.Location.XCoord == SharedEnums.Enums.BoardRows.Seven && board.BoardPieces[piece.Location.ArraySpotInt - 16].Side == SharedEnums.Enums.BlackOrWhite.None)
        {
          board.BoardPieces[piece.Location.ArraySpotInt - 16].IsMovableSpace = true;
        }
      }
      else
      {
        // One space in front.
        if (piece.Location.ArraySpotInt < 56 && board.BoardPieces[piece.Location.ArraySpotInt + 8].Side == SharedEnums.Enums.BlackOrWhite.None)
        {
          board.BoardPieces[piece.Location.ArraySpotInt + 8].IsMovableSpace = true;
        }
        // One space in front, diagonal left.
        if (piece.Location.ArraySpotInt < 55 && board.BoardPieces[piece.Location.ArraySpotInt + 9].Side == SharedEnums.Enums.BlackOrWhite.White)
        {
          if ((piece.Location.XCoord + 1) == board.BoardPieces[piece.Location.ArraySpotInt + 9].Location.XCoord)
          {
            board.BoardPieces[piece.Location.ArraySpotInt + 9].IsMovableSpace = true;
          }
        }
        // One space in front, diagonal right.
        if (piece.Location.ArraySpotInt < 57 && board.BoardPieces[piece.Location.ArraySpotInt + 7].Side == SharedEnums.Enums.BlackOrWhite.White)
        {
          if ((piece.Location.XCoord + 1) == board.BoardPieces[piece.Location.ArraySpotInt + 7].Location.XCoord)
          {
            board.BoardPieces[piece.Location.ArraySpotInt + 7].IsMovableSpace = true;
          }
        }
        //Two Spaces forward
        if (piece.Location.XCoord == SharedEnums.Enums.BoardRows.Two && board.BoardPieces[piece.Location.ArraySpotInt + 16].Side == SharedEnums.Enums.BlackOrWhite.None)
        {
          board.BoardPieces[piece.Location.ArraySpotInt + 16].IsMovableSpace = true;
        }
      }
    }
    #endregion
  }
}