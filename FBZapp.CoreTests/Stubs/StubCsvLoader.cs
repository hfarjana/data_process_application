using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.CoreTests.Stubs
{
    public class StubCsvLoader
    {
        public List<Comic> LoadComics()
        {
            return StubComicData.GetSampleComics();
        }
    }
}
