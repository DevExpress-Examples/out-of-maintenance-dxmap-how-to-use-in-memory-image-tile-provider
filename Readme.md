<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml.cs](./CS/DXMapInMemoryTileProvider/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXMapInMemoryTileProvider/MainWindow.xaml.vb))**
<!-- default file list end -->
# How to implement an in-memory image tile provider in the Map Control

This example illustrates how to generate image tiles at runtime.

<h3>Description</h3>

To do this, attach a custom tile generator class inherited from the 
**ImageTileSource** class to the **ImageTileDataProvider.TileSource** property. A tile image is returned in the **SimpleTileGenerator.GetImageSource** method.
