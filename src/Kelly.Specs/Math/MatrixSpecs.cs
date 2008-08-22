using Kelly.Math;
using Xunit;
using System;
using System.Linq;

namespace Kelly.Specs.Math {
	public class MatrixSpecs : EqualitySpecs<Matrix> {
		public class When_calculating_determinant {
			[Fact]
			public void Determinant_of_zero_matrix_should_be_zero() {
				Assert.Equal(0f, Matrix.Zero.CalculateDeterminant());
			}

			[Fact]
			public void Determinant_of_identity_matrix_should_be_one() {
				Assert.Equal(1f, Matrix.Identity.CalculateDeterminant());
			}

			[Fact]
			public void Determinant_of_matrix_with_a_zero_row_should_be_zero() {
				Assert.Equal(0f,
					new Matrix(
						0f, 0f, 0f, 0f,
						0f, 1f, 0f, 0f,
						0f, 0f, 1f, 0f,
						0f, 0f, 0f, 1f).CalculateDeterminant());
			}

			[Fact]
			public void Determinant_of_matrix_with_two_equal_rows_should_be_zero() {
				Assert.Equal(0f,
					new Matrix(
						1f, 1f, 1f, 1f,
						1f, 1f, 1f, 1f,
						0f, 0f, 1f, 0f,
						0f, 0f, 0f, 1f).CalculateDeterminant());
			}
			
			[Fact]
			public void Determinant_of_matrix_with_two_equal_columns_should_be_zero() {
				Assert.Equal(0f,
					new Matrix(
						1f, 1f, 0f, 0f,
						1f, 1f, 0f, 0f,
						1f, 1f, 1f, 0f,
						1f, 1f, 0f, 1f).CalculateDeterminant());
			}

			[Fact]
			public void Determinant_of_scaling_matrix_should_equal_all_of_the_axis_scalars_multiplied_together() {
				Assert.Equal(0f, Matrix.Scaling(0, 1, 1).CalculateDeterminant());
				Assert.Equal(0f, Matrix.Scaling(1, 0, 1).CalculateDeterminant());
				Assert.Equal(0f, Matrix.Scaling(1, 1, 0).CalculateDeterminant());

				Assert.Equal(1f, Matrix.Scaling(1f, 1f, 1f).CalculateDeterminant());
				Assert.Equal(2f, Matrix.Scaling(2f, 1f, 1f).CalculateDeterminant());
				Assert.Equal(8f, Matrix.Scaling(2f, 2f, 2f).CalculateDeterminant());
			}
		}

		public class When_calculating_transpose {
			[Fact]
			public void Transpose_of_identity_should_equal_identity() {
				Assert.Equal(Matrix.Identity, Matrix.Identity.Transpose());
			}

			[Fact]
			public void Columns_and_rows_should_become_interchanged() {
				var actualTranspose = CreateMatrixWithSequentialElements().Transpose();

				var expectedTranspose = new Matrix(
					1, 5, 9, 13,
					2, 6, 10, 14,
					3, 7, 11, 15,
					4, 8, 12, 16
				);

				Assert.Equal(expectedTranspose, actualTranspose);
			}
		}

		public class When_cloning_a_matrix {
			[Fact]
			public void All_elements_of_the_resulting_matrix_should_be_the_same_as_the_original() {
				var matrix = CreateMatrixWithSequentialElements();
				var clone = matrix.Clone();

				for (var col = 0; col < 4; col++)
				for (var row = 0; row < 4; row++) {
					Assert.Equal(matrix[row, col], clone[row, col]);
				}
			}
		}

		public class When_constructing_a_matrix_from_an_enumerable {
			[Fact]
			public void An_ArgumentException_is_thrown_if_the_enumerable_contains_less_than_16_elements() {
				Assert.Throws(typeof(ArgumentException), () => {
					new Matrix(Enumerable.Repeat(1f, 15));
				});
			}

			[Fact]
			public void An_ArgumentException_is_thrown_if_the_enumerable_contains_more_than_16_elements() {
				Assert.Throws(typeof(ArgumentException), () => {
					new Matrix(Enumerable.Repeat(1f, 17));
				});
			}

			[Fact]
			public void No_exception_is_thrown_if_the_enumerable_contains_exactly_16_elements() {
				Assert.DoesNotThrow(() => {
					new Matrix(Enumerable.Repeat(1f, 16));
				});
			}

			[Fact]
			public void Elements_are_assigned_in_row_major_order() {
				var matrix = new Matrix(Enumerable.Range(1, 16).Cast<float>());

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

		public class When_constructing_a_matrix_from_a_multidimensional_array {
			[Fact]
			public void An_ArgumentException_is_thrown_when_the_width_of_the_array_is_less_than_4() {
				Assert.Throws(typeof(ArgumentException), () => {
					new Matrix(new float[3, 4]);
				});
			}

			[Fact]
			public void An_ArgumentException_is_thrown_when_the_width_of_the_array_is_greater_than_4() {
				Assert.Throws(typeof(ArgumentException), () => {
					new Matrix(new float[5, 4]);
				});
			}

			[Fact]
			public void An_ArgumentException_is_thrown_when_the_height_of_the_array_is_less_than_4() {
				Assert.Throws(typeof(ArgumentException), () => {
					new Matrix(new float[4, 3]);
				});
			}

			[Fact]
			public void An_ArgumentException_is_thrown_when_the_height_of_the_array_is_greater_than_4() {
				Assert.Throws(typeof(ArgumentException), () => {
					new Matrix(new float[4, 5]);
				});
			}

			[Fact]
			public void No_exception_is_thrown_when_the_width_and_height_of_the_array_both_equal_4() {
				Assert.DoesNotThrow(() => {
					new Matrix(new float[4, 4]);
				});
			}

			[Fact]
			public void Elements_are_assigned_in_row_major_order() {
				var matrix = new Matrix(
					new float[4, 4] {
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

		private static Matrix CreateMatrixWithSequentialElements() {
			return new Matrix(Enumerable.Range(1, 16).Cast<float>());
		}

		private static Random _rng = new Random();

		protected override Matrix GetRandomInstance() {
			return new Matrix(
				Enumerable
					.Repeat(0f, 16)
					.Select(x => (float)_rng.NextDouble() * 10f));
		}

		protected override Matrix[] GetRandomInstancesThatAreEqual(int count) {
			var instance = GetRandomInstance();

			var array = new Matrix[count];

			for (var i = 0; i < array.Length; i++) {
				array[i] = instance.Clone();
			}

			return array;
		}
	}
}
