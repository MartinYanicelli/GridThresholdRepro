# GridThresholdRepro

Minimal .NET MAUI 10.0.110 repro: on Windows, a `CollectionView` with `GridItemsLayout` stops raising `RemainingItemsThresholdReached` after the first page, while the same `CollectionView` with `LinearItemsLayout` keeps loading.

Run it on Windows and scroll both lists to the end several times. Each label shows the item count, how many times the threshold was reached and the last `Scrolled.LastVisibleItemIndex`.

The code is in `MainPage.xaml` and `MainPage.xaml.cs`; the rest is the `dotnet new maui` template.
