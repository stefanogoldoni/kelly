using System;
using System.Linq;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.AxisAlignedBoundingBoxSpecs {
	public class When_constructing_an_AABB_from_a_sequence_of_points {
		[Fact]
		public void An_exception_is_thrown_if_the_enumerable_is_empty() {
			Assert.Throws<InvalidOperationException>(() => 
				AxisAlignedBoundingBox.FromPoints(Enumerable.Empty<Point>()));
		}	

		[Fact]
		public void When_the_sequence_only_contains_a_single_point_the_min_and_max_points_equal_the_point() {
			var thePoint = new Point(1, 2, 3);

			var aabb = AxisAlignedBoundingBox.FromPoints(
				new[] { thePoint }.Single());

			Assert.Equal(thePoint, aabb.Min);
			Assert.Equal(thePoint, aabb.Max);
		}

		[Fact]
		public void When_the_sequence_contains_more_than_a_single_point_the_Min_point_equals_the_element_wise_minimum_of_the_sequence() {
			var points = new[] {
				new Point(1, 2, 3),
				new Point(2, 3, 4),
				new Point(4, 5, 6),
				new Point(-1, 3, 7),	
				new Point(0, 0, -10)
			};

			var aabb = AxisAlignedBoundingBox.FromPoints(points.AsEnumerable());

			Assert.Equal(new Point(-1, 0, -10), aabb.Min);
		}

		[Fact]
		public void When_the_sequence_contains_more_than_a_single_point_the_Max_point_equals_the_element_wise_maximum_of_the_sequence() {
			var points = new[] {
				new Point(1, 2, 3),
				new Point(2, 3, 4),
				new Point(4, 5, 6),
				new Point(-1, 3, 7),	
				new Point(0, 0, -10)
			};

			var aabb = AxisAlignedBoundingBox.FromPoints(points.AsEnumerable());

			Assert.Equal(new Point(4, 5, 7), aabb.Max);
		}
	}
}
