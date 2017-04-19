using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Rapidash : Knight
  {
    #region " Constructor "
    public Rapidash(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Rapidash(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Rapidash; } }

    public override string ImagePath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Rapidash}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Rapidash}{FileSuffixes.ImageSuffix}"; } }
    
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Fire; } }
    #endregion
  }
}
