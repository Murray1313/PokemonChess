using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using Entities.Interfaces;

namespace PokemonChess.ViewModels
{
  [Export(typeof(PieceDataViewModel))]
  public class PieceDataViewModel : Screen
  {

    private string _gameText = string.Empty;


    [ImportingConstructor]
    public PieceDataViewModel()
    {
    }


    public string GameText
    {
      get { return _gameText; }
      set
      {
        _gameText = value;
        NotifyOfPropertyChange(() => GameText);
      }
    }

    public void AppendGenericMessage(string message, int turn, Entities.SharedEnums.Enums.BlackOrWhite side)
    {
      string appendString = (side == Entities.SharedEnums.Enums.BlackOrWhite.Black) ? (turn + "B") : (turn + "W");
      this.GameText = this.GameText + String.Format("{0}{2}: {1}{0}", Environment.NewLine, message, appendString);
      PokemonChess.Views.PieceDataView view = (PokemonChess.Views.PieceDataView)this.GetView();
      view.ChessTextBox.SelectionStart = view.ChessTextBox.Text.Length;
      view.ChessTextBox.ScrollToEnd();
    }

    public void AppendMoveMessage(int turnCount, Entities.SharedEnums.Enums.BlackOrWhite blackOrWhite, IPiece piece)
    {
      if (blackOrWhite == Entities.SharedEnums.Enums.BlackOrWhite.Black)
      {
        this.GameText = this.GameText + String.Format("{0}{4}B: {1} moves to {2}{3}{0}", Environment.NewLine, piece.Name, piece.Location.YCoord, (9 - ((int)piece.Location.XCoord + 1)), turnCount);
      }
      else if (blackOrWhite == Entities.SharedEnums.Enums.BlackOrWhite.White)
      {
        this.GameText = this.GameText + String.Format("{0}{4}W: {1} moves to {2}{3}{0}", Environment.NewLine, piece.Name, piece.Location.YCoord, (9 - ((int)piece.Location.XCoord + 1)), turnCount);
      }
      PokemonChess.Views.PieceDataView view = (PokemonChess.Views.PieceDataView)this.GetView();
      view.ChessTextBox.SelectionStart = view.ChessTextBox.Text.Length;
      view.ChessTextBox.ScrollToEnd();
    }
  }
}
