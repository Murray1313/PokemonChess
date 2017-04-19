using System;
using Entities.Interfaces;
using Entities.SharedEnums;
using Caliburn.Micro;

namespace Entities.EntityModels.Pieces
{
  public abstract class ChessPiece : PropertyChangedBase, IPiece
  {
    #region private
    private bool _isMoveableSpace;
    private bool _isSelected;
    private Location _location;
    #endregion

    #region Constructor(s)
    public ChessPiece(Enums.BlackOrWhite teamSide, int arrayLocation)
    {
      this.IsMovableSpace = false;
      this.IsSelected = false;
      this.Location = new Location(arrayLocation);
      this.Side = teamSide;
    }

    public ChessPiece(Enums.BlackOrWhite teamSide)
    {
      this.IsMovableSpace = false;
      this.IsSelected = false;
      this.Side = teamSide;
    }
    #endregion


    #region Standard Properties
    public bool IsMovableSpace
    {
      get { return _isMoveableSpace; }
      set
      {
        _isMoveableSpace = value;
        NotifyOfPropertyChange(() => IsMovableSpace);
      }
    }

    public bool IsSelected
    {
      get { return _isSelected; }
      set
      {
        _isSelected = value;
        NotifyOfPropertyChange(() => IsSelected);
      }
    }

    public Location Location
    {
      get { return _location; }
      set
      {
        _location = value;
        NotifyOfPropertyChange(() => Location);
      }
    }

    public Enums.BlackOrWhite Side { get; set; }
    #endregion


    #region Abstract Properties
    public abstract Enums.Pieces ChessPieceType { get; }

    public abstract string ImagePath { get; }

    public abstract string MainPath { get; }

    public abstract string Name { get; }

    public abstract Enums.TeamType PokemonType { get; }
    #endregion
  }
}
