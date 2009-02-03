using System.Collections.Generic;
using Kelly.Math;
using System.Linq;

namespace Kelly {
	public class AxisAlignedBoundingBox {
		public static AxisAlignedBoundingBox FromIntersectables(IEnumerable<IIntersectable> intersectables) {
			return intersectables
				.Select(i => i.GetBoundingBox())
				.Aggregate(Combine);
		}

		public static AxisAlignedBoundingBox Combine(AxisAlignedBoundingBox x, AxisAlignedBoundingBox y) {
			return new AxisAlignedBoundingBox(
				Point.ElementsMin(x.Min, y.Min), 
				Point.ElementsMax(x.Max, y.Max));
		}

		public static AxisAlignedBoundingBox FromPoints(params Point[] points) {
			return FromPoints((IEnumerable<Point>) points);
		}

		public static AxisAlignedBoundingBox FromPoints(IEnumerable<Point> points) {
			return new AxisAlignedBoundingBox(
				points.Aggregate(Point.ElementsMin),
				points.Aggregate(Point.ElementsMax));
		}

		public Point Min { get; private set; }
		public Point Max { get; private set; }

		public Vector Extents {
			get { return Max - Min; }
		}

		public AxisAlignedBoundingBox(Point min, Point max) {
			Min = Point.ElementsMin(min, max);
			Max = Point.ElementsMax(min, max);
		}

		public bool IntersectsRay(Ray ray, double min, double max) {
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

			return (tmin < max) && (tmax > min);
		}
	}
}