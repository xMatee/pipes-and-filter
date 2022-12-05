using System;
using System.Drawing;

namespace CompAndDel.Filters;

public class FilterSaver : IFilter
{
    private PictureProvider Provider = new PictureProvider();
    private string SavePath;
    public FilterSaver(string savePath)
    {
        this.SavePath = savePath;
    }
    public IPicture Filter(IPicture image)
    {
        IPicture result = image.Clone();
        this.Provider.SavePicture(result,this.SavePath);
        return result;
    }
}