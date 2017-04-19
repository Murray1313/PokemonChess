using Entities.Interfaces;
using System.Collections.Generic;
using Entities.EntityModels.Pieces.PokemonPieces;

namespace Entities
{
  public class Team
  {
    #region " Constructor "
    public Team()
    {
      this.CanCastleLeft = true;
      this.CanCastleRight = true;
    }

    public Team(SharedEnums.Enums.BlackOrWhite teamColor, SharedEnums.Enums.TeamType pokeType)
    {
      this.Side = teamColor;
      this.PokemonType = pokeType;
      this.Pieces = SetPieces(teamColor, pokeType);
      this.CanCastleLeft = true;
      this.CanCastleRight = true;
    }
    #endregion

    #region " Properties "

    public SharedEnums.Enums.BlackOrWhite Side { get; set; }

    public SharedEnums.Enums.TeamType PokemonType { get; set; }

    public List<IPiece> Pieces { get; set; }

    public bool CanCastleLeft { get; set; }

    public bool CanCastleRight { get; set; }

    #endregion


    #region " Methods "
    private List<IPiece> SetPieces(SharedEnums.Enums.BlackOrWhite teamColor, SharedEnums.Enums.TeamType pokeType)
    {
      List<IPiece> returnList = new List<IPiece>();

      switch (pokeType)
      {
        case SharedEnums.Enums.TeamType.Fire:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Vulpix(teamColor, (SharedEnums.Enums.BoardColumns)x));
          }
          returnList.Add(new Arcanine(teamColor, SharedEnums.Enums.BoardColumns.A));
          returnList.Add(new Rapidash(teamColor, SharedEnums.Enums.BoardColumns.B));
          returnList.Add(new Magmar(teamColor, SharedEnums.Enums.BoardColumns.C));
          returnList.Add(new Ninetails(teamColor));
          returnList.Add(new Charizard(teamColor));
          returnList.Add(new Magmar(teamColor, SharedEnums.Enums.BoardColumns.F));
          returnList.Add(new Rapidash(teamColor, SharedEnums.Enums.BoardColumns.G));
          returnList.Add(new Arcanine(teamColor, SharedEnums.Enums.BoardColumns.H));
          break;
        case SharedEnums.Enums.TeamType.Water:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Magikarp(teamColor, (SharedEnums.Enums.BoardColumns)x));
          }
          returnList.Add(new Poliwrath(teamColor, SharedEnums.Enums.BoardColumns.A));
          returnList.Add(new Seadra(teamColor, SharedEnums.Enums.BoardColumns.B));
          returnList.Add(new Golduck(teamColor, SharedEnums.Enums.BoardColumns.C));
          returnList.Add(new Lapras(teamColor));
          returnList.Add(new Blastoise(teamColor));
          returnList.Add(new Golduck(teamColor, SharedEnums.Enums.BoardColumns.F));
          returnList.Add(new Seadra(teamColor, SharedEnums.Enums.BoardColumns.G));
          returnList.Add(new Poliwrath(teamColor, SharedEnums.Enums.BoardColumns.H));
          break;
        case SharedEnums.Enums.TeamType.Grass:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Oddish(teamColor, (SharedEnums.Enums.BoardColumns)x));
          }
          returnList.Add(new Victreebell(teamColor, SharedEnums.Enums.BoardColumns.A));
          returnList.Add(new Tangela(teamColor, SharedEnums.Enums.BoardColumns.B));
          returnList.Add(new Exeggutor(teamColor, SharedEnums.Enums.BoardColumns.C));
          returnList.Add(new Vileplume(teamColor));
          returnList.Add(new Venusaur(teamColor));
          returnList.Add(new Exeggutor(teamColor, SharedEnums.Enums.BoardColumns.F));
          returnList.Add(new Tangela(teamColor, SharedEnums.Enums.BoardColumns.G));
          returnList.Add(new Victreebell(teamColor, SharedEnums.Enums.BoardColumns.H));
          break;
        case SharedEnums.Enums.TeamType.Poison:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Grimer(teamColor, (SharedEnums.Enums.BoardColumns)x));
          }
          returnList.Add(new Gengar(teamColor, SharedEnums.Enums.BoardColumns.A));
          returnList.Add(new Weezing(teamColor, SharedEnums.Enums.BoardColumns.B));
          returnList.Add(new Arbok(teamColor, SharedEnums.Enums.BoardColumns.C));
          returnList.Add(new Nidoqueen(teamColor));
          returnList.Add(new Nidoking(teamColor));
          returnList.Add(new Arbok(teamColor, SharedEnums.Enums.BoardColumns.F));
          returnList.Add(new Weezing(teamColor, SharedEnums.Enums.BoardColumns.G));
          returnList.Add(new Gengar(teamColor, SharedEnums.Enums.BoardColumns.H));
          break;
        default:
          break;
      }

      return returnList;
    }
    #endregion
  }
}
