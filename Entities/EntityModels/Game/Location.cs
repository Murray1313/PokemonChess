using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Location
  {
    public Location(int arrayLocation)
    {
      this.XCoord = (SharedEnums.Enums.BoardRows)(arrayLocation / 8);
      this.YCoord = (SharedEnums.Enums.BoardColumns)(arrayLocation % 8);
    }

    public Location(SharedEnums.Enums.BoardRows x, SharedEnums.Enums.BoardColumns y)
    {
      this.XCoord = x;
      this.YCoord = y;
    }


    public SharedEnums.Enums.BoardRows XCoord { get; set; }
    public SharedEnums.Enums.BoardColumns YCoord { get; set; }
    public int ArraySpotInt { get { return (((int)XCoord * 8) + (int)YCoord); } }
  }
}
