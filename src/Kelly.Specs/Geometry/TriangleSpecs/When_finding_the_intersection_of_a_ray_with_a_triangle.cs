using Kelly.Geometry;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Geometry.TriangleSpecs {
	public class When_finding_the_intersection_of_a_ray_with_a_triangle {
		[Fact]
		public void If_the_ray_points_at_the_triangle_the_result_is_not_null() {
			var ray = new Ray(Point.Zero, Vector.UnitX);

			var triangle = new Triangle(
				new Point(2, 2, 0), 
				new Point(2, -2, 2), 
				new Point(2, -2, -2)
				);

			Assert.NotNull(triangle.FindClosestIntersectionWith(ray));
		}

		[Fact]
		public void If_the_triangle_is_behind_the_ray_the_result_is_null() {
			var ray = new Ray(Point.Zero, -Vector.UnitX);

			var triangle = new Triangle(
				new Point(2, 2, 0),
				new Point(2, -2, 2),
				new Point(2, -2, -2)
				);

			Assert.Null(triangle.FindClosestIntersectionWith(ray));
		}

		[Fact]
		public void If_the_ray_does_not_point_at_the_triangle_the_result_is_null() {
			var ray = new Ray(Point.Zero, Vector.UnitZ);

			var triangle = new Triangle(
				new Point(2, 2, 0),
				new Point(2, -2, 2),
				new Point(2, -2, -2)
				);

			Assert.Null(triangle.FindClosestIntersectionWith(ray));
		}

		[Fact]
		public void If_the_ray_points_at_the_triangle_the_correct_distance_is_set_on_the_result() {
			var ray = new Ray(Point.Zero, Vector.UnitX);

			var triangle = new Triangle(
				new Point(2, 2, 0),
				new Point(2, -2, 2),
				new Point(2, -2, -2)
				);

			Assert.Equal(2d, triangle.FindClosestIntersectionWith(ray).Distance);
		}
	}
}
