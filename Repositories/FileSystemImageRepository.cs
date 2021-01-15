using System;
using Autofac;
using AutoMapper;

namespace FileSystemImage.Repositories
{
    public class FileSystemImageRepository : RepositoryBase, IDisposable
    {
        private readonly IMapper _mapper;
        private readonly ILifetimeScope _scope;

        public FileSystemImageRepository(IMapper mapper, ILifetimeScope scope)
        {
            _mapper = mapper;
            _scope = scope;
        }



        public void Dispose()
        {

        }
    }
}
