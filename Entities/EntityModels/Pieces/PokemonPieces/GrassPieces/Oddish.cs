using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Oddish : Pawn
  {
    #region " Constructor "
    public Oddish(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Oddish(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Oddish; } }

    public override string ImagePath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Oddish}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Oddish}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Grass; } }
    #endregion
  }
}
