using System.Drawing;
using System.Drawing.Imaging;

namespace Kelly {
	public static class MemoryRenderTargetExtensions {
		public unsafe static Bitmap ToBitmap(this MemoryRenderTarget target) {
			var bitmap = new Bitmap(target.Width, target.Height, PixelFormat.Format32bppRgb);

			var data = bitmap.LockBits(new Rectangle(0, 0, target.Width, target.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

			var scan0 = (byte*) data.Scan0;

			for(var line = 0; line < data.Height; line++) {
				var lineHead = scan0 + data.Stride * line;
			
				for(var pixel = 0; pixel < data.Width; pixel++) {
					var pixelPtr = ((int*) lineHead) + pixel;

					var color = target.Pixels[pixel, target.Height - 1 - line];
					*pixelPtr = color.ToArgb();
				}
			}

			bitmap.UnlockBits(data);

			return bitmap;
		}
	}
}
