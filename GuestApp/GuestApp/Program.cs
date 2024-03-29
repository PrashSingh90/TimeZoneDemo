using Guest_BAL.IServices;
using Guest_BAL.Services;
using Guest_BO.DataModel;
using Guest_DAL.Data;
using Guest_DAL.IRepository;
using Guest_DAL.Repository;
using GuestApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("GuestAppConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
     options =>
     {
         options.Password.RequiredLength = 4;
         options.Password.RequireDigit = true;
         options.Password.RequireNonAlphanumeric = false;
         options.Password.RequireUppercase = false;
         options.SignIn.RequireConfirmedAccount = true;
     }).AddEntityFrameworkStores<ApplicationDbContext>();


// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingConfig));


builder.Services.AddControllers();

var key = builder.Configuration.GetValue<string>("APISetting:Secret");

builder.Services.AddTransient<IGuestRepository, GuestRepository>();
builder.Services.AddTransient<IGuestService, GuestService>();

builder.Services.AddTransient<ITitleRepository, TitleRepository>();
builder.Services.AddTransient<ITitleService, TitleService>();

builder.Services.AddTransient<IGuestPhoneNumberRepository, GuestPhoneNumberRepository>();
builder.Services.AddTransient<IGuestPhoneNumberService, GuestPhoneNumberService>();

builder.Services.AddTransient<IPhoneRepository, PhoneRepository>();
builder.Services.AddTransient<IPhoneService, PhoneService>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
