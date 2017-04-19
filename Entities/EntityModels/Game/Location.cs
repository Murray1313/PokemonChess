using System;
using Entities.SharedEnums;
using Caliburn.Micro;

namespace Entities
{
    public class Location : PropertyChangedBase
    {
        #region Private
        private Enums.BoardRows _xcoord;
        private Enums.BoardColumns _ycoord;
        #endregion

        #region Constructors
        public Location(int arrayLocation)
        {
            this.XCoord = (Enums.BoardRows)(arrayLocation / 8);
            this.YCoord = (Enums.BoardColumns)(arrayLocation % 8);
        }

        public Location(Enums.BoardRows x, Enums.BoardColumns y)
        {
            this.XCoord = x;
            this.YCoord = y;
        }
        #endregion

        public Enums.BoardRows XCoord
        {
            get { return _xcoord; }
            set
            {
                _xcoord = value;
                NotifyOfPropertyChange(() => XCoord);
                NotifyOfPropertyChange(() => ArraySpotInt);
                NotifyOfPropertyChange(() => TopLocationModifier);
            }
        }

        public Enums.BoardColumns YCoord
        {
            get { return _ycoord; }
            set
            {
                _ycoord = value;
                NotifyOfPropertyChange(() => YCoord);
                NotifyOfPropertyChange(() => ArraySpotInt);
                NotifyOfPropertyChange(() => LeftLocationModifier);
            }
        }

        public int ArraySpotInt { get { return (((int)XCoord * 8) + (int)YCoord); } }

        // Properties used in the drawing of the Canvas.
        public Double LeftLocationModifier { get { return ((int)YCoord * .125); } }
        public Double TopLocationModifier { get { return ((int)XCoord * .125); } }
    }
}
