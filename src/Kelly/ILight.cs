using Kelly.Math;

namespace Kelly {
	public interface ILight {
		Point Position { get; }
		Color EmittedColor { get; }
	}
}
