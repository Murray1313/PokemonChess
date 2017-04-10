using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Entities.SharedEnums;

namespace PokemonChess.ViewModels
{
  public class SetupViewModel : Screen
  {

    #region " Private "
    private Enums.TeamType _whiteTeamType;
    private Enums.TeamType _blackTeamType;
    private readonly IWindowManager _windowManager;

    #endregion


    #region "Constructor"
    public SetupViewModel(IWindowManager windowManager)
    {
      _windowManager = windowManager;
    }
    #endregion


    #region " Properties "

    public BindableCollection<Enums.TeamType> WhiteTypes
    {
      get
      {
        return new BindableCollection<Enums.TeamType>() 
        { 
          Enums.TeamType.Water,
          Enums.TeamType.Grass,
          Enums.TeamType.Fire,
          Enums.TeamType.Poison
        };
      }
    }

    public BindableCollection<Enums.TeamType> BlackTypes
    {
      get
      {
        return new BindableCollection<Enums.TeamType>() 
        { 
          Enums.TeamType.Water,
          Enums.TeamType.Grass,
          Enums.TeamType.Fire,
          Enums.TeamType.Poison
        };
      }
    }

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
        NotifyOfPropertyChange(() => BlackTeamType);
      }
    }
    #endregion


    #region " Public Methods "
    public void Close()
    {
      TryClose(true);
    }
    #endregion
  }
}
