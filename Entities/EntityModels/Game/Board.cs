using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Entities.EntityModels.PokemonPieces;
using Entities.EntityModels.Pieces;
using PokemonChess;

namespace Entities
{
  public class Board : PropertyChangedBase
  {
    #region " Private "
    private IPiece[] _boardPieces;
    #endregion


    #region " Constructor "
    public Board()
    {
      this.BoardPieces = new IPiece[64];
      for (int x = 0; x < 64; x++)
      {
        this.BoardPieces[x] = new BlankSpace(x);
      }
    }

    public Board(Team whiteTeam, Team blackTeam)
    {
      this.BoardPieces = new IPiece[64];
      for (int x = 0; x < 64; x++) { this.BoardPieces[x] = new BlankSpace(x); }

      this.PlacePieces(whiteTeam);
      this.PlacePieces(blackTeam);
    }

    public Board(BindableCollection<String> importedStrings, SharedEnums.Enums.TeamType blackType, SharedEnums.Enums.TeamType whiteType)
    {
      this.BoardPieces = new IPiece[64];
      for (int x = 0; x < 64; x++)
      {
        if (importedStrings.ElementAt(x).Equals("BlankSpace"))
        {
          this.BoardPieces[x] = new BlankSpace(x);
        }
        else
        {
          this.BoardPieces[x] = General.GetPieceInstanceFromString(importedStrings.ElementAt(x), x, blackType, whiteType);
        }
      }
    }
    #endregion


    #region " Properties "

    public IPiece[] BoardPieces
    {
      get { return _boardPieces; }
      set
      {
        _boardPieces = value;
        NotifyOfPropertyChange(() => BoardPieces);
      }
    }

    #endregion


    #region " Methods "
    private void PlacePieces(Team team)
    {
      foreach (IPiece piece in team.Pieces) { this.BoardPieces[piece.Location.ArraySpotInt] = piece; }
    }

    public void ClearPlayablePieces()
    {
      for (int x = 0; x < 64; x++) { this.BoardPieces[x].IsMovableSpace = false; }
    }


    public IEnumerable<Location> GetPlayableSpaces(IPiece piece)
    {
      IEnumerable<Location> returnList = new List<Location>();
      switch (piece.GetType().BaseType.Name)
      {
        case Constants.PieceTypes.Pawn:
          Pawn pawn = (Pawn)piece;
          returnList = pawn.GetPawnsConquerableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Knight:
          Knight knight = (Knight)piece;
          returnList = knight.GetKnightsConquerableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Bishop:
          Bishop bishop = (Bishop)piece;
          returnList = bishop.GetBishopsConquerableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Rook:
          Rook rook = (Rook)piece;
          returnList = rook.GetRooksConquerableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Queen:
          Queen queen = (Queen)piece;
          returnList = queen.GetQueenConquerableSpaces(this, piece);
          break;
        case Constants.PieceTypes.King:
          King king = (King)piece;
          returnList = king.GetKingMovableSpaces(this, piece);
          break;
        default: break;
      }
      return returnList;
    }

    public void SetPlayablePieces(IPiece piece)
    {
      ClearPlayablePieces();
      switch (piece.GetType().BaseType.Name)
      {
        case Constants.PieceTypes.Pawn:
          Pawn pawn = (Pawn)piece;
          pawn.SetMovableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Knight:
          Knight knight = (Knight)piece;
          knight.SetMovableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Bishop:
          Bishop bishop = (Bishop)piece;
          bishop.SetMovableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Rook:
          Rook rook = (Rook)piece;
          rook.SetMovableSpaces(this, piece);
          break;
        case Constants.PieceTypes.Queen:
          Queen queen = (Queen)piece;
          queen.SetMovableSpaces(this, piece);
          break;
        case Constants.PieceTypes.King:
          King king = (King)piece;
          king.SetMovableSpaces(this, piece);
          break;
        default: break;
      }
    }
    #endregion
  }
}
