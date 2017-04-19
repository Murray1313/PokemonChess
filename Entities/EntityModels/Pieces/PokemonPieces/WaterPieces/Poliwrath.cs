using Entities.EntityModels.Pieces;
using Entities.Interfaces;
using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Poliwrath : Rook
  {
    #region " Constructor "
    public Poliwrath(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Poliwrath(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Poliwrath; } }

    public override string ImagePath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Poliwrath}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.WaterFolder}{PokemonNames.Poliwrath}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Water; } }
    #endregion
  }
}
