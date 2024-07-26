using BootstrapBlazor.OnlyServerTable2PDF.Components;
using BootstrapBlazor.OnlyServerTable2PDF.Data;
using Microsoft.AspNetCore.SignalR;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddBootstrapBlazor();

builder.Services.AddSingleton<WeatherForecastService>();

// 增加 Table 数据服务操作类
builder.Services.AddTableDemoDataService();

// 增加 SignalR 服务数据传输大小限制配置
builder.Services.Configure<HubOptions>(option => option.MaximumReceiveMessageSize = null);

// 增加 BootstrapBlazor 组件
builder.Services.AddBootstrapBlazor();

// 增加 Table Excel 导出服务
builder.Services.AddBootstrapBlazorTableExportService();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseResponseCompression();
}

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
