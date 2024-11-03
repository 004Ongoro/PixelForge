using System;
using System.Drawing;
using System.Drawing.Imaging; 

namespace PixelForge
{
    public static class ImageProcessor
    {

/// <summary>
/// Methods:
/// Resize Image:
/// Crop Image:
/// Rotate Image:
/// Covert Format:
/// Load from path
/// save to path
/// </summary>

        
        public static Bitmap ResizeImage(Bitmap image, int width, int height, bool preserveRatio = true)
        {
            if(preserveRatio){
                float aspectRatio = (float)image.Width / image.Height;

                if(width > height){
                    height = (int)(width / aspectRatio);
                }else{
                    width = (int)(height * aspectRatio);
                }

            }

            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage)){
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                graphics.DrawImage(image, 0,0,width,height);

            }

            return resizedImage;
        }

        /// <summary>
        /// Crops the image to a specified location.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="cropArea"></param>
        /// <returns></returns>
        public static Bitmap CropImage(Bitmap image, Rectangle cropArea)
        {
            Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height);

            using (Graphics graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
            }

            return croppedImage;
        }

        /// <summary>
        /// This method rotates the provided image at the specified angle.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="angle"></param>
        /// <returns></returns>

        public static Bitmap RotateImage(Bitmap image, float angle)
        {
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
                g.DrawImage(image, new Point(0, 0));
            }

            return rotatedImage;
        }

        /// <summary>
        /// Converts images to different formats and saves them to disk.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="outputPath"></param>
        /// <param name="format"></param>

        public static void ConvertImageFormat(Bitmap image, string outputPath, ImageFormat format)
        {
            image.Save(outputPath, format);
        }


        /// <summary>
        /// Gets the image from a file path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        public static Bitmap LoadImage(string path)
        {
            return (Bitmap) Image.FromFile(path);
        }


        /// <summary>
        /// Saves the image to disk.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        public static void SaveImage(Bitmap image, string path, ImageFormat format)
        {
            image.Save(path, format);
        }
    }
}
