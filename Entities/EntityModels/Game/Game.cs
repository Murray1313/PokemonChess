using System;
using System.Windows.Media;
using Caliburn.Micro;
using Entities.Interfaces;
using Entities.EntityModels.Game;

namespace Entities
{
  public class Game : PropertyChangedBase
  {

    #region " Private "
    private int _turnCount;
    private SharedEnums.Enums.BlackOrWhite _currentTurn = SharedEnums.Enums.BlackOrWhite.White;
    private IPiece _selectedPiece;
    private FaintedPokemonGraveyard _faintedWhitePokes = new FaintedPokemonGraveyard();
    private FaintedPokemonGraveyard _faintedBlackPokes = new FaintedPokemonGraveyard();
    #endregion


    #region " Constructor "

    public Game()
    {
      this.IsSaved = false;
      this.WhiteTeam = new Team();
      this.BlackTeam = new Team();
      this.TurnCount = 1;
      this.GameBoard = new Board();
      this.FaintedWhitePokes = new FaintedPokemonGraveyard();
      this.FaintedBlackPokes = new FaintedPokemonGraveyard();
    }

    public Game(SharedEnums.Enums.TeamType whiteType, SharedEnums.Enums.TeamType blackType)
    {
      this.IsSaved = false;
      this.WhiteTeam = new Team(SharedEnums.Enums.BlackOrWhite.White, whiteType);
      this.BlackTeam = new Team(SharedEnums.Enums.BlackOrWhite.Black, blackType);
      this.TurnCount = 1;
      this.GameBoard = new Board(this.WhiteTeam, this.BlackTeam);
      this.FaintedWhitePokes = new FaintedPokemonGraveyard();
      this.FaintedBlackPokes = new FaintedPokemonGraveyard();
    }

    #endregion


    #region " Properties "

    public Board GameBoard { get; set; }

    public bool IsSaved { get; set; }

    public Team WhiteTeam { get; set; }

    public Team BlackTeam { get; set; }

    public int TurnCount
    {
      get { return _turnCount; }
      set
      {
        _turnCount = value;
        NotifyOfPropertyChange(() => TurnCount);
      }
    }

    public SharedEnums.Enums.BlackOrWhite CurrentTurn
    {
      get { return _currentTurn; }
      set
      {
        _currentTurn = value;
        NotifyOfPropertyChange(() => CurrentTurn);
        NotifyOfPropertyChange(() => DisplayCurrentTurn);
      }
    }

    public IPiece SelectedPiece
    {
      get { return _selectedPiece; }
      set
      {
        _selectedPiece = value;
        NotifyOfPropertyChange(() => SelectedPiece);
        NotifyOfPropertyChange(() => DisplaySelectedPieceTitle);
      }
    }

    public String DisplaySelectedPieceTitle
    {
      get
      {
        if (this.SelectedPiece != null)
        {
          return $"{this.SelectedPiece.ChessPieceType} {this.SelectedPiece.Name}";
        }
        else { return String.Empty; }
      }
    }
    
    public String DisplayCurrentTurn
    {
      get
      {
        if (this.CurrentTurn == SharedEnums.Enums.BlackOrWhite.Black) { return "Black's Turn"; }
        else if (this.CurrentTurn == SharedEnums.Enums.BlackOrWhite.White) { return "White's Turn"; }
        else { return String.Empty; }
      }
    }

    public FaintedPokemonGraveyard FaintedWhitePokes
    {
      get { return _faintedWhitePokes; }
      set
      {
        _faintedWhitePokes = value;
        NotifyOfPropertyChange(() => FaintedWhitePokes);
      }
    }

    public FaintedPokemonGraveyard FaintedBlackPokes
    {
      get { return _faintedBlackPokes; }
      set
      {
        _faintedBlackPokes = value;
        NotifyOfPropertyChange(() => FaintedBlackPokes);
      }
    }
    #endregion


    #region " Methods "

    public void ChangeTurn()
    {
      this.CurrentTurn = (this.CurrentTurn == SharedEnums.Enums.BlackOrWhite.White) 
        ? SharedEnums.Enums.BlackOrWhite.Black 
        : SharedEnums.Enums.BlackOrWhite.White;
      this.TurnCount++;
    }

    public void SetSelected(IPiece newPiece)
    {
      if (this.SelectedPiece != null) { this.SelectedPiece.IsSelected = false; }
      this.SelectedPiece = newPiece;
      this.SelectedPiece.IsSelected = true;
    }
    #endregion

  }
}
