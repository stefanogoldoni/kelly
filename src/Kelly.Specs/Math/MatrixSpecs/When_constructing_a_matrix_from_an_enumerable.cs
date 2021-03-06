using System;
using System.Linq;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_constructing_a_matrix_from_an_enumerable {
		[Fact]
		public void An_ArgumentException_is_thrown_if_the_enumerable_contains_less_than_16_elements() {
			Assert.Throws(typeof(ArgumentException), () => {
			                                         	new Matrix(Enumerable.Repeat((double)1, 15));
			                                         });
		}

		[Fact]
		public void An_ArgumentException_is_thrown_if_the_enumerable_contains_more_than_16_elements() {
			Assert.Throws(typeof(ArgumentException), () => {
			                                         	new Matrix(Enumerable.Repeat((double)1, 17));
			                                         });
		}

		[Fact]
		public void No_exception_is_thrown_if_the_enumerable_contains_exactly_16_elements() {
			Assert.DoesNotThrow(() => {
			                    	new Matrix(Enumerable.Repeat((double)1, 16));
			                    });
		}

		[Fact]
		public void Elements_are_assigned_in_row_major_order() {
			// Cast<double>() would throw here as of 3.5 SP1
			//	See http://blogs.msdn.com/ed_maurer/archive/2008/02/16/breaking-change-in-linq-queries-using-explicitly-typed-range-variables.aspx
			var matrix = new Matrix(Enumerable.Range(1, 16).Select(x => (double)x));

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