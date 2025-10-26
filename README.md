# ASA Gym Management System - Web Version

A modern, web-based gym management system built with ASP.NET Core and Blazor Server. This application provides comprehensive gym management features including client management, membership tracking, payment processing, attendance monitoring, and locker management.

## Features

### Core Management
- **Client Management**: Complete client profiles with photos, contact information, and membership history
- **Package Management**: Create and manage gym packages with pricing and duration
- **Membership Tracking**: Track client memberships, instructors, and payment status
- **Payment Processing**: Record and manage payment transactions
- **Instructor Management**: Manage gym instructors and their assignments

### Advanced Features
- **Attendance Tracking**: Monitor client attendance and session records
- **Locker Management**: Assign and manage locker assignments
- **Gym Sessions**: Track entrance and exit times with real-time monitoring
- **Dashboard Analytics**: Comprehensive overview with statistics and charts
- **Search & Filtering**: Advanced search capabilities across all modules
- **Data Export**: Export data to CSV format for reporting

### Technical Features
- **Responsive Design**: Works on desktop, tablet, and mobile devices
- **Real-time Updates**: Live updates using SignalR
- **Dark/Light Theme**: User preference theme switching
- **Database Integration**: PostgreSQL with Entity Framework Core
- **Authentication**: Secure user authentication and authorization
- **Logging**: Comprehensive logging with Serilog

## Technology Stack

- **Backend**: ASP.NET Core 8.0
- **Frontend**: Blazor Server
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Logging**: Serilog
- **UI Framework**: Bootstrap 5
- **Icons**: Font Awesome
- **Styling**: Custom CSS with CSS Variables

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL 12 or later
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Gym.Web
   ```

2. **Configure Database**
   - Install PostgreSQL
   - Create a database named `gym_web_db`
   - Update connection string in `appsettings.json`

3. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

4. **Run Database Migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

6. **Access the Application**
   - Open browser and navigate to `https://localhost:5001`
   - Default admin credentials will be created on first run

### Database Configuration

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=gym_web_db;Username=postgres;Password=your_password"
  }
}
```

## Project Structure

```
Gym.Web/
├── Data/
│   └── GymDbContext.cs          # Entity Framework context
├── Models/
│   ├── ApplicationUser.cs       # User model
│   ├── Client.cs                # Client entity
│   ├── Package.cs               # Package entity
│   ├── Instructor.cs            # Instructor entity
│   ├── Membership.cs            # Membership entity
│   ├── Payment.cs               # Payment entity
│   ├── Session.cs               # Session entity
│   ├── Attendance.cs            # Attendance entity
│   └── GymSession.cs            # Gym session entity
├── Services/
│   ├── IClientService.cs        # Client service interface
│   ├── ClientService.cs         # Client service implementation
│   ├── IPackageService.cs       # Package service interface
│   ├── PackageService.cs        # Package service implementation
│   └── ...                      # Other service interfaces and implementations
├── Pages/
│   ├── Index.razor              # Dashboard page
│   ├── Clients.razor            # Clients management
│   ├── Packages.razor           # Packages management
│   ├── Instructors.razor       # Instructors management
│   ├── Memberships.razor        # Memberships management
│   ├── Payments.razor           # Payments management
│   ├── Attendance.razor         # Attendance tracking
│   ├── Lockers.razor            # Locker management
│   ├── Sessions.razor           # Gym sessions
│   └── Settings.razor           # System settings
├── Shared/
│   ├── MainLayout.razor         # Main layout component
│   └── NavMenu.razor            # Navigation menu
├── wwwroot/
│   ├── css/
│   │   └── app.css              # Custom styles
│   └── js/
│       └── app.js               # JavaScript functions
├── Program.cs                   # Application startup
└── appsettings.json             # Configuration
```

## Key Features Implementation

### Dashboard
- Real-time statistics and metrics
- Recent activity feed
- Expiring memberships alerts
- Quick access to all modules

### Client Management
- Complete client profiles with photos
- Search and filtering capabilities
- Membership history tracking
- Locker assignment management

### Package Management
- Visual package cards with pricing
- Duration and feature management
- Instructor assignments
- Member count tracking

### Membership Tracking
- Active/expired membership filtering
- Payment status monitoring
- Instructor assignments
- Expiration date tracking

### Locker Management
- Visual locker grid (200 lockers)
- Real-time availability status
- Client assignment tracking
- Occupancy statistics

### Gym Sessions
- Real-time session monitoring
- Entrance/exit time tracking
- Duration calculations
- Locker usage tracking

## Configuration

### Database Settings
The application uses PostgreSQL with Entity Framework Core. The database schema is automatically created on first run.

### Logging
Serilog is configured for comprehensive logging:
- Console output for development
- PostgreSQL logging for production
- Configurable log levels

### Authentication
ASP.NET Core Identity is used for user authentication:
- User registration and login
- Role-based authorization
- Password hashing with BCrypt

## Deployment

### Docker Deployment
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Gym.Web.csproj", "."]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gym.Web.dll"]
```

### Production Configuration
1. Update connection strings for production database
2. Configure logging for production environment
3. Set up SSL certificates
4. Configure reverse proxy (nginx/Apache)
5. Set up monitoring and health checks

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For support and questions:
- Create an issue in the repository
- Contact the development team
- Check the documentation

## Roadmap

### Planned Features
- [ ] Mobile app integration
- [ ] Advanced reporting and analytics
- [ ] Email/SMS notifications
- [ ] Face recognition integration
- [ ] API for third-party integrations
- [ ] Multi-language support
- [ ] Advanced user roles and permissions
- [ ] Automated backup and restore
- [ ] Performance monitoring
- [ ] Advanced search and filtering

### Version History
- **v1.0.0**: Initial release with core functionality
- **v1.1.0**: Added advanced features (planned)
- **v1.2.0**: Mobile integration (planned)
- **v2.0.0**: Major UI/UX overhaul (planned)
