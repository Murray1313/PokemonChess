using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Exeggutor : Bishop
  {
    #region " Constructor "
    public Exeggutor(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Exeggutor(Enums.BlackOrWhite teamSide, Enums.BoardColumns pieceSide) : base(teamSide, pieceSide) { }   
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Exeggutor; } }

    public override string ImagePath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Exeggutor}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Exeggutor}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Grass; } }
    #endregion
  }
}
