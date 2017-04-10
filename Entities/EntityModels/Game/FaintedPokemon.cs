using System.Linq;
using Caliburn.Micro;
using Entities.Interfaces;

namespace Entities.EntityModels.Game
{

  public class FaintedPokemon : PropertyChangedBase
  {

    #region Private
    private IPiece _pokemon;
    private int _faintedCount;
    #endregion


    #region Constructor
    public FaintedPokemon(IPiece inPokemon)
    {
      this.Pokemon = inPokemon;
      this.FaintedCount = 1;
    }
    #endregion


    #region Properties
    public IPiece Pokemon
    {
      get { return _pokemon; }
      set
      {
        _pokemon = value;
        NotifyOfPropertyChange(() => Pokemon);
      }
    }

    public int FaintedCount
    {
      get { return _faintedCount; }
      set
      {
        _faintedCount = value;
        NotifyOfPropertyChange(() => FaintedCount);
        NotifyOfPropertyChange(() => DisplayFaintedCount);
      }
    }

    public string DisplayFaintedCount { get {  return (FaintedCount > 1) ? $"x{this.FaintedCount}" : string.Empty; } }
    #endregion
  }


  public class FaintedPokemonGraveyard : BindableCollection<FaintedPokemon>
  { 
    public void AddFaintedPokemon(IPiece pokemon)
    {
      FaintedPokemon killedPieceType = this.FirstOrDefault(x => x.Pokemon.Name.Equals(pokemon.Name));

      if (killedPieceType != null)
      {
        killedPieceType.FaintedCount++;
      } 
      else
      {
        base.Add(new FaintedPokemon(pokemon));
      }
    }

    public void RemoveFaintedPokemon(IPiece pokemon)
    {
      FaintedPokemon killedPieceType = this.FirstOrDefault(x => x.Pokemon.Name.Equals(pokemon.Name));

      if (killedPieceType != null && killedPieceType.FaintedCount == 1)
      {
        base.Remove(killedPieceType);
      }
      else
      {
        killedPieceType.FaintedCount--;
      }
    }

  }

}
