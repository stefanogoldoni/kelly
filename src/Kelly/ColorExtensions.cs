
namespace Kelly {
	public static class ColorExtensions {
		public static int ToArgb(this Color color) {
			return
				(ToByteValue(color.R) << 16) +
				(ToByteValue(color.G) << 8) +
				(ToByteValue(color.B) << 0);
		}

		public static System.Drawing.Color ToDrawingColor(this Color color) {
			return System.Drawing.Color.FromArgb(
				ToByteValue(color.R),
				ToByteValue(color.G),
				ToByteValue(color.B)
				);
		}

		public static Color ToKellyColor(this System.Drawing.Color color) {
			return new Color(
				ToRealValue(color.R),
				ToRealValue(color.G),
				ToRealValue(color.B)
				);
		}

		private static byte ToByteValue(double component) {
			if (component > 255d)
				return 255;

			if (component < 0d)
				return 0;

			return (byte)(component * 255);
		}

		private static double ToRealValue(byte component) {
			return component / 255d;
		}
	}
}