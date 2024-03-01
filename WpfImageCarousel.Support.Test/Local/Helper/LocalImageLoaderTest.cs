using WpfImageCarousel.Support.Enums;
using WpfImageCarousel.Support.Local.Helpers;

namespace WpfImageCarousel.Support.Test.Local.Helper;

internal class LocalImageLoaderTest
{
    private LocalImageLoader _localImageLoader;

    [SetUp]
    public void SetUp()
    {
        _localImageLoader = new LocalImageLoader();
    }

    [Test]
    public async Task DownloadImagesToStringPathAsyncTest()
    {
        var result = await _localImageLoader.DownloadImagesToStringPathAsync();
        string expectValue = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FolderNames.WpfImageCarousel.ToString());

        Assert.That(result, Is.EqualTo(expectValue));
    }
}
