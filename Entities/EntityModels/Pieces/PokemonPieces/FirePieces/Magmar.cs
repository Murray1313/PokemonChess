using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Magmar : Bishop
  {
    #region " Constructor "
    public Magmar(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Magmar(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Magmar; } }

    public override string ImagePath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Magmar}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Magmar}{FileSuffixes.ImageSuffix}"; } }
    
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Fire; } }
    #endregion
  }
}
