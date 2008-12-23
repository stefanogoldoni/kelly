using Kelly.Math;

namespace Kelly.Geometry {
	public class AxisAlignedBoundingBox {
		public Point Min { get; set; }
		public Point Max { get; set; }

		public AxisAlignedBoundingBox(Point min, Point max) {
			Min = min;
			Max = max;
		}

		public bool IntersectsRaySegment(Ray ray, double min, double max) {
			double tmin, tmax, tYMin, tYMax, tZMin, tZMax;

			if (ray.Direction.X > 0) {
				tmin = (Min.X - ray.Origin.X) / ray.Direction.X;
				tmax = (Max.X - ray.Origin.X) / ray.Direction.X;
			}
			else {
				tmax = (Min.X - ray.Origin.X) / ray.Direction.X;
				tmin = (Max.X - ray.Origin.X) / ray.Direction.X;			
			}

			if (ray.Direction.Y > 0) {
				tYMin = (Min.Y - ray.Origin.Y) / ray.Direction.Y;
				tYMax = (Max.Y - ray.Origin.Y) / ray.Direction.Y;
			}
			else {
				tYMax = (Min.Y - ray.Origin.Y) / ray.Direction.Y;
				tYMin = (Max.Y - ray.Origin.Y) / ray.Direction.Y;				
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
			else {
				tZMax = (Min.Z - ray.Origin.Z) / ray.Direction.Z;
				tZMin = (Max.Z - ray.Origin.Z) / ray.Direction.Z;				
			}

			if(tmin > tZMax || tZMin > tmax)
				return false;

			if (tZMin > tmin)
				tmin = tZMin;

			if (tZMax < tmax)
				tmax = tZMax;

			return (tmin < max) && (tmax > min);
		}
	}
}
