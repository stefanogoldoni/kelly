using Kelly.Math;

namespace Kelly {
	public interface ILight {
		Color EmittedColor { get; }
		Point Position { get; }
	}
}
