using System;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.RaySpecs {
	public class When_constructing_a_ray {
		[Fact]
		public void ArgumentException_is_thrown_if_direction_is_not_a_unit_vector() {
			Assert.Throws<ArgumentException>(
				() => new Ray(Point.Zero, new Vector(1, 1, 1)));
		}

		[Fact]
		public void No_exception_is_thrown_when_direction_is_a_unit_vector() {
			Assert.DoesNotThrow(
				() => new Ray(Point.Zero, new Vector(1, 0, 0)));
		}
	}
}