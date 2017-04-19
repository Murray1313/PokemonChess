using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Weezing : Knight
  {
    #region " Constructor "
    public Weezing(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Weezing(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Weezing; } }

    public override string ImagePath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Weezing}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.PoisonFolder}{PokemonNames.Weezing}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Poison; } }    
    #endregion
  }
}
