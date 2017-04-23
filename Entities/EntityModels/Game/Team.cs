using Entities.Interfaces;
using System.Collections.Generic;
using Entities.SharedEnums;
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

    public Team(Enums.BlackOrWhite teamColor, Enums.TeamType pokeType)
    {
      this.Side = teamColor;
      this.PokemonType = pokeType;
      this.Pieces = SetPieces(teamColor, pokeType);
      this.CanCastleLeft = true;
      this.CanCastleRight = true;
    }
    #endregion

    #region " Properties "

    public Enums.BlackOrWhite Side { get; set; }

    public Enums.TeamType PokemonType { get; set; }

    public List<IPiece> Pieces { get; set; }

    public bool CanCastleLeft { get; set; }

    public bool CanCastleRight { get; set; }

    #endregion


    #region " Methods "
    private List<IPiece> SetPieces(Enums.BlackOrWhite teamColor, Enums.TeamType pokeType)
    {
      List<IPiece> returnList = new List<IPiece>();

      switch (pokeType)
      {
        case Enums.TeamType.Fire:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Vulpix(teamColor, (Enums.BoardColumns)x));
          }
          returnList.Add(new Arcanine(teamColor, Enums.BoardColumns.A));
          returnList.Add(new Rapidash(teamColor, Enums.BoardColumns.B));
          returnList.Add(new Magmar(teamColor, Enums.BoardColumns.C));
          returnList.Add(new Ninetails(teamColor));
          returnList.Add(new Charizard(teamColor));
          returnList.Add(new Magmar(teamColor, Enums.BoardColumns.F));
          returnList.Add(new Rapidash(teamColor, Enums.BoardColumns.G));
          returnList.Add(new Arcanine(teamColor, Enums.BoardColumns.H));
          break;
        case Enums.TeamType.Water:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Magikarp(teamColor, (Enums.BoardColumns)x));
          }
          returnList.Add(new Poliwrath(teamColor, Enums.BoardColumns.A));
          returnList.Add(new Seadra(teamColor, Enums.BoardColumns.B));
          returnList.Add(new Golduck(teamColor, Enums.BoardColumns.C));
          returnList.Add(new Lapras(teamColor));
          returnList.Add(new Blastoise(teamColor));
          returnList.Add(new Golduck(teamColor, Enums.BoardColumns.F));
          returnList.Add(new Seadra(teamColor, Enums.BoardColumns.G));
          returnList.Add(new Poliwrath(teamColor, Enums.BoardColumns.H));
          break;
        case Enums.TeamType.Grass:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Oddish(teamColor, (Enums.BoardColumns)x));
          }
          returnList.Add(new Victreebell(teamColor, Enums.BoardColumns.A));
          returnList.Add(new Tangela(teamColor, Enums.BoardColumns.B));
          returnList.Add(new Exeggutor(teamColor, Enums.BoardColumns.C));
          returnList.Add(new Vileplume(teamColor));
          returnList.Add(new Venusaur(teamColor));
          returnList.Add(new Exeggutor(teamColor, Enums.BoardColumns.F));
          returnList.Add(new Tangela(teamColor, Enums.BoardColumns.G));
          returnList.Add(new Victreebell(teamColor, Enums.BoardColumns.H));
          break;
        case Enums.TeamType.Poison:
          for (int x = 0; x < 8; x++)
          {
            returnList.Add(new Grimer(teamColor, (Enums.BoardColumns)x));
          }
          returnList.Add(new Gengar(teamColor, Enums.BoardColumns.A));
          returnList.Add(new Weezing(teamColor, Enums.BoardColumns.B));
          returnList.Add(new Arbok(teamColor, Enums.BoardColumns.C));
          returnList.Add(new Nidoqueen(teamColor));
          returnList.Add(new Nidoking(teamColor));
          returnList.Add(new Arbok(teamColor, Enums.BoardColumns.F));
          returnList.Add(new Weezing(teamColor, Enums.BoardColumns.G));
          returnList.Add(new Gengar(teamColor, Enums.BoardColumns.H));
          break;
        default:
          break;
      }

      return returnList;
    }
    #endregion
  }
}
