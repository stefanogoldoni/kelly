using System;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_constructing_a_matrix_from_an_array {
		[Fact]
		public void An_ArgumentException_is_thrown_when_the_width_of_the_array_is_less_than_4() {
			Assert.Throws(typeof (ArgumentException), () => { new Matrix(new double[3,4]); });
		}

		[Fact]
		public void An_ArgumentException_is_thrown_when_the_width_of_the_array_is_greater_than_4() {
			Assert.Throws(typeof (ArgumentException), () => { new Matrix(new double[5,4]); });
		}

		[Fact]
		public void An_ArgumentException_is_thrown_when_the_height_of_the_array_is_less_than_4() {
			Assert.Throws(typeof (ArgumentException), () => { new Matrix(new double[4,3]); });
		}

		[Fact]
		public void An_ArgumentException_is_thrown_when_the_height_of_the_array_is_greater_than_4() {
			Assert.Throws(typeof (ArgumentException), () => { new Matrix(new double[4,5]); });
		}

		[Fact]
		public void No_exception_is_thrown_when_the_width_and_height_of_the_array_both_equal_4() {
			Assert.DoesNotThrow(() => { new Matrix(new double[4,4]); });
		}

		[Fact]
		public void Elements_are_assigned_in_row_major_order() {
			var matrix = new Matrix(
				new double[4,4] {
				               	{1, 2, 3, 4},
				               	{5, 6, 7, 8},
				               	{9, 10, 11, 12},
				               	{13, 14, 15, 16},
				               }
				);

			Assert.Equal(1, matrix[0, 0]);
			Assert.Equal(2, matrix[0, 1]);
			Assert.Equal(3, matrix[0, 2]);
			Assert.Equal(4, matrix[0, 3]);

			Assert.Equal(5, matrix[1, 0]);
			Assert.Equal(6, matrix[1, 1]);
			Assert.Equal(7, matrix[1, 2]);
			Assert.Equal(8, matrix[1, 3]);

			Assert.Equal(9, matrix[2, 0]);
			Assert.Equal(10, matrix[2, 1]);
			Assert.Equal(11, matrix[2, 2]);
			Assert.Equal(12, matrix[2, 3]);

			Assert.Equal(13, matrix[3, 0]);
			Assert.Equal(14, matrix[3, 1]);
			Assert.Equal(15, matrix[3, 2]);
			Assert.Equal(16, matrix[3, 3]);
		}
	}
}