using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
  public interface IPiece
  {
    String Name { get; }

    String ImagePath { get; }

    String MainPath { get; }

    bool IsSelected { get; set; }

    bool IsMovableSpace { get; set; }

    Location Location { get; set; }

    SharedEnums.Enums.BlackOrWhite Side { get; set; }

    SharedEnums.Enums.TeamType PokemonType { get; }

    SharedEnums.Enums.Pieces ChessPieceType { get; }
  }
}
