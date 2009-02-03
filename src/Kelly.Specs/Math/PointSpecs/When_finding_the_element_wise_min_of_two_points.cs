using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.PointSpecs {
	public class When_finding_the_element_wise_min_of_two_points {
		[Fact]
		public void The_X_coord_of_the_result_equals_the_minimum_of_the_X_coords_of_the_two_points() {
			var left = new Point(.1, .2, .3);
			var right = new Point(.2, .1, 1.6);

			Assert.Equal(System.Math.Min(left.X, right.X), Point.ElementsMin(left, right).X);
		}

		[Fact]
		public void The_Y_coord_of_the_result_equals_the_minimum_of_the_Y_coords_of_the_two_points() {
			var left = new Point(.1, .2, .3);
			var right = new Point(.2, .1, 1.6);

			Assert.Equal(System.Math.Min(left.Y, right.Y), Point.ElementsMin(left, right).Y);
		}
		
		[Fact]
		public void The_Z_coord_of_the_result_equals_the_minimum_of_the_Z_coords_of_the_two_points() {
			var left = new Point(.1, .2, .3);
			var right = new Point(.2, .1, 1.6);

			Assert.Equal(System.Math.Min(left.Z, right.Z), Point.ElementsMin(left, right).Z);
		}
	}
}
