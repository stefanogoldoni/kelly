using Xunit;

namespace Kelly.Specs.ColorSpecs {
	public class When_converting_a_color_to_a_System_Drawing_Color {
		[Fact]
		public void Color_constants_convert_to_their_System_equivalents() {
			Assert.Equal(System.Drawing.Color.Black.ToArgb(), Color.Black.ToDrawingColor().ToArgb());
			Assert.Equal(System.Drawing.Color.White.ToArgb(), Color.White.ToDrawingColor().ToArgb());
			Assert.Equal(System.Drawing.Color.Red.ToArgb(), Color.Red.ToDrawingColor().ToArgb());

			// There is no named System.Drawing color that corresponds to "fully green"
			Assert.Equal(System.Drawing.Color.FromArgb(0, 255, 0).ToArgb(), Color.Green.ToDrawingColor().ToArgb());
			Assert.Equal(System.Drawing.Color.Blue.ToArgb(), Color.Blue.ToDrawingColor().ToArgb());
		}
	}
}
