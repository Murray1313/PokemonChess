using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Entities.Constants
{

  #region FileSuffixes
  public static class FileSuffixes
  {
    public const string ImageSuffix = ".png";
    public const string PieceSuffix = "Piece.png";
  }
  #endregion


  #region FolderPaths
  public static class FolderPaths
  {
    public const string FireFolder = "/PokemonChess;component/Images/FirePokemon/";
    public const string GrassFolder = "/PokemonChess;component/Images/GrassPokemon/";
    public const string PoisonFolder = "/PokemonChess;component/Images/PoisonPokemon/";
    public const string WaterFolder = "/PokemonChess;component/Images/WaterPokemon/";

    #region BlackPieces
    public const string BlackKingPath = "pack://application:,,,/Images/ChessPieces/BlackKing.PNG";
    public static ImageSource BlackKingImageSource { get { return StringToImageSource(BlackKingPath); } }

    public const string BlackQueenPath = "pack://application:,,,/Images/ChessPieces/BlackQueen.PNG";
    public static ImageSource BlackQueenImageSource { get { return StringToImageSource(BlackQueenPath); } }

    public const string BlackRookPath = "pack://application:,,,/Images/ChessPieces/BlackRook.PNG";
    public static ImageSource BlackRookImageSource { get { return StringToImageSource(BlackRookPath); } }

    public const string BlackBishopPath = "pack://application:,,,/Images/ChessPieces/BlackBishop.PNG";
    public static ImageSource BlackBishopImageSource { get { return StringToImageSource(BlackBishopPath); } }

    public const string BlackKnightPath = "pack://application:,,,/Images/ChessPieces/BlackKnight.PNG";
    public static ImageSource BlackKnightImageSource { get { return StringToImageSource(BlackKnightPath); } }

    public const string BlackPawnPath = "pack://application:,,,/Images/ChessPieces/BlackPawn.PNG";
    public static ImageSource BlackPawnImageSource { get { return StringToImageSource(BlackPawnPath); } }
    #endregion


    #region WhitePieces
    public const string WhiteKingPath = "pack://application:,,,/Images/ChessPieces/WhiteKing.PNG";
    public static ImageSource WhiteKingImageSource { get { return StringToImageSource(WhiteKingPath); } }

    public const string WhiteQueenPath = "pack://application:,,,/Images/ChessPieces/WhiteQueen.PNG";
    public static ImageSource WhiteQueenImageSource { get { return StringToImageSource(WhiteQueenPath); } }

    public const string WhiteRookPath = "pack://application:,,,/Images/ChessPieces/WhiteRook.PNG";
    public static ImageSource WhiteRookImageSource { get { return StringToImageSource(WhiteRookPath); } }

    public const string WhiteBishopPath = "pack://application:,,,/Images/ChessPieces/WhiteBishop.PNG";
    public static ImageSource WhiteBishopImageSource { get { return StringToImageSource(WhiteBishopPath); } }

    public const string WhiteKnightPath = "pack://application:,,,/Images/ChessPieces/WhiteKnight.PNG";
    public static ImageSource WhiteKnightImageSource { get { return StringToImageSource(WhiteKnightPath); } }

    public const string WhitePawnPath = "pack://application:,,,/Images/ChessPieces/WhitePawn.PNG";
    public static ImageSource WhitePawnImageSource { get { return StringToImageSource(WhitePawnPath); } }
    #endregion


    public static ImageSource StringToImageSource(string path)
    {
      var converter = new ImageSourceConverter();
      return (ImageSource)converter.ConvertFromString(path);
    }
  }
  #endregion


  #region PieceTypes
  public static class PieceTypes
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
  public static class PokemonNames
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
