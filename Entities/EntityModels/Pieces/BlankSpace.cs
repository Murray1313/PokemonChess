using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Entities.EntityModels.Pieces
{
  public class BlankSpace : PropertyChangedBase, IPiece
  {
    #region
    private bool _isSelected = false;
    private bool _isMovableSpace = false;
    #endregion


    #region " Constructor "
    public BlankSpace(Location location)
    {
      this.Location = location;
      this.Side = SharedEnums.Enums.BlackOrWhite.None;
    }


    public BlankSpace(int arrayLocation)
    {
      this.Location = new Location((SharedEnums.Enums.BoardRows)((arrayLocation) / 8), (SharedEnums.Enums.BoardColumns)(arrayLocation % 8));
      this.Side = SharedEnums.Enums.BlackOrWhite.None;
    }
    #endregion


    #region " Properties "
    public string Name { get { return ""; } }

    public string ImagePath { get { return "/PokemonChess;component/Images/BlankSpace.png"; } }

    public string MainPath { get { return "/PokemonChess;component/Images/BlankSpace.png"; } }

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

    public SharedEnums.Enums.BlackOrWhite Side { get; set; }

    public SharedEnums.Enums.TeamType PokemonType { get { return SharedEnums.Enums.TeamType.None; } }

    public SharedEnums.Enums.Pieces ChessPieceType { get { return SharedEnums.Enums.Pieces.NA; } }
    #endregion
  }
}
