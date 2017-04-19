using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Nidoqueen : Queen
  {
    #region " Constructor "
    public Nidoqueen(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Nidoqueen(Enums.BlackOrWhite teamSide) : base(teamSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Nidoqueen; } }

    public override string ImagePath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Nidoqueen}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Nidoqueen}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Poison; } }
    #endregion
  }
}
