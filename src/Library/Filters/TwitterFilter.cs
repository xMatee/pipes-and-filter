using System;
using System.Drawing;
using TwitterUCU;
using System.IO;

namespace CompAndDel.Filters;

public class TwitterFilter : IFilter
{
    private PictureProvider provider = new();
    TwitterImage sender = new();
    public IPicture Filter (IPicture picture){
        provider.SavePicture(picture,@"path.jpg");
        sender.PublishToTwitter("foto test",@"path.jpg");
        File.Delete(@"path.jpg");
        return picture;

    }
}