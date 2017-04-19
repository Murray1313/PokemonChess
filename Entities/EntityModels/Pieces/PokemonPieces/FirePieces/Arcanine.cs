using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Arcanine : Rook
  {
    #region " Constructor "
    public Arcanine(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Arcanine(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Arcanine; } }

    public override string ImagePath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Arcanine}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.FireFolder}{PokemonNames.Arcanine}{FileSuffixes.ImageSuffix}"; } }
   
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Fire; } }
    #endregion
  }
}
