﻿using Entities.EntityModels.Pieces;
using Entities.Interfaces;
using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.PokemonPieces
{
  public class Rapidash : Knight, IPiece
  {
    #region " Private "
    private bool _isSelected = false;
    private bool _isMovableSpace = false;
    #endregion


    #region " Constructor "
    public Rapidash(Enums.BlackOrWhite teamSide, int arrayLocation)
    {
      this.Side = teamSide;
      this.Location = new Location(arrayLocation);
    }

    public Rapidash(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide)
    {
      this.Side = teamSide;
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, pieceSide)
                                                              : new Location(Enums.BoardRows.One, pieceSide);
    }
    #endregion


    #region " Properties "
    public string Name { get { return PokemonNames.Rapidash; } }

    public string ImagePath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Rapidash}{FileSuffixes.PieceSuffix}"; } }

    public string MainPath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Rapidash}{FileSuffixes.ImageSuffix}"; } }

    public bool IsSelected
    {
      get { return _isSelected; }
      set
      {
        _isSelected = value;
        NotifyOfPropertyChange(() => IsSelected);
      }
    }

    public bool IsMovableSpace
    {
      get { return _isMovableSpace; }
      set
      {
        _isMovableSpace = value;
        NotifyOfPropertyChange(() => IsMovableSpace);
      }
    }

    public Location Location { get; set; }

    public Enums.BlackOrWhite Side { get; set; }

    public Enums.TeamType PokemonType { get { return Enums.TeamType.Fire; } }

    public Enums.Pieces ChessPieceType
    {
      get
      {
        switch (this.GetType().BaseType.Name)
        {
          case PieceTypes.King:
            return Enums.Pieces.King;
          case PieceTypes.Queen:
            return Enums.Pieces.Queen;
          case PieceTypes.Rook:
            return Enums.Pieces.Rook;
          case PieceTypes.Bishop:
            return Enums.Pieces.Bishop;
          case PieceTypes.Knight:
            return Enums.Pieces.Knight;
          case PieceTypes.Pawn:
            return Enums.Pieces.Pawn;
          default: return Enums.Pieces.NA;
        }
      }
    }
    #endregion
  }
}