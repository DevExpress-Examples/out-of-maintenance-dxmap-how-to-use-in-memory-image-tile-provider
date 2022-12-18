Imports DevExpress.Xpf.Map
Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace DXMapInMemoryTileProvider

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim tileDataProvider As ImageTileDataProvider = New ImageTileDataProvider()
            tileDataProvider.TileSource = New SimpleTileGenerator()
            Me.imageLayer.DataProvider = tileDataProvider
        End Sub
    End Class

    Public Class SimpleTileGenerator
        Inherits ImageTileSource

        Private rnd As Random = New Random()

        Public Overrides ReadOnly Property Name As String
            Get
                Return NameOf(SimpleTileGenerator)
            End Get
        End Property

        Public Overrides Function GetImageSource(ByVal x As Long, ByVal y As Long, ByVal level As Integer, ByVal size As Size) As ImageSource
            Dim drawingVisual As DrawingVisual = New DrawingVisual()
            Using drawingContext As DrawingContext = drawingVisual.RenderOpen()
                Dim text As FormattedText = New FormattedText($"{x}:{y}:{level}", New CultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Arial"), 14, Brushes.Black)
                drawingContext.DrawRectangle(New SolidColorBrush(Color.FromArgb(128, CByte(rnd.Next(255)), CByte(rnd.Next(255)), CByte(rnd.Next(255)))), Nothing, New Rect(New Point(), size))
                drawingContext.DrawText(text, New Point(5, 5))
                drawingContext.Close()
            End Using

            Dim bmp As RenderTargetBitmap = New RenderTargetBitmap(CInt(size.Width), CInt(size.Height), 96, 96, PixelFormats.Pbgra32)
            bmp.Render(drawingVisual)
            Return bmp
        End Function

        Protected Overrides Function CreateObject() As MapDependencyObject
            Return New SimpleTileGenerator()
        End Function
    End Class
End Namespace
