using Kelly.Geometry;
using Xunit;
using Kelly.Math;

namespace Kelly.Specs.Geometry.SphereSpecs {
	public class When_finding_the_intersection_of_a_ray_with_a_sphere {
		[Fact]
		public static void If_the_ray_points_at_the_sphere_the_result_is_not_null() {
			var sphere = new Sphere(new Point(0, 0, 5), 1);
			var ray = new Ray(Point.Zero, Vector.UnitZ);
			Assert.NotNull(sphere.FindClosestIntersectionWith(ray));
		}

		[Fact]
		public static void If_the_ray_does_not_point_at_the_sphere_the_result_is_null() {
			var sphere = new Sphere(new Point(0, 0, 5), 1);
			var ray = new Ray(Point.Zero, Vector.UnitY);
			Assert.Null(sphere.FindClosestIntersectionWith(ray));	
		}

		[Fact]
		public static void The_returned_distance_is_the_distance_from_the_ray_origin_to_the_closest_edge_of_the_sphere() {
			var sphere = new Sphere(new Point(0, 0, 2), 1);
			var ray = new Ray(Point.Zero, Vector.UnitZ);
			Assert.Equal(1, sphere.FindClosestIntersectionWith(ray).Distance);

			sphere = new Sphere(new Point(0, 0, -2), 1);
			ray = new Ray(Point.Zero, -Vector.UnitZ);
			Assert.Equal(1, sphere.FindClosestIntersectionWith(ray).Distance);

			sphere = new Sphere(new Point(15, 0, 0), 3);
			ray = new Ray(Point.Zero, Vector.UnitX);
			Assert.Equal(12, sphere.FindClosestIntersectionWith(ray).Distance);
		}
	}
}