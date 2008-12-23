using Kelly.Math;

namespace Kelly.AccelerationStructures {
	public class AxisAlignedBoundingBox {
		public Point Min { get; set; }
		public Point Max { get; set; }

		public AxisAlignedBoundingBox(Point min, Point max) {
			Min = min;
			Max = max;
		}

		public bool IntersectsRay(Ray ray, out double distance) {
			distance = double.PositiveInfinity;

			double tmin, tmax, tYMin, tYMax, tZMin, tZMax;

			if (ray.Direction.X > 0) {
				tmin = (Min.X - ray.Origin.X) / ray.Direction.X;
				tmax = (Max.X - ray.Origin.X) / ray.Direction.X;
			}
			else if(ray.Direction.X < 0) {
				tmax = (Min.X - ray.Origin.X) / ray.Direction.X;
				tmin = (Max.X - ray.Origin.X) / ray.Direction.X;			
			}
			else {
				tmin = double.NegativeInfinity;
				tmax = double.PositiveInfinity;
			}

			if (ray.Direction.Y > 0) {
				tYMin = (Min.Y - ray.Origin.Y) / ray.Direction.Y;
				tYMax = (Max.Y - ray.Origin.Y) / ray.Direction.Y;
			}
			else if (ray.Direction.Y < 0) {
				tYMax = (Min.Y - ray.Origin.Y) / ray.Direction.Y;
				tYMin = (Max.Y - ray.Origin.Y) / ray.Direction.Y;				
			}
			else {
				tYMin = double.NegativeInfinity;
				tYMax = double.PositiveInfinity;
			}

			if(tmin > tYMax || tYMin > tmax)
				return false;

			if (tYMin > tmin)
				tmin = tYMin;

			if (tYMax < tmax)
				tmax = tYMax;

			if (ray.Direction.Z > 0) {
				tZMin = (Min.Z - ray.Origin.Z) / ray.Direction.Z;
				tZMax = (Max.Z - ray.Origin.Z) / ray.Direction.Z;
			}
			else if (ray.Direction.Z < 0) {
				tZMax = (Min.Z - ray.Origin.Z) / ray.Direction.Z;
				tZMin = (Max.Z - ray.Origin.Z) / ray.Direction.Z;				
			}
			else {
				tZMin = double.NegativeInfinity;
				tZMax = double.PositiveInfinity;
			}

			if(tmin > tZMax || tZMin > tmax)
				return false;

			if (tZMin > tmin)
				tmin = tZMin;

			if (tZMax < tmax)
				tmax = tZMax;

			if (tmin > 0) {
				distance = tmin;				
			}
			else if (tmax > 0) {
				distance = tmax;
			}
			else {
				return false;
			}

			return true;
		}
	}
}