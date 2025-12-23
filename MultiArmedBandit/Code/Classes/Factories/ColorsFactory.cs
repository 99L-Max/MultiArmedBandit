using System.Drawing;

namespace MultiArmedBandit
{
    class ColorsFactory
    {
        private readonly Color[] _colors;

        public ColorsFactory()
        {
            _colors = new Color[]
            {
                Color.Red, Color.Green, Color.Blue,
                Color.Orange, Color.Purple, Color.Black,
                Color.Maroon, Color.DarkGreen, Color.Cyan,
                Color.Gold, Color.Indigo, Color.DimGray
            };
        }

        public Color GetColor(int index)
        {
            return _colors[index % _colors.Length];
        }
    }
}
