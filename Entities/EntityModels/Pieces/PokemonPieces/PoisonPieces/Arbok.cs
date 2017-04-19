using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Arbok : Bishop
  {
    #region " Constructor "
    public Arbok(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Arbok(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Arbok; } }

    public override string ImagePath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Arbok}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Arbok}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Poison; } }

    #endregion
  }
}
