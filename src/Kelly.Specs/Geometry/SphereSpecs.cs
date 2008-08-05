using System;
using System.Collections.Generic;
using Xunit;
using Kelly.Geometry;
using Kelly.Math;

namespace Kelly.Specs.Geometry {
	public class SphereSpecs {
		public class IntersectWith {
			[Fact]
			public void ReturnsCorrectValues() {
				Assert.Null(
					new Sphere(new Point(10, 0, 0), 1.0f).IntersectWith(
						new Ray(Point.Zero, new Vector(0, 1, 0))));

				var isec = new Sphere(new Point(10, 0, 0), 1.0f)
					.IntersectWith(
						new Ray(Point.Zero, new Vector(1, 0, 0)));

				Assert.NotNull(isec);
				Assert.Equal(9.0f, isec.Distance);
				Assert.Equal(new Point(9.0f, 0, 0), isec.Point);

				isec = new Sphere(new Point(10, 0, 0), 1.0f)
					.IntersectWith(
						new Ray(Point.Zero, new Vector(-1, 0, 0)));

				Assert.NotNull(isec);
				Assert.Equal(-9.0f, isec.Distance);
				Assert.Equal(new Point(9.0f, 0, 0), isec.Point);
			}
		}
	}
}
