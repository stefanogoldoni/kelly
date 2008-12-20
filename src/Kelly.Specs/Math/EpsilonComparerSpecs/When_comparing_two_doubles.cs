using Kelly.Math;
using Xunit;
using Xunit.Extensions;

namespace Kelly.Specs.Math.EpsilonComparerSpecs {
	public class When_comparing_two_doubles {
		[Theory]
		[InlineData(0)]
		[InlineData(1238739734819)]
		[InlineData(1337.00000000000001321)]
		public void If_the_two_values_are_equal_the_result_is_0(double value) {
			Assert.Equal(value, value, EpsilonComparer.DoubleComparer);
		}

		[Theory]
		[InlineData(0, .000000000000000012)]
		[InlineData(1.0000000000000001, 1.0000000000000002)]
		[InlineData(123456789123456033, 123456789123456000)]
		[InlineData(333333.1234567890123, 333333.1234567893210)]
		public void If_the_16_most_significant_digits_of_the_values_are_equal_the_result_is_0(double x, double y) {
			Assert.Equal(x, y, EpsilonComparer.DoubleComparer);	
		}

		[Theory]
		[InlineData(1.00000000000001, 1.00000000000002)]
		[InlineData(473187.43127897, 4869.35133)]
		[InlineData(123456789.12345, 123456789.12344)]
		public void If_the_15_most_significant_digits_of_the_values_are_not_equal_the_result_is_not_0(double x, double y) {
			Assert.NotEqual(x, y, EpsilonComparer.DoubleComparer);
		}

		[Theory]
		[InlineData(2, 1)]
		[InlineData(123456789.12345, 123456789.12344)]
		[InlineData(1337, .000000000001)]
		[InlineData(1000, 100)]
		public void If_the_first_value_is_greater_than_the_second_value_the_result_is_greater_than_0(double x, double y) {
			Assert.True(EpsilonComparer.DoubleComparer.Compare(x, y) > 0);
		}

		[Theory]
		[InlineData(0, 1)]
		[InlineData(123456789.1233, 123456789.12344)]
		[InlineData(0.000000003, 14)]
		[InlineData(100, 1000)]
		public void If_the_first_value_is_less_than_the_second_value_the_result_is_less_than_0(double x, double y) {
			Assert.True(EpsilonComparer.DoubleComparer.Compare(x, y) < 0);
		}
	}
}
