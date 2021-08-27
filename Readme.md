<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/202346300/19.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T828535)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml.cs](./CS/DXMapInMemoryTileProvider/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXMapInMemoryTileProvider/MainWindow.xaml.vb))**
<!-- default file list end -->
# How to implement an in-memory image tile provider in the Map Control

This example illustrates how to generate image tiles at runtime.

<h3>Description</h3>

To do this, attach a custom tile generator class inherited from the 
**ImageTileSource** class to the **ImageTileDataProvider.TileSource** property. A tile image is returned in the **SimpleTileGenerator.GetImageSource** method.
