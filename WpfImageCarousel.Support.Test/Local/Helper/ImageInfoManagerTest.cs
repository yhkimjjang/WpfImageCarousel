using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfImageCarousel.Support.Local.Helpers;

namespace WpfImageCarousel.Support.Test.Local.Helper;

internal class ImageInfoManagerTest
{
    private IImageLoder _loder;
    private ImageInfoManager? _imageInfoManager;

    [SetUp]
    public void Setup()
    {
        _loder = new LocalImageLoader();
    }

    [Test]
    public void ConstructorTest()
    {
        _imageInfoManager = new ImageInfoManager(_loder);
    }
}
