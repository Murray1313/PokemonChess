using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Nidoking : King
  {
    #region " Constructor "
    public Nidoking(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Nidoking(Enums.BlackOrWhite teamSide) : base(teamSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Nidoking; } }

    public override string ImagePath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Nidoking}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Nidoking}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Poison; } }
    #endregion
  }
}
