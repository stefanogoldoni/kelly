using FrigginAwesome;
using Kelly.Math;

namespace Kelly {
	public class OrthogonalCamera : ICamera {
		public Point Position { get; private set; }

		public Vector Direction { get; private set; }
		public Vector Up { get; private set; }
		
		public float Width { get; private set; }
		public float Height { get; private set; }

		private readonly Vector _right;

		public OrthogonalCamera(Point position, Vector direction, Vector up, float width, float height) {
			Ensure.That("direction", direction).IsNotEqualTo(Vector.Zero);
			Ensure.That("up", up).IsNotEqualTo(Vector.Zero);
			Ensure.That("width", width).IsGreaterThan(0);
			Ensure.That("height", height).IsGreaterThan(0);

			Position = position;

			Direction = direction.ToUnitVector();
			
			_right = Vector.CrossProduct(Direction, up.ToUnitVector());
			Up = Vector.CrossProduct(_right, Direction);

			Width = width;
			Height = height;
		}

		public Ray CreateRayThroughImagePlane(Point2 point) {
			var translate = (Up * Height * point.Y) + (_right * Width * point.X);

			return new Ray(Position + translate, Direction);
		}

		public Point2 FindIntersectionWithImagePlane(Ray ray) {
			throw new System.NotImplementedException();
		}
	}
}
