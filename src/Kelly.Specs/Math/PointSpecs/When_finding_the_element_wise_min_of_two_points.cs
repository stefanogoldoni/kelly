using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.PointSpecs {
	public class When_finding_the_element_wise_min_of_two_points {
		[Fact]
		public void The_X_coord_of_the_result_equals_the_minimum_of_the_X_coords_of_the_two_points() {
			var left = new Point(.1, .2, .3);
			var right = new Point(.2, .1, 1.6);

			Assert.Equal(new Point(.1, .1, .3), Point.ElementsMin(left, right));
		}
	}
}
