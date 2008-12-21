using Kelly.Math;

namespace Kelly {
	public class PointLight : ILight {
		public PointLight(Color emittedColor, Point position) {
			EmittedColor = emittedColor;
			Position = position;
		}

		public Color EmittedColor { get; private set; }
		public Point Position { get; private set; }
	}
}