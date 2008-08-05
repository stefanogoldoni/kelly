using System;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs {
	public class RaySpecs {
		public class Constructor {
			[Fact]
			public void Throws_IfPassedNonUnitDirection() {
				Assert.Throws<ArgumentException>(
					() => new Ray(Point.Zero, new Vector(1, 1, 1)));
			}

			[Fact]
			public void DoesNotThrow_IfPassedUnitDirection() {
				Assert.DoesNotThrow(
					() => new Ray(Point.Zero, new Vector(1, 0, 0)));
			}
		}
	}
}
