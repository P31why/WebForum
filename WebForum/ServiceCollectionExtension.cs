using Microsoft.EntityFrameworkCore;
using System.Text;
using WebForum.Application.User.Interface;
using WebForum.Application.User.Interfaces;
using WebForum.Application.User.Services;
using WebForum.Data;
using WebForum.Data.Entities;
using WebForum.Infrastructure.Entities;
using WebForum.Infrastructure.Interfaces;
using WebForum.Infrastructure.Mappers;
using WebForum.Infrastructure.Repository;
using WebForum.Mapper;

namespace WebForum.WebApi
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IBaseRepository<Guid, Topic>, BaseRepository<Guid, Topic>>();
            services.AddScoped<IBaseRepository<Guid, User>, BaseRepository<Guid, User>>();
            services.AddScoped<IBaseRepository<Guid, Post>, BaseRepository<Guid, Post>>();
            services.AddScoped<IBaseRepository<long, Comment>, BaseRepository<long, Comment>>();
            services.AddScoped<IBaseRepository<long, FollowedTopic>, BaseRepository<long, FollowedTopic>>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFollowedTopicRepository, FollowedTopicRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IFollowedTopicService,  FollowedTopicsService>();

            services.AddScoped<UserMapper>();
            services.AddScoped<TopicMapper>();
            services.AddScoped<PostMapper>();
            services.AddScoped<CommentMapper>();
            services.AddScoped<FollowedTopicsMapper>();

        }
    }
}
