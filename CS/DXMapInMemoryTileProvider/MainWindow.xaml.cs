using DevExpress.Xpf.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DXMapInMemoryTileProvider
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImageTileDataProvider tileDataProvider = new ImageTileDataProvider();
            tileDataProvider.TileSource = new SimpleTileGenerator();
            this.imageLayer.DataProvider = tileDataProvider;
        }
    }

    public class SimpleTileGenerator : ImageTileSource
    {
        Random rnd = new Random();
        public override string Name => nameof(SimpleTileGenerator);

        public override ImageSource GetImageSource(long x, long y, int level, System.Windows.Size size)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {

                FormattedText text = new FormattedText($"{x}:{y}:{level}", new CultureInfo("en-us"),
                                     FlowDirection.LeftToRight, new Typeface("Arial"), 14, System.Windows.Media.Brushes.Black);
                drawingContext.DrawRectangle(new SolidColorBrush(System.Windows.Media.Color.FromArgb(128, (byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255))), null, new Rect(new System.Windows.Point(), size));
                drawingContext.DrawText(text, new System.Windows.Point(5, 5));
                drawingContext.Close();
            }

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            return bmp;
        }

        protected override MapDependencyObject CreateObject()
        {
            return new SimpleTileGenerator();
        }
    }
}
