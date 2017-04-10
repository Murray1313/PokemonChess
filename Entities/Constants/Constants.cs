using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{


  #region FileSuffixes
  public class FileSuffixes
  {
    public const string ImageSuffix = ".png";
    public const string PieceSuffix = "Piece.png";
  }
  #endregion


  #region FolderPaths
  public class FolderPaths
  {
    public const string FireFolder = "/PokemonChess;component/Images/FirePokemon/";
    public const string GrassFolder = "/PokemonChess;component/Images/GrassPokemon/";
    public const string PoisonFolder = "/PokemonChess;component/Images/PoisonPokemon/";
    public const string WaterFolder = "/PokemonChess;component/Images/WaterPokemon/";
  }
  #endregion


  #region PieceTypes
  public class PieceTypes
  {
    public const string King = "King";
    public const string Queen = "Queen";
    public const string Rook = "Rook";
    public const string Bishop = "Bishop";
    public const string Knight = "Knight";
    public const string Pawn = "Pawn";
  }
  #endregion


  #region PokemonNames
  public class PokemonNames
  {
    // Fire
    public const string Arcanine = "Arcanine";
    public const string Vulpix = "Vulpix";
    public const string Ninetails = "Ninetails";
    public const string Charizard = "Charizard";
    public const string Magmar = "Magmar";
    public const string Rapidash = "Rapidash";

    // Water
    public const string Seadra = "Seadra";
    public const string Poliwrath = "Poliwrath";
    public const string Lapras = "Lapras";
    public const string Magikarp = "Magikarp";
    public const string Golduck = "Golduck";
    public const string Blastoise = "Blastoise";

    // Grass
    public const string Venusaur = "Venusaur";
    public const string Victreebell = "Victreebell";
    public const string Oddish = "Oddish";
    public const string Tangela = "Tangela";
    public const string Exeggutor = "Exeggutor";
    public const string Vileplume = "Vileplume";

    // Grass
    public const string Grimer = "Grimer";
    public const string Weezing = "Weezing";
    public const string Arbok = "Arbok";
    public const string Gengar = "Gengar";
    public const string Nidoking = "Nidoking";
    public const string Nidoqueen = "Nidoqueen";
  }
  #endregion
}
