
using F1TimeTrialTrack.Data;
using F1TimeTrialTrack.Helpers;
using F1TimeTrialTrack.Logic.Helpers;
using F1TimeTrialTrack.Logic.Logic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace F1TimeTrialTrack
{
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddTransient(typeof(Repository<>));
                builder.Services.AddTransient<DtoProvider>();
                builder.Services.AddTransient<TracksRatingLogic>();
                builder.Services.AddTransient<TTsRatingLogic>();
                builder.Services.AddTransient<TracksLogic>();
                builder.Services.AddTransient<TTsLogic>();

                builder.Services.AddIdentity<AppUser, IdentityRole>(
                    option =>
                    {
                        option.Password.RequireDigit = false;
                        option.Password.RequiredLength = 4;
                        option.Password.RequireNonAlphanumeric = false;
                        option.Password.RequireUppercase = false;
                        option.Password.RequireLowercase = false;
                    }
                    )
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<F1Context>()
                    .AddDefaultTokenProviders();

                builder.Services.AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidAudience = "F1TTT.com",
                            ValidIssuer = "F1TTT.com",
                            ValidateLifetime = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nagyontitkoskulcsdeténylegagyfasztiskaptamtõlenagyontitkoskulcsdeténylegagyfasztiskaptamtõle"))
                        };                                                                                                                                                                                                                                  
                    });

                builder.Services.AddDbContext<F1Context>(options =>
                {
                    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=F1TTT;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
                    options.UseLazyLoadingProxies();
                }
                );
                builder.Services.Configure<ApiBehaviorOptions>(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });


                builder.Services.AddControllers(opt =>
                {
                    opt.Filters.Add<ExceptF>();
                    opt.Filters.Add<ValidF>();

                });
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(opt =>
                {
                    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "F1TTT API", Version = "v1" });
                    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Irj be egy JWT tokent",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    });
                    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }

                }
            });

                    } );

                    var app = builder.Build();

                    // Configure the HTTP request pipeline.
                    if (app.Environment.IsDevelopment())
                    {
                        app.UseSwagger();
                        app.UseSwaggerUI();
                    }

                    app.UseHttpsRedirection();
                    app.UseAuthentication();
                    app.UseAuthorization();


                    app.MapControllers();

                    app.Run();
                }
        }
} 
