using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Vulpix : Pawn
  {
    #region " Constructor "
    public Vulpix(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation)
    {
      this.Side = teamSide;
      this.Location = new Location(arrayLocation);
    }

    public Vulpix(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Vulpix; } }

    public override string ImagePath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Vulpix}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Vulpix}{FileSuffixes.ImageSuffix}"; } }
    
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Fire; } }
    #endregion
  }
}
