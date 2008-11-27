using Kelly.Geometry;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Geometry {
	public class SphereSpecs {
		public class IntersectWith {
			[Fact]
			public void ReturnsCorrectValues() {
				var sphere = new Sphere(new Point(10, 0, 0), 1.0f);

				var intersection = sphere.Intersects(
					new Ray(Point.Zero, new Vector(0, 1, 0))
				);

				Assert.Null(intersection);

				intersection = sphere.Intersects(
					new Ray(Point.Zero, new Vector(1, 0, 0))
				);

				Assert.NotNull(intersection);
				Assert.Equal(9.0f, intersection.Distance);


				intersection = sphere.Intersects(
					new Ray(Point.Zero, new Vector(-1, 0, 0))
				);

				Assert.NotNull(intersection);
				Assert.Equal(-9.0f, intersection.Distance);
			}
		}
	}
}
