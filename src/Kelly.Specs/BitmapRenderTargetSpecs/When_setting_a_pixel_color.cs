using Xunit;

namespace Kelly.Specs.BitmapRenderTargetSpecs {
	public class When_setting_a_pixel_color {
		[Fact]
		public void Pixel_coordinates_are_relative_to_the_lower_left_corner_of_the_image() {
			using(var target = new BitmapRenderTarget(100, 100)) {
				target.SetPixelColor(new Pixel(0, 0), Color.Red);

				Assert.Equal(Color.Red.ToDrawingColor(), target.Bitmap.GetPixel(0, target.Height - 1));
			}
		}
	}
}
