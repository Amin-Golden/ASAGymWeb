using Gym.Web.Data;
using Gym.Web.Models;
using Gym.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.PostgreSQL(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection")!,
        tableName: "logs",
        needAutoCreateTable: true)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Database
builder.Services.AddDbContext<GymDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<GymDbContext>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Custom services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<ILockerService, LockerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GymDbContext>();
    context.Database.EnsureCreated();
}

app.Run();
