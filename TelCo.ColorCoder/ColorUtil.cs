using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public class ColorPair
    {
        public Color majorColor,minorColor;
        List<Color> colorMapMajor = new List<Color> { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
        List<Color> colorMapMinor = new List<Color> { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }

        public ColorPair GetColorFromPairNumber(int pairNumber)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            if (pairNumber < 1 || pairNumber > colorMapMajor.Count * colorMapMinor.Count)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }
            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / colorMapMajor.Count;
            int minorIndex = zeroBasedPairNumber % colorMapMinor.Count;
            // Construct the return val from the arrays
            ColorPair pair = new ColorPair()
            {
                majorColor = colorMapMajor[majorIndex],
                minorColor = colorMapMinor[minorIndex]
            };
            return pair;
        }

        public int GetPairNumberFromColor(ColorPair pair)
        {
            if (colorMapMajor.IndexOf(pair.majorColor) == -1 || colorMapMinor.IndexOf(pair.minorColor) == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (colorMapMajor.IndexOf(pair.majorColor) * colorMapMinor.Count) + (colorMapMinor.IndexOf(pair.minorColor) + 1);
        }
    }
}

