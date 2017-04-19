using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Vileplume : Queen
  {
    #region " Constructor "
    public Vileplume(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Vileplume(Enums.BlackOrWhite teamSide) : base(teamSide) { }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Vileplume; } }

    public override string ImagePath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Vileplume}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Vileplume}{FileSuffixes.ImageSuffix}"; } }
    
    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Grass; } }
    #endregion
  }
}
