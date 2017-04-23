using Entities.EntityModels;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces
{
  public abstract class Pawn : ChessPiece
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
    public override IEnumerable<Location> GetMovableSpaces(Board board)
    {
      List<Location> returnList = new List<Location>();
      if (this.Side == Enums.BlackOrWhite.White)
      {
        // One space in front, diagonal left.
        if (this.Location.ArraySpotInt > 8 && board.IsLocationOfTeamType(this.Location.ArraySpotInt - 9, Enums.BlackOrWhite.Black)
         && this.Location.YCoord != Enums.BoardColumns.A)
        {
          returnList.Add(new Location(this.Location.ArraySpotInt - 9));
        }
        // One space in front, diagonal right.
        if (this.Location.ArraySpotInt > 7 && board.IsLocationOfTeamType(this.Location.ArraySpotInt - 7, Enums.BlackOrWhite.Black)
         && this.Location.YCoord != Enums.BoardColumns.H)
        {
          returnList.Add(new Location(this.Location.ArraySpotInt - 7));
        }
      }
      else
      {
        // One space in front, diagonal left.
        if (this.Location.ArraySpotInt < 55 && board.IsLocationOfTeamType(this.Location.ArraySpotInt + 9, Enums.BlackOrWhite.White)
         && this.Location.YCoord != Enums.BoardColumns.H)
        {
          returnList.Add(new Location(this.Location.ArraySpotInt + 9));
        }
        // One space in front, diagonal right.
        if (this.Location.ArraySpotInt < 57 && board.IsLocationOfTeamType(this.Location.ArraySpotInt + 7, Enums.BlackOrWhite.White)
         && this.Location.YCoord != Enums.BoardColumns.A)
        {
          returnList.Add(new Location(this.Location.ArraySpotInt + 7));
        }
      }
      return returnList;
    }

    public override void SetMovableSpaces(Board board)
    {
      if (this.Side == Enums.BlackOrWhite.White)
      {
        // One space in front.
        if (this.Location.ArraySpotInt > 7 && board.IsLocationEmpty(this.Location.ArraySpotInt - 8))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 8));
        }
        // One space in front, diagonal left.
        if (this.Location.ArraySpotInt > 8 && board.IsLocationOfTeamType(this.Location.ArraySpotInt - 9, Enums.BlackOrWhite.Black)
         && this.Location.YCoord != Enums.BoardColumns.A)
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 9));
        }
        // One space in front, diagonal right.
        if (this.Location.ArraySpotInt > 7 && board.IsLocationOfTeamType(this.Location.ArraySpotInt - 7, Enums.BlackOrWhite.Black)
         && this.Location.YCoord != Enums.BoardColumns.H)
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 7));
        }
        //Two Spaces forward
        if (this.Location.XCoord == Enums.BoardRows.Seven && board.IsLocationEmpty(this.Location.ArraySpotInt - 16))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 16));
        }
      }
      else
      {
        // One space in front.
        if (this.Location.ArraySpotInt < 56 && board.IsLocationEmpty(this.Location.ArraySpotInt + 8))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 8));
        }
        // One space in front, diagonal right.
        if (this.Location.ArraySpotInt < 55 && board.IsLocationOfTeamType(this.Location.ArraySpotInt + 9, Enums.BlackOrWhite.White)
         && this.Location.YCoord != Enums.BoardColumns.H)
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 9));
        }
        // One space in front, diagonal left.
        if (this.Location.ArraySpotInt < 56 && board.IsLocationOfTeamType(this.Location.ArraySpotInt + 7, Enums.BlackOrWhite.White)
         && this.Location.YCoord != Enums.BoardColumns.A)
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 7));
        }
        //Two Spaces forward
        if (this.Location.XCoord == Enums.BoardRows.Two && board.IsLocationEmpty(this.Location.ArraySpotInt + 16))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 16));
        }
      }
    }
    #endregion
  }
}