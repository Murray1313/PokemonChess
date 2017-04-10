using Entities;
using Entities.EntityModels.Pieces;
using Entities.EntityModels.PokemonPieces;
using Entities.Interfaces;
using Entities.SharedEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonChess
{
  public static class General
  {

    #region " Single Check Moves "

    public static void SetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 1].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 1].IsMovableSpace = true;
        }
      }
    }

    public static void SetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 8].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 8].IsMovableSpace = true;
        }
      }
    }

    public static void SetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 1].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 1].IsMovableSpace = true;
        }
      }
    }

    public static void SetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 8].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 8].IsMovableSpace = true;
        }
      }
    }

    public static void SetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 9].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 9].IsMovableSpace = true;
        }
      }
    }

    public static void SetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt - 7].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 7].IsMovableSpace = true;
        }
      }
    }

    public static void SetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt + 7].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 7].IsMovableSpace = true;
        }
      }
    }

    public static void SetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 9].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 9].IsMovableSpace = true;
        }
      }
    }

    #endregion

    #region " Single Get Moves "

    public static IEnumerable<Location> GetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 1].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 1].Location);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> GetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 8].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 8].Location);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> GetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 1].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 1].Location);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> GetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 8].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 8].Location);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> GetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 9].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 9].Location);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> GetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt - 7].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 7].Location);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> GetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt + 7].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 7].Location);
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> GetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 9].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 9].Location);
        }
      }
      return returnList;
    }

    #endregion

    #region " Recursive Set Moves "
    public static void RecursiveSetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 1].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 1].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt - 1].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetLeft(board, board.BoardPieces[location.ArraySpotInt - 1].Location, initialPieceSide);
          }
        }
      }
    }

    public static void RecursiveSetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 8].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 8].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt - 8].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetUp(board, board.BoardPieces[location.ArraySpotInt - 8].Location, initialPieceSide);
          }
        }
      }
    }

    public static void RecursiveSetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 1].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 1].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt + 1].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetRight(board, board.BoardPieces[location.ArraySpotInt + 1].Location, initialPieceSide);
          }
        }
      }
    }

    public static void RecursiveSetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 8].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 8].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt + 8].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetDown(board, board.BoardPieces[location.ArraySpotInt + 8].Location, initialPieceSide);
          }
        }
      }
    }

    public static void RecursiveSetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 9].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 9].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt - 9].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetUpperLeft(board, board.BoardPieces[location.ArraySpotInt - 9].Location, initialPieceSide);
          }
        }
      }
    }

    public static void RecursiveSetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt - 7].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt - 7].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt - 7].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetUpperRight(board, board.BoardPieces[location.ArraySpotInt - 7].Location, initialPieceSide);
          }
        }
      }
    }

    public static void RecursiveSetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt + 7].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 7].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt + 7].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetLowerLeft(board, board.BoardPieces[location.ArraySpotInt + 7].Location, initialPieceSide);
          }
        }
      }
    }

    public static void RecursiveSetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 9].Side != initialPieceSide)
        {
          board.BoardPieces[location.ArraySpotInt + 9].IsMovableSpace = true;
          if (board.BoardPieces[location.ArraySpotInt + 9].Side == Enums.BlackOrWhite.None)
          {
            RecursiveSetLowerRight(board, board.BoardPieces[location.ArraySpotInt + 9].Location, initialPieceSide);
          }
        }
      }
    }
    #endregion

    #region " Recursive Get Moves "

    public static IEnumerable<Location> RecursiveGetLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 1].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 1].Location);
          if (board.BoardPieces[location.ArraySpotInt - 1].Side == Enums.BlackOrWhite.None)
          {
            returnList.AddRange(RecursiveGetLeft(board, board.BoardPieces[location.ArraySpotInt - 1].Location, initialPieceSide, returnList));
          }
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetUp(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 8].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 8].Location);
          if (board.BoardPieces[location.ArraySpotInt - 8].Side == Enums.BlackOrWhite.None)
          {
            returnList.AddRange(RecursiveGetUp(board, board.BoardPieces[location.ArraySpotInt - 8].Location, initialPieceSide, returnList));
          }
        }
      }
      return returnList;

    }

    public static IEnumerable<Location> RecursiveGetRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 1].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 1].Location);
          if (board.BoardPieces[location.ArraySpotInt + 1].Side == Enums.BlackOrWhite.None)
          {
            RecursiveGetRight(board, board.BoardPieces[location.ArraySpotInt + 1].Location, initialPieceSide, returnList);
          }
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetDown(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 8].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 8].Location);
          if (board.BoardPieces[location.ArraySpotInt + 8].Side == Enums.BlackOrWhite.None)
          {
            RecursiveGetDown(board, board.BoardPieces[location.ArraySpotInt + 8].Location, initialPieceSide, returnList);
          }
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetUpperLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt - 9].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 9].Location);
          if (board.BoardPieces[location.ArraySpotInt - 9].Side == Enums.BlackOrWhite.None)
          {
            RecursiveGetUpperLeft(board, board.BoardPieces[location.ArraySpotInt - 9].Location, initialPieceSide, returnList);
          }
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetUpperRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord > 0 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt - 7].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt - 7].Location);
          if (board.BoardPieces[location.ArraySpotInt - 7].Side == Enums.BlackOrWhite.None)
          {
            RecursiveGetUpperRight(board, board.BoardPieces[location.ArraySpotInt - 7].Location, initialPieceSide, returnList);
          }
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetLowerLeft(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord > 0)
      {
        if (board.BoardPieces[location.ArraySpotInt + 7].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 7].Location);
          if (board.BoardPieces[location.ArraySpotInt + 7].Side == Enums.BlackOrWhite.None)
          {
            RecursiveGetLowerLeft(board, board.BoardPieces[location.ArraySpotInt + 7].Location, initialPieceSide, returnList);
          }
        }
      }
      return returnList;
    }

    public static IEnumerable<Location> RecursiveGetLowerRight(Board board, Location location, Enums.BlackOrWhite initialPieceSide, List<Location> returnList)
    {
      if ((int)location.XCoord < 7 && (int)location.YCoord < 7)
      {
        if (board.BoardPieces[location.ArraySpotInt + 9].Side != initialPieceSide)
        {
          returnList.Add(board.BoardPieces[location.ArraySpotInt + 9].Location);
          if (board.BoardPieces[location.ArraySpotInt + 9].Side == Enums.BlackOrWhite.None)
          {
            RecursiveGetLowerRight(board, board.BoardPieces[location.ArraySpotInt + 9].Location, initialPieceSide, returnList);
          }
        }
      }
      return returnList;
    }

    #endregion


    public static bool EnsureKingSafety(Board board, Enums.BlackOrWhite side)
    {
      IEnumerable<IPiece> enemyPieces = board.BoardPieces.Where(x => x.Side != side && x.Side != Enums.BlackOrWhite.None);

      foreach (IPiece enemyPiece in enemyPieces)
      {
        IEnumerable<Location> movableLocations = board.GetPlayableSpaces(enemyPiece);
        foreach (Location location in movableLocations)
        {
          IPiece foundPiece = board.BoardPieces.FirstOrDefault(x => x.Location.ArraySpotInt == location.ArraySpotInt);
          if (foundPiece != null && foundPiece.ChessPieceType == Enums.Pieces.King && foundPiece.Side == side)
          {
            return true;
          }
        }
      }
      return false;
    }

    public static IPiece GetPieceInstanceFromString(String pokemonName, int arrayLocation, Enums.TeamType blackType, Enums.TeamType whiteType)
    {
      switch (pokemonName)
      {
        case Entities.Constants.PokemonNames.Arcanine:
          if (blackType == Enums.TeamType.Fire)  { return new Arcanine(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Arcanine(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Vulpix:
          if (blackType == Enums.TeamType.Fire) { return new Vulpix(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Vulpix(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Ninetails:
          if (blackType == Enums.TeamType.Fire) { return new Ninetails(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Ninetails(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Charizard:
          if (blackType == Enums.TeamType.Fire) { return new Charizard(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Charizard(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Magmar:
          if (blackType == Enums.TeamType.Fire) { return new Magmar(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Magmar(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Rapidash:
          if (blackType == Enums.TeamType.Fire) { return new Rapidash(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Fire) { return new Rapidash(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Venusaur:
          if (blackType == Enums.TeamType.Grass) { return new Venusaur(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Venusaur(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Victreebell:
          if (blackType == Enums.TeamType.Grass) { return new Victreebell(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Victreebell(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Oddish:
          if (blackType == Enums.TeamType.Grass) { return new Oddish(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Oddish(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Tangela:
          if (blackType == Enums.TeamType.Grass) { return new Tangela(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Tangela(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Exeggutor:
          if (blackType == Enums.TeamType.Grass) { return new Exeggutor(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Exeggutor(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Vileplume:
          if (blackType == Enums.TeamType.Grass) { return new Vileplume(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Grass) { return new Vileplume(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Grimer:
          if (blackType == Enums.TeamType.Poison) { return new Grimer(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Grimer(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Weezing:
          if (blackType == Enums.TeamType.Poison) { return new Weezing(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Weezing(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Arbok:
          if (blackType == Enums.TeamType.Poison) { return new Arbok(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Arbok(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Gengar:
          if (blackType == Enums.TeamType.Poison) { return new Gengar(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Gengar(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Nidoking:
          if (blackType == Enums.TeamType.Poison) { return new Nidoking(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Nidoking(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Nidoqueen:
          if (blackType == Enums.TeamType.Poison) { return new Nidoqueen(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Poison) { return new Nidoqueen(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Seadra:
          if (blackType == Enums.TeamType.Water) { return new Seadra(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Seadra(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Poliwrath:
          if (blackType == Enums.TeamType.Water) { return new Poliwrath(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Poliwrath(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Lapras:
          if (blackType == Enums.TeamType.Water) { return new Lapras(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Lapras(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Magikarp:
          if (blackType == Enums.TeamType.Water) { return new Magikarp(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Magikarp(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Golduck:
          if (blackType == Enums.TeamType.Water) { return new Golduck(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Golduck(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        case Entities.Constants.PokemonNames.Blastoise:
          if (blackType == Enums.TeamType.Water) { return new Blastoise(Enums.BlackOrWhite.Black, arrayLocation); }
          else if (whiteType == Enums.TeamType.Water) { return new Blastoise(Enums.BlackOrWhite.White, arrayLocation); }
          break;
        default: break;
      }
      return null;
    }

    public static bool IsCheckmate(Board board, Enums.BlackOrWhite blackOrWhite)
    {
      blackOrWhite = (blackOrWhite == Enums.BlackOrWhite.White) ? Enums.BlackOrWhite.Black : Enums.BlackOrWhite.White;
      bool isCheckmate = true;

      IPiece king = board.BoardPieces.FirstOrDefault(x => x.ChessPieceType == Enums.Pieces.King && x.Side == blackOrWhite);
      Location kingStartSpot = king.Location;
      
      List<Location> returnList = new List<Location>();
      GetLeft(board, kingStartSpot, king.Side, returnList);
      GetUp(board, kingStartSpot, king.Side, returnList);
      GetRight(board, kingStartSpot, king.Side, returnList);
      GetDown(board, kingStartSpot, king.Side, returnList);
      GetUpperLeft(board, kingStartSpot, king.Side, returnList);
      GetUpperRight(board, kingStartSpot, king.Side, returnList);
      GetLowerLeft(board, kingStartSpot, king.Side, returnList);
      GetLowerRight(board, kingStartSpot, king.Side, returnList);

      foreach (Location location in returnList)
      {
        IPiece oldPiece = board.BoardPieces[location.ArraySpotInt];
        king.Location = location;
        board.BoardPieces[king.Location.ArraySpotInt] = king;
        board.BoardPieces[kingStartSpot.ArraySpotInt] = new BlankSpace(kingStartSpot);
        isCheckmate = EnsureKingSafety(board, blackOrWhite);
        king.Location = kingStartSpot;
        board.BoardPieces[kingStartSpot.ArraySpotInt] = king;
        board.BoardPieces[location.ArraySpotInt] = oldPiece;
      }
      return isCheckmate;
    }
  }
}
