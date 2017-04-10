using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Caliburn.Micro;
using PokemonChess.ViewModels;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Entities;
using Entities.Interfaces;

namespace PokemonChess
{
  public class AppBootstrapper : BootstrapperBase
  {
    private CompositionContainer container;
    public SavedInfo savedInfo;

    public AppBootstrapper()
    {
      Initialize();
    }

    private string GetSettingsPath()
    {
      return System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Settings.xml");
    }

    protected override void Configure()
    {
      container = new CompositionContainer(new AggregateCatalog(AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));

      CompositionBatch batch = new CompositionBatch();

      batch.AddExportedValue<IWindowManager>(new WindowManager());
      batch.AddExportedValue<IEventAggregator>(new EventAggregator());
      batch.AddExportedValue(container);

      container.Compose(batch);
    }

    protected override object GetInstance(Type serviceType, string key)
    {
      string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
      var exports = container.GetExportedValues<object>(contract);

      if (exports.Count() > 0)
      {
        return exports.First();
      }

      throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
    }

    protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
    {
      var viewModel = IoC.Get<PokemonChessViewModel>();
      IWindowManager windowManager;
      try
      {
        windowManager = IoC.Get<IWindowManager>();
      }
      catch
      {
        windowManager = new WindowManager();
      }

      savedInfo = new SavedInfo();
      savedInfo.BoardPieceStrings = new BindableCollection<string>() { };
      savedInfo.SavedFaintedBlack = new BindableCollection<string>() { };
      savedInfo.SavedFaintedWhite = new BindableCollection<string>() { };

      savedInfo.LoadSettings(GetSettingsPath());

      if (savedInfo.BoardPieceStrings.Count != 0)
      {
        viewModel.CurrentGame = new Game();
        viewModel.CurrentGame.BlackTeam = new Team(Entities.SharedEnums.Enums.BlackOrWhite.Black, savedInfo.SavedBlackTeamType);
        viewModel.CurrentGame.BlackTeam.CanCastleLeft = savedInfo.CanBlackCastleLeft;
        viewModel.CurrentGame.BlackTeam.CanCastleRight = savedInfo.CanBlackCastleRight;
        viewModel.CurrentGame.WhiteTeam = new Team(Entities.SharedEnums.Enums.BlackOrWhite.White, savedInfo.SavedWhiteTeamType);
        viewModel.CurrentGame.WhiteTeam.CanCastleLeft = savedInfo.CanWhiteCastleLeft;
        viewModel.CurrentGame.WhiteTeam.CanCastleRight = savedInfo.CanWhiteCastleRight;
        viewModel.CurrentGame.GameBoard = new Board(savedInfo.BoardPieceStrings, savedInfo.SavedBlackTeamType, savedInfo.SavedWhiteTeamType);

        viewModel.CurrentGame.TurnCount = savedInfo.SavedTurnCount;
        viewModel.CurrentGame.CurrentTurn = savedInfo.SavedCurrentTurn;
        viewModel.PieceDataScreen.GameText = savedInfo.GameString;

        foreach (String blackey in savedInfo.SavedFaintedBlack)
        {
          viewModel.CurrentGame.FaintedBlackPokes.AddFaintedPokemon
            (General.GetPieceInstanceFromString(blackey, 0, savedInfo.SavedBlackTeamType, savedInfo.SavedWhiteTeamType));
        }
        foreach (String whitey in savedInfo.SavedFaintedWhite)
        {
          viewModel.CurrentGame.FaintedWhitePokes.AddFaintedPokemon
            (General.GetPieceInstanceFromString(whitey, 0, savedInfo.SavedBlackTeamType, savedInfo.SavedWhiteTeamType));
        }
      }
      viewModel.WhiteTeamType = savedInfo.WhiteDefaultTeam;
      viewModel.BlackTeamType = savedInfo.BlackDefaultTeam;

      dynamic settings = new System.Dynamic.ExpandoObject();
      settings.Title = "Pokemon Chess";
      settings.SizeToContent = System.Windows.SizeToContent.Manual;

      Uri iconUri = new Uri("pack://application:,,,/Images/FirePokemon/Charizard.ico", UriKind.Absolute);
      settings.Icon = BitmapFrame.Create(iconUri);
      settings.WindowStyle = WindowStyle.None;
      settings.WindowState = WindowState.Maximized;
      settings.ResizeMode = ResizeMode.NoResize;

      windowManager.ShowWindow(viewModel, null, settings);
    }


    /// <summary>
    /// Called as the program closes.  Handles all the cleaning up after the window that needs to happen
    /// on closing of the window.
    /// </summary>
    /// <param name="sender">object closing the program</param>
    /// <param name="e">window closing events</param>
    protected override void OnExit(object sender, EventArgs e)
    {
      PokemonChessViewModel viewModel = IoC.Get<PokemonChessViewModel>();

      if (viewModel.CurrentGame != null && viewModel.CurrentGame.IsSaved)
      {
        savedInfo.BoardPieceStrings = new BindableCollection<String>() { };
        for (int x = 0; x < 64; x++)
        {
          String s = viewModel.CurrentGame.GameBoard.BoardPieces[x].GetType().ToString();
          savedInfo.BoardPieceStrings.Add(s.Substring(s.LastIndexOf(".") + 1));
        }
        savedInfo.SavedBlackTeamType = viewModel.CurrentGame.BlackTeam.PokemonType;
        savedInfo.SavedWhiteTeamType = viewModel.CurrentGame.WhiteTeam.PokemonType;
        savedInfo.SavedTurnCount = viewModel.CurrentGame.TurnCount;
        savedInfo.SavedCurrentTurn = viewModel.CurrentGame.CurrentTurn;
        savedInfo.GameString = viewModel.PieceDataScreen.GameText;

        savedInfo.CanBlackCastleLeft = viewModel.CurrentGame.BlackTeam.CanCastleLeft;
        savedInfo.CanBlackCastleRight = viewModel.CurrentGame.BlackTeam.CanCastleRight;
        savedInfo.CanWhiteCastleLeft = viewModel.CurrentGame.WhiteTeam.CanCastleLeft;
        savedInfo.CanWhiteCastleRight = viewModel.CurrentGame.WhiteTeam.CanCastleRight;

        savedInfo.SavedFaintedBlack = new BindableCollection<string>() { };
        foreach (IPiece piece in viewModel.CurrentGame.FaintedBlackPokes)
        {
          String faintedBlakies = piece.GetType().ToString();
          savedInfo.SavedFaintedBlack.Add(faintedBlakies.Substring(faintedBlakies.LastIndexOf(".") + 1));
        }

        savedInfo.SavedFaintedWhite = new BindableCollection<string>() { };
        foreach (IPiece piece in viewModel.CurrentGame.FaintedWhitePokes)
        {
          String faintedWhities = piece.GetType().ToString();
          savedInfo.SavedFaintedWhite.Add(faintedWhities.Substring(faintedWhities.LastIndexOf(".") + 1));
        }
      }
      else
      {
        savedInfo.BoardPieceStrings = null;
        savedInfo.SavedBlackTeamType = Entities.SharedEnums.Enums.TeamType.None;
        savedInfo.SavedWhiteTeamType = Entities.SharedEnums.Enums.TeamType.None;
        savedInfo.SavedTurnCount = 0;
        savedInfo.SavedCurrentTurn = Entities.SharedEnums.Enums.BlackOrWhite.None;
        savedInfo.GameString = null;
        savedInfo.SavedFaintedBlack = null;
        savedInfo.SavedFaintedWhite = null;
      }

      savedInfo.WhiteDefaultTeam = viewModel.WhiteTeamType;
      savedInfo.BlackDefaultTeam = viewModel.BlackTeamType;
      savedInfo.SaveSettings(GetSettingsPath());

      base.OnExit(sender, e);
    }
  }
}
