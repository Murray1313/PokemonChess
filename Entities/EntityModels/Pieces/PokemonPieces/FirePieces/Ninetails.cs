using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Ninetails : Queen
  {
    #region " Constructor "
    public Ninetails(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Ninetails(Enums.BlackOrWhite teamSide) : base(teamSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Ninetails; } }

    public override string ImagePath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Ninetails}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Ninetails}{FileSuffixes.ImageSuffix}"; } }
    
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Fire; } }
    #endregion
  }
}
