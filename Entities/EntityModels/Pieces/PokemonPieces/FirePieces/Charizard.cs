using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Charizard : King
  {
    #region " Constructor "
    public Charizard(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Charizard(Enums.BlackOrWhite teamSide) : base(teamSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Charizard; } }

    public override string ImagePath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Charizard}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Charizard}{FileSuffixes.ImageSuffix}"; } }
  
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Fire; } }
    #endregion
  }
}
