using E_Learning_Management_System.Data;
using E_Learning_Management_System.Repository;
using E_LearningManagementSystem.Repository;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add Service to/////////////////////////////////////////////////////////////////////////////

builder.Services.AddControllers();
builder.Services.AddScoped<IAcountRepository, AcountRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IAdministratorRepository , AdministratorRepository>();
builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<ILearnerRepository, LearnerRepository>();
builder.Services.AddScoped<IDurationRepository, DurationRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IFeesRepository, FeesRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();

builder.Services.AddDbContext<ApplicatioDbContext>(options =>
{
    options. /*UseLazyLoadingProxies().*/
    UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
