using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Gengar : Rook
  {
    #region " Constructor "
    public Gengar(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Gengar(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Gengar; } }

    public override string ImagePath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Gengar}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Gengar}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Poison; } }
    #endregion
  }
}
