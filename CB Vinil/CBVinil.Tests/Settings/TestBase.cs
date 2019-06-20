using AutoMapper;
using CBVinil.Persistence;
using CBVinil.Tests.Settings.Factories;
using CBVinil.Tests.Settings.Interfaces;
using System;

namespace CBVinil.Tests.Settings
{
    public class TestBase<ISeed> : IDisposable
    {
        public readonly CBVinilContext _context;
        public readonly IMapper _mapper;

        public TestBase(ITestSeed seed)
        {
            _context = CBVinilContextFactoryTests.Create(seed);
            _mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            CBVinilContextFactoryTests.Destroy(_context);
        }
    }
}
