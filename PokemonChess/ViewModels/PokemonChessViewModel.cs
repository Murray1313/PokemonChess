﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using Entities;
using Entities.EntityModels;
using Entities.SharedEnums;
using Entities.Interfaces;
using System.Windows.Controls;
using Entities.EntityModels.Pieces;
using System.Windows;
using Entities.EntityModels.Pieces.PokemonPieces;
using System.Windows.Media.Imaging;

namespace PokemonChess.ViewModels
{
  [Export(typeof(PokemonChessViewModel))]
  public class PokemonChessViewModel : PropertyChangedBase
  {
    #region " Private "
    private Enums.TeamType _whiteTeamType;
    private Enums.TeamType _blackTeamType;
    private readonly IWindowManager _windowManager;
    #endregion


    [ImportingConstructor]
    public PokemonChessViewModel(PieceDataViewModel pieceDataScreen, IWindowManager windowManager)
    {
      this.PieceDataScreen = pieceDataScreen;
      _windowManager = windowManager;
    }

    #region " Properties "

    public Game CurrentGame { get; set; }

    public PieceDataViewModel PieceDataScreen { get; private set; }

    public Enums.TeamType WhiteTeamType
    {
      get { return _whiteTeamType; }
      set
      {
        _whiteTeamType = value;
        NotifyOfPropertyChange(() => WhiteTeamType);
      }
    }

    public Enums.TeamType BlackTeamType
    {
      get { return _blackTeamType; }
      set
      {
        _blackTeamType = value;
        NotifyOfPropertyChange(() => WhiteTeamType);
      }
    }
    #endregion


    #region " Event Methods "
    public void SelectSpace(IPiece selectedPiece)
    {
      if (selectedPiece != null)
      {
        this.CurrentGame.GameBoard.ClearPlayablePieces();
        this.CurrentGame.SetSelected(selectedPiece);

        if (selectedPiece.Side == this.CurrentGame.CurrentTurn)
        {
          this.CurrentGame.GameBoard.SetPlayablePieces(selectedPiece);
          if (selectedPiece.ChessPieceType == Enums.Pieces.King)
          {
            King king = (King)selectedPiece;
            if (selectedPiece.Side == Enums.BlackOrWhite.Black)
            {
              if (this.CurrentGame.BlackTeam.CanCastleLeft == true &&
                  this.CurrentGame.GameBoard.BoardPieces[1].Side == Enums.BlackOrWhite.None &&
                  this.CurrentGame.GameBoard.BoardPieces[2].Side == Enums.BlackOrWhite.None &&
                  this.CurrentGame.GameBoard.BoardPieces[3].Side == Enums.BlackOrWhite.None)
              {
                this.CurrentGame.GameBoard.BoardPieces[2].IsMovableSpace = true;
              }
              if (this.CurrentGame.BlackTeam.CanCastleRight == true &&
                  this.CurrentGame.GameBoard.BoardPieces[5].Side == Enums.BlackOrWhite.None &&
                  this.CurrentGame.GameBoard.BoardPieces[6].Side == Enums.BlackOrWhite.None)
              {
                this.CurrentGame.GameBoard.BoardPieces[6].IsMovableSpace = true;
              }
            }
            else if (selectedPiece.Side == Enums.BlackOrWhite.White)
            {
              if (this.CurrentGame.WhiteTeam.CanCastleLeft == true &&
                  this.CurrentGame.GameBoard.BoardPieces[57].Side == Enums.BlackOrWhite.None &&
                  this.CurrentGame.GameBoard.BoardPieces[58].Side == Enums.BlackOrWhite.None &&
                  this.CurrentGame.GameBoard.BoardPieces[59].Side == Enums.BlackOrWhite.None)
              {
                this.CurrentGame.GameBoard.BoardPieces[58].IsMovableSpace = true;
              }
              if (this.CurrentGame.WhiteTeam.CanCastleRight == true &&
                  this.CurrentGame.GameBoard.BoardPieces[61].Side == Enums.BlackOrWhite.None &&
                  this.CurrentGame.GameBoard.BoardPieces[62].Side == Enums.BlackOrWhite.None)
              {
                this.CurrentGame.GameBoard.BoardPieces[62].IsMovableSpace = true;
              }
            }
          }
        }
      }
    }

    public void DragMove(Image grid, IPiece piece)
    {
      if (piece != null && piece.GetType() != typeof(BlankSpace))
      {
        DragDrop.DoDragDrop(grid, piece, DragDropEffects.Move);
      }
    }

    public void MovePiece(IPiece takenPiece)
    {
      // Commented out should I ever get rid of SelectedPiece
      //IPiece movingPiece = (IPiece)dragEvent.Data.GetData(this.CurrentGame.SelectedPiece.GetType());
      Location oldSpot = this.CurrentGame.SelectedPiece.Location;
      Location newSpot = takenPiece.Location;
      if (takenPiece.Side == Enums.BlackOrWhite.Black) { this.CurrentGame.FaintedBlackPokes.AddFaintedPokemon(takenPiece); }
      else if (takenPiece.Side == Enums.BlackOrWhite.White) { this.CurrentGame.FaintedWhitePokes.AddFaintedPokemon(takenPiece); }

      this.CurrentGame.GameBoard.BoardPieces[oldSpot.ArraySpotInt] = new BlankSpace(this.CurrentGame.SelectedPiece.Location);
      this.CurrentGame.SelectedPiece.Location = newSpot;
      this.CurrentGame.SelectedPiece.IsSelected = false;
      this.CurrentGame.GameBoard.BoardPieces[newSpot.ArraySpotInt] = this.CurrentGame.SelectedPiece;

      if (General.EnsureKingSafety(this.CurrentGame.GameBoard, this.CurrentGame.SelectedPiece.Side))
      {
        this.CurrentGame.GameBoard.BoardPieces[newSpot.ArraySpotInt] = takenPiece;
        this.CurrentGame.SelectedPiece.Location = oldSpot;
        this.CurrentGame.SelectedPiece.IsSelected = false;
        this.CurrentGame.GameBoard.BoardPieces[oldSpot.ArraySpotInt] = this.CurrentGame.SelectedPiece;
        if (takenPiece.Side == Enums.BlackOrWhite.Black) { this.CurrentGame.FaintedBlackPokes.RemoveFaintedPokemon(takenPiece); }
        else if (takenPiece.Side == Enums.BlackOrWhite.White) { this.CurrentGame.FaintedWhitePokes.RemoveFaintedPokemon(takenPiece); }
        this.PieceDataScreen.AppendGenericMessage(String.Format("{0} in Check!", this.CurrentGame.SelectedPiece.Side), this.CurrentGame.TurnCount, this.CurrentGame.SelectedPiece.Side);
      }
      else
      { // Castle
        if (this.CurrentGame.SelectedPiece.ChessPieceType == Enums.Pieces.King)
        {
          King king = (King)this.CurrentGame.SelectedPiece;
          if (this.CurrentGame.CurrentTurn == Enums.BlackOrWhite.Black)
          {
            if (takenPiece.Location.ArraySpotInt == 2 && this.CurrentGame.BlackTeam.CanCastleLeft == true)
            {
              this.CurrentGame.GameBoard.BoardPieces[3] = this.CurrentGame.GameBoard.BoardPieces[0];
              this.CurrentGame.GameBoard.BoardPieces[3].Location = new Location(3);
              this.CurrentGame.GameBoard.BoardPieces[0] = new BlankSpace(0);
              this.PieceDataScreen.AppendGenericMessage(String.Format("{0}", this.CurrentGame.SelectedPiece.Name + " Castle!"), this.CurrentGame.TurnCount, this.CurrentGame.SelectedPiece.Side);
            }
            else if (takenPiece.Location.ArraySpotInt == 6 && this.CurrentGame.BlackTeam.CanCastleRight == true)
            {
              this.CurrentGame.GameBoard.BoardPieces[5] = this.CurrentGame.GameBoard.BoardPieces[7];
              this.CurrentGame.GameBoard.BoardPieces[5].Location = new Location(5);
              this.CurrentGame.GameBoard.BoardPieces[7] = new BlankSpace(7);
              this.PieceDataScreen.AppendGenericMessage(String.Format("{0}", this.CurrentGame.SelectedPiece.Name + " Castle!"), this.CurrentGame.TurnCount, this.CurrentGame.SelectedPiece.Side);
            }
            this.CurrentGame.BlackTeam.CanCastleLeft = false;
            this.CurrentGame.BlackTeam.CanCastleRight = false;
          }
          else if (this.CurrentGame.CurrentTurn == Enums.BlackOrWhite.White)
          {
            if (takenPiece.Location.ArraySpotInt == 58 && this.CurrentGame.WhiteTeam.CanCastleLeft == true)
            {
              this.CurrentGame.GameBoard.BoardPieces[59] = this.CurrentGame.GameBoard.BoardPieces[56];
              this.CurrentGame.GameBoard.BoardPieces[59].Location = new Location(59);
              this.CurrentGame.GameBoard.BoardPieces[56] = new BlankSpace(56);
              this.PieceDataScreen.AppendGenericMessage(String.Format("{0}", this.CurrentGame.SelectedPiece.Name + " Castle!"), this.CurrentGame.TurnCount, this.CurrentGame.SelectedPiece.Side);
            }
            else if (takenPiece.Location.ArraySpotInt == 62 && this.CurrentGame.WhiteTeam.CanCastleRight == true)
            {
              this.CurrentGame.GameBoard.BoardPieces[61] = this.CurrentGame.GameBoard.BoardPieces[63];
              this.CurrentGame.GameBoard.BoardPieces[61].Location = new Location(61);
              this.CurrentGame.GameBoard.BoardPieces[63] = new BlankSpace(63);
              this.PieceDataScreen.AppendGenericMessage(String.Format("{0}", this.CurrentGame.SelectedPiece.Name + " Castle!"), this.CurrentGame.TurnCount, this.CurrentGame.SelectedPiece.Side);
            }
            else
            {
              this.PieceDataScreen.AppendMoveMessage(this.CurrentGame.TurnCount, this.CurrentGame.CurrentTurn, this.CurrentGame.SelectedPiece);
            }
            this.CurrentGame.WhiteTeam.CanCastleLeft = false;
            this.CurrentGame.WhiteTeam.CanCastleRight = false;
          }
        }
        else if (this.CurrentGame.SelectedPiece.ChessPieceType == Enums.Pieces.Rook)
        {
          if (this.CurrentGame.CurrentTurn == Enums.BlackOrWhite.Black)
          {
            if (oldSpot.ArraySpotInt == 0) { this.CurrentGame.BlackTeam.CanCastleLeft = false; }
            else if (oldSpot.ArraySpotInt == 7) { this.CurrentGame.BlackTeam.CanCastleRight = false; }
          }
          else if (this.CurrentGame.CurrentTurn == Enums.BlackOrWhite.White)
          {
            if (oldSpot.ArraySpotInt == 56) { this.CurrentGame.WhiteTeam.CanCastleLeft = false; }
            else if (oldSpot.ArraySpotInt == 63) { this.CurrentGame.WhiteTeam.CanCastleRight = false; }
          }
          this.PieceDataScreen.AppendMoveMessage(this.CurrentGame.TurnCount, this.CurrentGame.CurrentTurn, this.CurrentGame.SelectedPiece);
        }
        else
        {
          this.PieceDataScreen.AppendMoveMessage(this.CurrentGame.TurnCount, this.CurrentGame.CurrentTurn, this.CurrentGame.SelectedPiece);
        }
        this.CurrentGame.ChangeTurn();

        bool inCheck = (this.CurrentGame.SelectedPiece.Side == Enums.BlackOrWhite.Black) ?
             General.EnsureKingSafety(this.CurrentGame.GameBoard, Enums.BlackOrWhite.White) :
             General.EnsureKingSafety(this.CurrentGame.GameBoard, Enums.BlackOrWhite.Black);
        if (inCheck)
        {
          if (General.IsCheckmate(this.CurrentGame.GameBoard, this.CurrentGame.SelectedPiece.Side))
          {
            this.PieceDataScreen.AppendGenericMessage(String.Format("Check Mate! {0} Wins!", this.CurrentGame.SelectedPiece.Side), 
              this.CurrentGame.TurnCount, this.CurrentGame.SelectedPiece.Side);
          }
          else
          {
            this.PieceDataScreen.AppendGenericMessage("Check!", this.CurrentGame.TurnCount, this.CurrentGame.SelectedPiece.Side);
          }
        }
      }
      this.CurrentGame.GameBoard.ClearPlayablePieces();
      this.CurrentGame.Refresh();
      NotifyOfPropertyChange(() => CurrentGame);
    }

    public void OpenMainMenu()
    {
      ViewModels.MenuViewModel menuViewModel = new ViewModels.MenuViewModel(_windowManager);
      menuViewModel.WillOpenSetup = false;

      Dictionary<string, object> settings = new Dictionary<string, object>();
      settings.Add("WindowStartupLocation", WindowStartupLocation.CenterOwner);
      settings.Add("WindowStyle", WindowStyle.ThreeDBorderWindow);
      settings.Add("ResizeMode", System.Windows.ResizeMode.NoResize);
      settings.Add("Height", 300);
      settings.Add("Width", 400);
      settings.Add("ShowInTaskbar", false);
      settings.Add("Title", "Menu");
      Uri iconUri = new Uri("pack://application:,,,/Images/FirePokemon/Charizard.ico", UriKind.Absolute);
      settings.Add("Icon", BitmapFrame.Create(iconUri));

      bool? startNewGame = _windowManager.ShowDialog(menuViewModel, null, settings);
      if (startNewGame != null && startNewGame.Value)
      {
        if (menuViewModel.WillOpenSetup)
        {
          ViewModels.SetupViewModel setupViewModel = new ViewModels.SetupViewModel(_windowManager);
          setupViewModel.BlackTeamType = this.BlackTeamType;
          setupViewModel.WhiteTeamType = this.WhiteTeamType;

          Dictionary<string, object> setupSettings = new Dictionary<string, object>();
          setupSettings.Add("WindowStartupLocation", WindowStartupLocation.CenterOwner);
          setupSettings.Add("WindowStyle", WindowStyle.ThreeDBorderWindow);
          setupSettings.Add("ResizeMode", System.Windows.ResizeMode.NoResize);
          setupSettings.Add("Height", 300);
          setupSettings.Add("Width", 400);
          setupSettings.Add("ShowInTaskbar", false);
          setupSettings.Add("Title", "Menu");
          Uri setupIconUri = new Uri("pack://application:,,,/Images/FirePokemon/Charizard.ico", UriKind.Absolute);
          setupSettings.Add("Icon", BitmapFrame.Create(iconUri));
          bool? closeClicked = _windowManager.ShowDialog(setupViewModel, null, setupSettings);
          if (closeClicked != null && closeClicked.Value)
          {
            this.BlackTeamType = setupViewModel.BlackTeamType;
            this.WhiteTeamType = setupViewModel.WhiteTeamType;
          }
          OpenMainMenu();
        }
        else
        {
          CurrentGame = new Game(this.WhiteTeamType, this.BlackTeamType);
          NotifyOfPropertyChange(() => CurrentGame);
        }
      }
      else
      {
        if (this.CurrentGame != null)
        {
          this.CurrentGame.IsSaved = true;
        }
      }
    }
    #endregion
  }
}
