using Entities.Interfaces;
using System.Collections.Generic;
using Entities.SharedEnums;
using System;

namespace Entities.EntityModels.Pieces
{
  public abstract class Knight : ChessPiece
  {
    public Knight(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Knight(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide)
    {
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, pieceSide)
                                                              : new Location(Enums.BoardRows.One, pieceSide);
    }

    public override Enums.Pieces ChessPieceType { get { return Enums.Pieces.Knight; } }

    #region IMoveMech
    public override IEnumerable<Location> GetMovableSpaces(Board board)
    {
      List<Location> returnList = new List<Location>();
      // Up 2
      if ((int)this.Location.XCoord > 1)
      { // Right 1
        if ((int)this.Location.YCoord < 7 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 15, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt - 15));
        }
        //Left 1
        if ((int)this.Location.YCoord > 0 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 17, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt - 17));
        }
      }
      // Up 1
      if ((int)this.Location.XCoord > 0)
      { // Right 2
        if ((int)this.Location.YCoord < 6 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 6, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt - 6));
        }
        // Left 2
        if ((int)this.Location.YCoord > 1 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 10, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt - 10));
        }
      }
      // Down 2
      if ((int)this.Location.XCoord < 6)
      { // Right 1
        if ((int)this.Location.YCoord < 7 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 17, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt + 17));
        }
        // Left 1
        if ((int)this.Location.YCoord > 0 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 15, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt + 15));
        }
      }
      // Down 1
      if ((int)this.Location.XCoord < 7)
      { // Right 2
        if ((int)this.Location.YCoord < 6 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 10, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt + 10));
        }
        // Left 2
        if ((int)this.Location.YCoord > 1 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 6, this.Side))
        {
          returnList.Add(new Location(this.Location.ArraySpotInt + 6));
        }
      }
      return returnList;
    }

    public override void SetMovableSpaces(Board board)
    {
      // Up 2
      if ((int)this.Location.XCoord > 1)
      { // Right 1
        if ((int)this.Location.YCoord < 7 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 15, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 15));
        }
        //Left 1
        if ((int)this.Location.YCoord > 0 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 17, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 17));
        }
      }
      // Up 1
      if ((int)this.Location.XCoord > 0)
      { // Right 2
        if ((int)this.Location.YCoord < 6 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 6, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 6));
        }
        // Left 2
        if ((int)this.Location.YCoord > 1 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt - 10, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt - 10));
        }
      }
      // Down 2
      if ((int)this.Location.XCoord < 6)
      { // Right 1
        if ((int)this.Location.YCoord < 7 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 17, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 17));
        }
        // Left 1
        if ((int)this.Location.YCoord > 0 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 15, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 15));
        }
      }
      // Down 1
      if ((int)this.Location.XCoord < 7)
      { // Right 2
        if ((int)this.Location.YCoord < 6 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 10, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 10));
        }
        // Left 2
        if ((int)this.Location.YCoord > 1 && !board.IsLocationOfTeamType(this.Location.ArraySpotInt + 6, this.Side))
        {
          board.MoveableSpaces.Add(new Location(this.Location.ArraySpotInt + 6));
        }
      }
    }
    #endregion
  }
}
