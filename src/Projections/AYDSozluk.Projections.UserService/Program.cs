using AYDSozluk.Projections.UserService;
using AYDSozluk.Projections.UserService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddTransient<UserService>();
        services.AddTransient<EmailService>();
    })
    .Build();

host.Run();
