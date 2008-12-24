using Kelly.AccelerationStructures;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.AccelerationStructures.AxisAlignedBoundingBoxSpecs {
	//public class When_finding_the_intersection_of_an_AABB_with_a_ray {
	//    [Fact]
	//    public void If_the_ray_points_at_the_AABB_the_result_is_true_and_the_distance_is_set_correctly() {
	//        var box = new AxisAlignedBoundingBox(new Point(0, 0, 0), new Point(2, 2, 2));
	//        var ray = new Ray(new Point(-1, 1, 1), new Vector(1, 0.1, 0.2).ToUnitVector()	);

	//        double distance;
	//        Assert.True(box.IntersectsRay(ray, out distance));
	//        Assert.Equal(1.02469507659596d, distance, EpsilonComparer.DoubleComparer);
	//    }

	//    [Fact]
	//    public void For_ray_directions_with_zeros_the_result_is_still_true_for_valid_intersections() {
	//        var box = new AxisAlignedBoundingBox(new Point(0, 0, 0), new Point(2, 2, 2));
	//        var ray = new Ray(new Point(-1, 1, 1), Vector.UnitX);

	//        double distance;
	//        Assert.True(box.IntersectsRay(ray, out distance));
	//        Assert.Equal(1d, distance);

	//        box = new AxisAlignedBoundingBox(new Point(0, 0, 0), new Point(2, 2, 2));
	//        ray = new Ray(new Point(1, -1, 1), Vector.UnitY);

	//        Assert.True(box.IntersectsRay(ray, out distance));
	//        Assert.Equal(1d, distance);

	//        box = new AxisAlignedBoundingBox(new Point(0, 0, 0), new Point(2, 2, 2));
	//        ray = new Ray(new Point(1, 1, -1), Vector.UnitZ);

	//        Assert.True(box.IntersectsRay(ray, out distance));
	//        Assert.Equal(1d, distance);
	//    }

	//    [Fact]
	//    public void If_the_ray_is_inside_the_AABB_the_result_is_true_and_the_distance_is_set_correctly() {
	//        var box = new AxisAlignedBoundingBox(new Point(0, 0, 0), new Point(2, 2, 2));
	//        var ray = new Ray(new Point(1, 1, 1), Vector.UnitX);

	//        double distance;
	//        Assert.True(box.IntersectsRay(ray, out distance));
	//        Assert.Equal(1d, distance);
	//    }

	//    [Fact]
	//    public void If_the_ray_does_not_point_at_the_AABB_the_result_is_false_and_the_distance_is_set_to_infinity() {
	//        var box = new AxisAlignedBoundingBox(new Point(1, 1, 1), new Point(2, 2, 2));
	//        var ray = new Ray(new Point(0.5, -1, 2), -Vector.UnitY);

	//        double distance;
	//        Assert.False(box.IntersectsRay(ray, out distance));
	//        Assert.Equal(double.PositiveInfinity, distance);
	//    }

	//    [Fact]
	//    public void If_the_AABB_is_behind_the_ray_the_result_is_false_and_the_distance_is_set_to_infinity() {
	//        var box = new AxisAlignedBoundingBox(new Point(1, 1, 1), new Point(2, 2, 2));
	//        var ray = new Ray(new Point(0, 0, 3), Vector.UnitZ);

	//        double distance;
	//        Assert.False(box.IntersectsRay(ray, out distance));
	//        Assert.Equal(double.PositiveInfinity, distance);
	//    }
	//}
}
