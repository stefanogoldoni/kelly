
namespace Kelly.Imaging {
	public static class ColorExtensions {
		public static System.Drawing.Color ToDrawingColor(this Color color) {
			return System.Drawing.Color.FromArgb(
				ConvertComponent(color.R),
				ConvertComponent(color.G),
				ConvertComponent(color.B)
			);
		}

		public static Color ToKellyColor(this System.Drawing.Color color) {
			return new Color(
				ConvertComponent(color.R),
				ConvertComponent(color.G),
				ConvertComponent(color.B)
			);
		}

		private static int ConvertComponent(double component) {
			return (int)(component * 255);
		}

		private static double ConvertComponent(int component) {
			return (double)component / 255f;
		}
	}
}
