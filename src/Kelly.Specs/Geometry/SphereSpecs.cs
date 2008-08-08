using Kelly.Geometry;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Geometry {
	public class SphereSpecs {
		public class IntersectWith {
			[Fact]
			public void ReturnsCorrectValues() {
				var sphere = new Sphere(new Point(10, 0, 0), 1.0f);

				float distance;

				Assert.False(
					sphere.IntersectWith(
						new Ray(Point.Zero, new Vector(0, 1, 0)), 
						out distance
					)
				);

				Assert.True(
					sphere.IntersectWith(
						new Ray(Point.Zero, new Vector(1, 0, 0)), 
						out distance
					)
				);

				Assert.Equal(9.0f, distance);
				
				Assert.True(
					sphere.IntersectWith(
						new Ray(Point.Zero, new Vector(-1, 0, 0)), 
						out distance
					)
				);

				Assert.Equal(-9.0f, distance);
			}
		}
	}
}
