﻿using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries.HeaderFooterGalleries
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeaderFooterGrid : ContentPage
	{
		readonly DemoFilteredItemSource _demoFilteredItemSource = new DemoFilteredItemSource(10);

		public HeaderFooterGrid()
		{
			InitializeComponent();

			CollectionView.ItemTemplate = ExampleTemplates.PhotoTemplate();
			CollectionView.ItemsSource = _demoFilteredItemSource.Items;
		}
	}
}