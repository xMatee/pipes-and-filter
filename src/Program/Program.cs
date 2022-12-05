using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            FilterNegative filternegative = new();
            FilterGreyscale filtergrey = new();
            PipeNull pipenull1 = new();
            PipeSerial pipeSerial2 = new(filternegative,pipenull1);
            PipeSerial pipeSerial1 = new(filtergrey, pipeSerial2);

            PictureProvider provider = new PictureProvider();
            IPicture beer = provider.GetPicture(@"beer.jpg");
            IPicture salida1 = pipeSerial1.Send(beer);
            provider.SavePicture(salida1, @"beer.salida1.jpg");




            PictureProvider provider2 = new PictureProvider(); 
            PipeNull pipeNull2 = new();

            FilterSaver saveNegative = new(@"beerNegative.output.jpg");
            PipeSerial pipeSerial4B = new(saveNegative,pipeNull2);

            IFilter filterNegativeB = new FilterNegative();
            IPipe pipeSerial3B = new PipeSerial(filternegative, pipeSerial4B);

            IFilter saveGrey = new FilterSaver(@"beerGreyscale.output.jpg");
            PipeSerial pipeSerial2B = new PipeSerial(saveGrey, pipeSerial3B);

            IFilter filterGreyscaleB = new FilterGreyscale();
            IPipe pipeSerial1B = new PipeSerial(filtergrey, pipeSerial2B);

            IPicture picture2 = provider2.GetPicture(@"beer.jpg");
            IPicture salida2 = pipeSerial1B.Send(picture2);
            


          
            PictureProvider provider3 = new();
            PipeNull pipeNull3 = new();
            TwitterFilter sender = new();
            TwitterImage publisher = new();

            publisher.PublishToTwitter("greyscale",@"beerGreyscale.output.jpg");
            PipeSerial pipeSerial4C = new(saveNegative,pipeNull3);
            IFilter filterNegativeC = new FilterNegative();
            IPipe pipeSerial3C = new PipeSerial(filternegative, pipeSerial4C);
            PipeSerial pipeSerial2C = new PipeSerial(saveGrey, pipeSerial3C);
            IPipe pipeSerial1C = new PipeSerial(filtergrey, pipeSerial2C);

            IPicture picture3 = provider2.GetPicture(@"luke.jpg");
            IPicture salida3 = pipeSerial1C.Send(picture3);
        }
    }
}
