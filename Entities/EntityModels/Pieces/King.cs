using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using PokemonChess;

namespace Entities.EntityModels.Pieces
{
  public class King : PropertyChangedBase, IMoveMechanics
  {
    public IEnumerable<Location> GetKingMovableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      General.GetLeft(board, piece.Location, piece.Side, returnList);
      General.GetUp(board, piece.Location, piece.Side, returnList);
      General.GetRight(board, piece.Location, piece.Side, returnList);
      General.GetDown(board, piece.Location, piece.Side, returnList);
      General.GetUpperLeft(board, piece.Location, piece.Side, returnList);
      General.GetUpperRight(board, piece.Location, piece.Side, returnList);
      General.GetLowerLeft(board, piece.Location, piece.Side, returnList);
      General.GetLowerRight(board, piece.Location, piece.Side, returnList);
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      General.SetLeft(board, piece.Location, piece.Side);
      General.SetUp(board, piece.Location, piece.Side);
      General.SetRight(board, piece.Location, piece.Side);
      General.SetDown(board, piece.Location, piece.Side);
      General.SetUpperLeft(board, piece.Location, piece.Side);
      General.SetUpperRight(board, piece.Location, piece.Side);
      General.SetLowerLeft(board, piece.Location, piece.Side);
      General.SetLowerRight(board, piece.Location, piece.Side);
    }
  }
}
