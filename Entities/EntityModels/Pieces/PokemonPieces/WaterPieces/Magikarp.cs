using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Magikarp : Pawn
  {
    #region " Constructor "
    public Magikarp(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Magikarp(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Override Properties "
    public override string Name { get { return PokemonNames.Magikarp; } }

    public override string ImagePath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Magikarp}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Magikarp}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Water; } }
    #endregion
  }
}
