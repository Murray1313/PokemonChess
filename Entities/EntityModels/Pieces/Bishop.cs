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
  public class Bishop : PropertyChangedBase, IMoveMechanics
  {

    public IEnumerable<Location> GetBishopsConquerableSpaces(Board board, IPiece piece)
    {
      List<Location> returnList = new List<Location>();
      General.RecursiveGetUpperLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetUpperRight(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetLowerLeft(board, piece.Location, piece.Side, returnList);
      General.RecursiveGetLowerRight(board, piece.Location, piece.Side, returnList);
      return returnList;
    }

    public void SetMovableSpaces(Board board, IPiece piece)
    {
      General.RecursiveSetUpperLeft(board, piece.Location, piece.Side);
      General.RecursiveSetUpperRight(board, piece.Location, piece.Side);
      General.RecursiveSetLowerLeft(board, piece.Location, piece.Side);
      General.RecursiveSetLowerRight(board, piece.Location, piece.Side);
    }
  }
}
