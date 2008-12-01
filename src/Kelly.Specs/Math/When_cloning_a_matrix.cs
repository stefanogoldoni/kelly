using Xunit;

namespace Kelly.Specs.Math {
	public partial class MatrixSpecs {
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
}