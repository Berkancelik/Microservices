using AutoMapper;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Services
{
    internal class CourseService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _mapper = mapper;
        }
    }
}
