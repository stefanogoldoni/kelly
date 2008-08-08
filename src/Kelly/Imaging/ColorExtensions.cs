
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

		private static int ConvertComponent(float component) {
			return (int)(component * 255);
		}

		private static float ConvertComponent(int component) {
			return (float)component / 255f;
		}
	}
}
