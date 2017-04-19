using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Blastoise : King
  {
    #region " Constructor "
    public Blastoise(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Blastoise(Enums.BlackOrWhite teamSide) : base(teamSide) { }
    #endregion


    #region " Override Properties "
    public override string Name { get { return PokemonNames.Blastoise; } }

    public override string ImagePath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Blastoise}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Blastoise}{FileSuffixes.ImageSuffix}"; } }
    
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Water; } }
    #endregion
  }
}
