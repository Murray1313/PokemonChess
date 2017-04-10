using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.SharedEnums;
using Caliburn.Micro;
using Entities.Interfaces;

namespace Entities
{
  public class SavedInfo : SettingsBase
  {
    public BindableCollection<String> BoardPieceStrings { get; set; }

    public SharedEnums.Enums.TeamType SavedWhiteTeamType { get; set; }

    public SharedEnums.Enums.TeamType SavedBlackTeamType { get; set; }

    public bool CanBlackCastleRight { get; set; }

    public bool CanBlackCastleLeft { get; set; }

    public bool CanWhiteCastleRight { get; set; }

    public bool CanWhiteCastleLeft { get; set; }

    public int SavedTurnCount { get; set; }

    public SharedEnums.Enums.BlackOrWhite SavedCurrentTurn { get; set; }

    public String GameString { get; set; }

    public BindableCollection<String> SavedFaintedBlack { get; set; }

    public BindableCollection<String> SavedFaintedWhite { get; set; }

    public Entities.SharedEnums.Enums.TeamType WhiteDefaultTeam { get; set; }

    public Entities.SharedEnums.Enums.TeamType BlackDefaultTeam { get; set; }
  }
}
