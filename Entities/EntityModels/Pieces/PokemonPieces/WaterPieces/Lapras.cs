using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Lapras : Queen
  {
    #region " Constructor "
    public Lapras(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Lapras(Enums.BlackOrWhite teamSide) : base(teamSide) { }
    #endregion


    #region " Override Properties "
    public override string Name { get { return PokemonNames.Lapras; } }

    public override string ImagePath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Lapras}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Lapras}{FileSuffixes.ImageSuffix}"; } }
  
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Water; } }
    #endregion
  }
}
