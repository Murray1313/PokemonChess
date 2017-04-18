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
    //public int BoardRow { get { return ((int)XCoord + 1); ; } }
    public SharedEnums.Enums.BoardColumns YCoord { get; set; }
    //public int BoardColumn { get { return ((int)YCoord + 1); } }
    public int ArraySpotInt { get { return (((int)XCoord * 8) + (int)YCoord); } }

    // Properties used in the drawing of the Canvas.
    public Double LeftLocationModifier { get { return ((int)XCoord * .125); } }
    public Double TopLocationModifier { get { return ((int)YCoord * .125); } }
    }
}
