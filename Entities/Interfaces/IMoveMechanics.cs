using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
  public interface IMoveMechanics
  {
    IEnumerable<Location> GetMovableSpaces(Board board);
    void SetMovableSpaces(Board board);
  }
}
