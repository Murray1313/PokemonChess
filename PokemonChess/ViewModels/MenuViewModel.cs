using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PokemonChess.ViewModels
{
  [Export(typeof(MenuViewModel))]
  public class MenuViewModel : Screen
  {

    #region " Private "

    private readonly IWindowManager _windowManager;

    #endregion


    #region " Constructor "

    [ImportingConstructor]
    public MenuViewModel(IWindowManager windowManager)
    {
      _windowManager = windowManager;
      this.WillOpenSetup = false;
    }

    #endregion


    #region " Properties "
    public bool WillOpenSetup { get; set; }
    #endregion


    #region " Button Methods

    public void CreateNewGame()
    {
      TryClose(true);
    }

    public void SaveGame()
    {
      TryClose(false);
    }

    public void Setup()
    {
      this.WillOpenSetup = true;
      TryClose(true);
    }

    public void Exit()
    {
      Application.Current.Shutdown();
    }

    #endregion
  }
}
