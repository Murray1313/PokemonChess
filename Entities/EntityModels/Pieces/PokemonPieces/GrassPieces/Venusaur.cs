using Entities.Constants;
using Entities.SharedEnums;

namespace Entities.EntityModels.Pieces.PokemonPieces
{
  public class Venusaur : King
  {
    #region " Constructor "
    public Venusaur(Enums.BlackOrWhite teamSide, int arrayLocation) : base(teamSide, arrayLocation) { }

    public Venusaur(Enums.BlackOrWhite teamSide) : base(teamSide)
    {
      this.Side = teamSide;
      this.Location = (this.Side == Enums.BlackOrWhite.White) ? new Location(Enums.BoardRows.Eight, Enums.BoardColumns.E)
                                                              : new Location(Enums.BoardRows.One, Enums.BoardColumns.E);
    }
    #endregion


    #region " Properties "
    public override string Name { get { return PokemonNames.Venusaur; } }

    public override string ImagePath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Venusaur}{FileSuffixes.PieceSuffix}"; } }

    public override string MainPath { get { return $"{FolderPaths.GrassFolder}{PokemonNames.Venusaur}{FileSuffixes.ImageSuffix}"; } }

    public override Enums.TeamType PokemonType { get { return Enums.TeamType.Grass; } }
    #endregion
  }
}
