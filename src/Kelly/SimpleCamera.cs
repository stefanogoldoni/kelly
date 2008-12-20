using Kelly.Math;

namespace Kelly {
	public class SimpleCamera : ICamera {
		public Point Position { get; set; }
		public Vector ViewDirection { get; set; }
		public Vector UpVector { get; set; }
		public double FieldOfView { get; set; }
		public double AspectRatio { get; set; }

		public SimpleCamera(Point position, Vector viewDirection, Vector upVector, double fieldOfView, double aspectRatio) {
			Position = position;
			ViewDirection = viewDirection;
			UpVector = upVector;
			FieldOfView = fieldOfView;
			AspectRatio = aspectRatio;
		}

		public Ray CreateRayThroughImagePlane(Point2 point) {
			throw new System.NotImplementedException();
		}

		public Point2 FindIntersectionWithImagePlane(Ray ray) {
			throw new System.NotImplementedException();
		}
	}
}
