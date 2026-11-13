using System.Collections.ObjectModel;

namespace GridThresholdRepro;

public partial class MainPage : ContentPage
{
    const int PageSize = 40;

    readonly Feed grid = new();
    readonly Feed list = new();

    public MainPage()
    {
        InitializeComponent();

        GridView.ItemsSource = grid.Items;
        ListView.ItemsSource = list.Items;

        grid.AddPage();
        list.AddPage();
        UpdateStatus();
    }

    void OnGridThresholdReached(object? sender, EventArgs e)
    {
        grid.ThresholdReachedCount++;
        grid.AddPage();
        UpdateStatus();
    }

    void OnListThresholdReached(object? sender, EventArgs e)
    {
        list.ThresholdReachedCount++;
        list.AddPage();
        UpdateStatus();
    }

    void OnGridScrolled(object? sender, ItemsViewScrolledEventArgs e)
    {
        grid.LastVisibleItemIndex = e.LastVisibleItemIndex;
        UpdateStatus();
    }

    void OnListScrolled(object? sender, ItemsViewScrolledEventArgs e)
    {
        list.LastVisibleItemIndex = e.LastVisibleItemIndex;
        UpdateStatus();
    }

    void UpdateStatus()
    {
        GridStatus.Text = grid.ToString();
        ListStatus.Text = list.ToString();
    }

    sealed class Feed
    {
        public ObservableCollection<string> Items { get; } = new();
        public int ThresholdReachedCount { get; set; }
        public int LastVisibleItemIndex { get; set; } = -1;

        public void AddPage()
        {
            int start = Items.Count;
            for (int i = start; i < start + PageSize; i++)
                Items.Add($"Item {i}");
        }

        public override string ToString() =>
            $"Items: {Items.Count} | RemainingItemsThresholdReached: {ThresholdReachedCount} | Scrolled.LastVisibleItemIndex: {LastVisibleItemIndex}";
    }
}
