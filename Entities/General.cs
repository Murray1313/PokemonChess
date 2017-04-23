using Entities;
using Entities.Constants;
using Entities.EntityModels.Pieces.PokemonPieces;
using Entities.Interfaces;
using Entities.SharedEnums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonChess
{
  public static class General
  {

    #region " Single Check Moves "

    public static void SetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 1, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 1));
      }
    }

    public static void SetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 8, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 8));
      }
    }


    public static void SetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 1, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 1));
      }
    }


    public static void SetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 8, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 8));
      }
    }

    public static void SetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 9, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 9));
      }
    }

    public static void SetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt - 7, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 7));
      }
    }

    public static void SetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt + 7, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 7));
      }
    }

    public static void SetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 9, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 9));
      }
    }

    #endregion

    #region " Single Get Moves "

    public static IEnumerable<Location> GetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 1, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt - 1));
      }
      return returnList;
    }

    public static IEnumerable<Location> GetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 8, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt - 8));
      }
      return returnList;
    }

    public static IEnumerable<Location> GetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 1, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt + 1));
      }
      return returnList;
    }

    public static IEnumerable<Location> GetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 8, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt + 8));
      }
      return returnList;
    }

    public static IEnumerable<Location> GetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 9, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt - 9));
      }
      return returnList;
    }

    public static IEnumerable<Location> GetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt - 7, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt - 7));
      }
      return returnList;
    }

    public static IEnumerable<Location> GetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt + 7, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt + 7));
      }
      return returnList;
    }

    public static IEnumerable<Location> GetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 9, initialPieceSide))
      {
        returnList.Add(new Location(location.ArraySpotInt + 9));
      }
      return returnList;
    }

    #endregion

    #region " Recursive Set Moves "
    public static void RecursiveSetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 1, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 1));
        if (board.IsLocationEmpty(location.ArraySpotInt - 1))
        {
          RecursiveSetLeft(board, new Location(location.ArraySpotInt - 1), initialPieceSide);
        }

      }
    }

    public static void RecursiveSetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 8, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 8));
        if (board.IsLocationEmpty(location.ArraySpotInt - 8))
        {
          RecursiveSetUp(board, new Location(location.ArraySpotInt - 8), initialPieceSide);
        }
      }
    }

    public static void RecursiveSetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 1, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 1));
        if (board.IsLocationEmpty(location.ArraySpotInt + 1))
        {
          RecursiveSetRight(board, new Location(location.ArraySpotInt + 1), initialPieceSide);
        }
      }
    }

    public static void RecursiveSetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 8, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 8));
        if (board.IsLocationEmpty(location.ArraySpotInt + 8))
        {
          RecursiveSetDown(board, new Location(location.ArraySpotInt + 8), initialPieceSide);
        }
      }
    }

    public static void RecursiveSetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 9, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 9));
        if (board.IsLocationEmpty(location.ArraySpotInt - 9))
        {
          RecursiveSetUpperLeft(board, new Location(location.ArraySpotInt - 9), initialPieceSide);
        }
      }
    }

    public static void RecursiveSetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt - 7, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt - 7));
        if (board.IsLocationEmpty(location.ArraySpotInt - 7))
        {
          RecursiveSetUpperRight(board, new Location(location.ArraySpotInt - 7), initialPieceSide);
        }
      }
    }

    public static void RecursiveSetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt + 7, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 7));
        if (board.IsLocationEmpty(location.ArraySpotInt + 7))
        {
          RecursiveSetLowerLeft(board, new Location(location.ArraySpotInt + 7), initialPieceSide);
        }
      }
    }

    public static void RecursiveSetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 9, initialPieceSide))
      {
        board.MoveableSpaces.Add(new Location(location.ArraySpotInt + 9));
        if (board.IsLocationEmpty(location.ArraySpotInt + 9))
        {
          RecursiveSetLowerRight(board, new Location(location.ArraySpotInt + 9), initialPieceSide);
        }
      }
    }
    #endregion

    #region " Recursive Get Moves "

    public static IEnumerable<Location> RecursiveGetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 1, initialPieceSide))
      {
        Location oneLeft = new Location(location.ArraySpotInt - 1);
        returnList.Add(oneLeft);
        if (board.IsLocationEmpty(location.ArraySpotInt - 1))
        {
          RecursiveGetLeft(board, oneLeft, initialPieceSide, returnList);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 8, initialPieceSide))
      {
        Location oneDown = new Location(location.ArraySpotInt - 8);
        returnList.Add(oneDown);
        if (board.IsLocationEmpty(location.ArraySpotInt - 8))
        {
          RecursiveGetUp(board, oneDown, initialPieceSide, returnList);
        }
      }
      return returnList;

    }

    public static IEnumerable<Location> RecursiveGetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 1, initialPieceSide))
      {
        Location oneRight = new Location(location.ArraySpotInt + 1);
        returnList.Add(oneRight);
        if (board.IsLocationEmpty(location.ArraySpotInt + 1))
        {
          RecursiveGetRight(board, oneRight, initialPieceSide, returnList);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 8, initialPieceSide))
      {
        Location oneDown = new Location(location.ArraySpotInt + 8);
        returnList.Add(oneDown);
        if (board.IsLocationEmpty(location.ArraySpotInt + 8))
        {
          RecursiveGetDown(board, oneDown, initialPieceSide, returnList);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt - 9, initialPieceSide))
      {
        Location oneUpperLeft = new Location(location.ArraySpotInt - 9);
        returnList.Add(oneUpperLeft);
        if (board.IsLocationEmpty(location.ArraySpotInt - 9))
        {
          RecursiveGetUpperLeft(board, oneUpperLeft, initialPieceSide, returnList);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt - 7, initialPieceSide))
      {
        Location oneUpperRight = new Location(location.ArraySpotInt - 7);
        returnList.Add(oneUpperRight);
        if (board.IsLocationEmpty(location.ArraySpotInt - 7))
        {
          RecursiveGetUpperRight(board, oneUpperRight, initialPieceSide, returnList);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0 && !board.IsLocationOfTeamType(location.ArraySpotInt + 7, initialPieceSide))
      {
        Location oneLowerLeft = new Location(location.ArraySpotInt + 7);
        returnList.Add(oneLowerLeft);
        if (board.IsLocationEmpty(location.ArraySpotInt + 7))
        {
          RecursiveGetLowerLeft(board, oneLowerLeft, initialPieceSide, returnList);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7 && !board.IsLocationOfTeamType(location.ArraySpotInt + 9, initialPieceSide))
      {
        Location oneLowerRight = new Location(location.ArraySpotInt + 9);
        returnList.Add(oneLowerRight);
        if (board.IsLocationEmpty(location.ArraySpotInt + 9))
        {
          RecursiveGetLowerRight(board, oneLowerRight, initialPieceSide, returnList);
        }
      }
      return returnList;
    }

    #endregion
   
    public static IPiece GetPieceInstanceFromString(String pokemonName, int arrayLocation, Enums.TeamType blackType, Enums.TeamType whiteType)
    {
      switch (pokemonName)
      {
        case PokemonNames.Arcanine:
          if (blackType == Enums.TeamType.Fire) { return new Arcanine(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Arcanine(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Vulpix:
          if (blackType == Enums.TeamType.Fire) { return new Vulpix(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Vulpix(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Ninetails:
          if (blackType == Enums.TeamType.Fire) { return new Ninetails(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Ninetails(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Charizard:
          if (blackType == Enums.TeamType.Fire) { return new Charizard(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Charizard(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Magmar:
          if (blackType == Enums.TeamType.Fire) { return new Magmar(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Magmar(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Rapidash:
          if (blackType == Enums.TeamType.Fire) { return new Rapidash(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Rapidash(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Venusaur:
          if (blackType == Enums.TeamType.Grass) { return new Venusaur(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Venusaur(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Victreebell:
          if (blackType == Enums.TeamType.Grass) { return new Victreebell(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Victreebell(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Oddish:
          if (blackType == Enums.TeamType.Grass) { return new Oddish(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Oddish(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Tangela:
          if (blackType == Enums.TeamType.Grass) { return new Tangela(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Tangela(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Exeggutor:
          if (blackType == Enums.TeamType.Grass) { return new Exeggutor(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Exeggutor(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Vileplume:
          if (blackType == Enums.TeamType.Grass) { return new Vileplume(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Vileplume(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Grimer:
          if (blackType == Enums.TeamType.Poison) { return new Grimer(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Grimer(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Weezing:
          if (blackType == Enums.TeamType.Poison) { return new Weezing(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Weezing(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Arbok:
          if (blackType == Enums.TeamType.Poison) { return new Arbok(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Arbok(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Gengar:
          if (blackType == Enums.TeamType.Poison) { return new Gengar(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Gengar(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Nidoking:
          if (blackType == Enums.TeamType.Poison) { return new Nidoking(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Nidoking(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Nidoqueen:
          if (blackType == Enums.TeamType.Poison) { return new Nidoqueen(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Nidoqueen(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Seadra:
          if (blackType == Enums.TeamType.Water) { return new Seadra(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Seadra(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Poliwrath:
          if (blackType == Enums.TeamType.Water) { return new Poliwrath(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Poliwrath(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Lapras:
          if (blackType == Enums.TeamType.Water) { return new Lapras(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Lapras(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Magikarp:
          if (blackType == Enums.TeamType.Water) { return new Magikarp(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Magikarp(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Golduck:
          if (blackType == Enums.TeamType.Water) { return new Golduck(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Golduck(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case PokemonNames.Blastoise:
          if (blackType == Enums.TeamType.Water) { return new Blastoise(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Blastoise(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        default: break;
      }
      return null;
    }
  }
}
