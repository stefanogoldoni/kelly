using Kelly.Math;

namespace Kelly.Materials {
	public class SolidMaterial : IMaterial {
		public Color Color { get; private set; }

		public SolidMaterial(Color color) {
			Color = color;
		}

		public Color GetColorAt(Point point) {
			return Color;
		}
	}
}
