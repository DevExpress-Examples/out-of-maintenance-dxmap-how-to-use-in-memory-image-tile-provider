Imports DevExpress.Xpf.Map
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DXMapInMemoryTileProvider
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			Dim tileDataProvider As New ImageTileDataProvider()
			tileDataProvider.TileSource = New SimpleTileGenerator()
			Me.imageLayer.DataProvider = tileDataProvider
		End Sub
	End Class

	Public Class SimpleTileGenerator
		Inherits ImageTileSource

		Private rnd As New Random()
		Public Overrides ReadOnly Property Name() As String
			Get
				Return NameOf(SimpleTileGenerator)
			End Get
		End Property

		Public Overrides Function GetImageSource(ByVal x As Long, ByVal y As Long, ByVal level As Integer, ByVal size As System.Windows.Size) As ImageSource
			Dim drawingVisual As New DrawingVisual()
			Using drawingContext As DrawingContext = drawingVisual.RenderOpen()

				Dim text As New FormattedText($"{x}:{y}:{level}", New CultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Arial"), 14, System.Windows.Media.Brushes.Black)
				drawingContext.DrawRectangle(New SolidColorBrush(System.Windows.Media.Color.FromArgb(128, CByte(rnd.Next(255)), CByte(rnd.Next(255)), CByte(rnd.Next(255)))), Nothing, New Rect(New System.Windows.Point(), size))
				drawingContext.DrawText(text, New System.Windows.Point(5, 5))
				drawingContext.Close()
			End Using

			Dim bmp As New RenderTargetBitmap(CInt(size.Width), CInt(size.Height), 96, 96, PixelFormats.Pbgra32)
			bmp.Render(drawingVisual)
			Return bmp
		End Function

		Protected Overrides Function CreateObject() As MapDependencyObject
			Return New SimpleTileGenerator()
		End Function
	End Class
End Namespace
