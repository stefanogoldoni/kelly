using Kelly.AccelerationStructures;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.AccelerationStructures.AxisAlignedBoundingBoxSpecs {
	public class When_finding_the_intersection_of_an_AABB_with_a_ray {
		[Fact]
		public void If_the_ray_points_at_the_AABB_the_result_is_true_and_the_distance_is_set_correctly() {
			var box = new AxisAlignedBoundingBox(new Point(0, 0, 0), new Point(2, 2, 2));
			var ray = new Ray(new Point(-1, 1, 1), Vector.UnitX);

			double distance;
			Assert.True(box.IntersectsRay(ray, out distance));
			Assert.Equal(1d, distance);
		}

		[Fact]
		public void If_the_ray_is_inside_the_AABB_the_result_is_true_and_the_distance_is_set_correctly() {
			var box = new AxisAlignedBoundingBox(new Point(0, 0, 0), new Point(2, 2, 2));
			var ray = new Ray(new Point(1, 1, 1), Vector.UnitX);

			double distance;
			Assert.True(box.IntersectsRay(ray, out distance));
			Assert.Equal(1d, distance);
		}

		[Fact]
		public void If_the_ray_does_not_point_at_the_AABB_the_result_is_false_and_the_distance_is_set_to_infinity() {
			var box = new AxisAlignedBoundingBox(new Point(1, 1, 1), new Point(2, 2, 2));
			var ray = new Ray(new Point(0.5, -1, 2), -Vector.UnitY);

			double distance;
			Assert.False(box.IntersectsRay(ray, out distance));
			Assert.Equal(double.PositiveInfinity, distance);
		}

		[Fact]
		public void If_the_AABB_is_behind_the_ray_the_result_is_false_and_the_distance_is_set_to_infinity() {
			var box = new AxisAlignedBoundingBox(new Point(1, 1, 1), new Point(2, 2, 2));
			var ray = new Ray(new Point(0, 0, 3), Vector.UnitZ);

			double distance;
			Assert.False(box.IntersectsRay(ray, out distance));
			Assert.Equal(double.PositiveInfinity, distance);
		}
	}
}
