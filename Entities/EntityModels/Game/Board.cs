using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Entities.SharedEnums;
using Entities.EntityModels.Pieces;
using PokemonChess;

namespace Entities
{
  public class Board : PropertyChangedBase
  {
    #region " Private "
    private BindableCollection<IPiece> _boardPieceCollection;
    private BindableCollection<Location> _moveableSpaces;
    #endregion


    #region " Constructor "
    public Board()
    {
      this.BoardPieceCollection = new BindableCollection<IPiece>();
      this.MoveableSpaces = new BindableCollection<Location>();
    }

    public Board(Team whiteTeam, Team blackTeam)
    {
      this.BoardPieceCollection = new BindableCollection<IPiece>();
      this.BoardPieceCollection.AddRange(whiteTeam.Pieces);
      this.BoardPieceCollection.AddRange(blackTeam.Pieces);
      this.MoveableSpaces = new BindableCollection<Location>();
    }

    public Board(BindableCollection<String> importedStrings, Enums.TeamType blackType, Enums.TeamType whiteType)
    {
      this.BoardPieceCollection = new BindableCollection<IPiece>();
      this.MoveableSpaces = new BindableCollection<Location>();
      foreach (String pokemonData in importedStrings)
      {
        string[] pokemonDataPieces = pokemonData.Split(' ');
        this.BoardPieceCollection.Add(General.GetPieceInstanceFromString(pokemonDataPieces[0], Int32.Parse(pokemonDataPieces[1]), blackType, whiteType));
      }
    }
    #endregion


    #region " Properties "

    public BindableCollection<IPiece> BoardPieceCollection
    {
      get { return _boardPieceCollection; }
      set
      {
        _boardPieceCollection = value;
        NotifyOfPropertyChange(() => BoardPieceCollection);
      }
    }

    public BindableCollection<Location> MoveableSpaces
    {
      get { return _moveableSpaces; }
      set
      {
        _moveableSpaces = value;
        NotifyOfPropertyChange(() => MoveableSpaces);
      }
    }
    #endregion


    #region " Methods "
    public bool IsLocationEmpty(int boardLocation)
    {
      return !this.BoardPieceCollection.Any(x => x.Location.ArraySpotInt == boardLocation);
    }

    public bool IsLocationOfTeamType(int boardLocation, Enums.BlackOrWhite teamType)
    {
      IPiece possiblePiece = BoardPieceCollection.FirstOrDefault(x => x.Location.ArraySpotInt == boardLocation);
      return (possiblePiece != null) ? possiblePiece.Side == teamType : false;
    }

    #endregion
  }
}
